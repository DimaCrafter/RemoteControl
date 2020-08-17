using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RCClient.UI.Components {
    public class Tabs : Control {
        public Tabs () {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        }

        private List<Tab> tabs = new List<Tab>();
        public Tab selected { get; private set; }
        public void AddTab (Tab tab, bool isSelected = false) {
            tabs.Add(tab);
            tab.container = this;
            if (isSelected) SelectTab(tab);
        }

        public event Action OnTabChange = () => {};
        public void SelectTab (Tab tab) {
            selected = tab;
            Controls.Clear();

            if (tab != null) {
                tab.content.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                tab.content.Top = TAB_HEIGHT + 1 + tabHeadingPadding / 2;
                tab.content.Left = 0;
                tab.content.Width = Width;
                tab.content.Height = Height - tab.content.Top;

                Controls.Add(tab.content);
            }

            Invalidate();
            OnTabChange();
        }

        public void RemoveTab (Tab tab) {
            var i = tabs.IndexOf(tab);
            tabs.Remove(tab);
            tab.content.Dispose();

            if (tab.isSelected) {
                Tab next = null;
                if (i == 0) {
                    if (tabs.Count > 0) next = tabs[0];
                } else {
                    next = tabs[i - 1];
                }

                SelectTab(next);
            } else {
                Invalidate();
            }
        }

        public T GetMeta<T> (string key) => (T) selected?.meta[key];

        // Render section ===========================================================================================================
        private const int TAB_HEIGHT = 25;
        public Color tabHeadingColor = Color.White;
        public Color tabHeadingBorder = Color.Gray;
        private Pen tabBorder;
        public int tabHeadingPadding = 10;
        protected override void OnPaint (PaintEventArgs e) {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var y = tabHeadingPadding / 2;

            tabBorder = new Pen(tabHeadingBorder, 1);
            e.Graphics.FillRectangle(new SolidBrush(tabHeadingColor), 0, 0, (int) e.Graphics.VisibleClipBounds.Width, y + TAB_HEIGHT);

            Image activeTab = null;
            if (tabs.Count > 0) {
                var x = tabHeadingPadding;
                foreach (var tab in tabs) {
                    if (tab.isSelected) {
                        activeTab = new Bitmap((int) e.Graphics.VisibleClipBounds.Width, (int) e.Graphics.VisibleClipBounds.Height);
                        var tabGraphics = Graphics.FromImage(activeTab);
                        tabGraphics.SmoothingMode = SmoothingMode.AntiAlias;

                        x += RenderTabItem(tabGraphics, x, y, tab);
                    } else {
                        x += RenderTabItem(e.Graphics, x, y, tab);
                    }
                }
            }

            e.Graphics.DrawLine(tabBorder, 0, y + TAB_HEIGHT, (int) e.Graphics.VisibleClipBounds.Width, y + TAB_HEIGHT);
            if (activeTab != null) e.Graphics.DrawImage(activeTab, 0, 0);
        }

        private int RenderTabItem (Graphics graphics, int x, int y, Tab tab) {
            // TODO: Переделать на graphics origin
            var textSize = graphics.MeasureString(tab.name, Font);
            var width = textSize.Width;
            if (tab.isClosable) width += 20;
            else width += 5;

            SolidBrush tabBG, textBrush;
            if (tab.isSelected) {
                tabBG = new SolidBrush(tab.content.BackColor);
                textBrush = new SolidBrush(tab.content.ForeColor);
            } else if (hovered == tab) {
                tabBG = new SolidBrush(Color.FromArgb(250, 250, 250));
                textBrush = new SolidBrush(tab.content.ForeColor);
            } else {
                tabBG = new SolidBrush(Color.FromArgb(250, 250, 250));
                textBrush = new SolidBrush(Color.FromArgb(200, tab.content.ForeColor));
            }

            var bgPath = new GraphicsPath();
            bgPath.AddBezier(x, y + TAB_HEIGHT + 1, x, y + TAB_HEIGHT + 1, x + 3, y, x + 5, y);
            bgPath.AddLine(x + 5, y, x + 5 + width, y);
            bgPath.AddBezier(x + 5 + width, y, x + 12 + width, y, x + 12 + width, y + TAB_HEIGHT + 1, x + 20 + width, y + TAB_HEIGHT + 1);
            bgPath.CloseFigure();
            graphics.FillPath(tabBG, bgPath);
            graphics.DrawPath(tabBorder, bgPath);

            if (tab.isClosable) {
                var closeIconY = y + (TAB_HEIGHT - 6) / 2;
                var closeIconX = x + width + 1;

                Pen closeIconPen;
                if (tab == hovered && isCloseHovered) {
                    graphics.FillEllipse(Brushes.Red, closeIconX - 9, closeIconY - 3, 12, 12);
                    closeIconPen = new Pen(Color.White, 1.5f);
                } else {
                    closeIconPen = new Pen(tabHeadingBorder, 1.5f);
                }

                graphics.DrawLine(closeIconPen, closeIconX - 6, closeIconY, closeIconX, closeIconY + 6);
                graphics.DrawLine(closeIconPen, closeIconX, closeIconY, closeIconX - 6, closeIconY + 6);
            }

            graphics.DrawString(tab.name, Font, textBrush, x + 10, y + (TAB_HEIGHT - textSize.Height) / 2);

            tab.lastWidth = (int) width;
            tab.lastX = x;
            return (int) width + 5;
        }

        private bool isCloseHovered = false;
        private bool IsTabHovered (Tab tab, int x, int y) {
            var isHovered = x >= tab.lastX && x <= tab.lastX + tab.lastWidth + 10;
            if (isHovered && tab.isClosable) {
                var closeIconX = tab.lastX + tab.lastWidth - 8;
                var closeIconY = (tabHeadingPadding + TAB_HEIGHT - 8) / 2 - 2;
                isCloseHovered = x >= closeIconX && x <= closeIconX + 12 && y >= closeIconY && y <= closeIconY + 12;
            }

            return isHovered;
        }

        private Tab hovered;
        protected override void OnMouseMove (MouseEventArgs e) {
            if (e.X > tabHeadingPadding && e.X < Width - tabHeadingPadding && e.Y > tabHeadingPadding / 2 && e.Y <= TAB_HEIGHT) {
                foreach (var tab in tabs) {
                    if (IsTabHovered(tab, e.X, e.Y)) {
                        hovered = tab;
                        Invalidate();
                        return;
                    }
                }
            }

            if (hovered != null) {
                Invalidate();
                hovered = null;
                isCloseHovered = false;
            }
        }

        protected override void OnClick (EventArgs e) {
            if (hovered != null) {
                if (hovered.isClosable && isCloseHovered) {
                    RemoveTab(hovered);
                    hovered = null;
                } else {
                    SelectTab(hovered);
                }
            }
        }
    }

    public class Tab {
        public string name;
        public UserControl content;
        internal Tabs container;

        public bool isClosable = true;
        public Dictionary<string, object> meta;
        public Icon icon;

        public bool isSelected {
            get { return container.selected == this; }
        }

        internal int lastX;
        internal int lastWidth;
    }
}
