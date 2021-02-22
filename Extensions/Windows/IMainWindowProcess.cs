using System;
using Xcalibur.NativeMethods.Monitors;

namespace Xcalibur.NativeMethods.Extensions.Windows
{
    /// <summary>
    /// Main Window Process interface.
    /// </summary>
    public interface IMainWindowProcess
    {
        int ProcessId { get; }
        IntPtr MainWindowHandle { get; }
        string MainWindowTitle { get; }
        IntPtr MonitorHandle { get; set; }
        RECT WindowRect { get; set; }
        bool IsWindowRectValid { get; set; }
        bool IsWindowResponding { get; }
    }
}
