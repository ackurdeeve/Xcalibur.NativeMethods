using System;
using Xcalibur.NativeMethods.Events;

namespace Xcalibur.NativeMethods.Extensions.Events
{
    /// <summary>
    /// Window handle, hook handle, and hook delegate
    /// </summary>
    public class WindowHandleAndHooks
    {
        public IntPtr MainWindowHandle { get; private set; }
        public int HookHandle { get; private set; }
        public EventHelper.HookProc HookCallBackDelegate { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowHandleAndHooks"/> class.
        /// </summary>
        /// <param name="mainWindowHandle">The main window handle.</param>
        /// <param name="hookHandle">The hook handle.</param>
        /// <param name="hookCallBackDelegate">The hook call back delegate.</param>
        public WindowHandleAndHooks(IntPtr mainWindowHandle, int hookHandle, 
            EventHelper.HookProc hookCallBackDelegate)
        {
            MainWindowHandle = mainWindowHandle;
            HookHandle = hookHandle;
            HookCallBackDelegate = hookCallBackDelegate;
        }
    }
}
