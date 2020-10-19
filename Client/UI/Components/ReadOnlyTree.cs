using System.Windows.Forms;

namespace RCClient.UI.Components {
    public class ReadOnlyTree : TreeView {
        protected override void WndProc (ref Message e) {
            // Eat left and right mouse clicks
            if (e.Msg != 0x201 && e.Msg != 0x204)
                base.WndProc(ref e);
        }

        protected override void OnAfterSelect (TreeViewEventArgs e) {
            SelectedNode = null;
        }
    }
}
