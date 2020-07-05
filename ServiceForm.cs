using MapleAutoBooster.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class ServiceForm : Form
    {
        private MapleConfig MapleConfig;
        private List<CustomBindValue> ServiceTypeList;
        private List<CustomBindValue> ServicePolicyList;
        private AbstractService Service;

        public ServiceForm(AbstractService service = null, MapleConfig config = null)
        {
            this.MapleConfig = config;
            InitializeComponent();
            BindControlValue();

            this.Service = service;
            if (service == null)
            {
                Service = this.Service ?? (AbstractService)Activator.CreateInstance(Type.GetType($"MapleAutoBooster.Service.{this.ServiceType.SelectedValue}"));
                this.BindDefaultSelectValue();
            }
            this.BindSelectVale();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Service.SaveValidation();
                if (this.MapleConfig.ServiceData == null)
                    this.MapleConfig.ServiceData = new List<ServiceConfig>();
                var serviceConfig = new ServiceConfig()
                {
                    Guid = this.Service.Id ?? Guid.NewGuid().ToString(),
                    ServiceTypeId = this.Service.ServiceTypeId,
                    ServicePolicy = this.Service.ServicePolicy,
                    ServiceName = this.Service.ServiceName,
                    ServiceDescription = this.Service.ServiceDescription,
                    Operations = JsonConvert.SerializeObject(this.Service.Operations.ToList())
                };
                this.MapleConfig.ServiceData.RemoveAll(x => x.Guid == serviceConfig.Guid);
                this.MapleConfig.ServiceData.Add(serviceConfig);
                //序列化成ServiceObject保存起来
                this.MapleConfig.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BindControlValue()
        {
            //服务类型
            ServiceTypeList = new List<CustomBindValue>();
            ServiceTypeList.Add(new CustomBindValue { Key = "ColorFinderService", Value = "矩形范围内找色" });
            ServiceTypeList.Add(new CustomBindValue { Key = "AutoKeyService", Value = "自动按键" });
            ServiceType.ValueMember = "Key";
            ServiceType.DisplayMember = "Value";
            ServiceType.DataSource = this.ServiceTypeList;

            //执行策略
            ServicePolicyList = new List<CustomBindValue>();
            ServicePolicyList.Add(new CustomBindValue { Key = ServicePolicyEnum.Loop.ToString(), Value = "循环执行" });
            ServicePolicyList.Add(new CustomBindValue { Key = ServicePolicyEnum.Once.ToString(), Value = "执行一次" });
            ServicePolicy.ValueMember = "Key";
            ServicePolicy.DisplayMember = "Value";
            ServicePolicy.DataSource = this.ServicePolicyList;
        }

        private void BindDefaultSelectValue()
        {
            Service.ServiceTypeId = this.ServiceTypeList.First().Key;
            Service.ServiceName = this.ServiceTypeList.First().Value;
        }

        private void BindSelectVale()
        {
            this.ServiceDescription.Text = this.Service.ServiceDescription;
            this.ServicePolicy.SelectedItem = this.ServicePolicyList.First(x => x.Key == this.Service.ServicePolicy.ToString());
            this.ServiceType.SelectedItem = this.ServiceTypeList.First(x => x.Key == this.Service.ServiceTypeId);
            this.Service.PrepareOperations();
            foreach (var serviceObject in this.Service.Operations.GroupBy(x => x.OperateTarget))
            {
                var serviceControl = this.Controls.Find($"ServiceDo{serviceObject.Key}", true).First();
                var opObjects = serviceObject.SelectMany(x => x.Operations);
                serviceControl.Text = String.Join("\n", opObjects.Select(x => x.OperationString));
                this.ServiceDo_Leave(serviceControl, null);
            }
        }

        private void ServiceType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ServiceType.SelectedValue.ToString()))
            {
                return;
            }
            Service = (AbstractService)Activator.CreateInstance(Type.GetType($"MapleAutoBooster.Service.{this.ServiceType.SelectedValue}"));
            Service.ServiceTypeId = Convert.ToString(this.ServiceType.SelectedValue);
            Service.ServiceName = Convert.ToString(this.ServiceType.Text);
            Service.ServicePolicy = (ServicePolicyEnum)Enum.Parse(typeof(ServicePolicyEnum), this.ServicePolicy.SelectedValue.ToString());
            this.BindSelectVale();
        }

        private void ServicePolicy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Service.ServicePolicy = (ServicePolicyEnum)Enum.Parse(typeof(ServicePolicyEnum), this.ServicePolicy.SelectedValue.ToString());
        }

        private void ServiceDo_Leave(object sender, EventArgs e)
        {
            var ServiceDoBox = (Control)sender;
            var ServiceTarget = Convert.ToString(ServiceDoBox.Tag);
            var ServiceText = ServiceDoBox.Text;
            var ServiceDoOperations = this.Service.Operations.Where(x => x.OperateTarget == ServiceTarget).FirstOrDefault();
            if (ServiceDoOperations == null)
            {
                ServiceDoOperations = new OperateObject();
                ServiceDoOperations.OperateId = Guid.NewGuid().ToString();
                ServiceDoOperations.OperateTarget = ServiceTarget;
                ServiceDoOperations.Operations = new List<IOperation>();
                this.Service.Operations.Add(ServiceDoOperations);
            }
            else
                ServiceDoOperations.Operations.Clear();
            StringBuilder sb = new StringBuilder();

            foreach (var item in ServiceText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var operation = new Operation(item);
                ServiceDoOperations.Operations.Add(operation);
                var text = this.Service.OperationText(this.Service, operation);
                sb.AppendLine(text);
            }
            var serviceDescription = this.Controls.Find($"ServiceDescription{ServiceTarget}", true).First();
            serviceDescription.Text = sb.ToString();
        }

        private void ServiceDescription_TextChanged(object sender, EventArgs e)
        {
            this.Service.ServiceDescription = this.ServiceDescription.Text;
        }
    }
}
