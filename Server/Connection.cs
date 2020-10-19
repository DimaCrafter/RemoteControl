using System.Diagnostics;
using Common;
using RCServer.Utils;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RCServer {
    class Connection {
        private readonly TcpClient connection;
        private readonly BinaryReader reader;
        private readonly BinaryWriter writer;
        public Connection (TcpClient connection) {
            this.connection = connection;
            reader = new BinaryReader(connection.GetStream());
            writer = new BinaryWriter(connection.GetStream());
        }

        public void HandlePacketes() {
            var endpoint = connection.Client.RemoteEndPoint.ToString();
            Logs.Write("SYS", "Connection from " + endpoint);

            while (connection.Connected) {
                while (!connection.GetStream().DataAvailable);
                switch ((PacketType) reader.ReadByte()) {
                    case PacketType.Info:
                        Program.DEVICE_INFO.Serialize(writer);
                        break;
                    case PacketType.Auth:
                        // TODO: Authentication
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
                        var script = ExecScript.Deserialize(reader);
                        new ScriptExecutor(script).Execute(endpoint, reader, writer);
                        break;
                    //case PacketType.GetScreenshot:
                    //    // TODO: check auth
                    //    SendScreenshot();
                    //    break;
                    case PacketType.CopyFile:
                        // TODO: check auth
                        DownloadFile();
                        break;
                    case PacketType.RequestControl:
                        // TODO: check auth
                        StartRemoteControl();
                        break;
                }
            }

            Logs.Write("SYS", "Disconnected: " + endpoint);
        }

        private void DownloadFile () {
            var path = OtherUtils.ParsePath(reader.ReadString());
            if (File.Exists(path)) {
                writer.Write(true);
                return;
            }

            writer.Write(false);
            MessageBox.Show(path);
            using var file = File.Create(path);
            var size = reader.ReadInt64();
            for (long i = 0; i < size; i++) {
                file.WriteByte(reader.ReadByte());
            }
        }
        
        private void StartRemoteControl () {
            if (reader.ReadBoolean()) {
                AnyDesk.Install();
            }

            var bytes = reader.ReadBytes(32);
            var password = "";
            foreach (var b in bytes) {
                // Hex with leading zero
                password += b.ToString("x2");
            }

            AnyDesk.StartService(password, true);
            writer.Write((byte) 0);
        }
    }
}
