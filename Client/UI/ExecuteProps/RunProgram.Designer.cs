namespace RCClient.UI.ExecuteProps {
    partial class RunProgram {
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
            this.wsMaximized = new System.Windows.Forms.RadioButton();
            this.wsMinimized = new System.Windows.Forms.RadioButton();
            this.wsHidden = new System.Windows.Forms.RadioButton();
            this.wsNormal = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileBtn = new RCClient.UI.Components.ImgButton();
            this.argsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.commandInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imgButton1 = new RCClient.UI.Components.ImgButton();
            this.waitCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // wsMaximized
            // 
            this.wsMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wsMaximized.AutoSize = true;
            this.wsMaximized.Location = new System.Drawing.Point(241, 575);
            this.wsMaximized.Name = "wsMaximized";
            this.wsMaximized.Size = new System.Drawing.Size(105, 17);
            this.wsMaximized.TabIndex = 9;
            this.wsMaximized.Tag = "Maximized";
            this.wsMaximized.Text = "Полноэкранное";
            this.wsMaximized.UseVisualStyleBackColor = true;
            this.wsMaximized.Click += new System.EventHandler(this.onWindowStateSelect);
            // 
            // wsMinimized
            // 
            this.wsMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wsMinimized.AutoSize = true;
            this.wsMinimized.Location = new System.Drawing.Point(157, 575);
            this.wsMinimized.Name = "wsMinimized";
            this.wsMinimized.Size = new System.Drawing.Size(78, 17);
            this.wsMinimized.TabIndex = 8;
            this.wsMinimized.Tag = "Minimized";
            this.wsMinimized.Text = "Свёрнутое";
            this.wsMinimized.UseVisualStyleBackColor = true;
            this.wsMinimized.Click += new System.EventHandler(this.onWindowStateSelect);
            // 
            // wsHidden
            // 
            this.wsHidden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wsHidden.AutoSize = true;
            this.wsHidden.Location = new System.Drawing.Point(82, 575);
            this.wsHidden.Name = "wsHidden";
            this.wsHidden.Size = new System.Drawing.Size(69, 17);
            this.wsHidden.TabIndex = 7;
            this.wsHidden.Tag = "Hidden";
            this.wsHidden.Text = "Скрытое";
            this.wsHidden.UseVisualStyleBackColor = true;
            this.wsHidden.Click += new System.EventHandler(this.onWindowStateSelect);
            // 
            // wsNormal
            // 
            this.wsNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.wsNormal.AutoSize = true;
            this.wsNormal.Location = new System.Drawing.Point(6, 575);
            this.wsNormal.Name = "wsNormal";
            this.wsNormal.Size = new System.Drawing.Size(70, 17);
            this.wsNormal.TabIndex = 6;
            this.wsNormal.Tag = "Normal";
            this.wsNormal.Text = "Обычное";
            this.wsNormal.UseVisualStyleBackColor = true;
            this.wsNormal.Click += new System.EventHandler(this.onWindowStateSelect);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Состояние окна:";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileBtn.image = null;
            this.openFileBtn.Location = new System.Drawing.Point(1540, 20);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(20, 20);
            this.openFileBtn.TabIndex = 4;
            this.openFileBtn.Click += new System.EventHandler(this.SelectFile);
            // 
            // argsBox
            // 
            this.argsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.argsBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.argsBox.FormattingEnabled = true;
            this.argsBox.IntegralHeight = false;
            this.argsBox.ItemHeight = 15;
            this.argsBox.Location = new System.Drawing.Point(6, 59);
            this.argsBox.Name = "argsBox";
            this.argsBox.Size = new System.Drawing.Size(1554, 458);
            this.argsBox.TabIndex = 3;
            this.argsBox.DoubleClick += new System.EventHandler(this.EditArgument);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Аргументы:";
            // 
            // commandInput
            // 
            this.commandInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandInput.Location = new System.Drawing.Point(6, 20);
            this.commandInput.Name = "commandInput";
            this.commandInput.Size = new System.Drawing.Size(1528, 20);
            this.commandInput.TabIndex = 1;
            this.commandInput.TextChanged += new System.EventHandler(this.commandInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Команда:";
            // 
            // imgButton1
            // 
            this.imgButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgButton1.BackColor = System.Drawing.SystemColors.Window;
            this.imgButton1.image = global::RCClient.Properties.Resources.close;
            this.imgButton1.Location = new System.Drawing.Point(1538, 495);
            this.imgButton1.Name = "imgButton1";
            this.imgButton1.Size = new System.Drawing.Size(20, 20);
            this.imgButton1.TabIndex = 10;
            this.imgButton1.Click += new System.EventHandler(this.RemoveArgument);
            // 
            // waitCheck
            // 
            this.waitCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.waitCheck.AutoSize = true;
            this.waitCheck.Location = new System.Drawing.Point(6, 539);
            this.waitCheck.Name = "waitCheck";
            this.waitCheck.Size = new System.Drawing.Size(149, 17);
            this.waitCheck.TabIndex = 11;
            this.waitCheck.Text = "Дождаться выполнения";
            this.waitCheck.UseVisualStyleBackColor = true;
            this.waitCheck.CheckedChanged += new System.EventHandler(this.waitCheck_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 523);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Доп. параметры:";
            // 
            // RunProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.waitCheck);
            this.Controls.Add(this.imgButton1);
            this.Controls.Add(this.wsMaximized);
            this.Controls.Add(this.wsMinimized);
            this.Controls.Add(this.wsHidden);
            this.Controls.Add(this.wsNormal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.argsBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandInput);
            this.Controls.Add(this.label1);
            this.Name = "RunProgram";
            this.Size = new System.Drawing.Size(1563, 612);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox commandInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox argsBox;
        private Components.ImgButton openFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton wsNormal;
        private System.Windows.Forms.RadioButton wsHidden;
        private System.Windows.Forms.RadioButton wsMinimized;
        private System.Windows.Forms.RadioButton wsMaximized;
        private Components.ImgButton imgButton1;
        private System.Windows.Forms.CheckBox waitCheck;
        private System.Windows.Forms.Label label4;
    }
}
