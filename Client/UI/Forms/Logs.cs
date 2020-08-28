using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient {
    public partial class Logs : Form {
        private static Logs instance;
        public Logs () {
            InitializeComponent();
            instance = this;
            Icon = Icons.GetSystemIcon("mmc.exe", 0, true);
        }

        private void onLoad (object sender, EventArgs e) {
            instance.textarea.AppendText(history);
        }

        private void onClose (object sender, FormClosingEventArgs e) {
            instance = null;
        }

        public static void OpenForm (Form target = null) {
            if (instance == null) new Logs();
            instance.Show();
            instance.Focus();

            if (target != null) {
                instance.DoMagnet(target);
                target.Resize += instance.DoMagnet;
                target.Move += instance.DoMagnet;

                instance.FormClosing += (sender, e) => {
                    target.Resize -= instance.DoMagnet;
                    target.Move -= instance.DoMagnet;
                };
            }
        }

        private void DoMagnet (object sender, object e = null) {
            if (!isMagneticCheck.Checked) return;

            var target = (Form) sender;
            instance.Height = target.Height;
            instance.Location = new Point(target.Location.X - Width + 5, target.Location.Y);
        }

        public static string history = "";
        public static void Write (string line) {
            history += line + "\r\n";

            if (instance != null) {
                Action invokable = () => instance.textarea.AppendText(line + "\r\n");

                if (instance.InvokeRequired) instance.Invoke(invokable);
                else invokable();
            }
        }
    }
}
