using System.Collections.Generic;
using System.Windows.Forms;
using RCClient.UI.Components;
using RCClient.UI.Forms;
using RCClient.UI.Modals;

namespace RCClient.UI.Pages {
    public partial class TemplatesPage : UserControl {
        private readonly List<Tab> tabs;
        public TemplatesPage (List<Tab> tabs) {
            this.tabs = tabs;
            InitializeComponent();

            foreach (var template in Settings.data.templates) {
                groupsBox.Items.Add(template.name);
            }
        }

        private async void AddTemplate (object sender, System.EventArgs e) {
            var res = await TextPrompt.Open(FindForm(), "Создание шаблона", "Название нового шаблона:");
            if (res.success) {
                Settings.data.templates.Add(new DeviceTemplate {
                    name = res.value
                });

                groupsBox.Items.Add(res.value);
                groupsBox.SelectedIndex = groupsBox.Items.Count - 1;
            }
        }

        private async void RenameTemplate (object sender, System.EventArgs e) {
            if (selected == null) return;

            var res = await TextPrompt.Open(FindForm(), "Изменение шаблона", $"Новое название шаблона {groupsBox.Items[groupsBox.SelectedIndex]}:");
            if (res.success) {
                selected.name = res.value;
                groupsBox.Items[groupsBox.SelectedIndex] = res.value;
            }
        }

        private DeviceTemplate selected = null;
        private void onSelect (object sender, System.EventArgs e) {
            devicesList.Items.Clear();
            if (groupsBox.SelectedIndex == -1) {
                selected = null;
                foreach (var tab in tabs) tab.visible = false;

                nameLabel.Text = "Шаблон не выбран";
                removeBtn.Enabled = false;
                renameBtn.Enabled = false;
                devicesList.Items.Clear();
                deviceCountLabel.Text = "0";
            } else {
                selected = Settings.data.templates[groupsBox.SelectedIndex];
                foreach (var tab in tabs) {
                    tab.visible = true;
                }

                nameLabel.Text = (string) groupsBox.Items[groupsBox.SelectedIndex];
                removeBtn.Enabled = true;
                renameBtn.Enabled = true;
                devicesList.Items.AddRange(selected.devices.ToArray());
                deviceCountLabel.Text = selected.devices.Count.ToString();

                DesktopPage.template = selected;
            }
        }

        private void groupsBox_Click (object sender, System.EventArgs e) {
            //if (groupsBox.SelectedIndex != -1) groupsBox.SelectedIndex = -1;
        }
    }
}
