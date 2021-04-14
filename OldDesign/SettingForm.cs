using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class SettingForm : Form
    {
        private MapleConfig MapleConfig;
        public SettingForm(MapleConfig config)
        {
            MapleConfig = config;
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.HotKeyServiceBoot.DataBindings.Add("Text", MapleConfig, "HotKeyServiceBoot", false, DataSourceUpdateMode.OnPropertyChanged);
            this.HotKeyServiceStop.DataBindings.Add("Text", MapleConfig, "HotKeyServiceStop", false, DataSourceUpdateMode.OnPropertyChanged);
            this.HotKeyKeyRecord.DataBindings.Add("Text", MapleConfig, "HotKeyKeyRecord", false, DataSourceUpdateMode.OnPropertyChanged);
            this.LoadGroupData();
        }
        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MapleConfig.HotKeys = new List<CustomBindValue>();
            this.MapleConfig.HotKeys.Add(new CustomBindValue() { Key = "HotKeyServiceBoot", Value = this.MapleConfig.HotKeyServiceBoot });
            this.MapleConfig.HotKeys.Add(new CustomBindValue() { Key = "HotKeyServiceStop", Value = this.MapleConfig.HotKeyServiceStop });
            this.MapleConfig.HotKeys.Add(new CustomBindValue() { Key = "HotKeyKeyRecord", Value = this.MapleConfig.HotKeyKeyRecord });

            var groupItem = this.ListGroupData.Items;
            this.MapleConfig.GroupData.Clear();
            foreach (ListViewItem item in groupItem)
            {
                this.MapleConfig.GroupData.Add(new CustomBindValue()
                {
                     Key = Convert.ToString(item.Tag),
                     Value = item.Text
                });
            }
            this.MapleConfig.Save();
        }

        /// <summary>
        /// 按键Down记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyDown(object sender, KeyEventArgs e)
        {
            StringBuilder keyValue = new StringBuilder();
            keyValue.Length = 0;
            keyValue.Append("");
            //F1-F12
            if ((e.KeyValue >= 112 && e.KeyValue <= 123))
            {
                keyValue.Append(e.KeyCode);
            }
            //if (e.Modifiers != 0)
            //{
            //    if (e.Control)
            //        keyValue.Append("Ctrl + ");
            //    if (e.Alt)
            //        keyValue.Append("Alt + ");
            //    if (e.Shift)
            //        keyValue.Append("Shift + ");
            //}
            //if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
            //    (e.KeyValue >= 65 && e.KeyValue <= 90) ||   //a-z/A-Z
            //    (e.KeyValue >= 112 && e.KeyValue <= 123))   //F1-F12
            //{
            //    keyValue.Append(e.KeyCode);
            //}
            //else if ((e.KeyValue >= 48 && e.KeyValue <= 57))    //0-9
            //{
            //    keyValue.Append(e.KeyCode.ToString().Substring(1));
            //}
            this.ActiveControl.Text = "";
            //设置当前活动控件的文本内容
            this.ActiveControl.Text = keyValue.ToString();
        }

        /// <summary>
        /// 按键抬起记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyUp(object sender, KeyEventArgs e)
        {
            string str = this.ActiveControl.Text.TrimEnd();
            int len = str.Length;
            if (len >= 1 && str.Substring(str.Length - 1) == "+")
            {
                this.ActiveControl.Text = "";
            }
        }

        private void LoadGroupData()
        {
            if (this.MapleConfig.GroupData == null)
                this.MapleConfig.GroupData = new List<CustomBindValue>();
            this.ListGroupData.Items.Clear();

            foreach (var item in this.MapleConfig.GroupData)
            {
                this.ListGroupData.Items.Add(new ListViewItem()
                {
                    Text = item.Value,
                    Tag = item.Key
                });
            }
        }

        private void BtnAddGroup_Click(object sender, EventArgs e)
        {
            var groupName = this.TxtGroupName.Text;
            if (groupName.Length == 0)
            {
                return;
            }

            this.ListGroupData.Items.Add(new ListViewItem()
            {
                Text = groupName,
                Tag = Guid.NewGuid().ToString()
            });            

        }

        private void BtnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (this.ListGroupData.SelectedItems.Count == 0)
            {
                return;
            }

            var selectItem = this.ListGroupData.SelectedItems[0];
            this.ListGroupData.Items.Remove(selectItem);
        }
    }
}
