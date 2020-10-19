using RCClient.UI.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCClient.UI.Pages {
    public partial class ObserverPage : UserControl {
        private List<Bitmap> images = new List<Bitmap>();
        public ObserverPage () {
            InitializeComponent();
            Disposed += (sender, e) => {
                isRunning = false;
            };

            onSizeChange();

            foreach (var template in Settings.data.templates) {
                groupList.Items.Add(template.name);
            }
        }

        private void onSizeChange (object sender = null, EventArgs e = null) {
            devicesView.TileSize = new Size(sizeSlider.Value, sizeSlider.Value / 16 * 9);
        }

        private void onGroupSelect (object sender, EventArgs e) {
            if (groupList.SelectedIndex == -1) {
                devicesView.Clear();
                return;
            }

            var connections = new List<Device>();
            var tasks = new List<Task>();
            foreach (var ip in Settings.data.templates[groupList.SelectedIndex].devices) {
                devicesView.tiles.Add(new Components.ImageTile { text = ip });

                images.Clear();
                var task = new Task(async () => {
                    try {
                        var device = await Device.Connect(IPAddress.Parse(ip));
                        connections.Add(device);
                        images.Add(null);
                    } catch (Exception) {
                        // TODO: full error handling
                    }
                });
                task.Start();
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            tasks.Clear();

            new Thread(ObserverThreadWorker).Start(connections);
        }

        private bool isRunning = true;
        private async void ObserverThreadWorker (object _connections) {
            var connections = (List<Device>) _connections;
            while (isRunning) {
                var i = 0;
                foreach (var device in connections) {
                    var screen = await device.GetScreenshot(devicesView.TileSize);
                    images[i] = screen;

                    var ip = device.ip.ToString();
                    var tile = devicesView.tiles.Find(tile => tile.text == ip);
                    tile.image = screen;
                }

                if (!isRunning) break;
                try {
                    devicesView.Invoke((Action) devicesView.Refresh);
                } catch (Exception) {
                    // TODO: Avoid Invoke error
                }

                Thread.Sleep(750);
            }

            foreach (var device in connections) {
                device.Disconnect();
            }
        }
    }
}
