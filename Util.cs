using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster
{
    public class Util
    {
        public static bool IsAdminRun()
        {
            System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        public static void ProcessStart(string executable, string[] args, int show = 1)
        {
            var arg = string.Empty;
            arg = args == null
                      ? string.Empty
                      : args.Aggregate(arg, (current, s) => current + $" {s}");

            var shExecInfo = new SHELLEXECUTEINFO();

            shExecInfo.cbSize = Marshal.SizeOf(shExecInfo);

            shExecInfo.fMask = 0;
            shExecInfo.hwnd = IntPtr.Zero;
            shExecInfo.lpVerb = "runas";
            shExecInfo.lpFile = executable;
            shExecInfo.lpParameters = arg;
            shExecInfo.nShow = show;

            if (ShellExecuteEx(ref shExecInfo) == false)
            {
                throw new Exception("Error.\r\n" + $"Executable: {executable}\r\n"
                                    + $"Arguments: {arg}");
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }
    }
}
