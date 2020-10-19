using RCClient.UI;
using RCClient.UI.Components;
using RCClient.UI.Pages;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient {
    public partial class MainForm : Form {
        public MainForm () {
            InitializeComponent();
            tabs.OnTabChange += () => {
                Text = "RemoteControl Client :: " + tabs.selected.name;
                Icon = tabs.GetMeta<Icon>("iconLarge");
            };
        }

        private void onLoad (object sender, EventArgs e) {
            tabs.AddTab(new Tab {
                name = "Панель управления",
                content = typeof(Dashboard),
                icon = Icons.GetSystemIcon("shell32.dll", 21, false),
                meta = new Dictionary<string, object> {
                    ["iconLarge"] = Icons.GetSystemIcon("shell32.dll", 21, true)
                },
                isClosable = false
            }, true);
            tabs.AddTab(new Tab {
                name = "Наблюдение",
                content = typeof(ObserverPage),
                icon = Icons.GetSystemIcon("networkexplorer.dll", 2, false),
                meta = new Dictionary<string, object> {
                    ["iconLarge"] = Icons.GetSystemIcon("networkexplorer.dll", 2, true)
                },
                isClosable = false
            });
        }
    }
}
