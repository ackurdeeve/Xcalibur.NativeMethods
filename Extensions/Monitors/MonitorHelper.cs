using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Xcalibur.NativeMethods.Monitors;
using Xcalibur.NativeMethods.Windows;
using NativeMonitorHelper = Xcalibur.NativeMethods.Monitors.MonitorHelper;

namespace Xcalibur.NativeMethods.Extensions.Monitors
{
    public static class MonitorHelper
    {
        private static IList<MonitorInfoWithHandle> _monitorInfos;

        /// <summary>
        /// Gets the monitors.
        /// </summary>
        /// <returns></returns>
        public static MonitorInfoWithHandle[] GetMonitors()
        {
            // New List
            _monitorInfos = new List<MonitorInfoWithHandle>();

            // Enumerate monitors
            NativeMonitorHelper.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnum, IntPtr.Zero);

            // Return list
            return _monitorInfos.ToArray();
        }

        /// <summary>
        /// Monitors the enum.
        /// </summary>
        /// <param name="hMonitor">The h monitor.</param>
        /// <param name="hdcMonitor">The HDC monitor.</param>
        /// <param name="lprcMonitor">The LPRC monitor.</param>
        /// <param name="dwData">The dw data.</param>
        /// <returns></returns>
        public static bool MonitorEnum(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
        {
            var mi = new MONITORINFO();
            mi.size = (uint)Marshal.SizeOf(mi);
            NativeMonitorHelper.GetMonitorInfo(hMonitor, ref mi);

            // Add to monitor info
            _monitorInfos.Add(new MonitorInfoWithHandle(hMonitor, mi));
            return true;
        }

        /// <summary>
        /// Clips the or center rect to monitor.
        /// </summary>
        /// <param name="windowArea">The window area.</param>
        /// <param name="mi">The mi.</param>
        /// <param name="flags">The flags.</param>
        public static void ClipOrCenterRectToMonitor(
            ref RECT windowArea, MONITORINFO mi, UInt32 flags)
        {
            RECT rc;
            int width = windowArea.right - windowArea.left;
            int height = windowArea.bottom - windowArea.top;

            // Get monitor area
            rc = flags == MonitorArea.MONITOR_WORKAREA ? mi.work : mi.monitor;

            // Center or clip the passed rect to the monitor rect 
            if (flags == MonitorArea.MONITOR_CENTER)
            {
                windowArea.left = rc.left + (rc.right - rc.left - width) / 2;
                windowArea.top = rc.top + (rc.bottom - rc.top - height) / 2;
                windowArea.right = windowArea.left + width;
                windowArea.bottom = windowArea.top + height;
            }
            else
            {
                windowArea.left = Math.Max(rc.left, Math.Min(rc.right - width, windowArea.left));
                windowArea.top = Math.Max(rc.top, Math.Min(rc.bottom - height, windowArea.top));
                windowArea.right = windowArea.left + width;
                windowArea.bottom = windowArea.top + height;
            }
        }

        /// <summary>
        /// Clips the or center window to monitor.
        /// </summary>
        /// <param name="handle">The HWND.</param>
        /// <param name="mi">The mi.</param>
        /// <param name="flags">The flags.</param>
        public static void ClipOrCenterWindowToMonitor(IntPtr handle, MONITORINFO mi, UInt32 flags)
        {
            var windowArea = new RECT();
            NativeMonitorHelper.GetWindowRect(handle, ref windowArea);
            ClipOrCenterRectToMonitor(ref windowArea, mi, flags);
            WindowHelper.SetWindowPos(handle, WindowZOrder.HWND_TOP, windowArea.left, windowArea.top,
                0, 0, WindowsPosition.SWP_NOSIZE | WindowsPosition.SWP_NOZORDER | WindowsPosition.SWP_NOACTIVATE);
        }
    }
}
