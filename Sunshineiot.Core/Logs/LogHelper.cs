/*************************************************************************
 * 文件名称 ：LogHelper.cs                          
 * 描述说明 ：日志处理
 * 
**************************************************************************/

using System;
using System.IO;
using System.Reflection;
using log4net;

namespace Sunshineiot.Core
{
    public class LogHelper
    {
        static LogHelper()
        {
            Init();
        }
        #region 全局设置
        public static void Init()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("Sunshineiot.Core.Logs.Default.config");
            log4net.Config.XmlConfigurator.Configure(xml);
        }

        public static void Init(string path)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        }

        public static void Init(Stream xml)
        {
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        #endregion

        public static void Logger(ILog log, string function, ErrorHandle errorHandleType, Action tryHandle, Action<Exception> catchHandle = null, Action finallyHandle = null)
        {
            try
            {
                log.Debug(function);
                tryHandle();
            }
            catch (Exception ex)
            {
                log.Error(function + "失败", ex);

                if (catchHandle != null)
                    catchHandle(ex);
                
                if (errorHandleType == ErrorHandle.Throw) 
                    throw ex;
            }
            finally
            {
                if (finallyHandle != null)
                    finallyHandle();
            }
        }
    }
}
