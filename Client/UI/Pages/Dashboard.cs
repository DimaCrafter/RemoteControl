using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RCClient.UI.Forms;
using System.Net;

namespace RCClient.UI.Pages {
    public partial class Dashboard : UserControl {
        public Dashboard () {
            InitializeComponent();
        }

        private readonly List<Device> devices = new List<Device>();
        private void onLoad (object sender, EventArgs e) {
            statusLabel.Text = "";
            var pcIcon = Icons.GetSystemBitmap("shell32.dll", 15, true);
            DisableInfoPanel();

            deviceView.LargeImageList = new ImageList {
                ImageSize = pcIcon.Size,
                ColorDepth = ColorDepth.Depth32Bit
            };
            deviceView.LargeImageList.Images.Add(pcIcon);
            deviceView.LargeImageList.Images.Add(Utils.GrayscaleImage(pcIcon));

            discoverBtn.Image = Icons.GetSystemBitmap("netcenter.dll", 11, false);
            saveDevicesBtn.Image = Icons.GetSystemBitmap("shell32.dll", 258, false);

            logsBtn.Image = Icons.GetSystemBitmap("mmc.exe", 0, false);
            templatesBtn.Image = Icons.GetSystemBitmap("shell32.dll", 165, false);
            settingsBtn.Image = Icons.GetSystemBitmap("imageres.dll", 109, false);

            executeBtn.Image = Icons.GetSystemBitmap("shell32.dll", 24, false);
            syncBtn.Image = Icons.GetSystemBitmap("imageres.dll", 228, false);
            connectBtn.Image = Icons.GetSystemBitmap("netcenter.dll", 1, false);

            Refresh();
        }

        private async void DiscoverDevices (object sender = null, EventArgs e = null) {
            if (Device.isDiscovering) {
                Device.isDiscovering = false;
                return;
            }

            discoverBtn.Text = "Остановить поиск";
            WriteStatus("Поиск устройств...", Status.Progress);
            var sw = new Stopwatch();
            sw.Start();

            await Device.Discover(devices, device => {
                Invoke((Action) delegate {
                    var item = new ListViewItem(new string[] { device.ip.ToString(), device.info.name }, 0);
                    item.Group = GetViewTemplateGroup(device.template);
                    deviceView.Items.Add(item);
                    devices.Add(device);
                });
            });

            sw.Stop();
            WriteStatus("Поиск устройств завершён", Status.Done);
            Logs.Write($"Поиск устройств завершён за {(sw.ElapsedMilliseconds / 1000f):N2} сек.");
            discoverBtn.Text = "Поиск устройств";
        }

        private const string INFO_PLACEHOLDER = "--------------------------------------\n--------------";
        private void DisableInfoPanel () {
            deviceIPLabel.Text = "Не выбрано";
            deviceNameLabel.Text = INFO_PLACEHOLDER;
            deviceOSLabel.Text = INFO_PLACEHOLDER;
            deviceCPULabel.Text = INFO_PLACEHOLDER;
            deviceVideoLabel.Text = INFO_PLACEHOLDER;
            deviceRAMLabel.Text = INFO_PLACEHOLDER;

            executeBtn.Enabled = false;
            syncBtn.Enabled = false;
            connectBtn.Enabled = false;

            groupSelect.Enabled = false;
            groupSelect.SelectedItem = null;
        }

        private enum Status {
            Progress,
            Done
        };
        private static readonly Image DONE_ICON = Icons.GetSystemBitmap("comres.dll", 8, false);
        private void WriteStatus (string text, Status status) {
            Invoke((Action) delegate {
                statusLabel.Text = text;

                switch (status) {
                    case Status.Progress:
                        statusImg.Image = Properties.Resources.progress;
                        break;
                    case Status.Done:
                        statusImg.Image = DONE_ICON;
                        Task.Run(() => {
                            Task.Delay(2500).Wait();
                            if (text == statusLabel.Text)
                                ClearStatus();
                        });
                        break;
                }
            });
        }

        private void ClearStatus () {
            Invoke((Action) delegate {
                statusLabel.Text = "";
                statusImg.Image = null;
            });
        }

        private void OpenLogs (object sender, EventArgs e) {
            Logs.OpenForm(FindForm());
        }

