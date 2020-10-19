using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCClient.UI.Components {
    public partial class Modal<T, V> : Form where T : Form {
        public Modal () {
            InitializeComponent();
        }

        private TaskCompletionSource<ModalResult> taskSource = new TaskCompletionSource<ModalResult>();
        protected void SetResult (V value) {
            taskSource.SetResult(new ModalResult {
                value = value,
                success = true
            });
            Close();
        }

        protected void Cancel () {
            taskSource.SetResult(new ModalResult {
                success = false
            });
            Close();
        }

        protected bool isResizable = false;
        public static Task<ModalResult> Open (Form parent, params object[] args) {
            var form = Activator.CreateInstance(typeof(T), args) as Modal<T, V>;
            form.Show();
            form.Location = new Point(
                parent.Location.X + (parent.Width - form.Width) / 2,
                parent.Location.Y + (parent.Height - form.Height) / 2
            );

            form.MinimumSize = form.Size;
            if (!form.isResizable) {
                form.MaximumSize = form.Size;
            }

            EventHandler handler = (sender, e) => {
                form.Activate();
                SystemSounds.Beep.Play();
            };

            parent.Activated += handler;
            form.taskSource.Task.ContinueWith(_ => {
                parent.Activated -= handler;
            });

            return form.taskSource.Task;
        }

        public struct ModalResult {
            public V value;
            public bool success;
        }
    }
}
