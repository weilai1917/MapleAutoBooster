using System;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string executePath = System.Windows.Forms.Application.ExecutablePath;

            //判断当前登录用户是否为管理员
            if (!Util.IsAdminRun())
            {
                Util.ProcessStart(executePath, null);
                Environment.Exit(0);
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
