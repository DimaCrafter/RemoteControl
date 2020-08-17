using RCClient.UI.Components;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RCClient.UI.Modals {
    public partial class NewLink : Modal<NewLink, LinkInfo> {
        public NewLink () {
            InitializeComponent();
        }

        private void onLoad (object sender, EventArgs e) {
            Icon = Icons.GetSystemIcon("shell32.dll", 135, true);
            linkIcon.Image = Icons.GetSystemBitmap("shell32.dll", 135, true);
        }

        private void onDragStart (object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void onDragEnd (object sender, DragEventArgs e) {
            var txt = (string) e.Data.GetData(DataFormats.Text);
            pathInput.Text = txt;
            GetInfo();
        }

        private Icon iconStruct;
        private static Regex TITLE_REGEX = new Regex("<title>(.*?)</title>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        private void SubmitForm (object sender, EventArgs e) {
            SetResult(new LinkInfo {
                icon = iconStruct,
                name = nameInput.Text,
                url = pathInput.Text
            });
        }

        private void Validate (object sender, EventArgs e) {
            getInfoBtn.Enabled = pathInput.Text != "";
            createBtn.Enabled = pathInput.Text != "" && nameInput.Text != "";
        }

        private void Cancel (object sender, EventArgs e) {
            Cancel();
        }

        private void GetInfo (object sender = null, EventArgs e = null) {
            var client = new WebClient();
            var parts = pathInput.Text.Split('/');

            try {
                var iconStream = new MemoryStream(client.DownloadData($"{parts[0]}//{parts[2]}/favicon.ico"));
                iconStruct = new Icon(iconStream);
                linkIcon.Image = iconStruct.ToBitmap();
            } catch (Exception) {
                linkIcon.Image = Icons.GetSystemBitmap("shell32.dll", 135, true);
                iconStruct = null;
            }

            try {
                client.Encoding = Encoding.UTF8;
                var matches = TITLE_REGEX.Match(client.DownloadString(pathInput.Text));
                nameInput.Text = matches.Groups[1].Value;
            } catch (Exception) {
                if (nameInput.Text == "") nameInput.Text = "Не удалось получить заголовок";
            }
        }
    }

    public struct LinkInfo {
        public string url;
        public Icon icon;
        public string name;
    }
}
