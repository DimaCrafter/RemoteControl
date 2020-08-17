using Common;
using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RCServer {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
            //var dm = new DesktopManager();
            //var o = 5;
            //dm.CreateShortcut(new Utils.Shortcut {
            //    name = "1",
            //    target = "https://yandex.ru",
            //    xGridOffset = o,
            //    yGridOffset = o,
            //    aligment = System.Drawing.ContentAlignment.TopLeft
            //});
            //dm.CreateShortcut(new Utils.Shortcut {
            //    name = "2",
            //    target = "https://yandex.ru",
            //    xGridOffset = o,
            //    yGridOffset = o,
            //    aligment = System.Drawing.ContentAlignment.TopRight
            //});
            //dm.CreateShortcut(new Utils.Shortcut {
            //    name = "3",
            //    target = "https://yandex.ru",
            //    xGridOffset = o,
            //    yGridOffset = o,
            //    aligment = System.Drawing.ContentAlignment.BottomRight
            //});
            //dm.CreateShortcut(new Utils.Shortcut {
            //    name = "4",
            //    target = "https://yandex.ru",
            //    xGridOffset = o,
            //    yGridOffset = o,
            //    aligment = System.Drawing.ContentAlignment.BottomLeft
            //});
            //dm.ExecuteTasks();
        }

        private void Log (string line) {
            if (!isServerStarted) return;
            log.Invoke(new Action(() => {
                log.Text += line + Environment.NewLine;
            }));
        }

        // Server methods
        private bool isServerStarted = true;
        private List<Client> connections = new List<Client>();
        private void StartServer () {
            Log("[SYS] Listening on port 2386");
            var server = new TcpListener(IPAddress.Any, 2386);
            server.Start();

            while (isServerStarted) {
                var socket = server.AcceptTcpClient();
                new Thread(new ThreadStart(() => {
                    var endpoint = socket.Client.RemoteEndPoint.ToString();
                    Log("[+] " + endpoint);

                    var client = new Client(socket);
                    connections.Add(client);
                    while (socket.Connected) {
                        var packet = client.Read();
                        if (packet == null) break;
                        DispatchRequest(client, packet);
                    }

                    Log("[-] " + endpoint);
                })).Start();
            }
        }

        private string ACCESS_KEY = "";
        private void DispatchRequest (Client client, byte[] packet) {
            switch ((PacketType) packet[0]) {
                case PacketType.Info:
                    client.SendStruct(PacketType.Info, DEVICE);
                    break;
                case PacketType.Auth:
                    var key = Encoding.UTF8.GetString(PacketBody(packet));
                    if (ACCESS_KEY.Length == 0 || ACCESS_KEY == key) {
                        ACCESS_KEY = key;
                        //client.send("authed");
                    } else {
                        //client.send("not authed");
                    }
                    break;
            }

            Log("Packet: " + Enum.GetName(typeof(PacketType), packet[0]));
            Log("Received: " + packet.Length + " bytes");
        }

        private byte[] PacketBody(byte[] packet) {
            return new ArraySegment<byte>(packet, 1, packet.Length - 1).Array;
        }

        // Data methods
        public DeviceInfo DEVICE;
        private void Form1_Load(object sender, EventArgs e) {
            new Thread(new ThreadStart(StartServer)).Start();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            DEVICE = new DeviceInfo();
            var osInfo = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get();
            foreach (var item in osInfo) {
                DEVICE.name = item["CSName"].ToString();
                DEVICE.os = item["Caption"] + " " + item["OSArchitecture"];
                DEVICE.ram = (int) Math.Ceiling(double.Parse(item["TotalVisibleMemorySize"].ToString()) / 1024 / 1024);
            }

            var processorInfo = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get();
            foreach (var item in processorInfo) {
                DEVICE.cpuName = item["Name"].ToString();
                DEVICE.cpuCores = int.Parse(item["NumberOfCores"].ToString());
            }

            var displayInfo = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get();
            foreach (var item in displayInfo) {
                DEVICE.videocard = item["Caption"].ToString();
                DEVICE.screenWidth = int.Parse(item["CurrentHorizontalResolution"].ToString());
                DEVICE.screenHeight = int.Parse(item["CurrentVerticalResolution"].ToString());
                DEVICE.bpp = int.Parse(item["CurrentBitsPerPixel"].ToString());
            }
        }

        private void StopServer (object sender = null, EventArgs e = null) {
            isServerStarted = false;
            foreach (var client in connections) client.Disconnect();
            connections.Clear();

            Application.ExitThread();
            Environment.Exit(0);
        }
    }
    public class Client {
        public bool isAuthed = false;

        private readonly TcpClient socket;
        public Client (TcpClient socket) {
            this.socket = socket;
            stream = socket.GetStream();
        }

        private NetworkStream stream;
        public byte[] Read () {
            while (true) {
                if (!socket.Connected) return null;
                else if (stream.DataAvailable) break;
                else Thread.Sleep(100);
            }

            var packet = new byte[socket.Available];
            stream.Read(packet, 0, packet.Length);
            return packet;
        }

        public void Send (byte[] packet) {
            stream.Write(packet, 0, packet.Length);
        }

        public void SendStruct<T> (PacketType type, T structure) where T: SerializableStruct<T> {
            stream.WriteByte((byte) type);
            structure.Serialize(stream);
        }

        public void Disconnect () {
            socket.Close();
        }
    }
}
