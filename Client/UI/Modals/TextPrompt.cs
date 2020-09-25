using RCClient.UI.Components;
using System;
using System.Drawing;

namespace RCClient.UI.Modals {
    public partial class TextPrompt : Modal<TextPrompt, string> {
        public TextPrompt (string title, string caption) {
            InitializeComponent();

            Text = title;
            captionLabel.Text = caption;
        }

        public TextPrompt (string title, string caption, string initial): this(title, caption) {
            input.Text = initial;
        }

        private void onLoad (object sender, EventArgs e) {
            Icon = SystemIcons.Question;
        }

        private void SubmitForm (object sender, EventArgs e) {
            SetResult(input.Text);
        }

        private void Validate (object sender, EventArgs e) {
            submitBtn.Enabled = input.Text.Trim().Length > 0;
        }

        private void Cancel (object sender, EventArgs e) {
            Cancel();
        }

        private void input_KeyPress (object sender, System.Windows.Forms.KeyPressEventArgs e) {
            if (e.KeyChar == '\r' && submitBtn.Enabled) {
                e.Handled = true;
                SubmitForm(sender, e);
            }
        }
    }
}
