using System.Drawing;

namespace RCClient.UI.ExecuteProps {
    public partial class SyncTime : Executable {
        public override Image icon => Icons.GetSystemBitmap("timedate.cpl", 0, false);
        public SyncTime () {
            type = "time_sync";
            name = "Синхронизировать время";

            InitializeComponent();
        }
    }
}
