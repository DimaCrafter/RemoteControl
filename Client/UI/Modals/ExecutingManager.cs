using Common;
using RCClient.Properties;
using RCClient.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient.UI {
    public partial class ExecutingManager : Modal<ExecutingManager, object> {
        public ExecutingManager (List<Device> devices, ExecScript script) {
            InitializeComponent();
            Icon = Icons.GetSystemIcon("shell32.dll", 24, true);
            isResizable = true;

            scriptNameLabel.Text = script.name;
            treeView.ImageList = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };
            treeView.ImageList.Images.Add(Resources.progressIcon);
            treeView.ImageList.Images.Add(Resources.success);
            treeView.ImageList.Images.Add(Resources.fail);
            treeView.ImageList.Images.Add(Resources.connectionLost);

            var deviceCount = 0;
            var devicesDone = 0;
            progressBar.Value = 0;
            progressBar.Maximum = 100;

            foreach (var device in devices) {
                var deviceNode = treeView.Nodes.Add(device.ip + " - подключение");
                deviceNode.ImageIndex = 0;

                device.Connect(true).ContinueWith(task => {
                    if (task.IsFaulted) {
                        // connectionLost
                        deviceNode.ImageIndex = 3;
                        return;
                    }

                    Invoke((Action) delegate {
                        involvedLabel.Text = ++deviceCount + " устройств";
                    });

                    ProceedDevice(deviceNode, device, script, () => {
                        devicesDone++;
                        progressBar.Value = devicesDone * 100 / devices.Count;

                        if (devicesDone == devices.Count) {
                            MessageBox.Show("Выполнение сценария завершено", "Сценарий " + script.name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    });
                });
            }
        }

        private int executedSteps = 0;
        private void ProceedDevice (TreeNode deviceNode, Device device, ExecScript script, Action onDetach) {
            var state = new ExecState();
            var executed = 0;
            var currentStep = 0;

            Action detach = null;
            void UpdateTree () {
                Invoke((Action) delegate {
                    deviceNode.Text = $"{device.ip} [{executed}/{script.steps.Count}]";
                    executedSteps++;

                    if (currentStep == script.steps.Count) {
                        executedSteps += script.steps.Count - executed;
                        // all tasks are executed ? success : fail
                        deviceNode.ImageIndex = executed == script.steps.Count ? 1 : 2;

                        detach();
                        onDetach();
                    }

                    progressBar.Value = executedSteps * 100 / script.steps.Count;
                });
            }

            detach = device.ExecuteScript(script, state, () => {
                switch ((ExecState.Status) state.status) {
                    case ExecState.Status.Pending:
                        Invoke((Action) delegate {
                            var taskNode = deviceNode.Nodes.Add(state.description);
                            // pending
                            taskNode.ImageIndex = 0;
                            deviceNode.Expand();
                        });
                        currentStep++;
                        break;
                    case ExecState.Status.Done:
                        Invoke((Action) delegate {
                            // success
                            deviceNode.Nodes[currentStep - 1].ImageIndex = 1;
                        });
                        executed++;
                        UpdateTree();
                        break;
                    case ExecState.Status.Error:
                        Invoke((Action) delegate {
                            // fail
                            deviceNode.Nodes[currentStep - 1].ImageIndex = 2;
                        });
                        UpdateTree();
                        break;
                }
            });

            device.onDisconnect += () => {
                // connectionLost
                deviceNode.ImageIndex = 3;
            };
        }
    }
}
