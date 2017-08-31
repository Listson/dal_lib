/*************************************************************************
 * 文件名称 ：ParamDeleteData.cs                          
 * 描述说明 ：接入参数数据
 * 
 
**************************************************************************/

using System.Collections.Generic;

namespace Sunshineiot.Core
{
    public class ParamInsertData
    {
        public string From { get; set; }
        public Dictionary<string,object> Columns { get; set; }

        public ParamInsertData()
        {
            From = "";
            Columns = new Dictionary<string, object>();
        }
    }
}
