using Common;
using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RCServer {
    static class Program {
        public static string EXE_PATH = Assembly.GetExecutingAssembly().Location;
        public static bool isStartService = false;

        [STAThread]
        static void Main (string[] args) {
            foreach (var arg in args) {
                if (arg == "--service") {
                    Logs.Start();
                    StartServer();
                    return;
                } else if (arg == "--start-service") {
                    isStartService = true;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public const int PORT = 2386;

        private static bool isStarted = true;
        private static List<Connection> connections = new List<Connection>();
        public static DeviceInfo DEVICE_INFO = Win32.GetDeviceInfo();
        public static void StartServer () {
            DEVICE_INFO = Win32.GetDeviceInfo();

            var listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Logs.Write("SYS", "Listening on port " + PORT);

            while (isStarted) {
                var client = listener.AcceptTcpClient();

                var connection = new Connection(client);
                connections.Add(connection);
                new Thread(connection.HandlePacketes).Start();
            }
        }
    }
}
