using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Security
{
    /// <summary>
    /// Security Attributes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int Length;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }
}
