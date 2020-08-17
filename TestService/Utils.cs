using System;
using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;

namespace RCServer {
    class Utils {
        private static ServiceController controller = new ServiceController(Program.name);
        public static bool isInstalled () {
            try { var status = controller.Status; }
            catch { return false; }
            return true;
        }

        public static bool isRunning () {
            if (!isInstalled()) return false;
            return controller.Status == ServiceControllerStatus.Running;
        }

        public static AssemblyInstaller getInstaller () {
            var installer = new AssemblyInstaller(typeof(ServerService).Assembly, null);
            installer.UseNewContext = true;
            return installer;
        }

        public static void Install () {
            if (isInstalled()) return;
            try {
                var installer = getInstaller();
                var state = new Hashtable();
                try {
                    installer.Install(state);
                    installer.Commit(state);
                } catch {
                    try { installer.Rollback(state); }
                    catch { throw; }
                }
            } catch {
                throw;
            }
        }

        public static void Uninstall () {
            if (!isInstalled()) return;
            try {
                var installer = getInstaller();
                var state = new Hashtable();
                installer.Uninstall(state);
            } catch {
                throw;
            }
        }

        public static void Start (int timeout = 5) {
            if (!isInstalled()) return;
            try {
                if (controller.Status != ServiceControllerStatus.Running) {
                    controller.Start();
                    controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(timeout));
                }
            } catch {
                throw;
            }
        }

        public static void Stop (int timeout = 5) {
            if (!isInstalled()) return;
            try {
                if (controller.Status != ServiceControllerStatus.Stopped) {
                    controller.Stop();
                    controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(timeout));
                }
            } catch {
                throw;
            }
        }
    }
}
