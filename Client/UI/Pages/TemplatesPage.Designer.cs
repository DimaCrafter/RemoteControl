namespace RCClient.UI.Pages {
    partial class TemplatesPage {
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
            this.groupsBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgButton3 = new RCClient.UI.Components.ImgButton();
            this.imgButton2 = new RCClient.UI.Components.ImgButton();
            this.imgButton1 = new RCClient.UI.Components.ImgButton();
            this.nameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // groupsBox
            // 
            this.groupsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsBox.FormattingEnabled = true;
            this.groupsBox.IntegralHeight = false;
            this.groupsBox.Location = new System.Drawing.Point(5, 21);
            this.groupsBox.Margin = new System.Windows.Forms.Padding(5);
            this.groupsBox.Name = "groupsBox";
            this.groupsBox.Size = new System.Drawing.Size(162, 495);
            this.groupsBox.TabIndex = 0;
            this.groupsBox.SelectedIndexChanged += new System.EventHandler(this.onSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Группы устройств:";
            // 
            // imgButton3
            // 
            this.imgButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgButton3.Enabled = false;
            this.imgButton3.image = global::RCClient.Properties.Resources.editInput;
            this.imgButton3.Location = new System.Drawing.Point(55, 518);
            this.imgButton3.Name = "imgButton3";
            this.imgButton3.Size = new System.Drawing.Size(20, 20);
            this.imgButton3.TabIndex = 4;
            // 
            // imgButton2
            // 
            this.imgButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgButton2.Enabled = false;
            this.imgButton2.image = global::RCClient.Properties.Resources.close;
            this.imgButton2.Location = new System.Drawing.Point(30, 518);
            this.imgButton2.Name = "imgButton2";
            this.imgButton2.Size = new System.Drawing.Size(20, 20);
            this.imgButton2.TabIndex = 3;
            // 
            // imgButton1
            // 
            this.imgButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgButton1.image = global::RCClient.Properties.Resources.add;
            this.imgButton1.Location = new System.Drawing.Point(5, 518);
            this.imgButton1.Name = "imgButton1";
            this.imgButton1.Size = new System.Drawing.Size(20, 20);
            this.imgButton1.TabIndex = 2;
            this.imgButton1.Click += new System.EventHandler(this.imgButton1_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(175, 3);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(192, 24);
            this.nameLabel.TabIndex = 25;
            this.nameLabel.Text = "Шаблон не выбран";
            // 
            // TemplatesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.imgButton3);
            this.Controls.Add(this.imgButton2);
            this.Controls.Add(this.imgButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupsBox);
            this.Name = "TemplatesPage";
            this.Size = new System.Drawing.Size(785, 542);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox groupsBox;
        private System.Windows.Forms.Label label1;
        private Components.ImgButton imgButton1;
        private Components.ImgButton imgButton2;
        private Components.ImgButton imgButton3;
        private System.Windows.Forms.Label nameLabel;
    }
}
