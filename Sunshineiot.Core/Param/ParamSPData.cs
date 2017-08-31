/*************************************************************************
 * 文件名称 ：ParamSPData.cs                          
 * 描述说明 ：SP参数数据
 * 
 
**************************************************************************/

using Sunshineiot.Data;
using System.Collections.Generic;
 

namespace Sunshineiot.Core
{
    public class ParamSPData
    {
        public string Name { get; set; }
        public Dictionary<string,object> Parameter { get; set; }
        public Dictionary<string, DataTypes> ParameterOut { get; set; }

        public ParamSPData()
        {
            Name = string.Empty;
            Parameter = new Dictionary<string, object>();
            ParameterOut = new Dictionary<string, DataTypes>();
        }
    }
}
