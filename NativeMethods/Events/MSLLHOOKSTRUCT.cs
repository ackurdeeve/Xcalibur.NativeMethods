using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Events
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MSLLHOOKSTRUCT
    {
        public POINT Point;
        public IntPtr MouseData;
        public IntPtr Flags;
        public IntPtr Time;
        public UIntPtr ExtraInfo;
    }
}
