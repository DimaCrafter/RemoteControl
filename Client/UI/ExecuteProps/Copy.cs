using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RCClient.UI.ExecuteProps {
    public partial class Copy : Executable {
        public override Image icon => Icons.GetSystemBitmap("shell32.dll", 68, false);
        public Copy () {
            type = "copy";
            name = "Копировать";

            InitializeComponent();
            openSrcFileBtn.image = Icons.GetSystemBitmap("shell32.dll", 0, false);
            openDestBtn.image = openSrcDirBtn.image = Icons.GetSystemBitmap("shell32.dll", 3, false);
        }

        public override void Reset () {
            srcInput.Text = "";
            destInput.Text = "";
        }

        public override void LoadResult () {
            srcInput.Text = GetValue("src", "");
            destInput.Text = GetValue("dest", "");
        }

        private void SelectSrcFile (object sender, EventArgs e) {
            if (srcInput.Text.Trim().Length > 0) {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(srcInput.Text);
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                srcInput.Text = openFileDialog.FileName;
            }
        }

        private void SelectSrcDir (object sender, EventArgs e) {
            if (srcInput.Text.Trim().Length > 0) {
                openDirectoryDialog.SelectedPath = srcInput.Text;
            }

            if (openDirectoryDialog.ShowDialog() == DialogResult.OK) {
                srcInput.Text = openDirectoryDialog.SelectedPath;
            }
        }

        private void SelectDestDir (object sender, EventArgs e) {
            if (destInput.Text.Trim().Length > 0) {
                openDirectoryDialog.SelectedPath = destInput.Text;
            }

            if (openDirectoryDialog.ShowDialog() == DialogResult.OK) {
                destInput.Text = openDirectoryDialog.SelectedPath;
            }
        }

        private void onSrcChanged (object sender, EventArgs e) {
            result["src"] = srcInput.Text;
        }

        private void onDestChanged (object sender, EventArgs e) {
            result["dest"] = destInput.Text;
        }
    }
}
