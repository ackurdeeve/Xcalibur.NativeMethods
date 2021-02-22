using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using Xcalibur.NativeMethods.Processes;
using Xcalibur.NativeMethods.Security;
using Xcalibur.NativeMethods.Windows;
using NativeProcessHelper = Xcalibur.NativeMethods.Processes.ProcessHelper;

namespace Xcalibur.NativeMethods.Extensions.Processes
{
    public static class ProcessHelper
    {
        /// <summary>
        /// Launches the given application with full admin rights, and in addition bypasses the Vista UAC prompt
        /// http://www.codeproject.com/Articles/35773/Subverting-Vista-UAC-in-Both-and-bit-Archite
        /// </summary>
        /// <param name="applicationName">The name of the application to launch</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="procInfo">Process information regarding the launched application that gets returned to the caller</param>
        /// <param name="consoleState">State of the console.</param>
        /// <param name="showWindow">The show window.</param>
        /// <returns></returns>
        public static bool StartProcessAndBypassUAC(string applicationName, string arguments,
            out PROCESS_INFORMATION procInfo, int consoleState = ConsoleState.CREATE_NEW_CONSOLE,
            int showWindow = WindowState.SW_SHOWNORMAL)
        {
            uint winlogonPid = 0;
            IntPtr hUserTokenDup = IntPtr.Zero, hPToken = IntPtr.Zero, hProcess = IntPtr.Zero;
            procInfo = new PROCESS_INFORMATION();

            // obtain the currently active session id; every logged on user in the system has a unique session id
            uint dwSessionId = NativeProcessHelper.WTSGetActiveConsoleSessionId();

            // obtain the process id of the winlogon process that is running within the currently active session
            var processes = Process.GetProcessesByName("winlogon");
            var process = processes.FirstOrDefault(x => (uint)x.SessionId == dwSessionId);
            if (process == null) return false;
            winlogonPid = (uint)process.Id;

            // obtain a handle to the winlogon process
            hProcess = NativeProcessHelper.OpenProcess(ConsoleState.MAXIMUM_ALLOWED, false, winlogonPid);

            // obtain a handle to the access token of the winlogon process
            if (!NativeProcessHelper.OpenProcessToken(hProcess, ConsoleState.TOKEN_DUPLICATE, ref hPToken))
            {
                NativeProcessHelper.CloseHandle(hProcess);
                return false;
            }

            //// Security attibute structure used in DuplicateTokenEx and CreateProcessAsUser
            //// I would prefer to not have to use a security attribute variable and to just 
            //// simply pass null and inherit (by default) the security attributes
            //// of the existing token. However, in C# structures are value types and therefore
            //// cannot be assigned the null value.
            var sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);

            // copy the access token of the winlogon process; the newly created token will be a primary token
            if (!NativeProcessHelper.DuplicateTokenEx(hPToken, ConsoleState.MAXIMUM_ALLOWED, ref sa,
                (int)Security.SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                (int)Security.TOKEN_TYPE.TokenPrimary, ref hUserTokenDup))
            {
                NativeProcessHelper.CloseHandle(hProcess);
                NativeProcessHelper.CloseHandle(hPToken);
                return false;
            }

            // By default CreateProcessAsUser creates a process on a non-interactive window station, meaning
            // the window station has a desktop that is invisible and the process is incapable of receiving
            // user input. To remedy this we set the lpDesktop parameter to indicate we want to enable user 
            // interaction with the new process.
            var si = new STARTUPINFO();
            si.cb = Marshal.SizeOf(si);

            // interactive window station parameter; basically this indicates that the process 
            // created can display a GUI on the desktop
            si.lpDesktop = @"winsta0\default";
            si.wShowWindow = 0;

            // flags that specify the priority and creation method of the process
            int dwCreationFlags = ProcessPriority.NORMAL_PRIORITY_CLASS | consoleState;

            // create a new process in the current user's logon session
            bool result = NativeProcessHelper.CreateProcessAsUser(
                hUserTokenDup,        // client's access token
                applicationName,      // file to execute
                " " + arguments,      // command line
                ref sa,               // pointer to process SECURITY_ATTRIBUTES
                ref sa,               // pointer to thread SECURITY_ATTRIBUTES
                false,                // handles are not inheritable
                dwCreationFlags,      // creation flags
                IntPtr.Zero,          // pointer to new environment block 
                null,                 // name of current directory 
                ref si,               // pointer to STARTUPINFO structure
                out procInfo          // receives information about new process
            );

            // Wait until application has terminated
            NativeProcessHelper.WaitForSingleObject(procInfo.hProcess, WaitTimer.INFINITE);

            // invalidate the handles
            NativeProcessHelper.CloseHandle(hProcess);
            NativeProcessHelper.CloseHandle(hPToken);
            NativeProcessHelper.CloseHandle(hUserTokenDup);

            // Return
            return result;
        }
    }
}
