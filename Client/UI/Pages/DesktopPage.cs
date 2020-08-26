using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCClient.Properties;
using RCClient.UI.Modals;

namespace RCClient.UI.Pages {
    public partial class DesktopPage : UserControl {
        public DesktopPage () {
            InitializeComponent();

            listViewMenu_AddShortcut.Image = Icons.GetSystemBitmap("shell32.dll", 263, false);
            listViewMenu_AddLink.Image = Icons.GetSystemBitmap("shell32.dll", 135, false);
            listViewMenu_ChangeBG.Image = Icons.GetSystemBitmap("imageres.dll", 67, false);

            listView.LargeImageList = new ImageList();
            listView.LargeImageList.ImageSize = new Size(32, 32);
            listView.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
        }

        static public void FillPictureBox (Control pbox, Bitmap bmp) {
            bool source_is_wider = (float) bmp.Width / bmp.Height > (float) pbox.Width / pbox.Height;

            var resized = new Bitmap(pbox.Width, pbox.Height);
            var g = Graphics.FromImage(resized);
            var dest_rect = new Rectangle(0, 0, pbox.Width, pbox.Height);
            Rectangle src_rect;

            if (source_is_wider) {
                float size_ratio = (float) pbox.Height / bmp.Height;
                int sample_width = (int) (pbox.Width / size_ratio);
                src_rect = new Rectangle((bmp.Width - sample_width) / 2, 0, sample_width, bmp.Height);
            } else {
                float size_ratio = (float) pbox.Width / bmp.Width;
                int sample_height = (int) (pbox.Height / size_ratio);
                src_rect = new Rectangle(0, (bmp.Height - sample_height) / 2, bmp.Width, sample_height);
            }

            g.DrawImage(bmp, dest_rect, src_rect, GraphicsUnit.Pixel);
            g.Dispose();

            pbox.BackgroundImage = resized;
            pbox.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private Bitmap wallpaper = Resources.wallpaper;
        private void CustomBorderForm_Load (object sender, EventArgs e) {
            FillPictureBox(listView, wallpaper);
        }

        private void CustomBorderForm_ResizeEnd (object sender, EventArgs e) {
            FillPictureBox(listView, wallpaper);
            foreach (DesktopItem item in listView.Items)
                PlaceByGrid(item);
        }

        private ListViewItem heldDownItem;
        private Point heldDownPoint;
        private Point heldMousePoint;
        private void listView1_MouseDown (object sender, MouseEventArgs e) {
            heldDownItem = listView.GetItemAt(e.X, e.Y);
            if (heldDownItem != null) {
                heldDownPoint = new Point(e.X - heldDownItem.Position.X, e.Y - heldDownItem.Position.Y);
            } else {
                heldDownPoint = e.Location;
            }
        }

        private void listView1_MouseMove (object sender, MouseEventArgs e) {
            if (heldDownItem != null) {
                listView.BeginUpdate();
                heldDownItem.Position = new Point(e.Location.X - heldDownPoint.X, e.Location.Y - heldDownPoint.Y);
                listView.EndUpdate();
                heldMousePoint = e.Location;
            }
        }

        private const int ITEM_SIZE = 72;
        private const int LIST_PADDING = 10;
        private void CalcGridAligment (DesktopItem item) {
            var isLeft = (item.Bounds.X - LIST_PADDING + item.Bounds.Width / 2) / (float) (listView.Width - LIST_PADDING * 2) < 0.5f;
            var isTop = (item.Bounds.Y - LIST_PADDING + item.Bounds.Height / 2) / (float) (listView.Height - LIST_PADDING * 2) < 0.5f;

            if (isLeft) {
                item.xGridOffset = item.Position.X / (ITEM_SIZE + LIST_PADDING);
                if (isTop) {
                    item.alignment = ContentAlignment.TopLeft;
                    item.yGridOffset = item.Position.Y / (ITEM_SIZE + LIST_PADDING);
                } else {
                    item.alignment = ContentAlignment.BottomLeft;
                    item.yGridOffset = (item.Position.Y - listView.Height) / (ITEM_SIZE + LIST_PADDING);
                }
            } else {
                item.xGridOffset = (item.Position.X - listView.Width) / (ITEM_SIZE + LIST_PADDING);
                if (isTop) {
                    item.alignment = ContentAlignment.TopRight;
                    item.yGridOffset = item.Position.Y / (ITEM_SIZE + LIST_PADDING);
                } else {
                    item.alignment = ContentAlignment.BottomRight;
                    item.yGridOffset = (item.Position.Y - listView.Height) / (ITEM_SIZE + LIST_PADDING);
                }
            }

            PlaceByGrid(item);
        }

        private void PlaceByGrid (DesktopItem item) {
            int x, y;
            switch (item.alignment) {
                case ContentAlignment.TopLeft:
                    x = (LIST_PADDING + ITEM_SIZE) * item.xGridOffset + LIST_PADDING;
                    y = (LIST_PADDING + ITEM_SIZE) * item.yGridOffset + LIST_PADDING;
                    break;
                case ContentAlignment.TopRight:
                    x = listView.Width + (LIST_PADDING + ITEM_SIZE) * item.xGridOffset;
                    y = (LIST_PADDING + ITEM_SIZE) * item.yGridOffset + LIST_PADDING;
                    break;
                case ContentAlignment.BottomRight:
                    x = listView.Width + (LIST_PADDING + ITEM_SIZE) * item.xGridOffset;
                    y = listView.Height + (LIST_PADDING + ITEM_SIZE) * item.yGridOffset;
                    break;
                case ContentAlignment.BottomLeft:
                    x = (LIST_PADDING + ITEM_SIZE) * item.xGridOffset + LIST_PADDING;
                    y = listView.Height + (LIST_PADDING + ITEM_SIZE) * item.yGridOffset;
                    break;
                default:
                    return;
            }

            var maxX = listView.Width - LIST_PADDING - ITEM_SIZE;
            var maxY = listView.Height - LIST_PADDING - ITEM_SIZE;
            if (x > maxX)
                x = maxX;
            if (y > maxY)
                y = maxY;

            item.Position = new Point(x, y);
        }

        private void listView1_MouseUp (object sender, MouseEventArgs e) {
            if (heldDownItem != null) {
                heldDownItem.Position = heldMousePoint;
                CalcGridAligment((DesktopItem) heldDownItem);
                heldDownItem = null;
            }
        }

        private void listView1_DoubleClick (object sender, EventArgs e) {
            if (listView.SelectedItems.Count != 0)
                listView.SelectedItems[0].BeginEdit();
        }

        private async void AddShortcut (object sender, EventArgs e) {
            var result = await NewShortcut.Open(FindForm());
            if (!result.success)
                return;

            listView.BeginUpdate();
            listView.LargeImageList.Images.Add(result.value.icon);
            var item = new DesktopItem {
                Text = result.value.name,
                ImageIndex = listView.LargeImageList.Images.Count - 1
            };
            listView.Items.Add(item);

            item.Position = heldDownPoint;
            CalcGridAligment(item);
            listView.EndUpdate();
        }

        private async void AddLink (object sender, EventArgs e) {
            var result = await NewLink.Open(FindForm());
            if (!result.success) return;

            listView.BeginUpdate();
            listView.LargeImageList.Images.Add(result.value.icon);
            var item = new DesktopItem {
                Text = result.value.name,
                ImageIndex = listView.LargeImageList.Images.Count - 1
            };
            listView.Items.Add(item);

            item.Position = heldDownPoint;
            CalcGridAligment(item);
            listView.EndUpdate();
        }

        private void ChangeBG (object sender, EventArgs e) {
            if (bgSelectDialog.ShowDialog() == DialogResult.OK) {
                wallpaper = new Bitmap(bgSelectDialog.FileName);
                FillPictureBox(listView, wallpaper);
                BackColor = ((Bitmap) listView.BackgroundImage).GetPixel(25, 0);
            }
        }
    }

    class DesktopItem : ListViewItem {
        public int xGridOffset;
        public int yGridOffset;
        public ContentAlignment alignment;
    }
}
