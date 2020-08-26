namespace RCClient.UI.Modals {
    partial class NewShortcut {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewShortcut));
            this.cancelBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pathInput = new System.Windows.Forms.TextBox();
            this.copyCheckbox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileIcon = new System.Windows.Forms.PictureBox();
            this.openFileBtn = new RCClient.UI.Components.ImgButton();
            this.openFolderBtn = new RCClient.UI.Components.ImgButton();
            ((System.ComponentModel.ISupportInitialize)(this.fileIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(211, 211);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.Cancel);
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createBtn.Enabled = false;
            this.createBtn.Location = new System.Drawing.Point(292, 211);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(75, 23);
            this.createBtn.TabIndex = 1;
            this.createBtn.Text = "Создать";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.Submit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Путь к файлу или директории:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(52, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вы также можете перетащить нужный файл или директорию\r\nв данное окно, чтобы не ук" +
    "азывать путь вручную";
            // 
            // pathInput
            // 
            this.pathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathInput.Location = new System.Drawing.Point(54, 28);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(272, 20);
            this.pathInput.TabIndex = 6;
            this.pathInput.TextChanged += new System.EventHandler(this.ValidateForm);
            // 
            // copyCheckbox
            // 
            this.copyCheckbox.AutoSize = true;
            this.copyCheckbox.Location = new System.Drawing.Point(55, 91);
            this.copyCheckbox.Name = "copyCheckbox";
            this.copyCheckbox.Size = new System.Drawing.Size(167, 17);
            this.copyCheckbox.TabIndex = 7;
            this.copyCheckbox.Text = "Скопировать на устройства";
            this.copyCheckbox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(52, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "Есть поставлена галочка, то указанный выше файл\r\nили директория будут скопированы" +
    " на все удалённые\r\nустройства с данным шаблоном";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // nameInput
            // 
            this.nameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameInput.Location = new System.Drawing.Point(54, 178);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(313, 20);
            this.nameInput.TabIndex = 10;
            this.nameInput.TextChanged += new System.EventHandler(this.ValidateForm);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Имя ярлыка:";
            // 
            // fileIcon
            // 
            this.fileIcon.Location = new System.Drawing.Point(12, 14);
            this.fileIcon.Name = "fileIcon";
            this.fileIcon.Size = new System.Drawing.Size(32, 32);
            this.fileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fileIcon.TabIndex = 2;
            this.fileIcon.TabStop = false;
            // 
            // openFileBtn
            // 
            this.openFileBtn.image = ((System.Drawing.Image)(resources.GetObject("openFileBtn.image")));
            this.openFileBtn.Location = new System.Drawing.Point(332, 28);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(16, 20);
            this.openFileBtn.TabIndex = 13;
            this.openFileBtn.Click += new System.EventHandler(this.OpenFile);
            // 
            // openFolderBtn
            // 
            this.openFolderBtn.image = ((System.Drawing.Image)(resources.GetObject("openFolderBtn.image")));
            this.openFolderBtn.Location = new System.Drawing.Point(354, 27);
            this.openFolderBtn.Name = "openFolderBtn";
            this.openFolderBtn.Size = new System.Drawing.Size(16, 20);
            this.openFolderBtn.TabIndex = 14;
            this.openFolderBtn.Click += new System.EventHandler(this.OpenFolder);
            // 
            // NewShortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 246);
            this.Controls.Add(this.openFolderBtn);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.copyCheckbox);
            this.Controls.Add(this.pathInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileIcon);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "NewShortcut";
            this.Text = "Создание ярлыка";
            this.Load += new System.EventHandler(this.onLoad);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.onDragEnd);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.onDragStart);
            ((System.ComponentModel.ISupportInitialize)(this.fileIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.PictureBox fileIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathInput;
        private System.Windows.Forms.CheckBox copyCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog openFolderDialog;
        private Components.ImgButton openFileBtn;
        private Components.ImgButton openFolderBtn;
    }
}