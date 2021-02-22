using System;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Events
{
    public static class EventHelper
    {
        /// <summary>
        /// Hook Processor.
        /// </summary>
        /// <param name="nCode">The n code.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Sets the windows hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <param name="lpfn">The LPFN.</param>
        /// <param name="hInstance">The h instance.</param>
        /// <param name="threadId">The thread identifier.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        /// <summary>
        /// Unhooks the windows hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        /// <summary>
        /// Calls the next hook ex.
        /// </summary>
        /// <param name="idHook">The identifier hook.</param>
        /// <param name="nCode">The n code.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Gets the state of the key.
        /// </summary>
        /// <param name="nVirtKey">The n virt key.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int nVirtKey);

        /// <summary>
        /// Loads the library.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LoadLibrary(string filename);

        /// <summary>
        /// Gets the module handle.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetModuleHandle(string filename);
    }
}
