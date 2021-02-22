using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Xcalibur.NativeMethods.Windows
{
    /// <summary>
    /// Win32 API Helper: Windows
    /// </summary>
    public static class WindowHelper
    {
        #region Members

        // Events
        public static uint EVENT_SYSTEM_FOREGROUND = 3;
        public static uint WINEVENT_OUTOFCONTEXT = 0;

        #endregion

        #region Methods

        /// <summary>
        /// EnumWindows Processor (delegate)
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// Enums the windows.
        /// </summary>
        /// <param name="enumProc">The enum proc.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        /// <summary>
        /// Flashes the window.
        /// </summary>
        /// <param name="pwfi">The pwfi.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        /// Gets the active window.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        /// <summary>
        /// Gets the foreground window.
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Sets the foreground window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// Locks the set foreground window.
        /// </summary>
        /// <param name="uLockCode">The u lock code.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool LockSetForegroundWindow(uint uLockCode);

        /// <summary>
        /// Gets the window thread process identifier.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="processId">The process identifier.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int processId);

        /// <summary>
        /// Gets the window text.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="lpString">The lp string.</param>
        /// <param name="nMaxCount">The n maximum count.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, [Out] StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// Gets the length of the window text.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// Determines whether [is window visible] [the specified h WND].
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is maximized.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);

        /// <summary>
        /// Determines whether the specified window is minimized.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// Determines whether [is hung application window] [the specified h WND].
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool IsHungAppWindow(IntPtr hWnd);

        /// <summary>
        /// Finds the window ex.
        /// </summary>
        /// <param name="hwndParent">The HWND parent.</param>
        /// <param name="hwndChildAfter">The HWND child after.</param>
        /// <param name="strClassName">Name of the string class.</param>
        /// <param name="strWindowName">Name of the string window.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string strClassName, string strWindowName);

        /// <summary>
        /// Finds the window.
        /// </summary>
        /// <param name="sClassName">Name of the s class.</param>
        /// <param name="sAppName">Name of the s application.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        /// <summary>
        /// Gets the ancestor of the provided window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="flags">The flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, int flags);

        /// <summary>
        /// Enables the window.
        /// </summary>
        /// <param name="hwnd">The HWND.</param>
        /// <param name="bEnable">if set to <c>true</c> [b enable].</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool EnableWindow(IntPtr hwnd, bool bEnable);

        /// <summary>
        /// Shows the window asynchronous.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="nCmdShow">The n command show.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Sets the window position.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="hWndInsertAfter">The h WND insert after.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="cx">The cx.</param>
        /// <param name="cy">The cy.</param>
        /// <param name="uFlags">The u flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
            int x, int y, int cx, int cy, uint uFlags);
        
        #endregion
    }
}