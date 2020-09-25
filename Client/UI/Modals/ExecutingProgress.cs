using Common;
using RCClient.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace RCClient.UI.Modals {
    public partial class ExecutingProgress : Modal<ExecutingProgress, object> {
        private Dictionary<Device, ExecState> states = new Dictionary<Device, ExecState>();
        public ExecutingProgress (List<Device> devices, ExecScript script) {
            InitializeComponent();
            Icon = Icons.GetSystemIcon("shell32.dll", 24, true);

            involvedLabel.Text = devices.Count + " устройств";

            new Thread((ThreadStart) async delegate {
                foreach (var device in devices) {
                    await device.Connect();
                    states.Add(device, new ExecState {
                        percent = 0xFA,
                        step = "Подключение"
                    });
                    device.ExecuteScript(script, state => onStateChanged(device, state));
                }
            }).Start();

            LogTable();
        }

        private void onStateChanged (Device device, ExecState state) {
            states[device] = state;
            Invoke((Action) LogTable);
        }

        private void LogTable () {
            richTextBox1.Clear();
            var maxL = 0;
            foreach (var pair in states) {
                var ip = pair.Key.ip.ToString();
                if (ip.Length > maxL) maxL = ip.Length;
            }

            foreach (var pair in states) {
                LogColor(Color.BlueViolet, $"[{pair.Key.ip}]".PadRight(maxL + 4));

                switch (pair.Value.percent) {
                    case 0xFA:
                        LogColor(Color.Blue, pair.Value.step + "...\n");
                        break;
                    case 0xFE:
                        LogColor(Color.Red, pair.Value.step + "\n");
                        break;
                    case 0xFF:
                        LogColor(Color.Green, "Выполнено\n");
                        break;
                    default:
                        LogColor(Color.DeepSkyBlue, $"{pair.Value.step} {pair.Value.percent}%\n");
                        break;
                }
            }
        }

        private void LogColor (Color color, string text) {
            richTextBox1.AppendText(text);
            richTextBox1.Select(richTextBox1.Text.Length - text.Length, text.Length);
            richTextBox1.SelectionColor = color;
            richTextBox1.DeselectAll();
        }
    }
}
