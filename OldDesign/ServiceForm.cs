using MapleAutoBooster.Abstract;
using MapleAutoBooster.ServiceAttribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MapleAutoBooster
{
    public partial class ServiceForm : Form
    {
        private MapleConfig MapleConfig;
        private List<CustomBindValue> ServiceTypeList;
        private List<CustomBindValue> ServicePolicyList;
        private AbstractBoosterService BoosterService;

        public ServiceForm(AbstractBoosterService service = null, MapleConfig config = null)
        {
            this.MapleConfig = config;
            InitializeComponent();
            BindControlValue();

            this.BoosterService = service;
            if (service == null)
            {
                BoosterService = this.BoosterService ?? (AbstractBoosterService)Activator.CreateInstance(Type.GetType(this.ServiceType.SelectedValue.ToString()));
                this.BindDefaultSelectValue();
            }
            this.BindSelectVale();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.BoosterService.SaveValidation();
                var serviceConfig = new ServiceConfig();
                if (!string.IsNullOrEmpty(this.BoosterService.Id))
                {
                    serviceConfig = this.MapleConfig.ServiceData.First(x => x.Guid == this.BoosterService.Id);
                }
                else
                {
                    serviceConfig.Guid = Guid.NewGuid().ToString();
                }

                serviceConfig.ServiceTypeId = this.BoosterService.ServiceTypeId;
                serviceConfig.ServicePolicy = this.BoosterService.ServicePolicy;
                serviceConfig.ServiceName = this.BoosterService.ServiceName;
                serviceConfig.ServiceGroup = this.BoosterService.ServiceGroup;
                serviceConfig.ServiceDescription = this.BoosterService.ServiceDescription;
                serviceConfig.Operations = JsonConvert.SerializeObject(this.BoosterService.Operations.ToList());

                if (string.IsNullOrEmpty(this.BoosterService.Id))
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
            var allService = Assembly.Load(this.GetType().Namespace).GetTypes().Where(x =>
               typeof(AbstractBoosterService).IsAssignableFrom(x) &&
                x.GetCustomAttribute(typeof(ServiceTypeAttribute), false) != null);

            if (allService != null && allService.Count() > 0)
            {
                foreach (var item in allService)
                {
                    ServiceTypeList.Add(new CustomBindValue
                    {
                        Key = item.FullName,
                        Value = ((DescriptionAttribute)item.GetCustomAttribute(typeof(DescriptionAttribute))).Description
                    });
                }
            }
            ServiceType.ValueMember = "Key";
            ServiceType.DisplayMember = "Value";
            ServiceType.DataSource = this.ServiceTypeList;

            //执行策略
            ServicePolicyList = new List<CustomBindValue>();
            ServicePolicyList.Add(new CustomBindValue { Key = ServicePolicyEnum.Once.ToString(), Value = "执行一次" });
            ServicePolicyList.Add(new CustomBindValue { Key = ServicePolicyEnum.Loop.ToString(), Value = "循环执行" });
            ServicePolicy.ValueMember = "Key";
            ServicePolicy.DisplayMember = "Value";
            ServicePolicy.DataSource = this.ServicePolicyList;

            //服务分组
            this.ServiceGroup.DisplayMember = "Value";
            this.ServiceGroup.ValueMember = "Key";
            this.ServiceGroup.DataSource = this.MapleConfig.GroupData;
        }

        private void BindDefaultSelectValue()
        {
            BoosterService.ServiceGroup = this.MapleConfig.GroupData.First().Key;
            BoosterService.ServiceTypeId = this.ServiceTypeList.First().Key;
            BoosterService.ServiceName = this.ServiceTypeList.First().Value;
        }

        private void BindSelectVale()
        {
            this.ServiceDescription.Text = this.BoosterService.ServiceDescription;
            this.ServicePolicy.SelectedItem = this.ServicePolicyList.First(x => x.Key == this.BoosterService.ServicePolicy.ToString());
            this.ServiceType.SelectedItem = this.ServiceTypeList.First(x => x.Key == this.BoosterService.ServiceTypeId);
            this.ServiceGroup.SelectedItem = this.MapleConfig.GroupData.First(x => x.Key == this.BoosterService.ServiceGroup);
            foreach (var serviceObject in this.BoosterService.Operations.GroupBy(x => x.OperateTarget))
            {
                var serviceControl = this.Controls.Find($"ServiceDo{serviceObject.Key}", true).First();
                var opObjects = serviceObject.SelectMany(x => x.Operations);
                serviceControl.Text = String.Join("\n", opObjects.Select(x => x.OperationString));
                this.ServiceDo_Leave(serviceControl, null);
            }
            this.ListCanActMethod.Items.Clear();
            var canActMethodName = this.BoosterService.GetType().GetMethods().Where(x => x.GetCustomAttributes(typeof(ServiceMethodAttribute), false).Any()).Select(x => x.Name);
            if (canActMethodName != null && canActMethodName.Count() > 0)
            {
                foreach (var item in canActMethodName)
                {
                    this.ListCanActMethod.Items.Add(item);
                }
            }

        }

        private void ServiceType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ServiceType.SelectedValue.ToString()))
            {
                return;
            }
            BoosterService = (AbstractBoosterService)Activator.CreateInstance(Type.GetType(this.ServiceType.SelectedValue.ToString()));
            BoosterService.ServiceTypeId = Convert.ToString(this.ServiceType.SelectedValue);
            BoosterService.ServiceName = Convert.ToString(this.ServiceType.Text);
            BoosterService.ServicePolicy = (ServicePolicyEnum)Enum.Parse(typeof(ServicePolicyEnum), this.ServicePolicy.SelectedValue.ToString());
            BoosterService.ServiceGroup = Convert.ToString(this.ServiceGroup.SelectedValue);
            this.BindSelectVale();
        }

        private void ServicePolicy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BoosterService.ServicePolicy = (ServicePolicyEnum)Enum.Parse(typeof(ServicePolicyEnum), this.ServicePolicy.SelectedValue.ToString());
        }

        private void ServiceDo_Leave(object sender, EventArgs e)
        {
            var ServiceDoBox = (Control)sender;
            var ServiceTarget = Convert.ToString(ServiceDoBox.Tag);
            var ServiceText = ServiceDoBox.Text;
            var ServiceDoOperations = this.BoosterService.Operations.Where(x => x.OperateTarget == ServiceTarget).FirstOrDefault();
            if (ServiceDoOperations == null)
            {
                ServiceDoOperations = new OperateObject();
                ServiceDoOperations.OperateId = Guid.NewGuid().ToString();
                ServiceDoOperations.OperateTarget = ServiceTarget;
                ServiceDoOperations.Operations = new List<IOperation>();
                this.BoosterService.Operations.Add(ServiceDoOperations);
            }
            else
                ServiceDoOperations.Operations.Clear();
            StringBuilder sb = new StringBuilder();

            foreach (var item in ServiceText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var operation = new Operation(item);
                ServiceDoOperations.Operations.Add(operation);
            }
        }

        private void ServiceDescription_TextChanged(object sender, EventArgs e)
        {
            this.BoosterService.ServiceDescription = this.ServiceDescription.Text;
        }

        private void ServiceGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.BoosterService.ServiceGroup = Convert.ToString(this.ServiceGroup.SelectedValue);
        }
    }
}
