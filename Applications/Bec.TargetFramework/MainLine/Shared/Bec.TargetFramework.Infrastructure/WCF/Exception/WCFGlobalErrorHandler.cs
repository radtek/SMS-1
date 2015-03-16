using System;
using Bec.TargetFramework.Infrastructure.WCF.Event;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    /// <summary>
    /// WCF全局异常处理
    /// </summary>
    public class WcfGlobalErrorHandler:IErrorHandler
    {
        /// <summary>
        /// 启用错误相关处理并返回一个值
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>是否终止会话和上下文</returns>
        public bool HandleError(System.Exception ex)
        {
            try
            {
                WcfGlobalEventHelper.FireException(new WcfGlobalException(ex.Message, ex.StackTrace, null, null));
            }
            catch(System.Exception e)
            {
                Trace.TraceError("WcfGlobalErrorHandler logging failed: " + ex.ToString());

                Serilog.Log.Logger.Error(ex, ex.Message, null);
            }

            return !(ex is FaultException);
        }

        public void ProvideFault(System.Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            // log error
            Serilog.Log.Logger.Error(error, error.Message, null);

            if (error is FaultException) return;

            var messageFault = MessageFault.CreateFault(
                new FaultCode("Sender"),
                new FaultReason(error.Message),
                error,
                new NetDataContractSerializer());

            fault = Message.CreateMessage(version, messageFault, null);
            
        }

    }
}
