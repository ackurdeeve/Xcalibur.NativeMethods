using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xcalibur.NativeMethods.Monitors;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var _monitorInfos = new List<MonitorInfoWithHandle>();

            GetMonitors();
                
            /// <summary>
            /// Monitor Enum Delegate
            /// </summary>
            /// <param name="hMonitor">A handle to the display monitor.</param>
            /// <param name="hdcMonitor">A handle to a device context.</param>
            /// <param name="lprcMonitor">A pointer to a RECT structure.</param>
            /// <param name="dwData">Application-defined data that EnumDisplayMonitors passes directly to the enumeration function.</param>
            /// <returns></returns>
            bool MonitorEnum(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData)
            {
                var mi = new MONITORINFO();
                mi.size = (uint)Marshal.SizeOf(mi);
                MonitorHelper.GetMonitorInfo(hMonitor, ref mi);
 
                // Add to monitor info
                _monitorInfos.Add(new MonitorInfoWithHandle(hMonitor, mi));
                return true;
            }

            /// <summary>
            /// Gets the monitors.
            /// </summary>
            /// <returns></returns>
            MonitorInfoWithHandle[] GetMonitors()
            {
                // New List
                _monitorInfos = new List<MonitorInfoWithHandle>();
 
                // Enumerate monitors
                MonitorHelper.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnum, IntPtr.Zero);
 
                // Return list
                return _monitorInfos.ToArray();
            }
            


            DEVICE_SCALE_FACTOR scaleValue1;
            DEVICE_SCALE_FACTOR scaleValue2;
            
            var monitor1 = _monitorInfos[0].MonitorHandle;
            GetScaleFactorForMonitor(monitor1,out scaleValue1);
            var monitor2 =  _monitorInfos[1].MonitorHandle;
            GetScaleFactorForMonitor(monitor2,out scaleValue2);
            

            Console.ReadKey();
        }
        
        [DllImport("Shcore.dll")]
        public static extern int GetScaleFactorForMonitor(IntPtr hMon, out DEVICE_SCALE_FACTOR value);

        public static int GetScale(IntPtr hWnd)
        {
            int res = GetScaleFactorForMonitor(hWnd, out DEVICE_SCALE_FACTOR value);
            return res;
        }

        public enum DEVICE_SCALE_FACTOR
        {
            // DEVICE_SCALE_FACTOR_INVALID,
            // SCALE_100_PERCENT,
            // SCALE_120_PERCENT,
            // SCALE_125_PERCENT,
            // SCALE_140_PERCENT,
            // SCALE_150_PERCENT,
            // SCALE_160_PERCENT,
            // SCALE_175_PERCENT,
            // SCALE_180_PERCENT,
            // SCALE_200_PERCENT,
            // SCALE_225_PERCENT,
            // SCALE_250_PERCENT,
            // SCALE_300_PERCENT,
            // SCALE_350_PERCENT,
            // SCALE_400_PERCENT,
            // SCALE_450_PERCENT,
            // SCALE_500_PERCENT
        } 
        
       
    }
}