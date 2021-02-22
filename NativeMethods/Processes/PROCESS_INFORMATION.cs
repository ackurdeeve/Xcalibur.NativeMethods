using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Processes
{
    /// <summary>
    /// Process information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_INFORMATION
    {
        public IntPtr hProcess;
        public IntPtr hThread;
        public uint dwProcessId;
        public uint dwThreadId;
    }
}
