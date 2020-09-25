using Common;
using RCClient.UI.Forms;
using System.Collections.Generic;
using System.Net;

namespace RCClient {
    public class DeviceTemplate : SerializableStruct<DeviceTemplate> {
        public string name;
        // Devices' IPs
        public List<string> devices = new List<string>();

        public string desktopBackground = "none";
        public List<Shortcut> desktopShortcuts = new List<Shortcut>();

        public async void Apply () {
            foreach (var ip in devices) {
                foreach (var deviceInfo in Settings.data.devices) {
                    if (deviceInfo.ip != ip) continue;

                    var device = await Device.Connect(IPAddress.Parse(ip));
                    //device.
                }
            }
        }
    }
}
