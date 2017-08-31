/*************************************************************************
 * 文件名称 ：ServiceBaseUpdate.cs                          
 * 描述说明 ：定义数据服务基类中的更新处理
 * 
 
 **************************************************************************/

using System;
using System.Collections.Generic;
namespace Sunshineiot.Core
{
    public partial class ServiceBase<T> where T : ModelBase, new()
    {
        protected virtual bool OnBeforeUpdate(UpdateEventArgs arg)
        {
            return true;
        }

        protected virtual void OnAfterUpdate(UpdateEventArgs arg)
        {

        }

        public int Update(ParamUpdate param)
        {
            var result = 0;
            Logger("更新记录", () =>
            {
                db.UseTransaction(true);
                var rtnBefore = this.OnBeforeUpdate(new UpdateEventArgs() { db = db, data = param.GetData() });
                if (!rtnBefore) return;
                result = BuilderParse(param).Execute();
                Msg.Set(MsgType.Success, APP.MSG_UPDATE_SUCCESS);
                this.OnAfterUpdate(new UpdateEventArgs() { db = db, data = param.GetData(), executeValue=result });
                db.Commit();
            });
            return result;
        }

        public int Update(T t)
        {
            IDictionary<string, object> ds = t.Extend(t);
            var pk = ModelBase.GetAttributeFields<T, PrimaryKeyAttribute>();
            if (pk.Count == 0)
            {
                throw new Exception("未找到实体主键！");
            }

            ParamUpdate pi = ParamUpdate.Instance();
            foreach (string field in pk)
            {
                pi.AndWhere(field, ds[field]);
            }

            foreach (string key in ds.Keys)
            {
                pi.Column(key, ds[key]);
            }
            return Update(pi);
        }
    }
}
