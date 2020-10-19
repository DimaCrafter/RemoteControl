using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCServer {
    class AnyDesk {
        private static readonly string EXE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\AnyDesk\AnyDesk.exe";
        private static readonly string CONFIG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnyDesk\\system.conf";
        private static Dictionary<string, string> DEFAULT_SETTINGS = new Dictionary<string, string> {
            { "ad.anynet.direct", "true" },
            { "ad.anynet.listen_port", "3170" },
            { "ad.anynet.proxy.mode", "0" },
            { "ad.security.update_type", "2" },
            { "ad.discovery.default_behavior", "0" },
            { "ad.discovery.enabled", "false" },
            { "ad.discovery.hidden", "true" }
        };

        public static void Install () {
            var installPath = Path.GetDirectoryName(EXE_PATH);
            var installerPath = installPath + "\\installer.exe";

            File.Move(EXE_PATH, installerPath);
            var installerProcess = Process.Start(installerPath, $"--silent --install \\\"{installPath}\\\"");
            installerProcess.WaitForExit();
            installerProcess.Dispose();

            Process.Start(installerPath, $"--stop-service");
            File.Delete(installerPath);

            var newSettings = "";
            foreach (var line in File.ReadLines(CONFIG_PATH)) {
                if (line.Length == 0)
                    continue;

                var pair = line.Split('=');
                if (DEFAULT_SETTINGS.ContainsKey(pair[0])) {
                    newSettings += pair[0] + "=" + DEFAULT_SETTINGS[pair[0]] + "\n";
                } else {
                    newSettings += line + "\n";
                }
            }

            File.WriteAllText(CONFIG_PATH, newSettings);
        }

        internal static void StartService (string password, bool isSilent = false) {
            var anydesk = Process.Start(new ProcessStartInfo {
                FileName = EXE_PATH,
                Arguments = "--set-password --start-service",
                RedirectStandardInput = true,
                UseShellExecute = false
            });

            anydesk.StandardInput.WriteLine(password);

            MessageBox.Show("echo " + password + " | " + EXE_PATH + " --set-password --start-service ");
            if (isSilent) {
                Win32.EnumWindows((hwnd, lParam) => {
                    var sb = new StringBuilder(256);
                    Win32.GetClassName(hwnd, sb, sb.Capacity);

                    if (sb.ToString().StartsWith("ad_win")) {
                        // Hiding the window to make it inactive
                        Win32.ShowWindow(hwnd, (int) Win32.SW.HIDE);
                        //// Making unvisible (also removes indicator from taskbar)
                        Win32.SetWindowLong(hwnd, (int) Win32.GWL.STYLE, (uint) ~Win32.WS.VISIBLE);
                        //// Showing window to trigger style update
                        Win32.ShowWindow(hwnd, (int) Win32.SW.SHOW);
                        // Now finally hiding window last time
                        Win32.ShowWindow(hwnd, (int) Win32.SW.HIDE);
                        return false;
                    } else {
                        return true;
                    }
                }, IntPtr.Zero);
            }
        }
    }
}
