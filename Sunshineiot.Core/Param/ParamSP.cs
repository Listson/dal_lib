/*************************************************************************
 * 文件名称 ：ParamSP.cs                          
 * 描述说明 ：SP参数构建
 * 
 
**************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using Sunshineiot.Data;
 

namespace Sunshineiot.Core
{
    public class ParamSP
    {
        protected ParamSPData data;

        public ParamSP Name(string name)
        {
            data.Name = name;
            return this;
        }

        public ParamSP Parameter(string name,object value)
        {
            data.Parameter.Add(name, value);
            return this;
        }

        public ParamSP ParameterOut(string name, DataTypes type)
        {
            data.ParameterOut.Add(name, type);
            return this;
        }
 
        public ParamSP()
        {
            data = new ParamSPData();
        }

        public static ParamSP Instance()
        {
            return new ParamSP();
        }

        public ParamSPData GetData()
        {
            return data;
        }
     }
}
