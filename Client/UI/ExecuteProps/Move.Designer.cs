namespace RCClient.UI.ExecuteProps {
    partial class Move {
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openSrcFileBtn = new RCClient.UI.Components.ImgButton();
            this.srcInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.destInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openDestBtn = new RCClient.UI.Components.ImgButton();
            this.openSrcDirBtn = new RCClient.UI.Components.ImgButton();
            this.openDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // openSrcFileBtn
            // 
            this.openSrcFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSrcFileBtn.image = null;
            this.openSrcFileBtn.Location = new System.Drawing.Point(1540, 20);
            this.openSrcFileBtn.Name = "openSrcFileBtn";
            this.openSrcFileBtn.Size = new System.Drawing.Size(20, 20);
            this.openSrcFileBtn.TabIndex = 4;
            this.openSrcFileBtn.Click += new System.EventHandler(this.SelectSrcFile);
            // 
            // srcInput
            // 
            this.srcInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srcInput.Location = new System.Drawing.Point(6, 20);
            this.srcInput.Name = "srcInput";
            this.srcInput.Size = new System.Drawing.Size(1502, 20);
            this.srcInput.TabIndex = 1;
            this.srcInput.TextChanged += new System.EventHandler(this.onSrcChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Источник:";
            // 
            // destInput
            // 
            this.destInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destInput.Location = new System.Drawing.Point(6, 64);
            this.destInput.Name = "destInput";
            this.destInput.Size = new System.Drawing.Size(1528, 20);
            this.destInput.TabIndex = 12;
            this.destInput.TextChanged += new System.EventHandler(this.onDestChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Цель:";
            // 
            // openDestBtn
            // 
            this.openDestBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openDestBtn.image = null;
            this.openDestBtn.Location = new System.Drawing.Point(1540, 64);
            this.openDestBtn.Name = "openDestBtn";
            this.openDestBtn.Size = new System.Drawing.Size(20, 20);
            this.openDestBtn.TabIndex = 13;
            this.openDestBtn.Click += new System.EventHandler(this.SelectDestDir);
            // 
            // openSrcDirBtn
            // 
            this.openSrcDirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openSrcDirBtn.image = null;
            this.openSrcDirBtn.Location = new System.Drawing.Point(1514, 20);
            this.openSrcDirBtn.Name = "openSrcDirBtn";
            this.openSrcDirBtn.Size = new System.Drawing.Size(20, 20);
            this.openSrcDirBtn.TabIndex = 14;
            this.openSrcDirBtn.Click += new System.EventHandler(this.SelectSrcDir);
            // 
            // Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openSrcDirBtn);
            this.Controls.Add(this.openDestBtn);
            this.Controls.Add(this.destInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openSrcFileBtn);
            this.Controls.Add(this.srcInput);
            this.Controls.Add(this.label1);
            this.Name = "Move";
            this.Size = new System.Drawing.Size(1563, 612);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox srcInput;
        private Components.ImgButton openSrcFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox destInput;
        private System.Windows.Forms.Label label2;
        private Components.ImgButton openDestBtn;
        private Components.ImgButton openSrcDirBtn;
        private System.Windows.Forms.FolderBrowserDialog openDirectoryDialog;
    }
}
