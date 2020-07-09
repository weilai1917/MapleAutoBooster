using MapleAutoBooster;
using MapleAutoBooster.Abstract;
using MapleAutoBooster.ToolBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class MainForm : Form
    {
        private bool Start = false;
        private MapleConfig MapleConfig;

        public MainForm()
        {
            MapleConfig = new MapleConfig();
            if (this.MapleConfig.ServiceData == null)
                this.MapleConfig.ServiceData = new List<ServiceConfig>();

            InitializeComponent();
            this.ReloadServices();
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            ServiceForm form = new ServiceForm(null, MapleConfig);
            form.ShowDialog();

            this.MapleConfig.Reload();
            this.ReloadServices();
        }

        private void BtnDelService_Click(object sender, EventArgs e)
        {
            if (this.ServiceList.Rows.Count <= 0)
            {
                return;
            }

            if (MessageBox.Show("确定要删除当前行吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                var guid = Convert.ToString(this.ServiceList.Rows[this.ServiceList.CurrentRow.Index].Cells[1].Value);
                this.MapleConfig.ServiceData.RemoveAll(x => x.Guid == guid);
                this.ReloadServices();
                this.MapleConfig.Save();
            }
        }

        private void ReloadServices()
        {
            this.ServiceList.DataSource = null;
            this.ServiceList.DataSource = this.MapleConfig.ServiceData;
            this.ServiceList.Update();
            this.ServiceList.Refresh();
        }

        private void ServiceList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            var serviceId = this.ServiceList.Rows[e.RowIndex].Cells[1].Value.ToString();
            var serviceData = this.MapleConfig.ServiceData.Where(x => x.Guid == serviceId).FirstOrDefault();
            if (serviceData == null)
            {
                //
                return;
            }
            var service = ServiceBuilder.ReBuildService(serviceData, false);
            ServiceForm form = new ServiceForm(service, MapleConfig);
            form.ShowDialog();

            this.MapleConfig.Reload();
            this.ReloadServices();
        }
        private void ServiceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }
            var serviceId = this.ServiceList.Rows[e.RowIndex].Cells[1].Value.ToString();
            var serviceData = this.MapleConfig.ServiceData.Where(x => x.Guid == serviceId).FirstOrDefault();
            if (serviceData == null)
            {
                //
                return;
            }
            serviceData.IsRun = Convert.ToBoolean(this.ServiceList.Rows[e.RowIndex].Cells[0].Value);
        }

        private void StartAllService()
        {
            LockAllControl(!Start);
            List<string> selRows = new List<string>();
            Task.Run(() =>
            {
                Parallel.ForEach(this.MapleConfig.ServiceData.Where(x => x.IsRun), new Action<ServiceConfig>(t =>
                {
                    var service = ServiceBuilder.ReBuildService(t, true);
                    service.RunAllOperations("1", ref Start);//run 将会在这阻塞

                    //如果出来了，就继续走another service
                    if (service.AnotherOperations != null && service.AnotherOperations.Count > 0)
                    {
                        this.RecursionService(service.AnotherOperations.Distinct().ToList());
                    }
                }));
            });
        }

        private void RecursionService(List<string> anotherOperations)
        {
            if (!Start)
                return;

            foreach (var serviceId in anotherOperations)
            {
                var another = ServiceBuilder.ReBuildService(this.MapleConfig.ServiceData.First(x => x.Guid == serviceId), true);
                another.RunAllOperations("1", ref Start);
                if (another.AnotherOperations != null)
                {
                    this.RecursionService(another.AnotherOperations.Distinct().ToList());
                }
            }
        }

        private void LockAllControl(bool lockCtl = false)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.BtnAddService.Enabled = lockCtl;
                this.BtnDelService.Enabled = lockCtl;
                this.ServiceList.Enabled = lockCtl;
            }));
        }

        #region 全局热键

        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();
        //如果函数执行成功，返回值不为0。  
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。  
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄  
            int id,                     //定义热键ID（不能与其它ID重复）            
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效  
            Keys vk                     //定义热键的内容  
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄  
            int id                      //要取消热键的ID  
            );

        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）  
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        /// <summary>  
        /// 注册热键  
        /// </summary>  
        /// <param name="hwnd">窗口句柄</param>  
        /// <param name="hotKey_id">热键ID</param>  
        /// <param name="keyModifiers">组合键</param>  
        /// <param name="key">热键</param>  
        public static void RegKey(IntPtr hwnd, int hotKey_id, KeyModifiers keyModifiers, Keys key)
        {
            try
            {
                if (!RegisterHotKey(hwnd, hotKey_id, keyModifiers, key))
                {
                    if (Marshal.GetLastWin32Error() == 1409) { MessageBox.Show("热键被占用 ！"); }
                    else
                    {
                        MessageBox.Show("注册热键失败！");
                    }
                }
            }
            catch (Exception) { }
        }
        /// <summary>  
        /// 注销热键  
        /// </summary>  
        /// <param name="hwnd">窗口句柄</param>  
        /// <param name="hotKey_id">热键ID</param>  
        public static void UnRegKey(IntPtr hwnd, int hotKey_id)
        {
            //注销Id号为hotKey_id的热键设定  
            UnregisterHotKey(hwnd, hotKey_id);
        }

        private const int WM_HOTKEY = 0x312; //窗口消息-热键  
        private const int WM_CREATE = 0x1; //窗口消息-创建  
        private const int WM_DESTROY = 0x2; //窗口消息-销毁  
        private const int F1 = 0x3572; //热键ID  
        private const int F2 = 0x3576; //热键ID  
        private const int F3 = 0x3578; //热键ID 
        private const int F8 = 0x3588; //热键ID 
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID  
                    switch (m.WParam.ToInt32())
                    {
                        case F1: //热键ID  
                            if (!Start)
                            {
                                this.Text = "(๑•ᴗ•๑)启动中";
                                this.Start = true;
                                this.StartAllService();
                            }
                            else
                            {
                                this.Text = "冒险发射器";
                                this.Start = false;
                                this.LockAllControl(true);
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建  
                    RegKey(Handle, F1, KeyModifiers.None, Keys.F1);
                    //RegKey(Handle, F8, KeyModifiers.None, Keys.F8);
                    break;
                case WM_DESTROY: //窗口消息-销毁  
                    UnRegKey(Handle, F1); //销毁热键  
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void ServiceList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ServiceList.IsCurrentCellDirty)
            {
                ServiceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MapleConfig.Save();
        }

    }
}
