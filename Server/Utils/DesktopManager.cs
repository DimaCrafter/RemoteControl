using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace RCServer.Utils {
    class DesktopManager {
        private readonly IntPtr _desktopHandle = Win32.GetDesktopWindow(Win32.DesktopWindow.SysListView32);

        private Action tasks = () => {};
        public void CreateShortcut (Shortcut shortcut) {
            shortcut.path = $@"{Shortcut.DESKTOP_PATH}\{shortcut.name}.lnk";
            var pos = shortcut.CalcGridPosition();
            shortcut.Create();

            tasks += () => {
                Win32.SendMessage(_desktopHandle, Win32.LVM_SETITEMPOSITION, names.IndexOf(shortcut.name), pos);
            };
        }

        public void UpdateBackground (string path) {
            tasks += () => {
                var regDektop = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                if (regDektop != null) {
                    regDektop.SetValue("Wallpaper", path, RegistryValueKind.String);
                    regDektop.Close();
                }
            };
        }

        public void ExecuteTasks () {
            // Notify ListView update
            Win32.SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);

            UpdateIndexes();
            tasks();

            // Send refresh (F5)
            Win32.PostMessage(_desktopHandle, Win32.WM_KEYDOWN, Win32.VK_F5, 0);
        }

        private List<string> names;
        public void UpdateIndexes () {
            names = new List<string>();
            var desktopElem = AutomationElement.FromHandle(_desktopHandle);

            for (
                var child = TreeWalker.ContentViewWalker.GetFirstChild(desktopElem);
                child != null;
                child = TreeWalker.ContentViewWalker.GetNextSibling(child)
            ) {
                names.Add(child.Current.Name);
            }
        }
    }
}
