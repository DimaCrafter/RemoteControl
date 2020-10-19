using RCClient.Properties;
using System;
using System.Drawing;

namespace RCClient.UI.ExecuteProps {
    public partial class CloseProgram : Executable {
        public override Image icon => Resources.close;
        public CloseProgram () {
            type = "end_process";
            name = "Завершить програму";

            InitializeComponent();
        }

        public override void Reset () {
            processNameInput.Text = "";
            timoutInput.Text = "2500";
            forceKillCheckbox.Checked = true;
        }

        public override void LoadResult () {
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
