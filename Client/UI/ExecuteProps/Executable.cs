using Common;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RCClient.UI.ExecuteProps {
    public class Executable: UserControl {
        public string name { get; protected set; }
        public virtual Image icon { get; }

        public Dictionary<string, string> result;
        public virtual void Reset () { }
        public virtual void LoadResult () { }

        public Executable () {
            Dock = DockStyle.Fill;
        }

        protected string GetValue (string key, string initial) {
            if (result.ContainsKey(key)) return result[key];
            else {
                result.Add(key, initial);
                return initial;
            }
        }
    }
}
