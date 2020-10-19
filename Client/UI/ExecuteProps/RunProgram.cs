using RCClient.UI.Modals;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RCClient.UI.ExecuteProps {
    public partial class RunProgram : Executable {
        public override Image icon => Icons.GetSystemBitmap("shell32.dll", 24, false);
        public RunProgram () {
            type = "run";
            name = "Выполнить";

            InitializeComponent();
            openFileBtn.image = Icons.GetSystemBitmap("shell32.dll", 0, false);
        }

        public override void Reset () {
            commandInput.Text = "";
            argsBox.Items.Clear();
            wsNormal.Checked = true;
            waitCheck.Checked = false;
        }

        public override void LoadResult () {
            commandInput.Text = GetValue("cmd", "");
            switch (GetValue("windowState", "Normal")) {
                case "Normal":
                    wsNormal.Checked = true;
                    break;
                case "Hidden":
                    wsHidden.Checked = true;
                    break;
                case "Minimized":
                    wsMinimized.Checked = true;
                    break;
                case "Maximized":
                    wsMaximized.Checked = true;
                    break;
            }

            var argsCount = int.Parse(GetValue("args", "0"));
            argsBox.Items.Clear();
            for (var i = 0; i < argsCount; i++) {
                argsBox.Items.Add(result["arg" + i]);
            }

            waitCheck.Checked = bool.Parse(GetValue("wait", "false"));
        }

        private async void EditArgument (object sender, EventArgs e) {
            if (argsBox.SelectedItem == null) {
                var res = await TextPrompt.Open(FindForm(), "Добавление аргумента", "Введите значение для нового аргумента");
                if (res.success) {
                    argsBox.Items.Add(res.value);
                    result["arg" + result["args"]] = res.value;
                    result["args"] = (int.Parse(result["args"]) + 1).ToString();
                }
            } else {
                var res = await TextPrompt.Open(FindForm(), "Изменение аргумента", "Введите новое значение для аргумента", (string) argsBox.SelectedItem);
                if (res.success) {
                    argsBox.Items[argsBox.SelectedIndex] = res.value;
                    result["arg" + argsBox.SelectedIndex] = res.value;
                }
            }
        }

        private void RemoveArgument (object sender, EventArgs e) {
            if (argsBox.SelectedItem == null) return;
            argsBox.Items.RemoveAt(argsBox.SelectedIndex);

            result["args"] = (int.Parse(result["args"]) - 1).ToString();
            result.Remove("arg" + result["args"]);
        }

        private void SelectFile (object sender, EventArgs e) {
            if (commandInput.Text.Trim().Length > 0) {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(commandInput.Text);
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                commandInput.Text = openFileDialog.FileName;
            }
        }

        private void onWindowStateSelect (object sender, EventArgs e) {
            result["windowState"] = (string) ((RadioButton) sender).Tag;
        }

        private void commandInput_TextChanged (object sender, EventArgs e) {
            result["cmd"] = commandInput.Text;
        }

        private void waitCheck_CheckedChanged (object sender, EventArgs e) {
            result["wait"] = waitCheck.Checked.ToString();
        }
    }
}
