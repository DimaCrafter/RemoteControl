namespace RCClient.UI.Pages {
    partial class DesktopPage {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent () {
            this.components = new System.ComponentModel.Container();
            this.listItemMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listViewMenu_AddShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewMenu_AddLink = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.listItemMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listItemMenu
            // 
            this.listItemMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listViewMenu_AddShortcut,
            this.listViewMenu_AddLink});
            this.listItemMenu.Name = "listItemMenu";
            this.listItemMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // listViewMenu_AddShortcut
            // 
            this.listViewMenu_AddShortcut.Name = "listViewMenu_AddShortcut";
            this.listViewMenu_AddShortcut.Size = new System.Drawing.Size(180, 22);
            this.listViewMenu_AddShortcut.Text = "Добавить ярлык";
            this.listViewMenu_AddShortcut.Click += new System.EventHandler(this.AddShortcut);
            // 
            // listViewMenu_AddLink
            // 
            this.listViewMenu_AddLink.Name = "listViewMenu_AddLink";
            this.listViewMenu_AddLink.Size = new System.Drawing.Size(180, 22);
            this.listViewMenu_AddLink.Text = "Добавить ссылку";
            this.listViewMenu_AddLink.Click += new System.EventHandler(this.AddLink);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(65)))), ((int)(((byte)(95)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 45);
            this.panel1.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.AutoArrange = false;
            this.listView.BackgroundImage = global::RCClient.Properties.Resources.wallpaper;
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.CheckBoxes = true;
            this.listView.ContextMenuStrip = this.listItemMenu;
            this.listView.ForeColor = System.Drawing.Color.White;
            this.listView.HideSelection = false;
            this.listView.LabelEdit = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.ShowGroups = false;
            this.listView.Size = new System.Drawing.Size(785, 417);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // DesktopPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.listView);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DesktopPage";
            this.Size = new System.Drawing.Size(785, 460);
            this.Load += new System.EventHandler(this.CustomBorderForm_Load);
            this.Resize += new System.EventHandler(this.CustomBorderForm_ResizeEnd);
            this.listItemMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ContextMenuStrip listItemMenu;
        private System.Windows.Forms.ToolStripMenuItem listViewMenu_AddShortcut;
        private System.Windows.Forms.ToolStripMenuItem listViewMenu_AddLink;
        private System.Windows.Forms.Panel panel1;
    }
}
