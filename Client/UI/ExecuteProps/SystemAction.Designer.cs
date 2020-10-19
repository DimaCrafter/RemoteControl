namespace RCClient.UI.ExecuteProps {
    partial class SystemAction {
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
            this.actionSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Действие:";
            // 
            // actionSelect
            // 
            this.actionSelect.FormattingEnabled = true;
            this.actionSelect.Items.AddRange(new object[] {
            "Завершение работы",
            "Перезагрузка",
            "Спящий режим"});
            this.actionSelect.Location = new System.Drawing.Point(6, 20);
            this.actionSelect.Name = "actionSelect";
            this.actionSelect.Size = new System.Drawing.Size(1564, 21);
            this.actionSelect.TabIndex = 3;
            // 
            // SystemAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionSelect);
            this.Controls.Add(this.label1);
            this.Name = "SystemAction";
            this.Size = new System.Drawing.Size(1563, 695);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox actionSelect;
    }
}
