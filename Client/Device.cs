using Common;
using RCClient.UI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        internal BinaryReader reader;
        internal BinaryWriter writer;
        private TcpClient client;

        public event Action<PacketType> onPacket = type => { };
        private void ReceivePacket () {
            var type = (PacketType) stream.ReadByte();

            switch (type) {
                case PacketType.Info:
                    info = ReadStruct<DeviceInfo>();
                    name = info.name;
                    break;
                case PacketType.GetTime:
                    writer.Write(DateTime.Now.ToBinary());
                    break;
                case PacketType.Sync:
                    writer.Write(template.desktopShortcuts.Count);
                    foreach (var shortcut in template.desktopShortcuts) {
                        shortcut.Serialize(writer);
                    }

                    if (template.desktopBackground == "none") {
                        writer.Write(false);
                    } else {
                        writer.Write(true);
                        writer.Write(template.desktopBackground);
                    }
                    break;
            }

            onPacket(type);
        }

        private Action ReceiveLoop (Action<PacketType> handler) {
            var isRunning = true;
            onPacket += handler;

            new Thread((ThreadStart) delegate {
                while (isRunning) {
                    ReceivePacket();
                }
            }).Start();

            return () => {
                isRunning = false;
                onPacket -= handler;
            };
        }

        private void WaitPacket (PacketType expectedType, Action callback) {
            Action<PacketType> handler = null;
            handler = type => {
                if (type == expectedType) {
                    callback();
                    onPacket -= handler;
                }
            };

            onPacket += handler;
        }

        private void WaitPacket (PacketType expectedType) {
            var taskSource = new TaskCompletionSource<object>();
            WaitPacket(expectedType, () => taskSource.SetResult(null));
            taskSource.Task.Wait();
        }

        public string RequestControl () {
            var isInstalled = WriteFile(AnyDeskForm.ANYDESK_PATH, "%" + ((int) Environment.SpecialFolder.ProgramFilesX86) + @"\AnyDesk\AnyDesk.exe");
            writer.Write((byte) PacketType.RequestControl);

            // isInstall
            writer.Write(!isInstalled);

            var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            rng.Dispose();
            // INSECURE!!!
            // TODO: RSA/AES-encrypted connection
            writer.Write(bytes);

            var passwd = "";
            foreach (var b in bytes) {
                passwd += b.ToString("x2");
            }

            // Wait for installation check end (just a dummy byte)
            reader.ReadByte();

            return passwd;
        }

        public Action ExecuteScript (ExecScript script, ExecState state, Action onStateChanged) {
            stream.WriteByte((byte) PacketType.ExecuteScript);
            WriteStruct(script);

            return ReceiveLoop(type => {
                if (type != PacketType.ExecuteScript)
                    return;

                state.status = reader.ReadByte();
                switch ((ExecState.Status) state.status) {
                    case ExecState.Status.Pending:
                    case ExecState.Status.Error:
                        state.description = reader.ReadString();
                        break;
                }

                onStateChanged();
            });
        }

        public unsafe Task<Bitmap> GetScreenshot (Size size) {
            var taskSource = new TaskCompletionSource<Bitmap>();
            writer.Write((byte) PacketType.GetScreenshot);
            writer.Write(size.Width);
            writer.Write(size.Height);

            WaitPacket(PacketType.GetScreenshot, () => {
                var bitmap = new Bitmap(reader.ReadInt32(), reader.ReadInt32());
                var length = bitmap.Width * bitmap.Height * 3;

                var bmpData = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                var dest = (byte*) bmpData.Scan0;

                for (var i = 0; i < length; i++) {
                    dest[i] = reader.ReadByte();
                }

                bitmap.UnlockBits(bmpData);
                taskSource.SetResult(bitmap);
            });
            return taskSource.Task;
        }

        // Network methods section =========================================================================
        public T ReadStruct<T> () where T: SerializableStruct<T> {
            return SerializableStruct<T>.Deserialize(reader);
        }
        public void WriteStruct<T> (T obj) where T : SerializableStruct<T> {
            obj.Serialize(writer);
        }

        public event Action onDisconnect = () => { };
        public void Disconnect () {
            client.Close();
        }

        /// <exception cref="SocketException"></exception>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<Device> Connect (IPAddress ip, bool isFast = false, Device device = null) {
            var client = new TcpClient();
            await Task.WhenAny(
                client.ConnectAsync(ip, Settings.data.port),
                Task.Delay(isFast ? Settings.data.fastTimeout : Settings.data.normalTimeout)
            );

            if (!client.Connected) {
                throw new TimeoutException("Connection timed out");
            }

            var stream = client.GetStream();
            if (device == null) device = new Device(ip);

            device.client = client;
            device.stream = stream;
            device.reader = new BinaryReader(stream);
            device.writer = new BinaryWriter(stream);
            // TODO: disconnection handler
            return device;
        }

        public Task Connect (bool isFast = false) {
            return Connect(ip, isFast, this);
        }

        public static bool isDiscovering = false;
        public static Task Discover (List<Device> devices, Action<Device> onData) {
            isDiscovering = true;
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

            return Task.WhenAll(tasks).ContinueWith(task => {
                isDiscovering = false;
            });
        }

        private static async Task DiscoverSubnet (List<Device> devices, IPNetwork network, Action<Device> onData) {
            var broadcast = network.Broadcast;
            foreach (var ip in network.ListIPAddress()) {
                if (!isDiscovering) break;
                if (ip.Equals(broadcast)) continue;

                foreach (var savedDevice in devices) {
                    if (savedDevice.ip.Equals(ip)) goto continueDiscover;
                }

                var device = new Device(ip);
                if (await device.FetchInfo()) {
                    onData(device);
                }

                continueDiscover:;
            }

            Logs.Write("Поиск в сети " + network + " окончен");
        }

        public async Task<bool> FetchInfo () {
            if (client == null || !client.Connected) {
                try {
                    await Connect(true);
                } catch (SocketException) {
                    return false;
                } catch (TimeoutException) {
                    return false;
                }
            }

            writer.Write((byte) PacketType.Info);
            info = ReadStruct<DeviceInfo>();
            name = info.name;

            Disconnect();
            return true;
        }

        private T SyncRead<T> (Func<T> execute) {
            lock (reader) {
                return execute();
            }
        }

        internal bool WriteFile (string path, string dest) {
            writer.Write((byte) PacketType.CopyFile);
            writer.Write(dest);

            var exists = reader.ReadBoolean();
            if (!exists) {
                using var file = File.OpenRead(path);
                lock (writer) {
                    writer.Write(file.Length);
                    file.CopyTo(stream);
                }
            }

            return exists;
        }
    }

    public class DeviceItem : SerializableStruct<DeviceItem> {
        public string name;
        public string ip;
    }
}
