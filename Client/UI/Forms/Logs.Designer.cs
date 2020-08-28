namespace RCClient {
    partial class Logs {
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
            this.textarea = new System.Windows.Forms.TextBox();
            this.isMagneticCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textarea
            // 
            this.textarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textarea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textarea.Font = new System.Drawing.Font("Consolas", 10F);
            this.textarea.Location = new System.Drawing.Point(0, 0);
            this.textarea.Multiline = true;
            this.textarea.Name = "textarea";
            this.textarea.ReadOnly = true;
            this.textarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textarea.Size = new System.Drawing.Size(344, 461);
            this.textarea.TabIndex = 0;
            // 
            // isMagneticCheck
            // 
            this.isMagneticCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isMagneticCheck.AutoSize = true;
            this.isMagneticCheck.Checked = true;
            this.isMagneticCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isMagneticCheck.Location = new System.Drawing.Point(2, 446);
            this.isMagneticCheck.Name = "isMagneticCheck";
            this.isMagneticCheck.Size = new System.Drawing.Size(15, 14);
            this.isMagneticCheck.TabIndex = 1;
            this.isMagneticCheck.UseVisualStyleBackColor = true;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 461);
            this.Controls.Add(this.isMagneticCheck);
            this.Controls.Add(this.textarea);
            this.Name = "Logs";
            this.Text = "Логи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClose);
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textarea;
        private System.Windows.Forms.CheckBox isMagneticCheck;
    }
}