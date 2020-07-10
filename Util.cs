using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static void LogTxt(string strLog, bool dev)
        {
            if (!dev)
                return;
            string sFileName = Application.StartupPath + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss fff") + "]" + strLog);
            sw.Close();
            fs.Close();
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
