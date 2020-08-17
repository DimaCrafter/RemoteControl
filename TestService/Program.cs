using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Windows.Forms;

namespace RCServer {
    static class Program {
        public static string name = ((AssemblyTitleAttribute) typeof(Program).Assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;
        public static string filename = Process.GetCurrentProcess().MainModule.ModuleName;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main (string[] args) {
            if (args.Length == 0) {
                ServiceBase.Run(new ServiceBase[] {
                    new ServerService()
                });
                return;
            }

            switch (args[0]) {
                case "-i":
                    try {
                        Utils.Install();
                        Utils.Start();
                    } catch (Exception err) {
                        MessageBox.Show(err.Message);
                    }
                    break;
                case "-u":
                    Utils.Stop();
                    Utils.Uninstall();
                    break;
                case "-h":
                default:
                    MessageBox.Show(
                        name + " usage:\n" +
                        "\n" +
                        filename + " -i  Install service\n" +
                        filename + " -u  Uninstall service\n" +
                        filename + " -h  Show this help"
                    );
                    break;
            }
        }
    }
}
