using Common;
using RCClient.UI.Forms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace RCClient {
    class Device {
        public IPAddress ip;
        public DeviceInfo info;

        private NetworkStream stream;
        private TcpClient client;

        public event Action<PacketType> onPacket = type => { };
        private void OnPacket (PacketType type) {
            switch (type) {
                case PacketType.Info:
                    info = ReadStruct<DeviceInfo>();
                    break;
            }

            onPacket(type);
        }

        // Network methods section =========================================================================
        public T ReadStruct<T> () where T: SerializableStruct<T> {
            return SerializableStruct<T>.Deserialize(stream);
        }

        public void Disconnect () {
            client.Close();
        }

        /// <exception cref="SocketException"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static Task<Device> Connect (IPAddress ip, bool isFast = false) {
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
                var device = new Device {
                    ip = ip,
                    client = client,
                    stream = stream
                };
                taskSource.SetResult(device);

                while (client.Connected) {
                    device.OnPacket((PacketType) stream.ReadByte());
                }
            })).Start();

            return taskSource.Task;
        }

        public static Task Discover (Action<Device> onData) {
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
                if (!isDHCP) baseIP = subnet.GatewayAddresses[0]?.Address;

                if (baseIP == null) continue;
                var network = IPNetwork.Parse(baseIP, mask);
                Logs.Write($"Поиск устройств в сети {intr.Name} (подсеть {network})");
                tasks.Add(DiscoverSubnet(network, onData));
            }

            return Task.WhenAll(tasks);
        }

        private static async Task DiscoverSubnet (IPNetwork network, Action<Device> onData) {
            var broadcast = network.Broadcast;
            foreach (var ip in network.ListIPAddress()) {
                if (ip.Equals(broadcast)) continue;

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
                Action<PacketType> handler = null;
                handler = type => {
                    if (type == PacketType.Info) {
                        device.onPacket -= handler;
                        device.Disconnect();
                        taskSource.SetResult(null);
                    }
                };

                device.onPacket += handler;
                await taskSource.Task;
                device.Disconnect();
                onData(device);
            }

            Logs.Write("Поиск в сети " + network + " окончен");
        }
    }

    public class DeviceItem : SerializableStruct<DeviceItem> {
        public string mac;
        public string name;
        public string ip;
    }
}
