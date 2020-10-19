using RCClient.UI.Components;
using RCClient.UI.Forms;
using RCClient.UI.Pages;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RCClient {
    public partial class TemplatesForm : Form {
        public TemplatesForm () {
            InitializeComponent();
        }

        private void OnLoad (object sender, EventArgs e) {
            Icon = Icons.GetSystemIcon("shell32.dll", 165, true);

            var dependentTabs = new List<Tab> {
                new Tab {
                    name = "Рабочий стол",
                    icon = Icons.GetSystemIcon("imageres.dll", -183, false),
                    content = typeof(DesktopPage)
                }
            };

            tabs.AddTab(new Tab {
                name = "Главная",
                contentInstance = new TemplatesPage(dependentTabs),
                icon = Icons.GetSystemIcon("shell32.dll", 165, false),
                isClosable = false
            }, true);

            foreach (var tab in dependentTabs) {
                tab.isClosable = false;
                tab.visible = false;
                tabs.AddTab(tab);
            }
        }

        private void OnClose (object sender, FormClosingEventArgs e) {
            switch (MessageBox.Show("Сохранить внесённые изменения?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
                case DialogResult.Yes:
                    Settings.Save();
                    break;
                case DialogResult.No:
                    Settings.LoadInit();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }
    }
}
