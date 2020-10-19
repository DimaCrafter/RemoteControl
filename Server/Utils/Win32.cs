using Common;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace RCServer.Utils {
    internal static class Win32 {
        public const uint WM_KEYDOWN = 0x100;
        public const uint WM_CLOSE = 0x10;

        public const int VK_F5 = 0x74;

        public const uint LVM_GETITEMCOUNT = 0x1000 + 4;
        public const uint LVM_SETITEMPOSITION = 0x1000 + 15;
        public const uint LVM_GETITEMPOSITION = 0x1000 + 16;
        public const uint LVM_GETITEMW = 0x1000 + 75;

        public const uint LVIF_TEXT = 0x0001;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx (IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public enum DesktopWindow {
            ProgMan,
            SHELLDLL_DefViewParent,
            SHELLDLL_DefView,
            SysListView32
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow ();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows (EnumWindowsProc lpEnumFunc, IntPtr lParam);

        public delegate bool EnumWindowsProc (IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName (IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        public static IntPtr GetDesktopWindow (DesktopWindow desktopWindow) {
            IntPtr _ProgMan = GetShellWindow();
            IntPtr _SHELLDLL_DefViewParent = _ProgMan;
            IntPtr _SHELLDLL_DefView = FindWindowEx(_ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
            IntPtr _SysListView32 = FindWindowEx(_SHELLDLL_DefView, IntPtr.Zero, "SysListView32", "FolderView");

            if (_SHELLDLL_DefView == IntPtr.Zero) {
                EnumWindows((hwnd, lParam) => {
                    var sb = new StringBuilder(256);
                    GetClassName(hwnd, sb, sb.Capacity);

                    if (sb.ToString() == "WorkerW") {
                        IntPtr child = FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                        if (child != IntPtr.Zero) {
                            _SHELLDLL_DefViewParent = hwnd;
                            _SHELLDLL_DefView = child;
                            _SysListView32 = FindWindowEx(child, IntPtr.Zero, "SysListView32", "FolderView");
                            ;
                            return false;
                        }
                    }
                    return true;
                }, IntPtr.Zero);
            }

            switch (desktopWindow) {
                case DesktopWindow.ProgMan:
                    return _ProgMan;
                case DesktopWindow.SHELLDLL_DefViewParent:
                    return _SHELLDLL_DefViewParent;
                case DesktopWindow.SHELLDLL_DefView:
                    return _SHELLDLL_DefView;
                case DesktopWindow.SysListView32:
                    return _SysListView32;
                default:
                    return IntPtr.Zero;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage (IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public static IntPtr MakeLParam (int wLow, int wHigh) {
            return (IntPtr) (((short) wHigh << 16) | (wLow & 0xffff));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage (IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId (IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess (ProcessAccess dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [Flags]
        public enum ProcessAccess {
            /// <summary>
            /// Required to create a thread.
            /// </summary>
            CreateThread = 0x0002,

            /// <summary>
            ///
            /// </summary>
            SetSessionId = 0x0004,

            /// <summary>
            /// Required to perform an operation on the address space of a process
            /// </summary>
            VmOperation = 0x0008,

            /// <summary>
            /// Required to read memory in a process using ReadProcessMemory.
            /// </summary>
            VmRead = 0x0010,

            /// <summary>
            /// Required to write to memory in a process using WriteProcessMemory.
            /// </summary>
            VmWrite = 0x0020,

            /// <summary>
            /// Required to duplicate a handle using DuplicateHandle.
            /// </summary>
            DupHandle = 0x0040,

            /// <summary>
            /// Required to create a process.
            /// </summary>
            CreateProcess = 0x0080,

            /// <summary>
            /// Required to set memory limits using SetProcessWorkingSetSize.
            /// </summary>
            SetQuota = 0x0100,

            /// <summary>
            /// Required to set certain information about a process, such as its priority class (see SetPriorityClass).
            /// </summary>
            SetInformation = 0x0200,

            /// <summary>
            /// Required to retrieve certain information about a process, such as its token, exit code, and priority class (see OpenProcessToken).
            /// </summary>
            QueryInformation = 0x0400,

            /// <summary>
            /// Required to suspend or resume a process.
            /// </summary>
            SuspendResume = 0x0800,

            /// <summary>
            /// Required to retrieve certain information about a process (see GetExitCodeProcess, GetPriorityClass, IsProcessInJob, QueryFullProcessImageName).
            /// A handle that has the PROCESS_QUERY_INFORMATION access right is automatically granted PROCESS_QUERY_LIMITED_INFORMATION.
            /// </summary>
            QueryLimitedInformation = 0x1000,

            /// <summary>
            /// Required to wait for the process to terminate using the wait functions.
            /// </summary>
            Synchronize = 0x100000,

            /// <summary>
            /// Required to delete the object.
            /// </summary>
            Delete = 0x00010000,

            /// <summary>
            /// Required to read information in the security descriptor for the object, not including the information in the SACL.
            /// To read or write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right.
            /// </summary>
            ReadControl = 0x00020000,

            /// <summary>
            /// Required to modify the DACL in the security descriptor for the object.
            /// </summary>
            WriteDac = 0x00040000,

            /// <summary>
            /// Required to change the owner in the security descriptor for the object.
            /// </summary>
            WriteOwner = 0x00080000,

            StandardRightsRequired = 0x000F0000,

            /// <summary>
            /// All possible access rights for a process object.
            /// </summary>
            AllAccess = StandardRightsRequired | Synchronize | 0xFFFF
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx (IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [Flags]
        public enum AllocationType {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool VirtualFreeEx (IntPtr hProcess, IntPtr lpAddress,
            int dwSize, FreeType dwFreeType);

        [Flags]
        public enum FreeType {
            Decommit = 0x4000,
            Release = 0x8000,
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle (IntPtr hHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory (IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, ref uint lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int ReadProcessMemory (IntPtr hProcess, IntPtr lpBaseAddress, [Out] IntPtr buffer, int size, ref uint lpNumberOfBytesRead);

        [DllImport("Shell32.dll")]
        public static extern int SHChangeNotify (int eventId, int flags, IntPtr item1, IntPtr item2);

        [DllImport("user32.dll")]
        public static extern bool PostMessage (IntPtr hWnd, uint Msg, int wParam, int lParam);

        // My utils for WMI
        public static string GetProcessArgs (Process process) {
            using var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id);
            using var objects = searcher.Get();
            foreach (var obj in objects) {
                return obj["CommandLine"].ToString();
            }

            return null;
        }

        public static DeviceInfo GetDeviceInfo () {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var result = new DeviceInfo();
            var osInfo = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem").Get();
            foreach (var item in osInfo) {
                result.name = item["CSName"].ToString();
                result.os = item["Caption"] + " " + item["OSArchitecture"];
                result.ram = (int) Math.Ceiling(double.Parse(item["TotalVisibleMemorySize"].ToString()) / 1024 / 1024);
            }

            var processorInfo = new ManagementObjectSearcher("SELECT * FROM Win32_Processor").Get();
            foreach (var item in processorInfo) {
                result.cpuName = item["Name"].ToString();
                result.cpuCores = int.Parse(item["NumberOfCores"].ToString());
            }

            var displayInfo = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get();
            foreach (var item in displayInfo) {
                result.videocard = item["Caption"].ToString();
                result.screenWidth = int.Parse(item["CurrentHorizontalResolution"].ToString());
                result.screenHeight = int.Parse(item["CurrentVerticalResolution"].ToString());
                result.bpp = int.Parse(item["CurrentBitsPerPixel"].ToString());
            }

            return result;
        }

        // Date & Time section
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetSystemTime (ref SYSTEMTIME st);

        public static bool SetSystemTime (DateTime date) {
            var st = new SYSTEMTIME {
                wYear = (short) date.Year,
                wMonth = (short) date.Month,
                wDayOfWeek = (short) date.DayOfWeek,
                wDay = (short) date.Day,
                wHour = (short) date.Hour,
                wMinute = (short) date.Minute,
                wSecond = (short) date.Second,
                wMilliseconds = (short) date.Millisecond
            };

            return SetSystemTime(ref st);
        }

        public enum SW : int {
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            HIDE = 0,

            /// <summary>
            /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            SHOWNORMAL = 1,

            /// <summary>
            /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
            /// </summary>
            NORMAL = 1,

            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            SHOWMINIMIZED = 2,

            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>
            SHOWMAXIMIZED = 3,

            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            MAXIMIZE = 3,

            /// <summary>
            /// Displays a window in its most recent size and position. This value is similar to <see cref="SW.SHOWNORMAL"/>, except the window is not activated.
            /// </summary>
            SHOWNOACTIVATE = 4,

            /// <summary>
            /// Activates the window and displays it in its current size and position.
            /// </summary>
            SHOW = 5,

            /// <summary>
            /// Minimizes the specified window and activates the next top-level window in the z-order.
            /// </summary>
            MINIMIZE = 6,

            /// <summary>
            /// Displays the window as a minimized window. This value is similar to <see cref="SW.SHOWMINIMIZED"/>, except the window is not activated.
            /// </summary>
            SHOWMINNOACTIVE = 7,

            /// <summary>
            /// Displays the window in its current size and position. This value is similar to <see cref="SW.SHOW"/>, except the window is not activated.
            /// </summary>
            SHOWNA = 8,

            /// <summary>
            /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
            /// </summary>
            RESTORE = 9,

            /// <summary>
            /// Items 10, 11 and 11 existed in the VB definition but not the c# definition - so I am assuming this was a mistake and have added them here.
            ///  Please forgive me if this is wrong!  I don't think it should have any negative impact.
            ///  According to what I have read elsewhere: The SHOWDEFAULT makes sure the window is restored prior to showing, then activating.
            ///  And the 11's try to coerce a window to minimized or maximized.
            /// </summary>
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11,
            MAX = 11
        }

        [DllImport("user32.dll")]
        public static extern bool ShowWindow (IntPtr hWnd, int nCmdShow);

        public enum GWL {
            /// <summary>Sets a new address for the window procedure.</summary>
            /// <remarks>You cannot change this attribute if the window does not belong to the same process as the calling thread.</remarks>
            WNDPROC = -4,

            /// <summary>Sets a new application instance handle.</summary>
            GWLP_HINSTANCE = -6,

            GWLP_HWNDPARENT = -8,

            /// <summary>Sets a new identifier of the child window.</summary>
            /// <remarks>The window cannot be a top-level window.</remarks>
            ID = -12,

            /// <summary>Sets a new window style.</summary>
            STYLE = -16,

            /// <summary>Sets a new extended window style.</summary>
            /// <remarks>See <see cref="ExWindowStyles"/>.</remarks>
            EXSTYLE = -20,

            /// <summary>Sets the user data associated with the window.</summary>
            /// <remarks>This data is intended for use by the application that created the window. Its value is initially zero.</remarks>
            USERDATA = -21,

            /// <summary>Sets the return value of a message processed in the dialog box procedure.</summary>
            /// <remarks>Only applies to dialog boxes.</remarks>
            MSGRESULT = 0,

            /// <summary>Sets new extra information that is private to the application, such as handles or pointers.</summary>
            /// <remarks>Only applies to dialog boxes.</remarks>
            USER = 8,

            /// <summary>Sets the new address of the dialog box procedure.</summary>
            /// <remarks>Only applies to dialog boxes.</remarks>
            DLGPROC = 4
        }

        public enum WS: uint {
            OVERLAPPED = 0x00000000,
            POPUP = 0x80000000,
            CHILD = 0x40000000,
            MINIMIZE = 0x20000000,
            VISIBLE = 0x10000000,
            DISABLED = 0x08000000,
            CLIPSIBLINGS = 0x04000000,
            CLIPCHILDREN = 0x02000000,
            MAXIMIZE = 0x01000000,
            CAPTION = 0x00C00000,     /* WS_BORDER | WS_DLGFRAME  */
            BORDER = 0x00800000,
            DLGFRAME = 0x00400000,
            VSCROLL = 0x00200000,
            HSCROLL = 0x00100000,
            SYSMENU = 0x00080000,
            THICKFRAME = 0x00040000,
            GROUP = 0x00020000,
            TABSTOP = 0x00010000,

            MINIMIZEBOX = 0x00020000,
            MAXIMIZEBOX = 0x00010000,

            EX_DLGMODALFRAME = 0x00000001,
            EX_NOPARENTNOTIFY = 0x00000004,
            EX_TOPMOST = 0x00000008,
            EX_ACCEPTFILES = 0x00000010,
            EX_TRANSPARENT = 0x00000020,
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLong (IntPtr hWnd, int nIndex, uint dwNewLong);
    }
}
