namespace RCClient.UI.Forms {
    partial class AnyDeskForm {
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
            this.windowPanel = new System.Windows.Forms.Panel();
            this.statusImg = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.windowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).BeginInit();
            this.SuspendLayout();
            // 
            // windowPanel
            // 
            this.windowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.windowPanel.Controls.Add(this.button1);
            this.windowPanel.Controls.Add(this.statusImg);
            this.windowPanel.Controls.Add(this.statusLabel);
            this.windowPanel.Location = new System.Drawing.Point(0, 0);
            this.windowPanel.Name = "windowPanel";
            this.windowPanel.Size = new System.Drawing.Size(514, 331);
            this.windowPanel.TabIndex = 0;
            this.windowPanel.Resize += new System.EventHandler(this.onWindowResize);
            // 
            // statusImg
            // 
            this.statusImg.Image = global::RCClient.Properties.Resources.progress;
            this.statusImg.Location = new System.Drawing.Point(10, 10);
            this.statusImg.Name = "statusImg";
            this.statusImg.Size = new System.Drawing.Size(22, 22);
            this.statusImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.statusImg.TabIndex = 1;
            this.statusImg.TabStop = false;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.Location = new System.Drawing.Point(38, 10);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(63, 21);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "STATUS";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AnyDeskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 331);
            this.Controls.Add(this.windowPanel);
            this.Name = "AnyDeskForm";
            this.Text = "AnyDeskForm";
            this.windowPanel.ResumeLayout(false);
            this.windowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel windowPanel;
        private System.Windows.Forms.PictureBox statusImg;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button button1;
    }
}