namespace RCClient.UI.Pages {
    partial class ObserverPage {
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupList = new System.Windows.Forms.ListBox();
            this.sizeSlider = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.devicesView = new RCClient.UI.Components.ObserverView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "В этом разделе Вы можете наблюдать сразу несколько устройств, объединённых один ш" +
    "аблоном.";
            // 
            // groupList
            // 
            this.groupList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupList.FormattingEnabled = true;
            this.groupList.IntegralHeight = false;
            this.groupList.Location = new System.Drawing.Point(7, 64);
            this.groupList.Name = "groupList";
            this.groupList.Size = new System.Drawing.Size(179, 300);
            this.groupList.TabIndex = 2;
            this.groupList.SelectedIndexChanged += new System.EventHandler(this.onGroupSelect);
            // 
            // sizeSlider
            // 
            this.sizeSlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sizeSlider.AutoSize = false;
            this.sizeSlider.LargeChange = 1;
            this.sizeSlider.Location = new System.Drawing.Point(7, 391);
            this.sizeSlider.Maximum = 512;
            this.sizeSlider.Minimum = 64;
            this.sizeSlider.Name = "sizeSlider";
            this.sizeSlider.Size = new System.Drawing.Size(179, 26);
            this.sizeSlider.TabIndex = 3;
            this.sizeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sizeSlider.Value = 150;
            this.sizeSlider.Scroll += new System.EventHandler(this.onSizeChange);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Размер изображений:";
            // 
            // devicesView
            // 
            this.devicesView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesView.BackColor = System.Drawing.SystemColors.Control;
            this.devicesView.Location = new System.Drawing.Point(192, 3);
            this.devicesView.Name = "devicesView";
            this.devicesView.Size = new System.Drawing.Size(595, 413);
            this.devicesView.TabIndex = 5;
            // 
            // ObserverPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.devicesView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeSlider);
            this.Controls.Add(this.groupList);
            this.Controls.Add(this.label1);
            this.Name = "ObserverPage";
            this.Size = new System.Drawing.Size(790, 420);
            ((System.ComponentModel.ISupportInitialize)(this.sizeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox groupList;
        private System.Windows.Forms.TrackBar sizeSlider;
        private System.Windows.Forms.Label label2;
        private Components.ObserverView devicesView;
    }
}
