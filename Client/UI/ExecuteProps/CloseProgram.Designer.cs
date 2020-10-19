namespace RCClient.UI.ExecuteProps {
    partial class CloseProgram {
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
            this.label1 = new System.Windows.Forms.Label();
            this.processNameInput = new System.Windows.Forms.TextBox();
            this.forceKillCheckbox = new System.Windows.Forms.CheckBox();
            this.timoutInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя процесса:";
            // 
            // processNameInput
            // 
            this.processNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processNameInput.Location = new System.Drawing.Point(6, 20);
            this.processNameInput.Name = "processNameInput";
            this.processNameInput.Size = new System.Drawing.Size(1577, 20);
            this.processNameInput.TabIndex = 1;
            this.processNameInput.TextChanged += new System.EventHandler(this.onProcessNameChanged);
            // 
            // forceKillCheckbox
            // 
            this.forceKillCheckbox.AutoSize = true;
            this.forceKillCheckbox.Checked = true;
            this.forceKillCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.forceKillCheckbox.Location = new System.Drawing.Point(6, 47);
            this.forceKillCheckbox.Name = "forceKillCheckbox";
            this.forceKillCheckbox.Size = new System.Drawing.Size(162, 17);
            this.forceKillCheckbox.TabIndex = 2;
            this.forceKillCheckbox.Text = "Принудительно завершить";
            this.forceKillCheckbox.UseVisualStyleBackColor = true;
            this.forceKillCheckbox.CheckedChanged += new System.EventHandler(this.onForceKillChanged);
            // 
            // timoutInput
            // 
            this.timoutInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timoutInput.Location = new System.Drawing.Point(6, 83);
            this.timoutInput.MaxLength = 5;
            this.timoutInput.Name = "timoutInput";
            this.timoutInput.Size = new System.Drawing.Size(1577, 20);
            this.timoutInput.TabIndex = 3;
            this.timoutInput.TextChanged += new System.EventHandler(this.onTimoutChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время ожидания (мс):";
            // 
            // CloseProgram
            // 
            this.Controls.Add(this.timoutInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.forceKillCheckbox);
            this.Controls.Add(this.processNameInput);
            this.Controls.Add(this.label1);
            this.Name = "CloseProgram";
            this.Size = new System.Drawing.Size(1586, 695);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox processNameInput;
        private System.Windows.Forms.CheckBox forceKillCheckbox;
        private System.Windows.Forms.TextBox timoutInput;
        private System.Windows.Forms.Label label2;
    }
}
