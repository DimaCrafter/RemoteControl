using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        private void pictureBox1_MouseEnter (object sender, EventArgs e) {
            pictureBox1.BackColor = SystemColors.Highlight;
        }

        private void pictureBox1_MouseLeave (object sender, EventArgs e) {
            pictureBox1.BackColor = SystemColors.Control;
        }

        public new event EventHandler Click = (sender, e) => { };
        private void pictureBox1_Click (object sender, EventArgs e) {
            Click(this, e);
        }

        protected override unsafe void OnEnabledChanged (EventArgs e = null) {
            if (_img == null) return;

            if (Enabled) pictureBox1.Image = _img;
            else {
                var img = (Bitmap) _img.Clone();
                var imgData = img.LockBits(new Rectangle(Point.Empty, img.Size), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                for (var y = 0; y < img.Height; y++) {
                    for (var x = 0; x < img.Width; x++) {
                        var i = (byte*) imgData.Scan0 + imgData.Stride * y + x * 4;
                        i[2] = i[1] = i[0] = (byte) ((i[2] + i[1] + i[0]) / 3);
                    }
                }

                img.UnlockBits(imgData);
                pictureBox1.Image = img;
            }
        }
    }
}
