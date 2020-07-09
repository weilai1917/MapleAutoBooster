using MapleAutoBooster.AbstractOperate;
using MapleAutoBooster.ServiceAttribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster.Abstract
{
    public abstract class AbstractBoosterService
    {
        #region 基本属性

        private string _guid;

        private string _serviceTypeId;

        private string _ServiceName;

        private string _ServiceDescription;

        private ServicePolicyEnum _ServicePolicy;

        public string Id { get => _guid; set => _guid = value; }
        public string ServiceTypeId { get => _serviceTypeId; set => _serviceTypeId = value; }
        public string ServiceName { get => _ServiceName; set => _ServiceName = value; }
        public string ServiceDescription { get => _ServiceDescription; set => _ServiceDescription = value; }
        public ServicePolicyEnum ServicePolicy { get => _ServicePolicy; set => _ServicePolicy = value; }

        #endregion

        public ICollection<OperateObject> Operations;

        public ICollection<string> AnotherOperations;
        public AbstractBoosterService()
        {
            this.Operations = new List<OperateObject>();
            this.AnotherOperations = new List<string>();
            var defaultOp = this.SetDefaultOperations();
            foreach (var operations in defaultOp.GroupBy(x => x.Item1))
            {
                var opObject = new OperateObject();
                opObject.OperateId = Guid.NewGuid().ToString();
                opObject.OperateTarget = operations.Key;
                opObject.Operations = new List<IOperation>();
                foreach (var item in operations)
                {
                    opObject.Operations.Add(new Operation(item.Item2));
                }
                this.Operations.Add(opObject);
            }
        }

        public abstract List<Tuple<string, string>> SetDefaultOperations();

        public void HandleOperationMethod(string opString, Action<MethodInfo, string[]> method)
        {
            string[] operateMethod = opString.Replace("\r", "").Replace("]", "").Split('[');
            if (string.IsNullOrWhiteSpace(operateMethod[0]) || operateMethod.Length < 2)
            {
                return;
            }
            var methodName = operateMethod[0];
            var methodParam = operateMethod[1];

            var thisMethod = this.GetType().GetMethod(methodName);
            if (thisMethod == null)
            {
                return;
            }
            var thisMethodParam = methodParam.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            method(thisMethod, thisMethodParam);
        }

        public bool ValidateOperationMethod(MethodInfo method, string[] param)
        {
            return method.GetParameters().Length == param.Length;
        }

        public void ExeuteOperationMethod(MethodInfo method, string[] param)
        {
            method.Invoke(this, param);
        }

        public string GetOperationMethodText(MethodInfo method, string[] param)
        {
            object[] attrs = method.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (null != attrs && attrs.Length > 0)
                return string.Format(((DescriptionAttribute)attrs[0]).Description, param);
            return string.Empty;
        }

        public void SaveValidation()
        {
            if (string.IsNullOrEmpty(ServiceTypeId.ToString()))
                throw new ArgumentNullException("服务类型不能为空!!!");
            if (string.IsNullOrEmpty(ServiceName))
                throw new ArgumentNullException("服务名称不能为空!!!");
            if (string.IsNullOrEmpty(ServiceDescription))
                throw new ArgumentNullException("服务描述不能为空!!!");
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [ServiceMethod]
        [Description("运行其他服务,id:{0}")]
        public void RunService(string serviceId)
        {
            if (this.AnotherOperations == null)
            {
                this.AnotherOperations = new HashSet<string>();
            }
            this.AnotherOperations.Add(serviceId);
        }

        public void RunAllOperations(string loopKey, ref bool start)
        {
            var operations = Operations.GroupBy(x => x.OperateTarget).OrderBy(x => x.Key);
            try
            {
                foreach (var item in operations)
                {
                    do
                    {
                        foreach (var operation in item.SelectMany(x => x.Operations))
                        {
                            this.HandleOperationMethod(operation.OperationString, (m, p) => this.ExeuteOperationMethod(m, p));
                            if (!start) break;
                        }
                    } while (this.ServicePolicy == ServicePolicyEnum.Loop && item.Key == loopKey && start);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Sleep(string sleepTime)
        {
            Thread.Sleep(Convert.ToInt32(sleepTime));
        }

        public void LockProgram(string program)
        {
            //锁定某个程序进行执行


        }
    }

    public enum ServicePolicyEnum : int
    {
        Loop = 0,
        Once = 1
    }
}
