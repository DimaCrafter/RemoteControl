using System;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient.UI.Components {
    public partial class ImgButton : UserControl {
        public ImgButton () {
            InitializeComponent();
        }

        private Image _img;
        public Image image {
            get { return _img; }
            set {
                _img = value;
                OnEnabledChanged();
            }
        }

        private void onMouseEnter (object sender, EventArgs e) {
           pictureBox.BackColor = SystemColors.Highlight;
        }

        private void onMouseLeave (object sender, EventArgs e) {
            pictureBox.BackColor = BackColor;
        }

        public new event EventHandler Click = (sender, e) => { };
        private void onClick (object sender, EventArgs e) {
            Click(sender, e);
        }

        protected override void OnEnabledChanged (EventArgs e = null) {
            if (_img == null) return;

            if (Enabled) pictureBox.Image = _img;
            else pictureBox.Image = Utils.GrayscaleImage(_img);

            base.OnEnabledChanged(e);
        }
    }
}
