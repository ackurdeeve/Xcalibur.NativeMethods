using System;
using Xcalibur.NativeMethods.Monitors;

namespace Xcalibur.NativeMethods.Extensions.Monitors
{
    /// <summary>
    /// Monitor information with handle interface.
    /// </summary>
    public interface IMonitorInfoWithHandle
    {
        IntPtr MonitorHandle { get; }
        MONITORINFO MonitorInfo { get; }
    }
}
