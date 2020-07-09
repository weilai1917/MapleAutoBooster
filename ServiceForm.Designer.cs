namespace MapleAutoBooster
{
    partial class ServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ServiceDescription = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ServicePolicy = new System.Windows.Forms.ComboBox();
            this.ServicePanel = new System.Windows.Forms.TabControl();
            this.ServiceBeforeLayout = new System.Windows.Forms.TabPage();
            this.ServiceDo0 = new System.Windows.Forms.RichTextBox();
            this.ServiceDoingLayout = new System.Windows.Forms.TabPage();
            this.ServiceDo1 = new System.Windows.Forms.RichTextBox();
            this.ServiceAfterLayout = new System.Windows.Forms.TabPage();
            this.ServiceDo2 = new System.Windows.Forms.RichTextBox();
            this.TopLayout = new System.Windows.Forms.Panel();
            this.ServiceType = new System.Windows.Forms.ComboBox();
            this.ControlLayout = new System.Windows.Forms.Panel();
            this.ServicePanel.SuspendLayout();
            this.ServiceBeforeLayout.SuspendLayout();
            this.ServiceDoingLayout.SuspendLayout();
            this.ServiceAfterLayout.SuspendLayout();
            this.TopLayout.SuspendLayout();
            this.ControlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "服务描述：";
            // 
            // ServiceDescription
            // 
            this.ServiceDescription.Location = new System.Drawing.Point(72, 35);
            this.ServiceDescription.Name = "ServiceDescription";
            this.ServiceDescription.Size = new System.Drawing.Size(273, 23);
            this.ServiceDescription.TabIndex = 4;
            this.ServiceDescription.TextChanged += new System.EventHandler(this.ServiceDescription_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.Location = new System.Drawing.Point(0, 0);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(349, 50);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "执行策略：";
            // 
            // ServicePolicy
            // 
            this.ServicePolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServicePolicy.FormattingEnabled = true;
            this.ServicePolicy.Location = new System.Drawing.Point(72, 63);
            this.ServicePolicy.Name = "ServicePolicy";
            this.ServicePolicy.Size = new System.Drawing.Size(273, 25);
            this.ServicePolicy.TabIndex = 12;
            this.ServicePolicy.SelectionChangeCommitted += new System.EventHandler(this.ServicePolicy_SelectionChangeCommitted);
            // 
            // ServicePanel
            // 
            this.ServicePanel.Controls.Add(this.ServiceBeforeLayout);
            this.ServicePanel.Controls.Add(this.ServiceDoingLayout);
            this.ServicePanel.Controls.Add(this.ServiceAfterLayout);
            this.ServicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServicePanel.Location = new System.Drawing.Point(0, 95);
            this.ServicePanel.Name = "ServicePanel";
            this.ServicePanel.SelectedIndex = 0;
            this.ServicePanel.Size = new System.Drawing.Size(349, 378);
            this.ServicePanel.TabIndex = 13;
            // 
            // ServiceBeforeLayout
            // 
            this.ServiceBeforeLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServiceBeforeLayout.Controls.Add(this.ServiceDo0);
            this.ServiceBeforeLayout.Location = new System.Drawing.Point(4, 26);
            this.ServiceBeforeLayout.Name = "ServiceBeforeLayout";
            this.ServiceBeforeLayout.Padding = new System.Windows.Forms.Padding(3);
            this.ServiceBeforeLayout.Size = new System.Drawing.Size(341, 467);
            this.ServiceBeforeLayout.TabIndex = 0;
            this.ServiceBeforeLayout.Text = "执行前";
            this.ServiceBeforeLayout.UseVisualStyleBackColor = true;
            // 
            // ServiceDo0
            // 
            this.ServiceDo0.BackColor = System.Drawing.Color.White;
            this.ServiceDo0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceDo0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceDo0.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceDo0.Location = new System.Drawing.Point(3, 3);
            this.ServiceDo0.Name = "ServiceDo0";
            this.ServiceDo0.Size = new System.Drawing.Size(333, 459);
            this.ServiceDo0.TabIndex = 4;
            this.ServiceDo0.Tag = "0";
            this.ServiceDo0.Text = "";
            this.ServiceDo0.Leave += new System.EventHandler(this.ServiceDo_Leave);
            // 
            // ServiceDoingLayout
            // 
            this.ServiceDoingLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServiceDoingLayout.Controls.Add(this.ServiceDo1);
            this.ServiceDoingLayout.Location = new System.Drawing.Point(4, 26);
            this.ServiceDoingLayout.Name = "ServiceDoingLayout";
            this.ServiceDoingLayout.Padding = new System.Windows.Forms.Padding(3);
            this.ServiceDoingLayout.Size = new System.Drawing.Size(341, 467);
            this.ServiceDoingLayout.TabIndex = 1;
            this.ServiceDoingLayout.Text = "执行服务";
            this.ServiceDoingLayout.UseVisualStyleBackColor = true;
            // 
            // ServiceDo1
            // 
            this.ServiceDo1.BackColor = System.Drawing.Color.White;
            this.ServiceDo1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceDo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceDo1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceDo1.Location = new System.Drawing.Point(3, 3);
            this.ServiceDo1.Name = "ServiceDo1";
            this.ServiceDo1.Size = new System.Drawing.Size(333, 459);
            this.ServiceDo1.TabIndex = 0;
            this.ServiceDo1.Tag = "1";
            this.ServiceDo1.Text = "";
            this.ServiceDo1.Leave += new System.EventHandler(this.ServiceDo_Leave);
            // 
            // ServiceAfterLayout
            // 
            this.ServiceAfterLayout.BackColor = System.Drawing.Color.White;
            this.ServiceAfterLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServiceAfterLayout.Controls.Add(this.ServiceDo2);
            this.ServiceAfterLayout.Location = new System.Drawing.Point(4, 26);
            this.ServiceAfterLayout.Name = "ServiceAfterLayout";
            this.ServiceAfterLayout.Padding = new System.Windows.Forms.Padding(3);
            this.ServiceAfterLayout.Size = new System.Drawing.Size(341, 348);
            this.ServiceAfterLayout.TabIndex = 2;
            this.ServiceAfterLayout.Text = "执行策略后执行";
            // 
            // ServiceDo2
            // 
            this.ServiceDo2.BackColor = System.Drawing.Color.White;
            this.ServiceDo2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceDo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceDo2.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceDo2.Location = new System.Drawing.Point(3, 3);
            this.ServiceDo2.Name = "ServiceDo2";
            this.ServiceDo2.Size = new System.Drawing.Size(333, 340);
            this.ServiceDo2.TabIndex = 2;
            this.ServiceDo2.Tag = "2";
            this.ServiceDo2.Text = "";
            this.ServiceDo2.Leave += new System.EventHandler(this.ServiceDo_Leave);
            // 
            // TopLayout
            // 
            this.TopLayout.Controls.Add(this.ServiceType);
            this.TopLayout.Controls.Add(this.label1);
            this.TopLayout.Controls.Add(this.ServicePolicy);
            this.TopLayout.Controls.Add(this.label3);
            this.TopLayout.Controls.Add(this.label2);
            this.TopLayout.Controls.Add(this.ServiceDescription);
            this.TopLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopLayout.Location = new System.Drawing.Point(0, 0);
            this.TopLayout.Name = "TopLayout";
            this.TopLayout.Size = new System.Drawing.Size(349, 95);
            this.TopLayout.TabIndex = 14;
            // 
            // ServiceType
            // 
            this.ServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServiceType.FormattingEnabled = true;
            this.ServiceType.Location = new System.Drawing.Point(72, 5);
            this.ServiceType.Name = "ServiceType";
            this.ServiceType.Size = new System.Drawing.Size(273, 25);
            this.ServiceType.TabIndex = 13;
            this.ServiceType.SelectionChangeCommitted += new System.EventHandler(this.ServiceType_SelectionChangeCommitted);
            // 
            // ControlLayout
            // 
            this.ControlLayout.Controls.Add(this.BtnSave);
            this.ControlLayout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlLayout.Location = new System.Drawing.Point(0, 473);
            this.ControlLayout.Name = "ControlLayout";
            this.ControlLayout.Size = new System.Drawing.Size(349, 50);
            this.ControlLayout.TabIndex = 15;
            // 
            // ServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 523);
            this.Controls.Add(this.ServicePanel);
            this.Controls.Add(this.TopLayout);
            this.Controls.Add(this.ControlLayout);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自定义服务规则";
            this.ServicePanel.ResumeLayout(false);
            this.ServiceBeforeLayout.ResumeLayout(false);
            this.ServiceDoingLayout.ResumeLayout(false);
            this.ServiceAfterLayout.ResumeLayout(false);
            this.TopLayout.ResumeLayout(false);
            this.TopLayout.PerformLayout();
            this.ControlLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServiceDescription;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ServicePolicy;
        private System.Windows.Forms.TabControl ServicePanel;
        private System.Windows.Forms.TabPage ServiceBeforeLayout;
        private System.Windows.Forms.TabPage ServiceDoingLayout;
        private System.Windows.Forms.Panel TopLayout;
        private System.Windows.Forms.Panel ControlLayout;
        private System.Windows.Forms.TabPage ServiceAfterLayout;
        private System.Windows.Forms.RichTextBox ServiceDo1;
        private System.Windows.Forms.RichTextBox ServiceDo2;
        private System.Windows.Forms.RichTextBox ServiceDo0;
        private System.Windows.Forms.ComboBox ServiceType;
    }
}