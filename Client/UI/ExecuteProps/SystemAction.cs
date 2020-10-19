using System.Collections.Generic;
using System.Drawing;

namespace RCClient.UI.ExecuteProps {
    public partial class SystemAction : Executable {
        public override Image icon => Icons.GetSystemBitmap("timedate.cpl", 0, false);
        public SystemAction () {
            type = "system_action";
            name = "Системное действие";

            InitializeComponent();
        }

        public override void Reset () {
            actionSelect.SelectedItem = null;
        }

        public override void LoadResult () {
            actionSelect.SelectedIndex = int.Parse(GetValue("action", "-1"));
        }
    }
}
