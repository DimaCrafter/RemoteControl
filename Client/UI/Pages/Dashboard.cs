using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace RCClient.UI.Pages {
    public partial class Dashboard : UserControl {
        public Dashboard () {
            InitializeComponent();
        }

        private readonly List<Device> devices = new List<Device>();
        private void onLoad (object sender, EventArgs e) {
            statusLabel.Text = "";
            //DiscoverDevices();
            var pcIcon = Icons.GetSystemBitmap("shell32.dll", 15, true);
            DisableInfoPanel();

            deviceView.LargeImageList = new ImageList {
                ImageSize = pcIcon.Size,
                ColorDepth = ColorDepth.Depth32Bit
            };
            deviceView.LargeImageList.Images.Add(pcIcon);

            discoverBtn.Image = Icons.GetSystemBitmap("netcenter.dll", 11, false);
            logsBtn.Image = Icons.GetSystemBitmap("mmc.exe", 0, false);
            connectBtn.Image = Icons.GetSystemBitmap("netcenter.dll", 1, false);
            templatesBtn.Image = Icons.GetSystemBitmap("shell32.dll", 165, false);
        }

        private async void DiscoverDevices (object sender = null, EventArgs e = null) {
            devices.Clear();
            deviceView.Items.Clear();
            WriteStatus("Поиск устройств...", Status.Progress);
            var sw = new Stopwatch();
            sw.Start();

            await Device.Discover(device => {
                devices.Add(device);
                Invoke((Action) delegate {
                    deviceView.Items.Add(new ListViewItem(new string[] { device.ip.ToString(), device.info.name }, 0));
                });
            });

            sw.Stop();
            WriteStatus("Поиск устройств завершён", Status.Done);
            Logs.Write($"Поиск устройств завершён за {(sw.ElapsedMilliseconds / 1000f):N2} сек.");
        }

        private const string INFO_PLACEHOLDER = "--------------------------------------\n--------------";
        private void DisableInfoPanel () {
            deviceIPLabel.Text = "Не выбрано";
            deviceNameLabel.Text = INFO_PLACEHOLDER;
            deviceOSLabel.Text = INFO_PLACEHOLDER;
            deviceCPULabel.Text = INFO_PLACEHOLDER;
            deviceVideoLabel.Text = INFO_PLACEHOLDER;
            deviceRAMLabel.Text = INFO_PLACEHOLDER;
            connectBtn.Enabled = false;
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
            } else {
                connectBtn.Enabled = true;

                var device = devices[deviceView.SelectedItems[0].Index];
                deviceIPLabel.Text = device.ip.ToString();
                deviceNameLabel.Text = device.info.name;
                deviceOSLabel.Text = device.info.os;
                deviceRAMLabel.Text = device.info.ram + " Гб";
                deviceVideoLabel.Text = $"{device.info.videocard}\n{device.info.screenWidth}x{device.info.screenHeight} {device.info.bpp}bpp";

                var cpuInfo = device.info.cpuName.Split('@');
                deviceCPULabel.Text = $"{cpuInfo[0].Replace("CPU", "").Trim()}\n{cpuInfo[1].Trim()} x {device.info.cpuCores} cores";
            }
        }

        private void OpenTemplates (object sender, EventArgs e) {
            var form = new TemplatesForm();
            form.Show();
        }
    }
}
