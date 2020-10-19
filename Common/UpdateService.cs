using System.Reflection;

namespace Common {
    public class UpdateService {
        public static void CheckUpdates () {
            //var currentVersion = Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;
            //System.Windows.Forms.MessageBox.Show(CompareVersions(currentVersion, "0.0.1-0").ToString());
        }

        public static sbyte CompareVersions (string a, string b) {
            if (a == b) return 0;

            var aParts = a.Split('.', '-');
            var bParts = b.Split('.', '-');
            for (var i = 0; i < aParts.Length; i++) {
                var aValue = byte.Parse(aParts[i]);
                var bValue = byte.Parse(bParts[i]);

                if (aValue == bValue) {
                    continue;
                } else if (bValue > aValue) {
                    return 1;
                } else {
                    return -1;
                }
            }

            return 0;
        }
    }
}
