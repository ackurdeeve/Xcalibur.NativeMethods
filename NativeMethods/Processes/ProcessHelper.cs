using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using Xcalibur.NativeMethods.Security;
using Xcalibur.NativeMethods.Windows;

namespace Xcalibur.NativeMethods.Processes
{
    /// <summary>
    /// Win32 API Helper: Processes, Handles, and Threads.
    /// </summary>
    public static class ProcessHelper
    {
        /// <summary>
        /// Closes the handle.
        /// </summary>
        /// <param name="hSnapshot">The h snapshot.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hSnapshot);

        /// <summary>
        /// WTSs the get active console session identifier.
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern uint WTSGetActiveConsoleSessionId();

        /// <summary>
        /// Waits for single object.
        /// </summary>
        /// <param name="hHandle">The h handle.</param>
        /// <param name="dwMilliseconds">The dw milliseconds.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        /// <summary>
        /// Processes the identifier to session identifier.
        /// </summary>
        /// <param name="dwProcessId">The dw process identifier.</param>
        /// <param name="pSessionId">The p session identifier.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern bool ProcessIdToSessionId(uint dwProcessId, ref uint pSessionId);

        /// <summary>
        /// Opens the process.
        /// </summary>
        /// <param name="dwDesiredAccess">The dw desired access.</param>
        /// <param name="bInheritHandle">if set to <c>true</c> [b inherit handle].</param>
        /// <param name="dwProcessId">The dw process identifier.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle,
            uint dwProcessId);

        /// <summary>
        /// Creates the process as user.
        /// </summary>
        /// <param name="hToken">The h token.</param>
        /// <param name="lpApplicationName">Name of the lp application.</param>
        /// <param name="lpCommandLine">The lp command line.</param>
        /// <param name="lpProcessAttributes">The lp process attributes.</param>
        /// <param name="lpThreadAttributes">The lp thread attributes.</param>
        /// <param name="bInheritHandle">if set to <c>true</c> [b inherit handle].</param>
        /// <param name="dwCreationFlags">The dw creation flags.</param>
        /// <param name="lpEnvironment">The lp environment.</param>
        /// <param name="lpCurrentDirectory">The lp current directory.</param>
        /// <param name="lpStartupInfo">The lp startup information.</param>
        /// <param name="lpProcessInformation">The lp process information.</param>
        /// <returns></returns>
        [DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUser", SetLastError = true,
            CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public extern static bool CreateProcessAsUser(IntPtr hToken, String lpApplicationName,
            String lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandle, int dwCreationFlags,
            IntPtr lpEnvironment, String lpCurrentDirectory, ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation);

        /// <summary>
        /// Duplicates the token ex.
        /// </summary>
        /// <param name="ExistingTokenHandle">The existing token handle.</param>
        /// <param name="dwDesiredAccess">The dw desired access.</param>
        /// <param name="lpThreadAttributes">The lp thread attributes.</param>
        /// <param name="TokenType">Type of the token.</param>
        /// <param name="ImpersonationLevel">The impersonation level.</param>
        /// <param name="DuplicateTokenHandle">The duplicate token handle.</param>
        /// <returns></returns>
        [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx")]
        public extern static bool DuplicateTokenEx(IntPtr ExistingTokenHandle, uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, int TokenType,
            int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);

        /// <summary>
        /// Opens the process token.
        /// </summary>
        /// <param name="ProcessHandle">The process handle.</param>
        /// <param name="DesiredAccess">The desired access.</param>
        /// <param name="TokenHandle">The token handle.</param>
        /// <returns></returns>
        [DllImport("advapi32", SetLastError = true), SuppressUnmanagedCodeSecurity]
        public static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);
    }
}
