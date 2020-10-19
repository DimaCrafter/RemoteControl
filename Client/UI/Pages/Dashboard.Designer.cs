namespace RCClient.UI.Pages {
    partial class Dashboard {
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
            this.deviceRAMLabel = new System.Windows.Forms.Label();
            this.discoverBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logsBtn = new System.Windows.Forms.Button();
            this.deviceVideoLabel = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.deviceIPLabel = new System.Windows.Forms.Label();
            this.deviceCPULabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.deviceOSLabel = new System.Windows.Forms.Label();
            this.deviceView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.templatesBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.groupSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveDevicesBtn = new System.Windows.Forms.Button();
            this.syncBtn = new System.Windows.Forms.Button();
            this.executeBtn = new System.Windows.Forms.Button();
            this.openScriptsBtn = new System.Windows.Forms.Button();
            this.statusImg = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imgButton1 = new RCClient.UI.Components.ImgButton();
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceRAMLabel
            // 
            this.deviceRAMLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceRAMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceRAMLabel.Location = new System.Drawing.Point(2, 260);
            this.deviceRAMLabel.Name = "deviceRAMLabel";
            this.deviceRAMLabel.Size = new System.Drawing.Size(232, 18);
            this.deviceRAMLabel.TabIndex = 37;
            this.deviceRAMLabel.Text = "8 Гб";
            // 
            // discoverBtn
            // 
            this.discoverBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.discoverBtn.Location = new System.Drawing.Point(6, 5);
            this.discoverBtn.Name = "discoverBtn";
            this.discoverBtn.Size = new System.Drawing.Size(165, 24);
            this.discoverBtn.TabIndex = 21;
            this.discoverBtn.Text = "Поиск устройств";
            this.discoverBtn.UseVisualStyleBackColor = true;
            this.discoverBtn.Click += new System.EventHandler(this.DiscoverDevices);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "ОЗУ:";
            // 
            // logsBtn
            // 
            this.logsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logsBtn.Location = new System.Drawing.Point(6, 80);
            this.logsBtn.Name = "logsBtn";
            this.logsBtn.Size = new System.Drawing.Size(165, 24);
            this.logsBtn.TabIndex = 22;
            this.logsBtn.Text = "Показать логи";
            this.logsBtn.UseVisualStyleBackColor = true;
            this.logsBtn.Click += new System.EventHandler(this.OpenLogs);
            // 
            // deviceVideoLabel
            // 
            this.deviceVideoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceVideoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceVideoLabel.Location = new System.Drawing.Point(2, 198);
            this.deviceVideoLabel.Name = "deviceVideoLabel";
            this.deviceVideoLabel.Size = new System.Drawing.Size(232, 38);
            this.deviceVideoLabel.TabIndex = 35;
            this.deviceVideoLabel.Text = "Nvidia GT 250 GMS Eco\r\n800x600 32bbp";
            // 
            // connectBtn
            // 
            this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectBtn.Location = new System.Drawing.Point(5, 393);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(229, 23);
            this.connectBtn.TabIndex = 23;
            this.connectBtn.Text = "Подключиться";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Видеокарта:";
            // 
            // deviceIPLabel
            // 
            this.deviceIPLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceIPLabel.AutoSize = true;
            this.deviceIPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceIPLabel.Location = new System.Drawing.Point(1, 5);
            this.deviceIPLabel.Name = "deviceIPLabel";
            this.deviceIPLabel.Size = new System.Drawing.Size(138, 24);
            this.deviceIPLabel.TabIndex = 24;
            this.deviceIPLabel.Text = "192.168.0.104";
            // 
            // deviceCPULabel
            // 
            this.deviceCPULabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceCPULabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceCPULabel.Location = new System.Drawing.Point(2, 136);
            this.deviceCPULabel.Name = "deviceCPULabel";
            this.deviceCPULabel.Size = new System.Drawing.Size(232, 38);
            this.deviceCPULabel.TabIndex = 33;
            this.deviceCPULabel.Text = "Intel Pentium Core 2 Duo\r\n1 ____ x 2 core";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Имя компьютера:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Процессор:";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceNameLabel.Location = new System.Drawing.Point(2, 53);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(232, 18);
            this.deviceNameLabel.TabIndex = 26;
            this.deviceNameLabel.Text = "Обычной имя";
            // 
            // deviceOSLabel
            // 
            this.deviceOSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceOSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceOSLabel.Location = new System.Drawing.Point(2, 95);
            this.deviceOSLabel.Name = "deviceOSLabel";
            this.deviceOSLabel.Size = new System.Drawing.Size(232, 18);
            this.deviceOSLabel.TabIndex = 31;
            this.deviceOSLabel.Text = "Windows 7 Home Basic x86";
            // 
            // deviceView
            // 
            this.deviceView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.deviceView.HideSelection = false;
            this.deviceView.Location = new System.Drawing.Point(177, 5);
            this.deviceView.Name = "deviceView";
            this.deviceView.Size = new System.Drawing.Size(363, 411);
            this.deviceView.TabIndex = 27;
            this.deviceView.UseCompatibleStateImageBehavior = false;
            this.deviceView.View = System.Windows.Forms.View.Tile;
            this.deviceView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.onSelectDevice);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Имя";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Операционная система:";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(24, 401);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 29;
            this.statusLabel.Text = "Статус";
            // 
            // templatesBtn
            // 
            this.templatesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.templatesBtn.Location = new System.Drawing.Point(6, 109);
            this.templatesBtn.Name = "templatesBtn";
            this.templatesBtn.Size = new System.Drawing.Size(165, 24);
            this.templatesBtn.TabIndex = 38;
            this.templatesBtn.Text = "Шаблоны";
            this.templatesBtn.UseVisualStyleBackColor = true;
            this.templatesBtn.Click += new System.EventHandler(this.OpenTemplates);
            // 
            // settingsBtn
            // 
            this.settingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.Location = new System.Drawing.Point(6, 136);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(165, 24);
            this.settingsBtn.TabIndex = 39;
            this.settingsBtn.Text = "Параметры";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.OpenSettings);
            // 
            // groupSelect
            // 
            this.groupSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupSelect.FormattingEnabled = true;
            this.groupSelect.Location = new System.Drawing.Point(5, 304);
            this.groupSelect.Name = "groupSelect";
            this.groupSelect.Size = new System.Drawing.Size(229, 21);
            this.groupSelect.TabIndex = 40;
            this.groupSelect.SelectedIndexChanged += new System.EventHandler(this.onGroupChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Шаблон:";
            // 
            // saveDevicesBtn
            // 
            this.saveDevicesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveDevicesBtn.Location = new System.Drawing.Point(6, 34);
            this.saveDevicesBtn.Name = "saveDevicesBtn";
            this.saveDevicesBtn.Size = new System.Drawing.Size(165, 24);
            this.saveDevicesBtn.TabIndex = 43;
            this.saveDevicesBtn.Text = "Сохранить устройства";
            this.saveDevicesBtn.UseVisualStyleBackColor = true;
            this.saveDevicesBtn.Click += new System.EventHandler(this.SaveDevices);
            // 
            // syncBtn
            // 
            this.syncBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.syncBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.syncBtn.Location = new System.Drawing.Point(5, 364);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(229, 23);
            this.syncBtn.TabIndex = 44;
            this.syncBtn.Text = "Синхронизировать";
            this.syncBtn.UseVisualStyleBackColor = true;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click);
            // 
            // executeBtn
            // 
            this.executeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.executeBtn.Location = new System.Drawing.Point(5, 335);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(229, 23);
            this.executeBtn.TabIndex = 45;
            this.executeBtn.Text = "Выполнить";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.OpenExecute);
            // 
            // openScriptsBtn
            // 
            this.openScriptsBtn.Image = global::RCClient.Properties.Resources.script;
            this.openScriptsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.openScriptsBtn.Location = new System.Drawing.Point(6, 165);
            this.openScriptsBtn.Name = "openScriptsBtn";
            this.openScriptsBtn.Size = new System.Drawing.Size(165, 24);
            this.openScriptsBtn.TabIndex = 46;
            this.openScriptsBtn.Text = "Сценарии";
            this.openScriptsBtn.UseVisualStyleBackColor = true;
            this.openScriptsBtn.Click += new System.EventHandler(this.OpenScripts);
            // 
            // statusImg
            // 
            this.statusImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusImg.Location = new System.Drawing.Point(4, 400);
            this.statusImg.Name = "statusImg";
            this.statusImg.Size = new System.Drawing.Size(16, 16);
            this.statusImg.TabIndex = 28;
            this.statusImg.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.discoverBtn);
            this.splitContainer1.Panel1.Controls.Add(this.saveDevicesBtn);
            this.splitContainer1.Panel1.Controls.Add(this.logsBtn);
            this.splitContainer1.Panel1.Controls.Add(this.templatesBtn);
            this.splitContainer1.Panel1.Controls.Add(this.settingsBtn);
            this.splitContainer1.Panel1.Controls.Add(this.openScriptsBtn);
            this.splitContainer1.Panel1.Controls.Add(this.imgButton1);
            this.splitContainer1.Panel1.Controls.Add(this.deviceView);
            this.splitContainer1.Panel1.Controls.Add(this.statusImg);
            this.splitContainer1.Panel1.Controls.Add(this.statusLabel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.executeBtn);
            this.splitContainer1.Panel2.Controls.Add(this.syncBtn);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.groupSelect);
            this.splitContainer1.Panel2.Controls.Add(this.deviceRAMLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.deviceVideoLabel);
            this.splitContainer1.Panel2.Controls.Add(this.connectBtn);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.deviceIPLabel);
            this.splitContainer1.Panel2.Controls.Add(this.deviceCPULabel);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.deviceNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.deviceOSLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Size = new System.Drawing.Size(790, 420);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.TabIndex = 47;
            // 
            // imgButton1
            // 
            this.imgButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgButton1.BackColor = System.Drawing.SystemColors.Window;
            this.imgButton1.image = global::RCClient.Properties.Resources.refresh;
            this.imgButton1.Location = new System.Drawing.Point(517, 393);
            this.imgButton1.Name = "imgButton1";
            this.imgButton1.Size = new System.Drawing.Size(20, 20);
            this.imgButton1.TabIndex = 42;
            this.imgButton1.Click += new System.EventHandler(this.Refresh);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(790, 420);
            this.Load += new System.EventHandler(this.onLoad);
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label deviceRAMLabel;
        private System.Windows.Forms.Button discoverBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button logsBtn;
        private System.Windows.Forms.Label deviceVideoLabel;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label deviceIPLabel;
        private System.Windows.Forms.Label deviceCPULabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Label deviceOSLabel;
        private System.Windows.Forms.ListView deviceView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox statusImg;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button templatesBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.ComboBox groupSelect;
        private System.Windows.Forms.Label label1;
        private Components.ImgButton imgButton1;
        private System.Windows.Forms.Button saveDevicesBtn;
        private System.Windows.Forms.Button syncBtn;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.Button openScriptsBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
