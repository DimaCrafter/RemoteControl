namespace RCClient.UI.ExecuteProps {
    partial class WindowsMaintenance {
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
            this.componentSelect = new System.Windows.Forms.ComboBox();
            this.componentsList = new System.Windows.Forms.CheckedListBox();
            this.removeBtn = new RCClient.UI.Components.ImgButton();
            this.SuspendLayout();
            // 
            // componentSelect
            // 
            this.componentSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentSelect.FormattingEnabled = true;
            this.componentSelect.Items.AddRange(new object[] {
            "OEMHelpCustomization",
            "CorporationHelpCustomization",
            "SimpleTCP",
            "SNMP",
            "WMISnmpProvider",
            "TelnetServer",
            "TelnetClient",
            "WindowsGadgetPlatform",
            "InboxGames",
            "More Games",
            "Solitaire",
            "SpiderSolitaire",
            "Hearts",
            "FreeCell",
            "Minesweeper",
            "PurblePlace",
            "IIS-WebServerRole",
            "IIS-WebServer",
            "IIS-CommonHttpFeatures",
            "IIS-HttpErrors",
            "IIS-HttpRedirect",
            "IIS-ApplicationDevelopment",
            "IIS-Security",
            "IIS-URLAuthorization",
            "IIS-RequestFiltering",
            "IIS-NetFxExtensibility",
            "IIS-HealthAndDiagnostics",
            "IIS-HttpLogging",
            "IIS-LoggingLibraries",
            "IIS-RequestMonitor",
            "IIS-HttpTracing",
            "IIS-IPSecurity",
            "IIS-Performance",
            "IIS-HttpCompressionDynamic",
            "IIS-WebServerManagementTools",
            "IIS-ManagementScriptingTools",
            "IIS-IIS6ManagementCompatibility",
            "IIS-Metabase",
            "WAS-WindowsActivationService",
            "WAS-ProcessModel",
            "WAS-NetFxEnvironment",
            "WAS-ConfigurationAPI",
            "IIS-HostableWebCore",
            "MediaPlayback",
            "WindowsMediaPlayer",
            "NetFx3",
            "WCF-HTTP-Activation",
            "WCF-NonHTTP-Activation",
            "RasRip",
            "MSMQ-Container",
            "MSMQ-Server",
            "MSMQ-Triggers",
            "MSMQ-ADIntegration",
            "MSMQ-HTTP",
            "MSMQ-Multicast",
            "MSMQ-DCOMProxy",
            "Printing-Foundation-Features",
            "Printing-Foundation-LPRPortMonitor",
            "Printing-Foundation-LPDPrintService",
            "Printing-Foundation-InternetPrinting-Client",
            "FaxServicesClientPackage",
            "TFTP",
            "MSRDC-Infrastructure",
            "Printing-XPSServices-Features",
            "Indexing-Service-Package",
            "Xps-Foundation-Xps-Viewer",
            "SearchEngine-Client-Package",
            "Internet-Explorer-Optional-x86"});
            this.componentSelect.Location = new System.Drawing.Point(6, 3);
            this.componentSelect.Name = "componentSelect";
            this.componentSelect.Size = new System.Drawing.Size(1554, 21);
            this.componentSelect.TabIndex = 0;
            this.componentSelect.Text = "Добавить компонент";
            this.componentSelect.SelectedIndexChanged += new System.EventHandler(this.onComponentSelect);
            // 
            // componentsList
            // 
            this.componentsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.componentsList.FormattingEnabled = true;
            this.componentsList.IntegralHeight = false;
            this.componentsList.Location = new System.Drawing.Point(6, 30);
            this.componentsList.Name = "componentsList";
            this.componentsList.Size = new System.Drawing.Size(1554, 662);
            this.componentsList.TabIndex = 1;
            this.componentsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.onComponentToggle);
            // 
            // removeBtn
            // 
            this.removeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeBtn.BackColor = System.Drawing.SystemColors.Window;
            this.removeBtn.image = global::RCClient.Properties.Resources.close;
            this.removeBtn.Location = new System.Drawing.Point(1538, 670);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(20, 20);
            this.removeBtn.TabIndex = 11;
            this.removeBtn.Click += new System.EventHandler(this.onRemove);
            // 
            // WindowsMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.componentsList);
            this.Controls.Add(this.componentSelect);
            this.Name = "WindowsMaintenance";
            this.Size = new System.Drawing.Size(1563, 695);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox componentSelect;
        private System.Windows.Forms.CheckedListBox componentsList;
        private Components.ImgButton removeBtn;
    }
}
