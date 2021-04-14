namespace MapleAutoBooster
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.HotKeyServiceStop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HotKeyKeyRecord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HotKeyServiceBoot = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnDeleteGroup = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BtnAddGroup = new System.Windows.Forms.Button();
            this.TxtGroupName = new System.Windows.Forms.TextBox();
            this.ListGroupData = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(379, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.HotKeyServiceStop);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.HotKeyKeyRecord);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.HotKeyServiceBoot);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 213);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "热键";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // HotKeyServiceStop
            // 
            this.HotKeyServiceStop.Location = new System.Drawing.Point(87, 35);
            this.HotKeyServiceStop.Name = "HotKeyServiceStop";
            this.HotKeyServiceStop.ReadOnly = true;
            this.HotKeyServiceStop.Size = new System.Drawing.Size(261, 23);
            this.HotKeyServiceStop.TabIndex = 10;
            this.HotKeyServiceStop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.HotKeyServiceStop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "服务暂停：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "键盘录制：";
            // 
            // HotKeyKeyRecord
            // 
            this.HotKeyKeyRecord.Location = new System.Drawing.Point(87, 64);
            this.HotKeyKeyRecord.Name = "HotKeyKeyRecord";
            this.HotKeyKeyRecord.ReadOnly = true;
            this.HotKeyKeyRecord.Size = new System.Drawing.Size(261, 23);
            this.HotKeyKeyRecord.TabIndex = 8;
            this.HotKeyKeyRecord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.HotKeyKeyRecord.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "启动/停止：";
            // 
            // HotKeyServiceBoot
            // 
            this.HotKeyServiceBoot.Location = new System.Drawing.Point(87, 6);
            this.HotKeyServiceBoot.Name = "HotKeyServiceBoot";
            this.HotKeyServiceBoot.ReadOnly = true;
            this.HotKeyServiceBoot.Size = new System.Drawing.Size(261, 23);
            this.HotKeyServiceBoot.TabIndex = 6;
            this.HotKeyServiceBoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.HotKeyServiceBoot.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnDeleteGroup);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.BtnAddGroup);
            this.tabPage2.Controls.Add(this.TxtGroupName);
            this.tabPage2.Controls.Add(this.ListGroupData);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(371, 213);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "服务分组";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteGroup
            // 
            this.BtnDeleteGroup.Location = new System.Drawing.Point(133, 89);
            this.BtnDeleteGroup.Name = "BtnDeleteGroup";
            this.BtnDeleteGroup.Size = new System.Drawing.Size(142, 29);
            this.BtnDeleteGroup.TabIndex = 4;
            this.BtnDeleteGroup.Text = "删除选中";
            this.BtnDeleteGroup.UseVisualStyleBackColor = true;
            this.BtnDeleteGroup.Click += new System.EventHandler(this.BtnDeleteGroup_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(133, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "删除选中";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtnAddGroup
            // 
            this.BtnAddGroup.Location = new System.Drawing.Point(133, 54);
            this.BtnAddGroup.Name = "BtnAddGroup";
            this.BtnAddGroup.Size = new System.Drawing.Size(142, 29);
            this.BtnAddGroup.TabIndex = 3;
            this.BtnAddGroup.Text = "添加分组";
            this.BtnAddGroup.UseVisualStyleBackColor = true;
            this.BtnAddGroup.Click += new System.EventHandler(this.BtnAddGroup_Click);
            // 
            // TxtGroupName
            // 
            this.TxtGroupName.Location = new System.Drawing.Point(133, 25);
            this.TxtGroupName.Name = "TxtGroupName";
            this.TxtGroupName.Size = new System.Drawing.Size(142, 23);
            this.TxtGroupName.TabIndex = 2;
            // 
            // ListGroupData
            // 
            this.ListGroupData.Dock = System.Windows.Forms.DockStyle.Left;
            this.ListGroupData.FullRowSelect = true;
            this.ListGroupData.HideSelection = false;
            this.ListGroupData.Location = new System.Drawing.Point(3, 3);
            this.ListGroupData.MultiSelect = false;
            this.ListGroupData.Name = "ListGroupData";
            this.ListGroupData.ShowGroups = false;
            this.ListGroupData.Size = new System.Drawing.Size(124, 207);
            this.ListGroupData.TabIndex = 1;
            this.ListGroupData.UseCompatibleStateImageBehavior = false;
            this.ListGroupData.View = System.Windows.Forms.View.List;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "分组标题";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 243);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HotKeyKeyRecord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HotKeyServiceBoot;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView ListGroupData;
        private System.Windows.Forms.TextBox TxtGroupName;
        private System.Windows.Forms.Button BtnAddGroup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnDeleteGroup;
        private System.Windows.Forms.TextBox HotKeyServiceStop;
        private System.Windows.Forms.Label label4;
    }
}