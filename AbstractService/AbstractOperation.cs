using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.Abstract
{
    public abstract class AbstractOperation
    {
        private string _OperationString;
        public string OperationString { get => _OperationString; set => _OperationString = value; }

        public void HandleOperationMethod(AbstractBoosterService service, Action<MethodInfo, string[]> method)
        {
            string[] operateMethod = this.OperationString.Replace("\r", "").Replace("]", "").Split('[');
            if (string.IsNullOrWhiteSpace(operateMethod[0]) || operateMethod.Length < 2)
            {
                return;
            }
            var methodName = operateMethod[0];
            var methodParam = operateMethod[1];

            var thisMethod = service.GetType().GetMethod(methodName);
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

    }
}
