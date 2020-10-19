namespace RCClient.UI.ExecuteProps {
    partial class Remove {
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
            this.pathInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // pathInput
            // 
            this.pathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathInput.Location = new System.Drawing.Point(6, 20);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(1502, 20);
            this.pathInput.TabIndex = 1;
            this.pathInput.TextChanged += new System.EventHandler(this.onSrcChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь:";
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
            // Remove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openSrcDirBtn);
            this.Controls.Add(this.openSrcFileBtn);
            this.Controls.Add(this.pathInput);
            this.Controls.Add(this.label1);
            this.Name = "Remove";
            this.Size = new System.Drawing.Size(1563, 612);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathInput;
        private Components.ImgButton openSrcFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Components.ImgButton openSrcDirBtn;
        private System.Windows.Forms.FolderBrowserDialog openDirectoryDialog;
    }
}
