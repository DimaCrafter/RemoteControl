using Common;
using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RCServer {
    class Server {
        private bool isStarted = true;
        private List<Client> connections = new List<Client>();
        public DeviceInfo DEVICE;
        public void Start () {
            DEVICE = Win32.GetDeviceInfo();
            var server = new TcpListener(IPAddress.Any, 2386);
            server.Start();
            Logs.Write("SYS", "Listening on port 2386");

            while (isStarted) {
                var socket = server.AcceptTcpClient();
                new Thread(new ThreadStart(() => {
                    var endpoint = socket.Client.RemoteEndPoint.ToString();
                    Logs.Write("SYS", "Connection from " + endpoint);

                    var client = new Client(socket);
                    var stream = socket.GetStream();
                    connections.Add(client);
                    while (socket.Connected) {
                        while (!stream.DataAvailable);
                        DispatchRequest(client, (PacketType) stream.ReadByte());
                    }

                    Logs.Write("SYS", "Disconnected: " + endpoint);
                })).Start();
            }
        }

        public void Stop (object sender = null, EventArgs e = null) {
            isStarted = false;
            foreach (var client in connections) client.Disconnect();
            connections.Clear();

            Application.ExitThread();
        }

        private string ACCESS_KEY = "";
        private void DispatchRequest (Client client, PacketType packet) {
            switch (packet) {
                case PacketType.Info:
                    client.SendStruct(PacketType.Info, DEVICE);
                    break;
                case PacketType.Auth:
                    //var key = Encoding.UTF8.GetString(PacketBody(packet));
                    //if (ACCESS_KEY.Length == 0 || ACCESS_KEY == key) {
                    //    ACCESS_KEY = key;
                    //    //client.send("authed");
                    //} else {
                    //    //client.send("not authed");
                    //}
                    break;
                case PacketType.ExecuteScript:
                    // TODO: check auth
                    client.ExecuteScript();
                    break;
            }

            Logs.Write("INFO", $"Received packet {Enum.GetName(typeof(PacketType), packet)}");
        }

        private byte[] PacketBody (byte[] packet) {
            return new ArraySegment<byte>(packet, 1, packet.Length - 1).Array;
        }
    }
}
