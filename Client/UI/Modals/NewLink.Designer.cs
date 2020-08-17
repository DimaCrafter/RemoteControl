namespace RCClient.UI.Modals {
    partial class NewLink {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.pathInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkIcon = new System.Windows.Forms.PictureBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.getInfoBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.linkIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pathInput
            // 
            this.pathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathInput.Location = new System.Drawing.Point(52, 29);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(313, 20);
            this.pathInput.TabIndex = 18;
            this.pathInput.TextChanged += new System.EventHandler(this.Validate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(50, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 26);
            this.label2.TabIndex = 17;
            this.label2.Text = "Вы также можете перетащить ссылку из браузера\r\nв данное окно, чтобы не указывать " +
    "адрес вручную";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "URL адрес:";
            // 
            // linkIcon
            // 
            this.linkIcon.Location = new System.Drawing.Point(10, 15);
            this.linkIcon.Name = "linkIcon";
            this.linkIcon.Size = new System.Drawing.Size(32, 32);
            this.linkIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.linkIcon.TabIndex = 15;
            this.linkIcon.TabStop = false;
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.Enabled = false;
            this.createBtn.Location = new System.Drawing.Point(290, 137);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 14;
            this.createBtn.Text = "Создать";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.SubmitForm);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(209, 137);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.Cancel);
            // 
            // nameInput
            // 
            this.nameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameInput.Location = new System.Drawing.Point(52, 106);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(174, 20);
            this.nameInput.TabIndex = 22;
            this.nameInput.TextChanged += new System.EventHandler(this.Validate);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Имя ссылки:";
            // 
            // getInfoBtn
            // 
            this.getInfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getInfoBtn.Enabled = false;
            this.getInfoBtn.Location = new System.Drawing.Point(232, 104);
            this.getInfoBtn.Name = "getInfoBtn";
            this.getInfoBtn.Size = new System.Drawing.Size(133, 23);
            this.getInfoBtn.TabIndex = 23;
            this.getInfoBtn.Text = "Получить информацию";
            this.getInfoBtn.UseVisualStyleBackColor = true;
            this.getInfoBtn.Click += new System.EventHandler(this.GetInfo);
            // 
            // NewLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 171);
            this.Controls.Add(this.getInfoBtn);
            this.Controls.Add(this.pathInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkIcon);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label4);
            this.Name = "NewLink";
            this.Text = "Создание ссылки";
            this.Load += new System.EventHandler(this.onLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.onDragEnd);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.onDragStart);
            ((System.ComponentModel.ISupportInitialize)(this.linkIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox linkIcon;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button getInfoBtn;
    }
}