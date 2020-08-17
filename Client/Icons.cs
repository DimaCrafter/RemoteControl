using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

class Icons {
    [DllImport("Shell32", CharSet = CharSet.Unicode)]
    private static extern int ExtractIconEx (
        string lpszFile,
        int nIconIndex,
        IntPtr[] phIconLarge,
        IntPtr[] phIconSmall,
        int nIcons
    );

    [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
    private static extern int DestroyIcon (IntPtr hIcon);

    private static IntPtr GetHandle (string file, int index, bool isLarge) {
        var large = new IntPtr[1];
        var small = new IntPtr[1];
        ExtractIconEx(file, index, large, small, 1);
        return isLarge ? large[0] : small[0];
    }

    public static Icon GetSystemIcon (string file, int index, bool isLarge) {
        try { return Icon.FromHandle(GetHandle(file, index, isLarge)); }
        catch { return null; }
    }

    public static Bitmap GetSystemBitmap (string file, int index, bool isLarge) {
        return GetSystemIcon(file, index, isLarge)?.ToBitmap();
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct SHFILEINFO {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    [DllImport("shell32.dll")]
    private static extern IntPtr SHGetFileInfo (string path, uint attributes, ref SHFILEINFO info, uint size, uint flags);

    private const uint SHGFI_ICON = 0x100;
    private const uint SHGFI_LARGEICON = 0x0;

    public static Icon GetFileIcon (string path) {
        SHFILEINFO shinfo = new SHFILEINFO();
        SHGetFileInfo(path, 0, ref shinfo, (uint) Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);

        return shinfo.hIcon == IntPtr.Zero ? null : Icon.FromHandle(shinfo.hIcon);
    }

    public static Bitmap GetFileBitmap (string file) {
        return GetFileIcon(file)?.ToBitmap();
    }
}
