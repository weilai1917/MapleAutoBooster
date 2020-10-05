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
        private bool Stop = false;
        private MapleConfig MapleConfig;
        private string CurrGroupKey = string.Empty;

        public MainForm()
        {
            MapleConfig = new MapleConfig();
            if (this.MapleConfig.ServiceData == null)
                this.MapleConfig.ServiceData = new List<ServiceConfig>();

            InitializeComponent();

            this.UpGradeGroup();
            this.ReloadHotKeys();
            this.LoadGroupData();
            this.ReloadServices();
        }

        /// <summary>
        ///升级判断，加上默认分组
        ///如果所有的分组都为null,并且分组个数也为null，则创建，并重置所有的分组
        /// </summary>
        private void UpGradeGroup()
        {
            if (this.MapleConfig.GroupData != null)
            {
                return;
            }

            if (this.MapleConfig.ServiceData != null && this.MapleConfig.ServiceData.Count(x => !string.IsNullOrEmpty(x.ServiceGroup)) > 0)
            {
                return;
            }

            var guidKey = Guid.NewGuid().ToString();
            this.MapleConfig.GroupData = new List<CustomBindValue>();
            this.MapleConfig.GroupData.Add(new CustomBindValue()
            {
                Key = guidKey,
                Value = "默认"
            });

            this.MapleConfig.ServiceData.ForEach(x => x.ServiceGroup = guidKey);
            this.MapleConfig.Save();
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CurrGroupKey))
            {
                MessageBox.Show("请先添加服务分组。", "发射！");
                return;
            }


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
            this.ServiceList.DataSource = this.MapleConfig.ServiceData.Where(x => x.ServiceGroup == CurrGroupKey)?.ToList();
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

        private void LockAllControl(bool lockCtl = false)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.BtnAddService.Enabled = lockCtl;
                this.BtnDelService.Enabled = lockCtl;
                this.ServiceList.Enabled = lockCtl;
                this.BtnRecordKey.Enabled = lockCtl;
                this.MainMenu.Enabled = lockCtl;
            }));
        }

        private void ServiceList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ServiceList.IsCurrentCellDirty)
            {
                ServiceList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void LogTxt(string logTxt)
        {
            this.LogBox.BeginInvoke(new Action(() =>
            {
                if (this.LogBox.Lines.Length > 2000)
                {
                    this.LogBox.Text = "";
                }
                string logAppend = DateTime.Now.ToString("[HH:mm:ss]: ") + logTxt + "\r\n";
                this.LogBox.AppendText(logAppend);
                this.LogBox.Select((this.LogBox.Text.Length - logAppend.Length) + 1, logAppend.Length - 1);
                this.LogBox.SelectionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.LogBox.ScrollToCaret();
                this.LogBox.SelectionStart = this.LogBox.Text.Length;
                //Util.LogTxt(logTxt, true);
            }));
        }

        private void LogStatus(string logTxt)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.runStatus.Text = logTxt;
            }));
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm(MapleConfig);
            form.ShowDialog();
            CurrGroupKey = string.Empty;
            this.MapleConfig.Reload();
            //刷新一下热键注册
            this.ReloadHotKeys();
            //刷新一下分组
            this.LoadGroupData();
        }

        private void LoadGroupData()
        {
            if (this.MapleConfig.GroupData == null)
            {
                return;
            }

            this.ServiceGroupBox.ComboBox.DisplayMember = "Value";
            this.ServiceGroupBox.ComboBox.ValueMember = "Key";
            this.ServiceGroupBox.ComboBox.DataSource = this.MapleConfig.GroupData;
        }

        private void ServiceGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectGroup = this.ServiceGroupBox.SelectedItem;
            if (selectGroup != null)
            {
                var groupData = (CustomBindValue)selectGroup;
                CurrGroupKey = groupData.Key;
                this.ReloadServices();
            }
        }

        private void BtnCopyService_Click(object sender, EventArgs e)
        {

        }
    }
}
