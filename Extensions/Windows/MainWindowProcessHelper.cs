using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xcalibur.NativeMethods.Monitors;
using Xcalibur.NativeMethods.Windows;

namespace Xcalibur.NativeMethods.Extensions.Windows
{
    public static class MainWindowProcessHelper
    {
        private static IList<IMainWindowProcess> _enumeratedWindows;

        /// <summary>
        /// Retrieves a list of all main window handles and their associated process id's.
        /// </summary>
        /// <returns></returns>
        public static IMainWindowProcess[] GetMainWindowProcesses()
        {
            // new list
            _enumeratedWindows = new List<IMainWindowProcess>();

            // Enumerate windows
            WindowHelper.EnumWindows(EnumTheWindows, IntPtr.Zero);

            // Return list
            return _enumeratedWindows.ToArray();
        }

        /// <summary>
        /// Enumerates through each window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        private static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            int size = WindowHelper.GetWindowTextLength(hWnd);

            // Get window area
            var rect = new RECT();
            MonitorHelper.GetWindowRect(hWnd, ref rect);

            // Evaluate
            if (size++ <= 0 || !WindowHelper.IsWindowVisible(hWnd)) return true;

            // Get window title
            var sb = new StringBuilder(size);
            WindowHelper.GetWindowText(hWnd, sb, size);

            // Get owning process id
            int processId = 0;
            WindowHelper.GetWindowThreadProcessId(hWnd, out processId);

            // Get current monitor
            var monitorHandle = MonitorHelper.MonitorFromRect(ref rect, MonitorPostion.MONITOR_DEFAULTTONEAREST);

            // Window rectange - valid
            var isWindowRectValid = MonitorHelper.IsWindowRectValid(rect);

            // Window state
            var isWindowResponding = !WindowHelper.IsHungAppWindow(hWnd);

            // Add to enumerated windows
            _enumeratedWindows.Add(
                new MainWindowProcess(processId, hWnd, sb.ToString(),
                    monitorHandle, rect, isWindowRectValid, isWindowResponding));
            return true;
        }
    }
}
