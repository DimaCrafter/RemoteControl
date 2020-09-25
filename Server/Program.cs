using RCServer.Utils;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace RCServer {
    static class Program {
        public static string EXE_PATH = Assembly.GetExecutingAssembly().Location;
        public const string SERVICE_TITLE = "RemoteControl Server Service";
        public static bool isStartService = false;

        [STAThread]
        static void Main (string[] args) {
            foreach (var arg in args) {
                if (arg == "--service") {
                    Logs.Start();
                    var server = new Server();
                    server.Start();
                    // TODO: Handle shutdown
                    return;
                } else if (arg == "--start-service") {
                    isStartService = true;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
