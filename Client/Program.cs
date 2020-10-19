using Common;
using System;
using System.Windows.Forms;

namespace RCClient {
    static class Program {
        [STAThread]
        static void Main () {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UpdateService.CheckUpdates();

            Application.Run(new MainForm());
        }
    }
}
