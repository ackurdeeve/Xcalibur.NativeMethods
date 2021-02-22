using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Xcalibur.NativeMethods.Monitors
{
    /// <summary>
    /// Native Monitor methods.
    /// </summary>
    public static class MonitorHelper
    {
        #region Members

        public const int OFF_CANVAS_KEY = -32000;

        #endregion

        /// <summary>
        /// Monitor Enum Delegate
        /// </summary>
        /// <param name="hMonitor">The h monitor.</param>
        /// <param name="hdcMonitor">The HDC monitor.</param>
        /// <param name="lprcMonitor">The LPRC monitor.</param>
        /// <param name="dwData">The dw data.</param>
        /// <returns></returns>
        public delegate bool MonitorEnumDelegate(IntPtr hMonitor, IntPtr hdcMonitor,
            ref RECT lprcMonitor, IntPtr dwData);

        /// <summary>
        /// Determines whether [is window rect valid] [the specified rect].
        /// </summary>
        /// <param name="rect">The rect.</param>
        /// <returns></returns>
        public static bool IsWindowRectValid(RECT rect)
        {
            return rect.top != OFF_CANVAS_KEY &&
                   rect.bottom != OFF_CANVAS_KEY &&
                   rect.left != OFF_CANVAS_KEY &&
                   rect.right != OFF_CANVAS_KEY;
        }

        /// <summary>
        /// Gets the rectangle representing the frame of a window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref RECT rectangle);

        /// <summary>
        /// Enums the display monitors.
        /// </summary>
        /// <param name="hdc">The HDC.</param>
        /// <param name="lprcClip">The LPRC clip.</param>
        /// <param name="lpfnEnum">The LPFN enum.</param>
        /// <param name="dwData">The dw data.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip,
            MonitorEnumDelegate lpfnEnum, IntPtr dwData);
        
        /// <summary>
        /// Gets the monitor information.
        /// </summary>
        /// <param name="hmon">The hmon.</param>
        /// <param name="mi">The mi.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetMonitorInfo(IntPtr hmon, ref MONITORINFO mi);

        /// <summary>
        /// Monitors from rect.
        /// </summary>
        /// <param name="lprc">The LPRC.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromRect([In] ref RECT lprc, uint dwFlags);
        
        /// <summary>
        /// A simple class to group our handles.
        /// </summary>
        /// <returns></returns>
    }
}
