namespace RCClient.UI.Forms {
    partial class ScriptForm {
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
            this.scriptList = new System.Windows.Forms.ListBox();
            this.stepsList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.stepTypeBox = new System.Windows.Forms.ComboBox();
            this.propsPanel = new System.Windows.Forms.Panel();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.stepDownBtn = new RCClient.UI.Components.ImgButton();
            this.stepUpBtn = new RCClient.UI.Components.ImgButton();
            this.renameScriptBtn = new RCClient.UI.Components.ImgButton();
            this.removeStepBtn = new RCClient.UI.Components.ImgButton();
            this.removeScriptBtn = new RCClient.UI.Components.ImgButton();
            this.addStepBtn = new RCClient.UI.Components.ImgButton();
            this.createScriptBtn = new RCClient.UI.Components.ImgButton();
            this.importBtn = new RCClient.UI.Components.ImgButton();
            this.exportBtn = new RCClient.UI.Components.ImgButton();
            this.SuspendLayout();
            // 
            // scriptList
            // 
            this.scriptList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scriptList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scriptList.FormattingEnabled = true;
            this.scriptList.IntegralHeight = false;
            this.scriptList.ItemHeight = 16;
            this.scriptList.Location = new System.Drawing.Point(12, 25);
            this.scriptList.Name = "scriptList";
            this.scriptList.Size = new System.Drawing.Size(183, 381);
            this.scriptList.TabIndex = 0;
            this.scriptList.SelectedIndexChanged += new System.EventHandler(this.onScriptSelect);
            // 
            // stepsList
            // 
            this.stepsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.stepsList.AutoArrange = false;
            this.stepsList.CausesValidation = false;
            this.stepsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepsList.HideSelection = false;
            this.stepsList.Location = new System.Drawing.Point(201, 25);
            this.stepsList.MultiSelect = false;
            this.stepsList.Name = "stepsList";
            this.stepsList.ShowGroups = false;
            this.stepsList.Size = new System.Drawing.Size(214, 381);
            this.stepsList.TabIndex = 1;
            this.stepsList.UseCompatibleStateImageBehavior = false;
            this.stepsList.View = System.Windows.Forms.View.List;
            this.stepsList.SelectedIndexChanged += new System.EventHandler(this.onStepSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Список сценариев:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Шаги сценария:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Параметры текущего шага:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Действие:";
            // 
            // stepTypeBox
            // 
            this.stepTypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stepTypeBox.FormattingEnabled = true;
            this.stepTypeBox.Location = new System.Drawing.Point(427, 49);
            this.stepTypeBox.Name = "stepTypeBox";
            this.stepTypeBox.Size = new System.Drawing.Size(381, 21);
            this.stepTypeBox.TabIndex = 6;
            this.stepTypeBox.SelectedIndexChanged += new System.EventHandler(this.onStepTypeChanged);
            // 
            // propsPanel
            // 
            this.propsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propsPanel.Location = new System.Drawing.Point(421, 74);
            this.propsPanel.Name = "propsPanel";
            this.propsPanel.Size = new System.Drawing.Size(390, 358);
            this.propsPanel.TabIndex = 7;
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "rcs";
            this.saveDialog.Filter = "RemoteControl Script|*.rcs|Все файлы|*.*";
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "rcs";
            this.openDialog.Filter = "RemoteControl Script|*.rcs|Все файлы|*.*";
            // 
            // stepDownBtn
            // 
            this.stepDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stepDownBtn.image = global::RCClient.Properties.Resources.moveDown;
            this.stepDownBtn.Location = new System.Drawing.Point(395, 412);
            this.stepDownBtn.Name = "stepDownBtn";
            this.stepDownBtn.Size = new System.Drawing.Size(20, 20);
            this.stepDownBtn.TabIndex = 14;
            this.stepDownBtn.Click += new System.EventHandler(this.StepDown);
            // 
            // stepUpBtn
            // 
            this.stepUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.stepUpBtn.image = global::RCClient.Properties.Resources.moveUp;
            this.stepUpBtn.Location = new System.Drawing.Point(370, 412);
            this.stepUpBtn.Name = "stepUpBtn";
            this.stepUpBtn.Size = new System.Drawing.Size(20, 20);
            this.stepUpBtn.TabIndex = 13;
            this.stepUpBtn.Click += new System.EventHandler(this.StepUp);
            // 
            // renameScriptBtn
            // 
            this.renameScriptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renameScriptBtn.image = global::RCClient.Properties.Resources.editInput;
            this.renameScriptBtn.Location = new System.Drawing.Point(62, 412);
            this.renameScriptBtn.Name = "renameScriptBtn";
            this.renameScriptBtn.Size = new System.Drawing.Size(20, 20);
            this.renameScriptBtn.TabIndex = 12;
            this.renameScriptBtn.Click += new System.EventHandler(this.RenameScript);
            // 
            // removeStepBtn
            // 
            this.removeStepBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeStepBtn.image = global::RCClient.Properties.Resources.close;
            this.removeStepBtn.Location = new System.Drawing.Point(226, 412);
            this.removeStepBtn.Name = "removeStepBtn";
            this.removeStepBtn.Size = new System.Drawing.Size(20, 20);
            this.removeStepBtn.TabIndex = 11;
            this.removeStepBtn.Click += new System.EventHandler(this.removeStepBtn_Click);
            // 
            // removeScriptBtn
            // 
            this.removeScriptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeScriptBtn.image = global::RCClient.Properties.Resources.close;
            this.removeScriptBtn.Location = new System.Drawing.Point(37, 412);
            this.removeScriptBtn.Name = "removeScriptBtn";
            this.removeScriptBtn.Size = new System.Drawing.Size(20, 20);
            this.removeScriptBtn.TabIndex = 10;
            this.removeScriptBtn.Click += new System.EventHandler(this.RemoveScript);
            // 
            // addStepBtn
            // 
            this.addStepBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addStepBtn.image = global::RCClient.Properties.Resources.add;
            this.addStepBtn.Location = new System.Drawing.Point(201, 412);
            this.addStepBtn.Name = "addStepBtn";
            this.addStepBtn.Size = new System.Drawing.Size(20, 20);
            this.addStepBtn.TabIndex = 9;
            this.addStepBtn.Click += new System.EventHandler(this.AddStep);
            // 
            // createScriptBtn
            // 
            this.createScriptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createScriptBtn.image = global::RCClient.Properties.Resources.add;
            this.createScriptBtn.Location = new System.Drawing.Point(12, 412);
            this.createScriptBtn.Name = "createScriptBtn";
            this.createScriptBtn.Size = new System.Drawing.Size(20, 20);
            this.createScriptBtn.TabIndex = 8;
            this.createScriptBtn.Click += new System.EventHandler(this.CreateScript);
            // 
            // importBtn
            // 
            this.importBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importBtn.image = global::RCClient.Properties.Resources.import;
            this.importBtn.Location = new System.Drawing.Point(175, 412);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(20, 20);
            this.importBtn.TabIndex = 15;
            this.importBtn.Click += new System.EventHandler(this.Import);
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportBtn.image = global::RCClient.Properties.Resources.export;
            this.exportBtn.Location = new System.Drawing.Point(150, 412);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(20, 20);
            this.exportBtn.TabIndex = 16;
            this.exportBtn.Click += new System.EventHandler(this.Export);
            // 
            // ScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 441);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.stepDownBtn);
            this.Controls.Add(this.stepUpBtn);
            this.Controls.Add(this.renameScriptBtn);
            this.Controls.Add(this.removeStepBtn);
            this.Controls.Add(this.removeScriptBtn);
            this.Controls.Add(this.addStepBtn);
            this.Controls.Add(this.createScriptBtn);
            this.Controls.Add(this.propsPanel);
            this.Controls.Add(this.stepTypeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stepsList);
            this.Controls.Add(this.scriptList);
            this.Name = "ScriptForm";
            this.Text = "Управление сценариями";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScriptForm_FormClosing);
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox scriptList;
        private System.Windows.Forms.ListView stepsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox stepTypeBox;
        private System.Windows.Forms.Panel propsPanel;
        private Components.ImgButton createScriptBtn;
        private Components.ImgButton addStepBtn;
        private Components.ImgButton removeScriptBtn;
        private Components.ImgButton removeStepBtn;
        private Components.ImgButton renameScriptBtn;
        private Components.ImgButton stepUpBtn;
        private Components.ImgButton stepDownBtn;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private Components.ImgButton importBtn;
        private Components.ImgButton exportBtn;
    }
}