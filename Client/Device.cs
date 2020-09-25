using Common;
using RCClient.UI.Forms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCClient {
    public class Device {
        public Device (IPAddress ip) {
            this.ip = ip;
            SetTemplate();
        }

        public string name { get; private set; }
        public Device (DeviceItem item) {
            ip = IPAddress.Parse(item.ip);
            name = item.name;
            SetTemplate();
        }

        private void SetTemplate () {
            foreach (var template in Settings.data.templates) {
                if (template.devices.Contains(ip.ToString())) {
                    this.template = template;
                    break;
                }
            }
        }

        public IPAddress ip;
        public DeviceInfo info;
        public DeviceTemplate template;

        private NetworkStream stream;
        private TcpClient client;

        public event Action<PacketType> onPacket = type => { };
        private void OnPacket (PacketType type) {
            switch (type) {
                case PacketType.Info:
                    info = ReadStruct<DeviceInfo>();
                    name = info.name;
                    break;
            }

            onPacket(type);
        }

        public void ExecuteScript (ExecScript script, Action<ExecState> onStateChanged) {
            stream.WriteByte((byte) PacketType.ExecuteScript);
            WriteStruct(script);

            Action<PacketType> handler = null;
            handler = type => {
                if (type == PacketType.ExecuteScript) {
                    var state = ReadStruct<ExecState>();
                    onStateChanged(state);

                    if (state.percent == 0xFF) {
                        onPacket -= handler;
                        Disconnect();
                    }
                }
            };

            onPacket += handler;
        }

        // Network methods section =========================================================================
        public T ReadStruct<T> () where T: SerializableStruct<T> {
            return SerializableStruct<T>.Deserialize(stream);
        }
        public void WriteStruct<T> (T obj) where T : SerializableStruct<T> {
            obj.Serialize(stream);
        }

        public void Disconnect () {
            client.Close();
        }

        /// <exception cref="SocketException"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static Task<Device> Connect (IPAddress ip, bool isFast = false, Device device = null) {
            var taskSource = new TaskCompletionSource<Device>();
            new Thread(new ThreadStart(() => {
                var client = new TcpClient();
                var connection = client.BeginConnect(ip, Settings.data.port, null, null);

                if (!connection.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(isFast ? Settings.data.fastTimeout : Settings.data.normalTimeout))) {
                    client.Close();
                    taskSource.SetException(new TimeoutException("Connection timed out"));
                    return;
                }

                try {
                    client.EndConnect(connection);
                } catch (SocketException) {
                    return;
                } catch (Exception err) {
                    taskSource.SetException(err);
                    return;
                }

                var stream = client.GetStream();
                if (device == null) device = new Device(ip);

                device.client = client;
                device.stream = stream;
                taskSource.SetResult(device);

                while (client.Connected) {
                    device.OnPacket((PacketType) stream.ReadByte());
                }
            })).Start();

            return taskSource.Task;
        }

        public Task Connect (bool isFast = false) {
            return Connect(ip, isFast, this);
        }

        public static Task Discover (List<Device> devices, Action<Device> onData) {
            var tasks = new List<Task>();
            foreach (var intr in NetworkInterface.GetAllNetworkInterfaces()) {
                if (intr.OperationalStatus != OperationalStatus.Up || intr.Name.ToLower().Contains("loopback")) {
                    continue;
                }

                var subnet = intr.GetIPProperties();
                IPAddress mask = null;
                IPAddress baseIP = null;

                var isDHCP = subnet.GatewayAddresses.Count == 0;
                foreach (var ip in subnet.UnicastAddresses) {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork) {
                        mask = ip.IPv4Mask;
                        if (isDHCP) baseIP = ip.Address;
                        break;
                    }
                }

                if (mask == null) continue;
                if (!isDHCP) {
                    foreach (var ip in subnet.GatewayAddresses) {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork) {
                            baseIP = ip.Address;
                            break;
                        }
                    }
                }

                if (baseIP == null) continue;
                var network = IPNetwork.Parse(baseIP, mask);
                Logs.Write($"Поиск устройств в сети {intr.Name} (подсеть {network})");
                tasks.Add(DiscoverSubnet(devices, network, onData));
            }

            return Task.WhenAll(tasks);
        }

        private static async Task DiscoverSubnet (List<Device> devices, IPNetwork network, Action<Device> onData) {
            var broadcast = network.Broadcast;
            foreach (var ip in network.ListIPAddress()) {
                if (ip.Equals(broadcast)) continue;

                foreach (var savedDevice in devices) {
                    if (savedDevice.ip.Equals(ip)) goto continueDiscover;
                }

                Device device;
                try {
                    device = await Connect(ip, true);
                } catch (SocketException) {
                    continue;
                } catch (TimeoutException) {
                    continue;
                }

                device.stream.WriteByte((byte) PacketType.Info);

                var taskSource = new TaskCompletionSource<object>();
                void handler (PacketType type) {
                    if (type == PacketType.Info) {
                        device.onPacket -= handler;
                        device.Disconnect();
                        taskSource.SetResult(null);
                    }
                }

                device.onPacket += handler;
                await taskSource.Task;
                device.Disconnect();
                onData(device);

                continueDiscover:;
            }

            Logs.Write("Поиск в сети " + network + " окончен");
        }

        public async Task<bool> FetchInfo () {
            try {
                await Connect(true);
            } catch (SocketException) {
                return false;
            } catch (TimeoutException) {
                return false;
            }

            stream.WriteByte((byte) PacketType.Info);

            var taskSource = new TaskCompletionSource<object>();
            Action<PacketType> handler = null;
            handler = type => {
                if (type == PacketType.Info) {
                    onPacket -= handler;
                    Disconnect();
                    taskSource.SetResult(null);
                }
            };

            onPacket += handler;
            await taskSource.Task;
            return true;
        }
    }

    public class DeviceItem : SerializableStruct<DeviceItem> {
        public string name;
        public string ip;
    }
}
