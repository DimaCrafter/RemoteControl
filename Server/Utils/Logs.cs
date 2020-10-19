using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace RCServer.Utils {
    class Logs {
        public static string LOGS_DIR = Environment.CurrentDirectory + "\\logs";
        public static void Start () {
            if (!Directory.Exists(LOGS_DIR)) {
                Directory.CreateDirectory(LOGS_DIR);
            }

            Write("SYS", "Service started");
        }

        public static void Write (string scope, string message) {
            File.AppendAllText(
                $"{LOGS_DIR}\\{DateTime.Now:dd-MM-yyyy}.log",
                $"[{DateTime.Now:HH:mm:ss}] [{scope}] {message}{Environment.NewLine}"
            );
        }

        public static void Stop () {
            Write("SYS", "Service stopped");
        }

        public static List<Log> GetLogs (Action<LogsEventType, Log> handler) {
            var result = new List<Log>();
            if (!Directory.Exists(LOGS_DIR)) {
                Directory.CreateDirectory(LOGS_DIR);
            }

            foreach (var filename in Directory.GetFiles(LOGS_DIR)) {
                result.Add(new Log(filename));
            }

            var watcher = new FileSystemWatcher(LOGS_DIR, "*.log");
            watcher.Created += (sender, e) => {
                var log = new Log(e.FullPath);
                result.Add(log);
                handler(LogsEventType.Created, log);
            };
            watcher.Changed += (sender, e) => {
                foreach (var log in result) {
                    if (log.path == e.FullPath) {
                        handler(LogsEventType.Changed, log);
                        return;
                    }
                }
            };
            watcher.Deleted += (sender, e) => {
                var i = 0;
                foreach (var log in result) {
                    if (log.path == e.FullPath) {
                        handler(LogsEventType.Removed, log);
                        result.RemoveAt(i);
                        return;
                    } else {
                        i++;
                    }
                }
            };

            watcher.EnableRaisingEvents = true;

            return result;
        }
    }

    enum LogsEventType {
        Created, Changed, Removed
    }

    class Log {
        public string name;
        public string path;
        public bool isActual {
            get { return name == DateTime.Now.ToString("dd-MM-yyyy"); }
        }

        public Log (string path) {
            this.path = path;
            name = Path.GetFileNameWithoutExtension(path);
        }

        private static readonly Regex LINE_REGEX = new Regex(@"^\[([0-9]{2}:[0-9]{2}:[0-9]{2})\] \[([a-zA-z0-9]+)(?:\s[^]]+)?] (.*)$");
        private int linesPrinted = 0;
        public void Print (RichTextBox textarea) {
            textarea.Clear();

            // avoid system file lock
            Thread.Sleep(250);
            var lines = File.ReadAllLines(path);
            linesPrinted = lines.Length;
            foreach (var line in lines) {
                PrintLine(textarea, line);
            }

            textarea.ScrollToCaret();
        }

        public void Refresh (RichTextBox textarea) {
            // avoid system file lock
            Thread.Sleep(250);
            var lines = File.ReadAllLines(path);

            // Printing not printed (appended) lines
            for (var i = linesPrinted; i < lines.Length; i++) {
                PrintLine(textarea, lines[i]);
            }

            linesPrinted = lines.Length;
            textarea.ScrollToCaret();
        }

        private void PrintLine (RichTextBox textarea, string line) {
            var matched = LINE_REGEX.Match(line);

            var color = Color.Black;
            switch (matched.Groups[2].Value) {
                case "SYS":
                    color = Color.Tomato;
                    break;
                case "INFO":
                    color = Color.DodgerBlue;
                    break;
                case "ERR":
                    color = Color.FromArgb(225, 16, 0);
                    break;
                case "Script":
                    color = Color.FromArgb(0, 188, 212);
                    break;
            }

            textarea.Invoke((Action) delegate {
                LogColor(textarea, color, line + "\n");
            });
        }

        public void LogColor (RichTextBox textarea, Color color, string text) {
            textarea.AppendText(text);
            textarea.Select(textarea.Text.Length - text.Length, text.Length);
            textarea.SelectionColor = color;
            textarea.DeselectAll();
        }

        public void Remove () {
            File.Delete(path);
        }
    }
}
