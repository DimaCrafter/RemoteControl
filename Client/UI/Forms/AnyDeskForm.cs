using RCClient.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RCClient.UI.Forms {
    public partial class AnyDeskForm : Form {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent (IntPtr child, IntPtr parent);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos (IntPtr window, IntPtr hWndInsertAfter, int x, int y, int width, int height, uint flags);

        [DllImport("user32.dll")]
        static extern int SendMessage (IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        struct POINT {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MINMAXINFO {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT minSize;
            public POINT maxSize;
        }

        enum WinMsg: uint {
            GetMinMaxInfo = 0x0024
        }

        private Process anydesk;
        public static readonly string ANYDESK_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\AnyDesk\AnyDesk.exe";
        public readonly string ip;
        public AnyDeskForm (string ip) {
            InitializeComponent();
            this.ip = ip;
        }

        private void onWindowResize (object sender = null, EventArgs e = null) {
            // 0x10 - SWP_NOACTIVATE
            SetWindowPos(anydesk.MainWindowHandle, IntPtr.Zero, -1, -32, windowPanel.Width + 2, windowPanel.Height + 34, 0x10);
        }

        private async void button1_Click (object sender, EventArgs e) {
            if (!File.Exists(ANYDESK_PATH)) {
                statusImg.Image = Resources.close;
                statusLabel.Text = "Данная фунция не доступна без установленного AnyDesk";
                return;
            }

            statusLabel.Text = "Подключение к " + ip + "...";
            var device = await Device.Connect(IPAddress.Parse(ip));

            statusLabel.Text = "Проверка установки AnyDesk...";
            var passwd = device.RequestControl();

            statusLabel.Text = "Запуск сессии...";
            anydesk = Process.Start(new ProcessStartInfo {
                FileName = ANYDESK_PATH,
                Arguments = "--plain --with-password " + ip + ":3170",
                RedirectStandardInput = true,
                UseShellExecute = false
            });

            anydesk.StandardInput.WriteLine(passwd);

            // Allow the process to open it's window
            System.Threading.Thread.Sleep(500);
            statusImg.Dispose();
            statusLabel.Dispose();
            SetParent(anydesk.MainWindowHandle, windowPanel.Handle);

            var ptr = Marshal.AllocHGlobal(Marshal.SizeOf<MINMAXINFO>());
            SendMessage(anydesk.MainWindowHandle, (uint) WinMsg.GetMinMaxInfo, IntPtr.Zero, ptr);
            var winInfo = Marshal.PtrToStructure<MINMAXINFO>(ptr);

            var dx = Width - windowPanel.Width;
            var dy = Height - windowPanel.Height;
            MinimumSize = new System.Drawing.Size(winInfo.minSize.X + dx, winInfo.minSize.Y + dy);
            onWindowResize();
        }
    }
}
