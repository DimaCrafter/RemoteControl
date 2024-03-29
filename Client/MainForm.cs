﻿using Microsoft.WindowsAPICodePack.Shell;
using RCClient.UI.Components;
using RCClient.UI.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
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
                content = new Dashboard(),
                icon = Icons.GetSystemIcon("shell32.dll", 21, false),
                meta = new Dictionary<string, object> {
                    ["iconLarge"] = Icons.GetSystemIcon("shell32.dll", 21, true)
                },
                isClosable = false
            }, true);
        }
    }
}
