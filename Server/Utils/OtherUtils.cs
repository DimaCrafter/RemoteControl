using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace RCServer.Utils {
    class OtherUtils {
        private static readonly Regex PATH_ENV_REGEX = new Regex("(?:%(.*?)%)|(?:%([0-9]+))");
        public static string ParsePath (string path) {
            return PATH_ENV_REGEX.Replace(path, match => {
                if (match.Groups[1].Success) {
                    return Environment.GetEnvironmentVariable(match.Groups[1].Value);
                } else if (match.Groups[2].Success) {
                    return Environment.GetFolderPath((Environment.SpecialFolder) int.Parse(match.Groups[2].Value));
                }

                return match.Value;
            });
        }

        public static List<Process> GetChildProcesses (int parentID) {
            var query = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId = " + parentID);

            var result = new List<Process>();
            foreach (var item in query.Get()) {
                var pid = int.Parse(item.GetPropertyValue("ProcessId").ToString());
                result.Add(Process.GetProcessById(pid));
            }

            return result;
        }

        public static List<Process> GetChildProcesses (Process parent) {
            return GetChildProcesses(parent.Id);
        }

        //private static Regex CMD_PROGRESS_REGEX = new Regex(@"\[[ =]+([0-9.]+%)[ =]+\]");
        public static bool ToggleWindowsComponent (string name, bool status) {
            var dism = Process.Start(new ProcessStartInfo {
                FileName = "dism.exe",
                Arguments = $"/online /{(status ? "en" : "dis")}able-feature \"/featurename:{name}\"",
                //UseShellExecute = false,
                //CreateNoWindow = true,
                //RedirectStandardOutput = true,
                //StandardOutputEncoding = Encoding.GetEncoding("CP866")
            });

            dism.WaitForExit();
            return dism.ExitCode == 0;
        }
    }
}
