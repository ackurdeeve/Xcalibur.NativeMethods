using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Events
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KBLLHOOKSTRUCT
    {
        public int KeyCode;
        public int ScanCode;
        public int Flags;
        public int Time;
        public int ExtraInfo;
    }
}
