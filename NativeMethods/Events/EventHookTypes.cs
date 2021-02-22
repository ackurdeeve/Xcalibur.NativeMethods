namespace Xcalibur.NativeMethods.Events
{
    /// <summary>
    /// Event hook types
    /// </summary>
    public static class EventHookTypes
    {
        public static readonly int WH_MSGFILTER = -1;
        public static readonly int WH_JOURNALRECORD = 0;
        public static readonly int WH_JOURNALPLAYBACK = 1;
        public static readonly int WH_KEYBOARD = 2;
        public static readonly int WH_GETMESSAGE = 3;
        public static readonly int WH_CALLWNDPROC = 4;
        public static readonly int WH_CBT = 5;
        public static readonly int WH_SYSMSGFILTER = 6;
        public static readonly int WH_MOUSE = 7;
        public static readonly int WH_HARDWARE = 8;
        public static readonly int WH_DEBUG = 9;
        public static readonly int WH_SHELL = 10;
        public static readonly int WH_FOREGROUNDIDLE = 11;
        public static readonly int WH_CALLWNDPROCRET = 12;
        public static readonly int WH_KEYBOARD_LL = 13;
        public static readonly int WH_MOUSE_LL = 14;
    }
}
