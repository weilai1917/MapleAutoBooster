using MapleAutoBooster.AbstractOperate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleAutoBooster.Abstract
{
    public abstract class AbstractService : IService
    {

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 运行时还是设计时
        /// </summary>
        public bool Runtime = false;

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

        public ICollection<OperateObject> Operations;

        public ICollection<string> AnotherOperations;

        public virtual void PrepareOperations()
        {
            if (this.Operations == null)
            {
                this.Operations = new List<OperateObject>();
                this.AnotherOperations = new List<string>();
                this.SetDefaultOperations();
            }
        }

        public abstract void SetDefaultOperations();

        public virtual bool AnalyseOperation(AbstractService services, IOperation op)
        {
            string[] opStr = op.OperationString.Replace("\r", "").Split(new char[] { '-' }, 2);
            if (string.IsNullOrWhiteSpace(opStr[0]))
            {
                return false;
            }
            var method = services.GetType().GetMethod(opStr[0]);
            if (method == null)
                return false;
            op.DoWork(() =>
            {
                method.Invoke(services, opStr.Length > 1 ? new object[] { opStr[1] } : null);
                return string.Empty;
            });
            return true;
        }

        public virtual string OperationText(AbstractService services, IOperation op)
        {
            string[] opStr = op.OperationString.Replace("\r", "").Split(new char[] { '-' }, 2);
            string opDesc = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(opStr[0]))
                {
                    return opDesc;
                }
                var method = services.GetType().GetMethod(opStr[0]);
                opDesc = op.DoWork(() =>
                {
                    return Convert.ToString(method.Invoke(services, opStr.Length > 1 ? new object[] { opStr[1] } : null));
                });
            }
            catch (Exception ex)
            {
                return op.OperationString;
            }

            return opDesc;
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

        public string RunService(string serviceId)
        {
            if (this.AnotherOperations == null)
            {
                this.AnotherOperations = new HashSet<string>();
            }
            this.AnotherOperations.Add(serviceId);
            return $"运行其他服务,id:{serviceId}";
        }

        public void Run(string loopKey, ref bool start)
        {
            var operate = Operations.GroupBy(x => x.OperateTarget).OrderBy(x => x.Key);
            foreach (var item in operate)
            {
                try
                {
                    do
                    {
                        foreach (var operation in item.SelectMany(x => x.Operations))
                        {
                            if (!this.AnalyseOperation(this, operation) || !start)
                            {
                                break;
                            }
                        }
                    } while (this.ServicePolicy == ServicePolicyEnum.Loop && item.Key == loopKey && start);
                }
                catch (Exception)
                {
                }

            }
        }

        public string Sleep(string sleepTime)
        {
            if (Runtime)
            {
                Thread.Sleep(Convert.ToInt32(sleepTime));
            }
            return $"休眠{sleepTime}毫秒";
        }

        public string LockProgram(string program)
        {
            //锁定某个程序进行执行


            return "";
        }
    }

    public enum ServicePolicyEnum : int
    {
        Loop = 0,
        Once = 1
    }
}
