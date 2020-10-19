using Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RCClient.UI.Forms {
    public partial class ExecuteForm : Form {
        private List<Device> devices;
        public ExecuteForm (List<Device> devices) {
            InitializeComponent();
            Icon = Icons.GetSystemIcon("shell32.dll", 24, true);

            this.devices = devices;
            involvedLabel.Text = devices.Count + " устройств";

            scriptList.Items.Add("[Создать одноразовый сценарий]");
            foreach (var script in Settings.data.scripts) {
                scriptList.Items.Add(script.name);
            }
        }

        private void Cancel (object sender, EventArgs e) {
            Close();
        }

        private async void Execute (object sender, EventArgs e) {
            ExecScript script;
            if (scriptList.SelectedIndex == 0) {
                script = await ScriptForm.CreateTempScript();
            } else {
                script = Settings.data.scripts[scriptList.SelectedIndex - 1];
            }

            Close();
            // Locking main form
            await ExecutingManager.Open(Application.OpenForms[0], devices, script);
        }
    }
}
