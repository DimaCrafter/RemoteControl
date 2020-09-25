namespace RCServer {
    partial class MainForm {
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
            this.installBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.logsList = new System.Windows.Forms.ComboBox();
            this.removeLogBtn = new System.Windows.Forms.Button();
            this.logsTextarea = new System.Windows.Forms.RichTextBox();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(12, 12);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(151, 23);
            this.installBtn.TabIndex = 0;
            this.installBtn.Text = "Установить";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.InstallService);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(12, 99);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(151, 23);
            this.removeBtn.TabIndex = 1;
            this.removeBtn.Text = "Удалить задачу";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.RemoveTask);
            // 
            // logsList
            // 
            this.logsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsList.FormattingEnabled = true;
            this.logsList.ItemHeight = 13;
            this.logsList.Location = new System.Drawing.Point(169, 13);
            this.logsList.Name = "logsList";
            this.logsList.Size = new System.Drawing.Size(338, 21);
            this.logsList.TabIndex = 2;
            this.logsList.SelectedIndexChanged += new System.EventHandler(this.onLogSelected);
            // 
            // removeLogBtn
            // 
            this.removeLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLogBtn.Location = new System.Drawing.Point(513, 12);
            this.removeLogBtn.Name = "removeLogBtn";
            this.removeLogBtn.Size = new System.Drawing.Size(59, 23);
            this.removeLogBtn.TabIndex = 3;
            this.removeLogBtn.Text = "Удалить";
            this.removeLogBtn.UseVisualStyleBackColor = true;
            this.removeLogBtn.Click += new System.EventHandler(this.RemoveLog);
            // 
            // logsTextarea
            // 
            this.logsTextarea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsTextarea.BackColor = System.Drawing.SystemColors.Window;
            this.logsTextarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logsTextarea.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logsTextarea.ForeColor = System.Drawing.Color.Black;
            this.logsTextarea.Location = new System.Drawing.Point(169, 41);
            this.logsTextarea.Name = "logsTextarea";
            this.logsTextarea.ReadOnly = true;
            this.logsTextarea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.logsTextarea.Size = new System.Drawing.Size(403, 308);
            this.logsTextarea.TabIndex = 4;
            this.logsTextarea.Text = "";
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(12, 70);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(151, 23);
            this.stopBtn.TabIndex = 6;
            this.stopBtn.Text = "Остановить";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopService);
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(12, 41);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(151, 23);
            this.startBtn.TabIndex = 5;
            this.startBtn.Text = "Запустить";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartService);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Открыть директорию установки в проводнике";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenInExplorer);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.logsTextarea);
            this.Controls.Add(this.removeLogBtn);
            this.Controls.Add(this.logsList);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.installBtn);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Управление сервером";
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ComboBox logsList;
        private System.Windows.Forms.Button removeLogBtn;
        private System.Windows.Forms.RichTextBox logsTextarea;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button button1;
    }
}