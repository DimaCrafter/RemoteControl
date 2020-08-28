using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RCClient.UI.Forms {
    public partial class Settings : Form {
        // Static utils
        public static SettingsStruct data;
        private const string SETTINGS_FILE = "settings.bcf";
        static Settings () { LoadInit(); }

        public static void LoadInit () {
            if (File.Exists(SETTINGS_FILE)) {
                var file = File.OpenRead(SETTINGS_FILE);
                data = SettingsStruct.Deserialize(file);
                file.Close();
            } else {
                data = new SettingsStruct();
            }
        }

        public static void Save () {
            if (File.Exists(SETTINGS_FILE)) {
                File.Delete(SETTINGS_FILE);
            }

            var file = File.OpenWrite(SETTINGS_FILE);
            data.Serialize(file);
            file.Close();
        }

        // Form methods
        public Settings () {
            InitializeComponent();

            Icon = Icons.GetSystemIcon("imageres.dll", 109, true);
        }

        private static Settings instance;
        public static void Open (Form parent) {
            if (instance == null) instance = new Settings();

            instance.Show();
            instance.Left = parent.Left + (parent.Width - instance.Width) / 2;
            instance.Top = parent.Top + (parent.Height - instance.Height) / 2;
            instance.Focus();
        }

        private void onClose (object sender, FormClosingEventArgs e) {
            instance = null;
        }

        private void onLoad (object sender, EventArgs e) {
            portInput.Text = data.port.ToString();
            fastTimeoutInput.Text = data.fastTimeout.ToString();
            normalTimeoutInput.Text = data.normalTimeout.ToString();
        }

        private void OnSaveClick (object sender, EventArgs e) {
            try {
                data.port = Utils.ParseInt(portInput.Text, 1, 65536, "Порт сервиса должен быть в диапазоне от 1 до 65536.");
                data.fastTimeout = Utils.ParseInt(fastTimeoutInput.Text, 30, 1200, "Время ожидания при сканировании должно быть в диапазоне от 30 до 1200 мс.");
                data.port = Utils.ParseInt(portInput.Text, 1200, 10000, "Время ожидания при подключении должно быть в диапазоне от 1200 до 10000.");
            } catch (Utils.PareseIntError err) {
                MessageBox.Show(err.Message, "Неверный параметр", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Save();
            Close();
        }

        private void OnCancelClick (object sender, EventArgs e) {
            Close();
        }

        private void ClearDevices (object sender, EventArgs e) {
            data.devices.Clear();
            MessageBox.Show("Список устройств был успешно очищен.");
        }
    }

    public class SettingsStruct : SerializableStruct<SettingsStruct> {
        public int port = 2386;
        public int fastTimeout = 65;
        public int normalTimeout = 2500;
        public List<DeviceItem> devices = new List<DeviceItem>();
    }
}
