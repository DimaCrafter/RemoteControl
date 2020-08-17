using RCClient.UI.Components;
using RCClient.UI.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCClient {
    public partial class TemplatesForm : Form {
        public TemplatesForm () {
            InitializeComponent();
        }

        private void OnLoad (object sender, EventArgs e) {
            Icon = Icons.GetSystemIcon("shell32.dll", 165, true);

            tabs.AddTab(new Tab {
                name = "Рабочий стол",
                icon = Icons.GetSystemIcon("imageres.dll", -183, false),
                content = new DesktopPage(),
                isClosable = false
            }, true);
        }
    }
}
