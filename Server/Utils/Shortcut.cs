using Common;
using IWshRuntimeLibrary;
using System;
using System.Windows.Forms;

namespace RCServer.Utils {
    class Shortcut : Common.Shortcut {
        private static WshShell shell = new WshShell();
        public static string DESKTOP_PATH;

        static Shortcut () {
            object shDesktop = "Desktop";
            DESKTOP_PATH = (string) shell.SpecialFolders.Item(ref shDesktop);
        }

        /// <summary>
        /// Calculates shortcut position on desktop grid
        /// </summary>
        /// <returns>Pointer to LParam</returns>
        public IntPtr CalcGridPosition () {
            var width = 44 + 29;
            var height = 44 + 60;
            var x = xGridOffset * width + 12;
            var y = yGridOffset * height + 2;

            switch (aligment) {
                case ShortcutAlignment.TopRight:
                    x = Screen.PrimaryScreen.WorkingArea.Width - x - width;
                    break;
                case ShortcutAlignment.BottomRight:
                    x = Screen.PrimaryScreen.WorkingArea.Width - x - width;
                    y = Screen.PrimaryScreen.WorkingArea.Height - y - height;
                    break;
                case ShortcutAlignment.BottomLeft:
                    y = Screen.PrimaryScreen.WorkingArea.Height - y - height;
                    break;
            }

            return Win32.MakeLParam(x, y);
        }

        private IWshShortcut lnk;
        public void Create () {
            lnk = (IWshShortcut) shell.CreateShortcut(path);
            lnk.TargetPath = target;

            if (icon == null) {
                if (target.StartsWith("http")) lnk.IconLocation = "SHELL32.dll,135";
            } else {
                lnk.IconLocation = icon;
            }

            lnk.Save();
        }
    }
}
