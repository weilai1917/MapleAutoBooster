using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleAutoBooster.AbstractOperate
{
    public abstract class AbstractOperateService : IService
    {
        //public OperateObject oObject { get; private set; }

        //private bool isValidObj = false;

        //public abstract bool ValidateOperateObject();

        //public void SetOperateObject(OperateObject o)
        //{
        //    if (!ValidateOperateObject())
        //    {
        //        throw new ArgumentException("执行服务校验格式不通过，请按照描述正确配置。");
        //    }
        //    this.isValidObj = true;
        //    this.oObject = o;
        //}

        //public IOperation OnProcess()
        //{
        //    if (!isValidObj)
        //    {
        //        throw new ArgumentException("???");
        //    }

        //    IOperation lastOperate = null;
        //    foreach (var operate in oObject.Operations)
        //    {
        //        lastOperate = operate;
        //       // operate.DoWork();
        //    }
        //    return lastOperate;
        //}
    }
}
