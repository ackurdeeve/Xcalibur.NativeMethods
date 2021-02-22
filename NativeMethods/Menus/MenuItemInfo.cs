using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Menus
{
    /// <summary>
    /// Menu item information.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MENUITEMINFO
    {
        public uint Size;
        public uint Mask;
        public uint Type;
        public uint State;
        public uint Identifier;
        public IntPtr SubMenuHandle;
        public IntPtr CheckedBitmapHandle;
        public IntPtr UncheckedBitmapHandle;
        public IntPtr ItemData;
        public string TypeData;
        public uint TextLength;
        public IntPtr DisplayBitmapHandle;
    }
}
