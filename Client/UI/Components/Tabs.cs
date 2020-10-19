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
            if (selected != null && selected.content != null) {
                selected.contentInstance.Dispose();
                selected.contentInstance = null;
            }

            selected = tab;
            Controls.Clear();

            if (tab != null) {
                if (tab.contentInstance == null) {
                    tab.contentInstance = (UserControl) Activator.CreateInstance(tab.content);
                }

                tab.contentInstance.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
                tab.contentInstance.Top = TAB_HEIGHT + 1 + tabHeadingPadding / 2;
                tab.contentInstance.Left = 0;
                tab.contentInstance.Width = Width;
                tab.contentInstance.Height = Height - tab.contentInstance.Top;

                tab.contentInstance.BackColorChanged += (sender, e) => {
                    Invalidate();
                };

                Controls.Add(tab.contentInstance);
            }

            Invalidate();
            OnTabChange();
        }

        public void RemoveTab (Tab tab) {
            var i = tabs.IndexOf(tab);
            tabs.Remove(tab);

            if (tab.isSelected) {
                Tab next = null;
                if (i == 0) {
                    if (tabs.Count > 0) next = tabs[0];
                } else {
                    next = tabs[i - 1];
                }

                SelectTab(next);
            } else {
                if (tab.contentInstance != null) {
                    tab.contentInstance.Dispose();
                    tab.contentInstance = null;
                }

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

            var prerendered = new List<Image>();
            var x = tabHeadingPadding;
            foreach (var tab in tabs) {
                if (!tab.visible) continue;

                var layer = new Bitmap((int) e.Graphics.VisibleClipBounds.Width, (int) e.Graphics.VisibleClipBounds.Height);
                var tabGraphics = Graphics.FromImage(layer);
                tabGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (tab.isSelected) {
                    // Rendering border line here because active tab is upper layer
                    tabGraphics.DrawLine(tabBorder, 0, y + TAB_HEIGHT, (int) e.Graphics.VisibleClipBounds.Width, y + TAB_HEIGHT);

                    x += RenderTabItem(tabGraphics, x, y, tab);
                    prerendered.Add(layer);
                } else {
                    x += RenderTabItem(tabGraphics, x, y, tab);
                    prerendered.Insert(0, layer);
                }
            }

            foreach (var layer in prerendered) {
                e.Graphics.DrawImage(layer, 0, 0);
            }
        }

        private int RenderTabItem (Graphics graphics, int x, int y, Tab tab) {
            // Current X for rendering with offset
            var cx = x;

            // Calculating tab width
            var textSize = graphics.MeasureString(tab.name, Font);
            var width = (int) textSize.Width + 14;
            if (tab.isClosable) width += 16;
            if (tab.icon != null) width += 16 + 5;

            SolidBrush tabBG, textBrush;
            if (tab.isSelected) {
                tabBG = new SolidBrush(tab.contentInstance.BackColor);
                textBrush = new SolidBrush(tab.contentInstance.ForeColor);
            } else if (hovered == tab) {
                tabBG = new SolidBrush(Color.FromArgb(250, 250, 250));
                textBrush = new SolidBrush(ForeColor);
            } else {
                tabBG = new SolidBrush(Color.FromArgb(250, 250, 250));
                textBrush = new SolidBrush(Color.FromArgb(200, ForeColor));
            }

            // Tab shape
            var bgPath = new GraphicsPath();
            bgPath.AddBezier(
                cx,      y + TAB_HEIGHT + 1,
                cx +  5, y + TAB_HEIGHT + 1,
                cx +  5, y,
                cx + 12, y
            );
            // ??? Why offset 2 with same curve!?
            bgPath.AddBezier(
                cx - 2 + width, y,
                cx + 5 + width, y,
                cx + 5 + width, y + TAB_HEIGHT + 1,
                cx + 14 + width, y + TAB_HEIGHT + 1
            );
            bgPath.CloseFigure();
            graphics.FillPath(tabBG, bgPath);
            graphics.DrawPath(tabBorder, bgPath);

            // Padding before tab name
            cx += 15;

            // Drawing tab icon with padding tab's name
            if (tab.icon != null) {
                graphics.DrawIcon(tab.icon, new Rectangle(cx, y + (TAB_HEIGHT - 16) / 2 + 1, 16, 16));
                cx += 20;
            }

            graphics.DrawString(tab.name, Font, textBrush, cx, y + (TAB_HEIGHT - textSize.Height) / 2);
            cx += (int) textSize.Width + 5;

            // Drawing close icon
            if (tab.isClosable) {
                // Margin for rendering around middle point
                cx += 6;

                var closeIconY = y + (TAB_HEIGHT - 6) / 2;
                Pen closeIconPen;
                if (tab == hovered && isCloseHovered) {
                    graphics.FillEllipse(Brushes.Red, cx - 9, closeIconY - 3, 12, 12);
                    closeIconPen = new Pen(Color.White, 1.5f);
                } else {
                    closeIconPen = new Pen(tabHeadingBorder, 1.5f);
                }

                graphics.DrawLine(closeIconPen, cx - 6, closeIconY, cx, closeIconY + 6);
                graphics.DrawLine(closeIconPen, cx, closeIconY, cx - 6, closeIconY + 6);
            }

            tab.lastWidth = width;
            tab.lastX = x;

            // offset between tabs
            return width - 3;
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
        public Type content;
        public UserControl contentInstance;
        internal Tabs container;

        public bool isClosable = true;
        public Dictionary<string, object> meta;
        public Icon icon;

        public bool isSelected {
            get { return container.selected == this; }
        }

        internal int lastX;
        internal int lastWidth;
        private bool _visible = true;
        public bool visible {
            get { return _visible; }
            set {
                _visible = value;
                if (container != null) container.Invalidate();
            }
        }
    }
}
