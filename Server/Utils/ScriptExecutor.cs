using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RCServer.Utils {
    internal class ScriptExecutor {
        private ExecScript script;
        private BinaryWriter writer;
        private BinaryReader reader;
        private static int executed = 0;
        private int currentIndex;

        public ScriptExecutor (ExecScript script) {
            this.script = script;
            currentIndex = executed++;
        }

        private void Log (string message) {
            Logs.Write("Script #" + currentIndex, message);
        }

        private void CommitPending (string description) {
            writer.Write((byte) PacketType.ExecuteScript);
            writer.Write((byte) ExecState.Status.Pending);
            writer.Write(description);

            Log(description);
        }

        private void CommitPercent (int percent) {
            writer.Write((byte) PacketType.ExecuteScript);
            writer.Write((byte) percent);
            writer.Flush();
        }

        private void CommitDone () {
            writer.Write((byte) PacketType.ExecuteScript);
            writer.Write((byte) ExecState.Status.Done);

            Log("Successfully done");
            isTaskSuccess = true;
        }

        private void CommitError (string message) {
            writer.Write((byte) PacketType.ExecuteScript);
            writer.Write((byte) ExecState.Status.Error);
            writer.Write(message);

            Log("Error:\n" + message);
            isTaskSuccess = false;
        }

        private bool isTaskSuccess;
        public void Execute (string endpoint, BinaryReader reader, BinaryWriter writer) {
            this.writer = writer;
            this.reader = reader;
            Log("Executing script from " + endpoint);

            foreach (var step in script.steps) {
                switch (step["type"]) {
                    case "run":
                        RunProgram(step);
                        break;
                    case "copy":
                        Copy(step);
                        break;
                    case "wait_device":
                        WaitDevice(step);
                        break;
                    case "move":
                        Move(step);
                        break;
                    case "remove":
                        Remove(step);
                        break;
                    case "maintain_components":
                        MaintainComponents(step);
                        break;
                    case "sync":
                        Synchronize();
                        break;
                }

                if (!isTaskSuccess) {
                    // TODO: conditional error skip
                    break;
                }
            }
        }

        private void Synchronize () {
            CommitPending("Синхронизация");
            writer.Write((byte) PacketType.Sync);

            var shortcuts = reader.ReadInt32();
            var desktop = new DesktopManager();
            for (var i = 0; i < shortcuts; i++) {
                var shortcut = Shortcut.Deserialize(reader);
                desktop.CreateShortcut((Shortcut) shortcut);
            }

            // If applying new background
            // Note: C:\Windows\Web\Wallpaper\Windows\img0.jpg - default
            if (reader.ReadBoolean()) {
                desktop.UpdateBackground(reader.ReadString());
            }

            desktop.ExecuteTasks();
            CommitDone();
        }

        private void MaintainComponents (Dictionary<string, string> info) {
            var argsCount = int.Parse(info["args"]);
            CommitPending("Обслуживание Windows");

            var errored = 0;
            for (var i = 0; i < argsCount; i++) {
                CommitPercent(i * 100 / argsCount);

                var entry = info["arg" + i].Split('|');
                if (!OtherUtils.ToggleWindowsComponent(entry[0], bool.Parse(entry[1]))) {
                    errored++;
                }
            }

            if (errored > 0) {
                CommitError("Обслуживание " + errored + " компонентов Windows не проведено");
            } else {
                CommitDone();
            }
        }

        private void Remove (Dictionary<string, string> info) {
            try {
                if (Directory.Exists(info["path"])) {
                    Directory.Delete(info["path"], true);
                } else if (File.Exists(info["path"])) {
                    File.Delete(info["path"]);
                }

                CommitDone();
            } catch (Exception err) {
                CommitError(err.Message);
            }
        }

        private void Move (Dictionary<string, string> info) {
            CommitPending("Перемещение " + info["src"] + " в " + info["dest"]);
            var dest = info["dest"] + "\\" + Path.GetFileName(info["src"]);

            try {
                if (!Directory.Exists(info["dest"])) {
                    Directory.CreateDirectory(info["dest"]);
                }

                if (Directory.Exists(info["src"])) {
                    Directory.Move(info["src"], dest);
                } else if (File.Exists(info["src"])) {
                    File.Move(info["src"], dest);
                } else {
                    CommitError("Директория или файл " + info["src"] + " не обнаружен");
                    return;
                }

                CommitDone();
            } catch (Exception err) {
                CommitError(err.Message);
            }
        }

        private void WaitDevice (Dictionary<string, string> info) {
            CommitPending("Ожидание " + info["path"]);
            while (true) {
                var drive = new DriveInfo(info["path"]);
                if (drive.IsReady) break;
                else Thread.Sleep(150);
            }

            CommitDone();
        }

        private void RunProgram (Dictionary<string, string> info) {
            var args = "";
            var argsCount = int.Parse(info["args"]);
            for (var i = 0; i < argsCount; i++) {
                args += $"\"{info["arg" + i]}\" ";
            }

            CommitPending("Выполнение " + info["cmd"] + " " + args);

            try {
                var process = Process.Start(new ProcessStartInfo {
                    FileName = info["cmd"],
                    Arguments = args,
                    WindowStyle = (ProcessWindowStyle) Enum.Parse(typeof(ProcessWindowStyle), info["windowState"]),
                    UseShellExecute = false
                });

                foreach (var childProcess in OtherUtils.GetChildProcesses(process)) {
                    MessageBox.Show(childProcess.ProcessName);
                }

                if (bool.Parse(info["wait"])) {
                    process.WaitForExit();
                }

                CommitDone();
            } catch (Exception err) {
                CommitError(err.Message);
            }
        }

        private void Copy (Dictionary<string, string> info) {
            var dest = info["dest"] + "\\" + Path.GetFileName(info["src"]);
            if (Directory.Exists(info["src"])) {
                CommitPending("Копирование директории " + info["src"] + " в " + info["dest"]);

                // https://stackoverflow.com/a/3822913/7528800
                Directory.CreateDirectory(dest);
                foreach (var dir in Directory.GetDirectories(info["src"], "*", SearchOption.AllDirectories)) {
                    Directory.CreateDirectory(dir.Replace(info["src"], dest));
                }

                var fileList = Directory.GetFiles(info["src"], "*.*", SearchOption.AllDirectories);

                var filesTotal = fileList.Length;
                var filesDone = 0;
                foreach (var file in fileList) {
                    File.Copy(file, file.Replace(info["src"], dest), true);
                    filesDone++;
                    CommitPercent(filesDone * 100 / filesTotal);
                }

                CommitDone();
            } else if (File.Exists(info["src"])) {
                CommitPending("Копирование файла " + info["src"] + " в " + info["dest"]);

                File.Copy(info["src"], dest, true);

                CommitDone();
            }
        }
    }
}
