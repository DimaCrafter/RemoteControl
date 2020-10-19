using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient.UI.Components {
    public partial class ObserverView : UserControl {
        private Size _tileSize = new Size(160, 90);
        [Browsable(true)]
        [Description("Minimal tile size")]
        public Size TileSize {
            get { return _tileSize; }
            set { _tileSize = value; Refresh(); }
        }

        [Browsable(true)]
        [Description("Minimal tile size")]
        public List<ImageTile> tiles = new List<ImageTile>();

        private VScrollBar scrollbar = new VScrollBar {
            Enabled = false,
            Dock = DockStyle.Right
        };

        public ObserverView (IContainer container) {
            container.Add(this);

            Controls.Add(scrollbar);
            scrollbar.Scroll += onScroll;

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        private void onScroll (object sender, ScrollEventArgs e) {
            Refresh();
        }

        private static Brush TEXT_BG = new SolidBrush(Color.FromArgb(64, 0, 0, 0));
        private static int TEXT_PADDING = 5;
        protected override void OnPaint (PaintEventArgs e) {
            var containerWidth = Width - scrollbar.Width;
            var tilesPerRow = containerWidth / TileSize.Width;
            var tileWidth = containerWidth / tilesPerRow;
            var i = 0;

            foreach (var tile in tiles) {
                var y = i / tilesPerRow;
                var x = tileWidth * (i - tilesPerRow * y);
                y *= TileSize.Height;
                i++;

                if (tile.image == null) continue;

                if (y >= e.ClipRectangle.Height) {
                    scrollbar.Value = e.ClipRectangle.Height;
                    scrollbar.Maximum = e.ClipRectangle.Height;
                    scrollbar.Enabled = true;
                    break;
                }

                var destWidth = (float) TileSize.Height / tile.image.Height * tile.image.Width;
                var imgRect = new Rectangle(x + (int) (tileWidth - destWidth) / 2, y, (int) destWidth, TileSize.Height);
                e.Graphics.DrawImage(tile.image, imgRect);

                var strMeasure = e.Graphics.MeasureString(tile.text, Font, tileWidth);
                var textX = imgRect.Right - (int) strMeasure.Width - TEXT_PADDING;
                e.Graphics.FillRectangle(TEXT_BG, textX - TEXT_PADDING, y, strMeasure.Width + TEXT_PADDING * 2, strMeasure.Height + TEXT_PADDING * 2);
                e.Graphics.DrawString(tile.text, Font, Brushes.White, new Point(textX, y + TEXT_PADDING));
            }

            base.OnPaint(e);
        }

        public void Clear () {
            tiles.Clear();
            CreateGraphics().FillRectangle(new SolidBrush(BackColor), Bounds);
        }
    }

    public class ImageTile {
        public Image image;
        public string text;
    }
}
