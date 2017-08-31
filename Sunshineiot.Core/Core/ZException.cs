/*************************************************************************
 * 文件名称 ：ZException.cs                          
 * 描述说明 ：框架错误定义
 * 
 
 **************************************************************************/

using System;

namespace Sunshineiot.Core
{
	public class ZException : Exception
	{
		public ZException(string message): base(message){}
        public ZException(string message, Exception innerException) : base(message, innerException) { }
	}
}
