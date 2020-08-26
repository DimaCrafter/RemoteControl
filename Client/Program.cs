using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RCClient {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main () {
            var _in = new Settings2();
            _in.devices.Add(new DeviceItem {
                mac = "FF:FF:FF:FF:FF:FF",
                name = "My PC",
                ip = "lcoalhost"
            });

            var fsIn = File.OpenWrite(@"D:\test.bin");
            _in.Serialize(fsIn);
            fsIn.Close();

            var fsOut = File.OpenRead(@"D:\test.bin");
            var _out = Settings2.Deserialize(fsOut);
            fsOut.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
