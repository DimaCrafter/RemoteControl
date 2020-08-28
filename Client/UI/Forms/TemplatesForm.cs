using RCClient.UI.Components;
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
                    content = new DesktopPage()
                }
            };

            tabs.AddTab(new Tab {
                name = "Главная",
                icon = Icons.GetSystemIcon("imageres.dll", -183, false),
                content = new TemplatesPage(dependentTabs),
                isClosable = false
            }, true);

            foreach (var tab in dependentTabs) {
                tab.isClosable = false;
                tab.visible = false;
                tabs.AddTab(tab);
            }

            //tabs.AddTab(new Tab {
            //    name = "Рабочий стол",
            //    icon = Icons.GetSystemIcon("imageres.dll", -183, false),
            //    content = new DesktopPage(),
            //    isClosable = false
            //}, true);
        }
    }
}
