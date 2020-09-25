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
            this.nameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.devicesList = new System.Windows.Forms.ListBox();
            this.deviceCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.renameBtn = new RCClient.UI.Components.ImgButton();
            this.removeBtn = new RCClient.UI.Components.ImgButton();
            this.addBtn = new RCClient.UI.Components.ImgButton();
            this.SuspendLayout();
            // 
            // groupsBox
            // 
            this.groupsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsBox.FormattingEnabled = true;
            this.groupsBox.IntegralHeight = false;
            this.groupsBox.Location = new System.Drawing.Point(5, 5);
            this.groupsBox.Margin = new System.Windows.Forms.Padding(5);
            this.groupsBox.Name = "groupsBox";
            this.groupsBox.Size = new System.Drawing.Size(162, 389);
            this.groupsBox.TabIndex = 0;
            this.groupsBox.Click += new System.EventHandler(this.groupsBox_Click);
            this.groupsBox.SelectedIndexChanged += new System.EventHandler(this.onSelect);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(175, 5);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(192, 24);
            this.nameLabel.TabIndex = 25;
            this.nameLabel.Text = "Шаблон не выбран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Устройства:";
            // 
            // devicesList
            // 
            this.devicesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.devicesList.IntegralHeight = false;
            this.devicesList.Location = new System.Drawing.Point(179, 55);
            this.devicesList.Name = "devicesList";
            this.devicesList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.devicesList.Size = new System.Drawing.Size(169, 339);
            this.devicesList.TabIndex = 27;
            // 
            // deviceCountLabel
            // 
            this.deviceCountLabel.Location = new System.Drawing.Point(321, 39);
            this.deviceCountLabel.Name = "deviceCountLabel";
            this.deviceCountLabel.Size = new System.Drawing.Size(27, 13);
            this.deviceCountLabel.TabIndex = 30;
            this.deviceCountLabel.Text = "0";
            this.deviceCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Доп. параметры:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(359, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 17);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Синхронизировать время";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // renameBtn
            // 
            this.renameBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renameBtn.Enabled = false;
            this.renameBtn.image = global::RCClient.Properties.Resources.editInput;
            this.renameBtn.Location = new System.Drawing.Point(55, 396);
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(20, 20);
            this.renameBtn.TabIndex = 4;
            this.renameBtn.Click += new System.EventHandler(this.RenameTemplate);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeBtn.Enabled = false;
            this.removeBtn.image = global::RCClient.Properties.Resources.close;
            this.removeBtn.Location = new System.Drawing.Point(30, 396);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(20, 20);
            this.removeBtn.TabIndex = 3;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addBtn.image = global::RCClient.Properties.Resources.add;
            this.addBtn.Location = new System.Drawing.Point(5, 396);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(20, 20);
            this.addBtn.TabIndex = 2;
            this.addBtn.Click += new System.EventHandler(this.AddTemplate);
            // 
            // TemplatesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceCountLabel);
            this.Controls.Add(this.devicesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.renameBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.groupsBox);
            this.Name = "TemplatesPage";
            this.Size = new System.Drawing.Size(765, 420);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox groupsBox;
        private Components.ImgButton addBtn;
        private Components.ImgButton removeBtn;
        private Components.ImgButton renameBtn;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox devicesList;
        private System.Windows.Forms.Label deviceCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
