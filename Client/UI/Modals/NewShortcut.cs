using RCClient.UI.Components;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RCClient.UI.Modals {
    public partial class NewShortcut : Modal<NewShortcut, ShortcutInfo> {
        public NewShortcut () {
            InitializeComponent();
        }

        private void onLoad (object sender, EventArgs e) {
            Icon = Icons.GetSystemIcon("shell32.dll", 263, true);
            fileIcon.Image = SystemIcons.Application.ToBitmap();
            openFileBtn.Image = Icons.GetSystemBitmap("shell32.dll", 0, false);
            openFolderBtn.Image = Icons.GetSystemBitmap("shell32.dll", 3, false);
        }

        private void onDragStart (object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void onDragEnd (object sender, DragEventArgs e) {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            pathInput.Text = files[0];
        }

        private void ValidateForm (object sender, EventArgs e) {
            if (pathInput.Text != "" && nameInput.Text == "") {
                nameInput.Text = Path.GetFileNameWithoutExtension(pathInput.Text);
            }

            createBtn.Enabled = pathInput.Text != "" && nameInput.Text != "";
            fileIcon.Image = Icons.GetFileBitmap(pathInput.Text) ?? SystemIcons.Application.ToBitmap();
        }

        private void Cancel (object sender, EventArgs e) {
            Cancel();
        }

        private void OpenFile (object sender, EventArgs e) {
            openFileDialog.FileName = pathInput.Text;
            if (pathInput.Text != "") {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(pathInput.Text);
            }

            openFileDialog.ShowDialog();
            pathInput.Text = openFileDialog.FileName;
        }

        private void OpenFolder (object sender, EventArgs e) {
            openFolderDialog.SelectedPath = pathInput.Text;
            openFolderDialog.ShowDialog();
            pathInput.Text = openFolderDialog.SelectedPath;
        }

        private void ImgButtonEnter (object sender, EventArgs e) {
            var btn = (Control) sender;
            btn.BackColor = SystemColors.Highlight;
        }

        private void ImgButtonLeave (object sender, EventArgs e) {
            var btn = (Control) sender;
            btn.BackColor = SystemColors.Control;
        }

        private void Submit (object sender, EventArgs e) {
            SetResult(new ShortcutInfo {
                path = pathInput.Text,
                name = nameInput.Text,
                isCopy = copyCheckbox.Checked
            });
        }
    }

    public struct ShortcutInfo {
        public string path;
        public string name;
        public bool isCopy;
    }
}
