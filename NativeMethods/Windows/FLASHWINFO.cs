using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Windows
{
    /// <summary>
    /// Flash Window Information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
        public UInt32 cbSize;
        public IntPtr hwnd;
        public UInt32 dwFlags;
        public UInt32 uCount;
        public UInt32 dwTimeout;
    }
}
