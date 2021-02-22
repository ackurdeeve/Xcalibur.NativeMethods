using System;
using System.Runtime.InteropServices;

namespace Xcalibur.Win32.Win32ApiHelper
{
    public class EventHook
    {
        /// <summary>
        /// Event delegate
        /// </summary>
        /// <param name="hWinEventHook">The h win event hook.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="idObject">The identifier object.</param>
        /// <param name="idChild">The identifier child.</param>
        /// <param name="dwEventThread">The dw event thread.</param>
        /// <param name="dwmsEventTime">The DWMS event time.</param>
        public delegate void WinEventDelegate(
            IntPtr hWinEventHook,
            uint eventType,
            IntPtr hWnd,
            int idObject,
            int idChild,
            uint dwEventThread,
            uint dwmsEventTime);

        /// <summary>
        /// Sets the win event hook.
        /// </summary>
        /// <param name="eventMin">The event minimum.</param>
        /// <param name="eventMax">The event maximum.</param>
        /// <param name="hmodWinEventProc">The hmod win event proc.</param>
        /// <param name="lpfnWinEventProc">The LPFN win event proc.</param>
        /// <param name="idProcess">The identifier process.</param>
        /// <param name="idThread">The identifier thread.</param>
        /// <param name="dwFlags">The dw flags.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetWinEventHook(
            uint eventMin,
            uint eventMax,
            IntPtr hmodWinEventProc,
            WinEventDelegate lpfnWinEventProc,
            uint idProcess,
            uint idThread,
            uint dwFlags);

        /// <summary>
        /// Unhooks the win event.
        /// </summary>
        /// <param name="hWinEventHook">The h win event hook.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        #region Members

        public const uint EVENT_SYSTEM_FOREGROUND = 3;
        public const uint WINEVENT_OUTOFCONTEXT = 0;
        public const uint EVENT_OBJECT_CREATE = 0x8000;

        private readonly WinEventDelegate _procDelegate;
        private readonly IntPtr _hWinEventHook;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHook"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="eventMin">The event minimum.</param>
        /// <param name="eventMax">The event maximum.</param>
        public EventHook(WinEventDelegate handler, uint eventMin, uint eventMax)
        {
            _procDelegate = handler;
            _hWinEventHook = SetWinEventHook(eventMin, eventMax, IntPtr.Zero, handler, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHook"/> class.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="eventMin">The event minimum.</param>
        public EventHook(WinEventDelegate handler, uint eventMin)
            : this(handler, eventMin, eventMin)
        {
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            UnhookWinEvent(_hWinEventHook);
        }

        #endregion
    }
}