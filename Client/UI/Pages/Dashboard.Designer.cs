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
            this.statusImg = new System.Windows.Forms.PictureBox();
            this.templatesBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).BeginInit();
            this.SuspendLayout();
            // 
            // deviceRAMLabel
            // 
            this.deviceRAMLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceRAMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceRAMLabel.Location = new System.Drawing.Point(581, 260);
            this.deviceRAMLabel.Name = "deviceRAMLabel";
            this.deviceRAMLabel.Size = new System.Drawing.Size(199, 18);
            this.deviceRAMLabel.TabIndex = 37;
            this.deviceRAMLabel.Text = "8 Гб";
            // 
            // discoverBtn
            // 
            this.discoverBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.discoverBtn.Location = new System.Drawing.Point(6, 5);
            this.discoverBtn.Name = "discoverBtn";
            this.discoverBtn.Size = new System.Drawing.Size(165, 23);
            this.discoverBtn.TabIndex = 21;
            this.discoverBtn.Text = "Поиск устройств";
            this.discoverBtn.UseVisualStyleBackColor = true;
            this.discoverBtn.Click += new System.EventHandler(this.DiscoverDevices);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "ОЗУ:";
            // 
            // logsBtn
            // 
            this.logsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logsBtn.Location = new System.Drawing.Point(6, 34);
            this.logsBtn.Name = "logsBtn";
            this.logsBtn.Size = new System.Drawing.Size(165, 23);
            this.logsBtn.TabIndex = 22;
            this.logsBtn.Text = "Показать логи";
            this.logsBtn.UseVisualStyleBackColor = true;
            this.logsBtn.Click += new System.EventHandler(this.OpenLogs);
            // 
            // deviceVideoLabel
            // 
            this.deviceVideoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceVideoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceVideoLabel.Location = new System.Drawing.Point(581, 198);
            this.deviceVideoLabel.Name = "deviceVideoLabel";
            this.deviceVideoLabel.Size = new System.Drawing.Size(199, 38);
            this.deviceVideoLabel.TabIndex = 35;
            this.deviceVideoLabel.Text = "Nvidia GT 250 GMS Eco\r\n800x600 32bbp";
            // 
            // connectBtn
            // 
            this.connectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.connectBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectBtn.Location = new System.Drawing.Point(580, 393);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(204, 23);
            this.connectBtn.TabIndex = 23;
            this.connectBtn.Text = "Подключиться";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(581, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Видеокарта:";
            // 
            // deviceIPLabel
            // 
            this.deviceIPLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceIPLabel.AutoSize = true;
            this.deviceIPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deviceIPLabel.Location = new System.Drawing.Point(580, 5);
            this.deviceIPLabel.Name = "deviceIPLabel";
            this.deviceIPLabel.Size = new System.Drawing.Size(138, 24);
            this.deviceIPLabel.TabIndex = 24;
            this.deviceIPLabel.Text = "192.168.0.104";
            // 
            // deviceCPULabel
            // 
            this.deviceCPULabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceCPULabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceCPULabel.Location = new System.Drawing.Point(581, 136);
            this.deviceCPULabel.Name = "deviceCPULabel";
            this.deviceCPULabel.Size = new System.Drawing.Size(199, 38);
            this.deviceCPULabel.TabIndex = 33;
            this.deviceCPULabel.Text = "Intel Pentium Core 2 Duo\r\n1 ____ x 2 core";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Имя компьютера:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Процессор:";
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceNameLabel.Location = new System.Drawing.Point(581, 53);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(199, 18);
            this.deviceNameLabel.TabIndex = 26;
            this.deviceNameLabel.Text = "Обычной имя";
            // 
            // deviceOSLabel
            // 
            this.deviceOSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceOSLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.deviceOSLabel.Location = new System.Drawing.Point(581, 95);
            this.deviceOSLabel.Name = "deviceOSLabel";
            this.deviceOSLabel.Size = new System.Drawing.Size(199, 18);
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
            this.deviceView.Size = new System.Drawing.Size(397, 411);
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
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(581, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Операционная система:";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(30, 401);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 29;
            this.statusLabel.Text = "Статус";
            // 
            // statusImg
            // 
            this.statusImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusImg.Location = new System.Drawing.Point(10, 400);
            this.statusImg.Name = "statusImg";
            this.statusImg.Size = new System.Drawing.Size(16, 16);
            this.statusImg.TabIndex = 28;
            this.statusImg.TabStop = false;
            // 
            // templatesBtn
            // 
            this.templatesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.templatesBtn.Location = new System.Drawing.Point(6, 63);
            this.templatesBtn.Name = "templatesBtn";
            this.templatesBtn.Size = new System.Drawing.Size(165, 23);
            this.templatesBtn.TabIndex = 38;
            this.templatesBtn.Text = "Шаблоны";
            this.templatesBtn.UseVisualStyleBackColor = true;
            this.templatesBtn.Click += new System.EventHandler(this.OpenTemplates);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.templatesBtn);
            this.Controls.Add(this.deviceRAMLabel);
            this.Controls.Add(this.discoverBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logsBtn);
            this.Controls.Add(this.deviceVideoLabel);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.deviceIPLabel);
            this.Controls.Add(this.deviceCPULabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deviceNameLabel);
            this.Controls.Add(this.deviceOSLabel);
            this.Controls.Add(this.deviceView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusImg);
            this.Controls.Add(this.statusLabel);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(790, 420);
            this.Load += new System.EventHandler(this.onLoad);
            ((System.ComponentModel.ISupportInitialize)(this.statusImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
