namespace MapleAutoBooster
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainMenu = new System.Windows.Forms.ToolStrip();
            this.BtnAddService = new System.Windows.Forms.ToolStripSplitButton();
            this.BtnCopyService = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnDelService = new System.Windows.Forms.ToolStripButton();
            this.BtnSetting = new System.Windows.Forms.ToolStripButton();
            this.BtnRecordKey = new System.Windows.Forms.ToolStripButton();
            this.ServiceGroupBox = new System.Windows.Forms.ToolStripComboBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.ServiceList = new System.Windows.Forms.DataGridView();
            this.serviceDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MainStatuStrip = new System.Windows.Forms.StatusStrip();
            this.runStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mapleConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.IsRun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePolicyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataBindingSource)).BeginInit();
            this.MainStatuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapleConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.AliceBlue;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAddService,
            this.BtnDelService,
            this.BtnSetting,
            this.BtnRecordKey,
            this.ServiceGroupBox});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(444, 25);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "toolStrip1";
            // 
            // BtnAddService
            // 
            this.BtnAddService.AutoSize = false;
            this.BtnAddService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnAddService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCopyService});
            this.BtnAddService.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddService.Image")));
            this.BtnAddService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddService.Name = "BtnAddService";
            this.BtnAddService.Size = new System.Drawing.Size(72, 22);
            this.BtnAddService.Text = "添加服务";
            this.BtnAddService.ButtonClick += new System.EventHandler(this.BtnAddService_Click);
            // 
            // BtnCopyService
            // 
            this.BtnCopyService.BackColor = System.Drawing.Color.White;
            this.BtnCopyService.Name = "BtnCopyService";
            this.BtnCopyService.ShowShortcutKeys = false;
            this.BtnCopyService.Size = new System.Drawing.Size(116, 22);
            this.BtnCopyService.Text = "复制服务";
            this.BtnCopyService.Click += new System.EventHandler(this.BtnCopyService_Click);
            // 
            // BtnDelService
            // 
            this.BtnDelService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnDelService.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelService.Image")));
            this.BtnDelService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnDelService.Name = "BtnDelService";
            this.BtnDelService.Size = new System.Drawing.Size(60, 22);
            this.BtnDelService.Text = "删除服务";
            this.BtnDelService.Click += new System.EventHandler(this.BtnDelService_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Image = ((System.Drawing.Image)(resources.GetObject("BtnSetting.Image")));
            this.BtnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(52, 22);
            this.BtnSetting.Text = "设置";
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // BtnRecordKey
            // 
            this.BtnRecordKey.Image = ((System.Drawing.Image)(resources.GetObject("BtnRecordKey.Image")));
            this.BtnRecordKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnRecordKey.Name = "BtnRecordKey";
            this.BtnRecordKey.Size = new System.Drawing.Size(76, 22);
            this.BtnRecordKey.Text = "录制键盘";
            this.BtnRecordKey.Visible = false;
            // 
            // ServiceGroupBox
            // 
            this.ServiceGroupBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ServiceGroupBox.BackColor = System.Drawing.Color.White;
            this.ServiceGroupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServiceGroupBox.DropDownWidth = 75;
            this.ServiceGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServiceGroupBox.IntegralHeight = false;
            this.ServiceGroupBox.Name = "ServiceGroupBox";
            this.ServiceGroupBox.Size = new System.Drawing.Size(100, 25);
            this.ServiceGroupBox.SelectedIndexChanged += new System.EventHandler(this.ServiceGroupBox_SelectedIndexChanged);
            // 
            // LogBox
            // 
            this.LogBox.BackColor = System.Drawing.Color.White;
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogBox.Location = new System.Drawing.Point(0, 432);
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(444, 132);
            this.LogBox.TabIndex = 2;
            this.LogBox.Text = "";
            // 
            // ServiceList
            // 
            this.ServiceList.AllowUserToResizeRows = false;
            this.ServiceList.AutoGenerateColumns = false;
            this.ServiceList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServiceList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServiceList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ServiceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsRun,
            this.guidDataGridViewTextBoxColumn,
            this.serviceTypeIdDataGridViewTextBoxColumn,
            this.serviceNameDataGridViewTextBoxColumn,
            this.serviceDescriptionDataGridViewTextBoxColumn,
            this.servicePolicyDataGridViewTextBoxColumn,
            this.operationsDataGridViewTextBoxColumn});
            this.ServiceList.DataSource = this.serviceDataBindingSource;
            this.ServiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceList.Location = new System.Drawing.Point(0, 25);
            this.ServiceList.Name = "ServiceList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServiceList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ServiceList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ServiceList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ServiceList.RowTemplate.Height = 23;
            this.ServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ServiceList.Size = new System.Drawing.Size(444, 407);
            this.ServiceList.TabIndex = 4;
            this.ServiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceList_CellContentClick);
            this.ServiceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceList_CellDoubleClick);
            this.ServiceList.CurrentCellDirtyStateChanged += new System.EventHandler(this.ServiceList_CurrentCellDirtyStateChanged);
            // 
            // serviceDataBindingSource
            // 
            this.serviceDataBindingSource.DataMember = "ServiceData";
            this.serviceDataBindingSource.DataSource = this.mapleConfigBindingSource;
            // 
            // MainStatuStrip
            // 
            this.MainStatuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runStatus});
            this.MainStatuStrip.Location = new System.Drawing.Point(0, 564);
            this.MainStatuStrip.Name = "MainStatuStrip";
            this.MainStatuStrip.Size = new System.Drawing.Size(444, 22);
            this.MainStatuStrip.TabIndex = 3;
            this.MainStatuStrip.Text = "statusStrip1";
            // 
            // runStatus
            // 
            this.runStatus.BackColor = System.Drawing.SystemColors.Control;
            this.runStatus.Name = "runStatus";
            this.runStatus.Size = new System.Drawing.Size(429, 17);
            this.runStatus.Spring = true;
            this.runStatus.Text = "当前没有正在运行的服务。";
            // 
            // mapleConfigBindingSource
            // 
            this.mapleConfigBindingSource.DataSource = typeof(MapleAutoBooster.MapleConfig);
            // 
            // IsRun
            // 
            this.IsRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsRun.DataPropertyName = "IsRun";
            this.IsRun.FillWeight = 104.8624F;
            this.IsRun.HeaderText = "启动";
            this.IsRun.Name = "IsRun";
            this.IsRun.Width = 40;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.FillWeight = 101.5228F;
            this.guidDataGridViewTextBoxColumn.HeaderText = "Id";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Width = 50;
            // 
            // serviceTypeIdDataGridViewTextBoxColumn
            // 
            this.serviceTypeIdDataGridViewTextBoxColumn.DataPropertyName = "ServiceTypeId";
            this.serviceTypeIdDataGridViewTextBoxColumn.HeaderText = "ServiceTypeId";
            this.serviceTypeIdDataGridViewTextBoxColumn.Name = "serviceTypeIdDataGridViewTextBoxColumn";
            this.serviceTypeIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.serviceTypeIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // serviceNameDataGridViewTextBoxColumn
            // 
            this.serviceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.serviceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName";
            this.serviceNameDataGridViewTextBoxColumn.FillWeight = 97.87158F;
            this.serviceNameDataGridViewTextBoxColumn.HeaderText = "服务名称";
            this.serviceNameDataGridViewTextBoxColumn.Name = "serviceNameDataGridViewTextBoxColumn";
            this.serviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.serviceNameDataGridViewTextBoxColumn.Visible = false;
            this.serviceNameDataGridViewTextBoxColumn.Width = 81;
            // 
            // serviceDescriptionDataGridViewTextBoxColumn
            // 
            this.serviceDescriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serviceDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ServiceDescription";
            this.serviceDescriptionDataGridViewTextBoxColumn.FillWeight = 97.87158F;
            this.serviceDescriptionDataGridViewTextBoxColumn.HeaderText = "服务描述";
            this.serviceDescriptionDataGridViewTextBoxColumn.Name = "serviceDescriptionDataGridViewTextBoxColumn";
            this.serviceDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // servicePolicyDataGridViewTextBoxColumn
            // 
            this.servicePolicyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.servicePolicyDataGridViewTextBoxColumn.DataPropertyName = "ServicePolicy";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.servicePolicyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.servicePolicyDataGridViewTextBoxColumn.FillWeight = 97.87158F;
            this.servicePolicyDataGridViewTextBoxColumn.HeaderText = "服务策略";
            this.servicePolicyDataGridViewTextBoxColumn.Name = "servicePolicyDataGridViewTextBoxColumn";
            this.servicePolicyDataGridViewTextBoxColumn.ReadOnly = true;
            this.servicePolicyDataGridViewTextBoxColumn.Width = 81;
            // 
            // operationsDataGridViewTextBoxColumn
            // 
            this.operationsDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.operationsDataGridViewTextBoxColumn.DataPropertyName = "Operations";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.operationsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.operationsDataGridViewTextBoxColumn.HeaderText = "操作";
            this.operationsDataGridViewTextBoxColumn.Name = "operationsDataGridViewTextBoxColumn";
            this.operationsDataGridViewTextBoxColumn.ReadOnly = true;
            this.operationsDataGridViewTextBoxColumn.Visible = false;
            this.operationsDataGridViewTextBoxColumn.Width = 57;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(444, 586);
            this.Controls.Add(this.ServiceList);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.MainStatuStrip);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "冒险发射器";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataBindingSource)).EndInit();
            this.MainStatuStrip.ResumeLayout(false);
            this.MainStatuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapleConfigBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MainMenu;
        private System.Windows.Forms.ToolStripButton BtnSetting;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.DataGridView ServiceList;
        private System.Windows.Forms.ToolStripButton BtnDelService;
        private System.Windows.Forms.BindingSource serviceDataBindingSource;
        private System.Windows.Forms.BindingSource mapleConfigBindingSource;
        private System.Windows.Forms.ToolStripSplitButton BtnAddService;
        private System.Windows.Forms.ToolStripMenuItem BtnCopyService;
        private System.Windows.Forms.ToolStripComboBox ServiceGroupBox;
        private System.Windows.Forms.StatusStrip MainStatuStrip;
        private System.Windows.Forms.ToolStripButton BtnRecordKey;
        private System.Windows.Forms.ToolStripStatusLabel runStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePolicyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationsDataGridViewTextBoxColumn;
    }
}