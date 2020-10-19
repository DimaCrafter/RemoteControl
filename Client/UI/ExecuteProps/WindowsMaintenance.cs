using System.Drawing;
using System.Windows.Forms;

namespace RCClient.UI.ExecuteProps {
    public partial class WindowsMaintenance : Executable {
        public override Image icon => Icons.GetSystemBitmap("imageres.dll", 109, false);
        public WindowsMaintenance () {
            type = "maintain_components";
            name = "Обслуживание Windows";

            InitializeComponent();
        }

        public override void Reset () {
            componentsList.Items.Clear();
        }

        public override void LoadResult () {
            var count = int.Parse(GetValue("args", "0"));
            componentsList.Items.Clear();
            for (var i = 0; i < count; i++) {
                var entry = result["arg" + i].Split('|');
                componentsList.Items.Add(entry[0], bool.Parse(entry[1]));
            }
        }

        private void onComponentSelect (object sender, System.EventArgs e) {
            if (componentSelect.SelectedIndex == -1)
                return;

            var selected = (string) componentSelect.SelectedItem;
            componentsList.Items.Add(selected, false);
            result["arg" + (componentsList.Items.Count - 1)] = selected + "|false";

            componentSelect.SelectedItem = null;
            componentSelect.Text = "Добавить компонент";
            result["args"] = componentsList.Items.Count.ToString();
        }

        private void onComponentToggle (object sender, ItemCheckEventArgs e) {
            if (componentsList.SelectedItem == null)
                return;

            result["arg" + e.Index] = componentsList.SelectedItem + "|" + (e.NewValue == CheckState.Checked);
        }

        private void onRemove (object sender, System.EventArgs e) {
            if (componentsList.SelectedIndex == -1)
                return;

            // TODO: normal removal
        }
    }
}