        private void onSelectDevice (object sender, EventArgs e) {
            if (deviceView.SelectedItems.Count == 0) {
                DisableInfoPanel();
            } else if (deviceView.SelectedItems.Count > 1) {
                DisableInfoPanel();
                deviceIPLabel.Text = "Выбрано " + deviceView.SelectedItems.Count;
                executeBtn.Enabled = true;
                syncBtn.Enabled = true;
                groupSelect.Enabled = true;
            } else {
                var device = devices[deviceView.SelectedItems[0].Index];
                if (device.info == null) {
                    DisableInfoPanel();
                    deviceIPLabel.Text = device.ip.ToString();
                } else {
                    executeBtn.Enabled = true;
                    syncBtn.Enabled = true;
                    connectBtn.Enabled = true;

                    deviceIPLabel.Text = device.ip.ToString();
                    deviceNameLabel.Text = device.info.name;
                    deviceOSLabel.Text = device.info.os;
                    deviceRAMLabel.Text = device.info.ram + " Гб";
                    deviceVideoLabel.Text = $"{device.info.videocard}\n{device.info.screenWidth}x{device.info.screenHeight} {device.info.bpp}bpp";

                    var cpuInfo = device.info.cpuName.Split('@');
                    deviceCPULabel.Text = $"{cpuInfo[0].Replace("CPU", "").Trim()}\n{cpuInfo[1].Trim()} x {device.info.cpuCores} cores";
                }

                groupSelect.Enabled = true;
                groupSelect.SelectedItem = device.template?.name;
            }
        }

        private void OpenTemplates (object sender, EventArgs e) {
            var form = new TemplatesForm();
            form.Show();
        }

        private void OpenSettings (object sender, EventArgs e) {
            Settings.Open(FindForm());
        }

        private void onGroupChanged (object sender, EventArgs e) {
            if (groupSelect.SelectedIndex == -1) return;

            var devices = Settings.data.templates[groupSelect.SelectedIndex].devices;
            foreach (ListViewItem device in deviceView.SelectedItems) {
                foreach (var template in Settings.data.templates) {
                    var i = template.devices.IndexOf(device.Text);
                    if (i != -1) template.devices.RemoveAt(i);
                }

                if (!devices.Contains(device.Text)) devices.Add(device.Text);
                device.Group = deviceView.Groups[groupSelect.SelectedIndex];
            }
        }

        private async void Refresh (object sender = null, EventArgs e = null) {
            deviceView.Groups.Clear();
            groupSelect.Items.Clear();
            foreach (var template in Settings.data.templates) {
                groupSelect.Items.Add(template.name);
                deviceView.Groups.Add(new ListViewGroup(template.name));
            }

            if (Settings.data.devices.Count == 0) DiscoverDevices();
            else {
                WriteStatus("Обновление списка", Status.Progress);
                devices.Clear();
                deviceView.Items.Clear();

                foreach (var item in Settings.data.devices) {
                    var device = new Device(item);
                    devices.Add(device);

                    var listItem = new ListViewItem(new string[] { item.ip });
                    listItem.Group = GetViewTemplateGroup(device.template);
                    listItem.ImageIndex = await device.FetchInfo() ? 0 : 1;
                    item.name = device.name;
                    listItem.SubItems.Add(item.name);
                    deviceView.Items.Add(listItem);
                }

                WriteStatus("Список обновлён", Status.Done);
            }
        }

        private void SaveDevices (object sender, EventArgs e) {
            Settings.data.devices.Clear();
            foreach (var device in devices) {
                Settings.data.devices.Add(new DeviceItem {
                    ip = device.ip.ToString(),
                    name = device.name
                });
            }

            Settings.Save();
            MessageBox.Show("Успешно сохранено!");
        }

        // Utils
        private ListViewGroup GetViewTemplateGroup (DeviceTemplate template) {
            if (template == null) return null;

            return deviceView.Groups[groupSelect.Items.IndexOf(template.name)];
        }

        private void OpenScripts (object sender, EventArgs e) {
            var form = new ScriptForm();
            form.Show();
        }

        private void OpenExecute (object sender, EventArgs e) {
            var devices = new List<Device>();
            foreach (ListViewItem selected in deviceView.SelectedItems) {
                devices.Add(new Device(IPAddress.Parse(selected.Text)));
            }

            var form = new ExecuteForm(devices);
            form.Show();
        }

        private void syncBtn_Click (object sender, EventArgs e) {
            var devices = new List<Device>();
            foreach (ListViewItem item in deviceView.SelectedItems) {
                devices.Add(new Device(IPAddress.Parse(item.Text)));
            }

            ExecutingManager.Open(ParentForm, devices, new Common.ExecScript {
                name = "[Синхронизация]",
                steps = new List<Dictionary<string, string>> {
                    new Dictionary<string, string> {
                        { "type", "sync" }
                    }
                }
            });
        }

        private void connectBtn_Click (object sender, EventArgs e) {
            new AnyDeskForm(deviceView.SelectedItems[0].Text).Show();
        }
    }
}
