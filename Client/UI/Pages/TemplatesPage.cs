using System.Collections.Generic;
using System.Windows.Forms;
using RCClient.UI.Components;

namespace RCClient.UI.Pages {
    public partial class TemplatesPage : UserControl {
        private readonly List<Tab> tabs;
        public TemplatesPage (List<Tab> tabs) {
            this.tabs = tabs;
            InitializeComponent();
        }

        private void imgButton1_Click (object sender, System.EventArgs e) {
            groupsBox.Items.Add("test");
        }

        private void onSelect (object sender, System.EventArgs e) {
            if (groupsBox.SelectedIndex == -1) {
                foreach (var tab in tabs) tab.visible = false;
            } else {
                foreach (var tab in tabs) tab.visible = true;
            }
        }
    }
}
