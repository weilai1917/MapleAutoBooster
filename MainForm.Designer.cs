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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnUser = new System.Windows.Forms.ToolStripButton();
            this.BtnConnect = new System.Windows.Forms.ToolStripButton();
            this.BtnAddService = new System.Windows.Forms.ToolStripButton();
            this.BtnDelService = new System.Windows.Forms.ToolStripButton();
            this.BtnSetting = new System.Windows.Forms.ToolStripButton();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ServiceList = new System.Windows.Forms.DataGridView();
            this.IsRun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceTypeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servicePolicyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mapleConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapleConfigBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnUser,
            this.BtnConnect,
            this.BtnAddService,
            this.BtnDelService,
            this.BtnSetting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(445, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnUser
            // 
            this.BtnUser.Image = ((System.Drawing.Image)(resources.GetObject("BtnUser.Image")));
            this.BtnUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Size = new System.Drawing.Size(76, 22);
            this.BtnUser.Text = "用户信息";
            this.BtnUser.Visible = false;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("BtnConnect.Image")));
            this.BtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(76, 22);
            this.BtnConnect.Text = "关联登录";
            this.BtnConnect.Visible = false;
            // 
            // BtnAddService
            // 
            this.BtnAddService.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtnAddService.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddService.Image")));
            this.BtnAddService.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAddService.Name = "BtnAddService";
            this.BtnAddService.Size = new System.Drawing.Size(60, 22);
            this.BtnAddService.Text = "添加服务";
            this.BtnAddService.Click += new System.EventHandler(this.BtnAddService_Click);
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
            // 
            // LogBox
            // 
            this.LogBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LogBox.Location = new System.Drawing.Point(0, 224);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(445, 343);
            this.LogBox.TabIndex = 2;
            this.LogBox.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(445, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ServiceList
            // 
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
            this.ServiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServiceList.Size = new System.Drawing.Size(445, 199);
            this.ServiceList.TabIndex = 4;
            this.ServiceList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceList_CellContentClick);
            this.ServiceList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceList_CellDoubleClick);
            this.ServiceList.CurrentCellDirtyStateChanged += new System.EventHandler(this.ServiceList_CurrentCellDirtyStateChanged);
            // 
            // IsRun
            // 
            this.IsRun.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsRun.DataPropertyName = "IsRun";
            this.IsRun.FillWeight = 104.8624F;
            this.IsRun.HeaderText = "";
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
            this.guidDataGridViewTextBoxColumn.Width = 80;
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
            // 
            // serviceDataBindingSource
            // 
            this.serviceDataBindingSource.DataMember = "ServiceData";
            this.serviceDataBindingSource.DataSource = this.mapleConfigBindingSource;
            // 
            // mapleConfigBindingSource
            // 
            this.mapleConfigBindingSource.DataSource = typeof(MapleAutoBooster.MapleConfig);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 589);
            this.Controls.Add(this.ServiceList);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "冒险发射器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapleConfigBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnConnect;
        private System.Windows.Forms.ToolStripButton BtnSetting;
        private System.Windows.Forms.ToolStripButton BtnUser;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView ServiceList;
        private System.Windows.Forms.ToolStripButton BtnAddService;
        private System.Windows.Forms.ToolStripButton BtnDelService;
        private System.Windows.Forms.BindingSource serviceDataBindingSource;
        private System.Windows.Forms.BindingSource mapleConfigBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceTypeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceDescriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servicePolicyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationsDataGridViewTextBoxColumn;
    }
}