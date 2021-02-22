using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Monitors
{
    /// <summary>
    /// Monitor information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MONITORINFO
    {
        public uint size;
        public RECT monitor;
        public RECT work;
        public uint flags;
    }
}
