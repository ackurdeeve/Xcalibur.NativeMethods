using System;
using Xcalibur.NativeMethods.Monitors;

namespace Xcalibur.NativeMethods.Extensions.Windows
{
    /// <summary>
    /// Main Window Process.
    /// </summary>
    internal class MainWindowProcess : IMainWindowProcess
    {
        #region Properties
        
        /// <summary>
        /// Gets the process identifier.
        /// </summary>
        /// <value>
        /// The process identifier.
        /// </value>
        public int ProcessId { get; private set; }

        /// <summary>
        /// Gets the main window handle.
        /// </summary>
        /// <value>
        /// The main window handle.
        /// </value>
        public IntPtr MainWindowHandle { get; private set; }

        /// <summary>
        /// Gets the main window title.
        /// </summary>
        /// <value>
        /// The main window title.
        /// </value>
        public string MainWindowTitle { get; private set; }

        /// <summary>
        /// Gets or sets the monitor handle.
        /// </summary>
        /// <value>
        /// The monitor handle.
        /// </value>
        public IntPtr MonitorHandle { get; set; }

        /// <summary>
        /// Gets the window rect.
        /// </summary>
        /// <value>
        /// The window rect.
        /// </value>
        public RECT WindowRect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is window rect valid.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is window rect valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsWindowRectValid { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is window responding.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is window responding; otherwise, <c>false</c>.
        /// </value>
        public bool IsWindowResponding { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowProcess" /> class.
        /// </summary>
        /// <param name="processId">The process identifier.</param>
        /// <param name="mainWindowHandle">The main window handle.</param>
        /// <param name="mainWindowTitle">The main window title.</param>
        /// <param name="monitorHandle">The monitor handle.</param>
        /// <param name="windowRect">The window rect.</param>
        /// <param name="isWindowRectValid">if set to <c>true</c> [is window rect valid].</param>
        /// <param name="isWindowResponding">if set to <c>true</c> [is window responding].</param>
        public MainWindowProcess(int processId, IntPtr mainWindowHandle, string mainWindowTitle,
            IntPtr monitorHandle, RECT windowRect, bool isWindowRectValid, 
            bool isWindowResponding)
        {
            ProcessId = processId;
            MainWindowHandle = mainWindowHandle;
            MainWindowTitle = mainWindowTitle;
            MonitorHandle = monitorHandle;
            WindowRect = windowRect;
            IsWindowRectValid = isWindowRectValid;
            IsWindowResponding = isWindowResponding;
        }

        #endregion
    }
}
