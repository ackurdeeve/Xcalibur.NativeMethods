using System;

namespace Xcalibur.NativeMethods.Windows
{
    public static class WindowZOrder
    {
        public static IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static IntPtr HWND_BOTTOM = new IntPtr(1);
        public static IntPtr HWND_TOP = new IntPtr(0);
    }
}
