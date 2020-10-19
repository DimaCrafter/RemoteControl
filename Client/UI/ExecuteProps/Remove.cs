using RCClient.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RCClient.UI.ExecuteProps {
    public partial class Remove : Executable {
        public override Image icon => Resources.close;
        public Remove () {
            type = "remove";
            name = "Удалить";

            InitializeComponent();
            openSrcFileBtn.image = Icons.GetSystemBitmap("shell32.dll", 0, false);
            openSrcDirBtn.image = Icons.GetSystemBitmap("shell32.dll", 3, false);
        }

        public override void Reset () {
            pathInput.Text = "";
        }

        public override void LoadResult () {
            pathInput.Text = GetValue("path", "");
        }

        private void SelectSrcFile (object sender, EventArgs e) {
            if (pathInput.Text.Trim().Length > 0) {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(pathInput.Text);
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                pathInput.Text = openFileDialog.FileName;
            }
        }

        private void SelectSrcDir (object sender, EventArgs e) {
            if (pathInput.Text.Trim().Length > 0) {
                openDirectoryDialog.SelectedPath = pathInput.Text;
            }

            if (openDirectoryDialog.ShowDialog() == DialogResult.OK) {
                pathInput.Text = openDirectoryDialog.SelectedPath;
            }
        }


        private void onSrcChanged (object sender, EventArgs e) {
            result["path"] = pathInput.Text;
        }
    }
}
