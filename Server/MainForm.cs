using Microsoft.Win32.TaskScheduler;
using RCServer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RCServer {
    public partial class MainForm : Form {
        public const string SERVICE_TASK_NAME = "RemoteControl Server Startup";
        private static readonly TaskService taskService = new TaskService();

        private List<Log> logs;
        public MainForm () {
            InitializeComponent();
            if (taskService.GetTask(SERVICE_TASK_NAME) == null) {
                removeBtn.Enabled = false;
            } else {
                installBtn.Enabled = false;
            }

            logs = Logs.GetLogs((e, log) => {
                Invoke((System.Action) delegate {
                    switch (e) {
                        case LogsEventType.Created:
                            logsList.Items.Add(log.name);
                            if (log.isActual) logsList.SelectedIndex = logs.Count - 1;
                            break;
                        case LogsEventType.Changed:
                            log.Refresh(logsTextarea);
                            break;
                        case LogsEventType.Removed:
                            logsList.Items.Remove(log.name);
                            break;
                    }
                });
            });

            foreach (var log in logs) {
                logsList.Items.Add(log.name);
            }

            if (GetServiceProcess() == null) {
                stopBtn.Enabled = false;
            } else {
                startBtn.Enabled = false;
            }
        }

        private void onLoad (object sender, EventArgs e) {
            if (logs.Count == 0) {
                removeLogBtn.Enabled = false;
            } else {
                logsList.SelectedIndex = logs.Count - 1;
            }

            if (Program.isStartService) StartService();
        }

        public Process GetServiceProcess () {
            foreach (var process in Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)) {
                if (Win32.GetProcessArgs(process).Contains("--service")) {
                    return process;
                }
            }

            return null;
        }

        private void InstallService (object sender, EventArgs e) {
            var task = taskService.NewTask();
            //task.RegistrationInfo.Description = "TODO: Description";

            task.Triggers.Add(new LogonTrigger {
                UserId = Environment.MachineName + "\\" + Environment.UserName,
                Enabled = true
            });

            var destPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\RCServer";
            Directory.CreateDirectory(destPath);
            var destExe = destPath + "\\RCServer.exe";
            File.Copy(Program.EXE_PATH, destExe, true);

            task.Actions.Add(new ExecAction(destExe, "--service", destPath));
            task.Principal.RunLevel = TaskRunLevel.Highest;

            taskService.RootFolder.RegisterTaskDefinition(SERVICE_TASK_NAME, task);
            Process.Start(new ProcessStartInfo {
                FileName = destExe,
                Arguments = "--start-service",
                WorkingDirectory = destPath
            });
            Environment.Exit(0);
        }

        private void RemoveTask (object sender, EventArgs e) {
            taskService.RootFolder.DeleteTask(SERVICE_TASK_NAME, false);
            installBtn.Enabled = true;
            removeBtn.Enabled = false;
        }

        private void RemoveLog (object sender, EventArgs e) {
            logs[logsList.SelectedIndex].Remove();
            logsList.Items.RemoveAt(logsList.SelectedIndex);

            var count = logsList.Items.Count;
            if (logsList.SelectedIndex == count) {
                logsList.SelectedIndex--;
            } else if (count == 0) {
                logsList.SelectedIndex = -1;
            }

            onLogSelected(sender, e);
        }

        private void onLogSelected (object sender, EventArgs e) {
            if (logsList.SelectedIndex == -1) {
                logsTextarea.Clear();
                logsList.Text = "";
                removeLogBtn.Enabled = false;
            } else {
                logs[logsList.SelectedIndex].Print(logsTextarea);
                removeLogBtn.Enabled = true;
            }
        }

        private void StartService (object sender = null, EventArgs e = null) {
            var process = Process.Start(Program.EXE_PATH, "--service");
            process.EnableRaisingEvents = true;
            process.Exited += (sender, e) => {
                Invoke((System.Action) delegate {
                    startBtn.Enabled = true;
                    stopBtn.Enabled = false;
                });
            };

            startBtn.Enabled = false;
            stopBtn.Enabled = true;
        }

        private void StopService (object sender = null, EventArgs e = null) {
            GetServiceProcess()?.Kill();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
        }

        private void OpenInExplorer (object sender, EventArgs e) {
            Process.Start("explorer.exe", Environment.CurrentDirectory);
        }
    }
}
