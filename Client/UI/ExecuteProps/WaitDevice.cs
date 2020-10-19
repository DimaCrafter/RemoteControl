using System.Drawing;

namespace RCClient.UI.ExecuteProps {
    public partial class WaitDevice : Executable {
        public override Image icon => Icons.GetSystemBitmap("shell32.dll", 149, false);
        public WaitDevice () {
            type = "wait_device";
            name = "Ожидание устройства";

            InitializeComponent();
        }

        public override void Reset () {
            pathInput.Text = "";
        }

        public override void LoadResult () {
            pathInput.Text = GetValue("path", "");
        }

        private void pathInput_TextChanged (object sender, System.EventArgs e) {
            result["path"] = pathInput.Text;
        }
    }
}
