using System;

namespace Xcalibur.NativeMethods.Events
{
    public struct CWPSTRUCT
    {
        public IntPtr lParam;
        public IntPtr wParam;
        public uint message;
        public IntPtr hwnd;
    }
}
