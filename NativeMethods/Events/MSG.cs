using System;

namespace Xcalibur.NativeMethods.Events
{
    public struct MSG
    {
        public IntPtr hwnd;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public IntPtr time;
        public POINT pt;
    }
}
