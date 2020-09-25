using RCClient.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RCClient.UI.ExecuteProps {
    public partial class CloseProgram : Executable {
        public override Image icon => Resources.close;
        public CloseProgram () {
            name = "Завершить програму";
            InitializeComponent();
        }

        public override void Reset () {
            result = new Dictionary<string, string>();
            result["type"] = "1";

            processNameInput.Text = "";
            timoutInput.Text = "2500";
            forceKillCheckbox.Checked = true;
        }

        public override void LoadResult () {
            result["type"] = "1";
            processNameInput.Text = GetValue("process", "");
            timoutInput.Text = GetValue("timeout", "2500");
            forceKillCheckbox.Checked = timoutInput.Text != "0";
        }

        private void onForceKillChanged (object sender, EventArgs e) {
            timoutInput.Enabled = forceKillCheckbox.Checked;
            onTimoutChanged(sender, e);
        }

        private void onProcessNameChanged (object sender, EventArgs e) {
            result["process"] = processNameInput.Text;
        }

        private void onTimoutChanged (object sender, EventArgs e) {
            if (forceKillCheckbox.Checked) {
                result["timeout"] = timoutInput.Text;
            } else {
                result["timeout"] = "0";
            }
        }
    }
}
