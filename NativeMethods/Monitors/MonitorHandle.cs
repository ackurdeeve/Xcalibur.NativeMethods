using System;

namespace Xcalibur.NativeMethods.Monitors
{
    public interface IMonitorInfoWithHandle
    {
        IntPtr MonitorHandle { get; }
        MONITORINFO MonitorInfo { get; }
    }
    
    public class MonitorInfoWithHandle : IMonitorInfoWithHandle
    {
        /// <summary>
        /// Gets the monitor handle.
        /// </summary>
        /// <value>
        /// The monitor handle.
        /// </value>
        public IntPtr MonitorHandle { get; private set; }
 
        /// <summary>
        /// Gets the monitor information.
        /// </summary>
        /// <value>
        /// The monitor information.
        /// </value>
        public MONITORINFO MonitorInfo { get; private set; }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="MonitorInfoWithHandle"/> class.
        /// </summary>
        /// <param name="monitorHandle">The monitor handle.</param>
        /// <param name="monitorInfo">The monitor information.</param>
        public MonitorInfoWithHandle(IntPtr monitorHandle, MONITORINFO monitorInfo)
        {
            MonitorHandle = monitorHandle;
            MonitorInfo = monitorInfo;
        }
    }
}