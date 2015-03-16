using System.ComponentModel;
using Bec.TargetFramework.Infrastructure.WCF.Exception;

namespace Bec.TargetFramework.Infrastructure.WCF.Event
{
    public delegate void WcfGlobalExceptionEventHandler(WcfGlobalException ex);

    public delegate void WcfGlobalInvocationEventHandler(WcfGlobalInvocation invocation);
    public  class WcfGlobalEventHelper
    {
        //发生异常时
        private static EventHandlerList listExceptionHandler = new EventHandlerList();
        private static readonly object keyException = new object();

        //未发生异常时
        private static EventHandlerList listInvocationHandler = new EventHandlerList();
        private static readonly object keyInvocation = new object();

        /// <summary>
        /// wcf方法发生异常时触发该事件
        /// </summary>
        public static event WcfGlobalExceptionEventHandler OnGlobalExceptionExec
        {
            add { listExceptionHandler.AddHandler(keyException, value); }
            remove { listExceptionHandler.RemoveHandler(keyException, value); }
        }

        public static void FireException(WcfGlobalException ex)
        {
            var handler = (WcfGlobalExceptionEventHandler)listExceptionHandler[keyException];
            if(handler != null)
            {
                handler(ex);
            }
        }
        /// <summary>
        /// wcf方法调用成功是触发该事件
        /// </summary>
        public static event WcfGlobalInvocationEventHandler onGlobalInvocationExec
        {
            add { listInvocationHandler.AddHandler(keyInvocation,value);}
            remove { listInvocationHandler.RemoveHandler(keyInvocation,value);}
        }

        public static void FireInvocation(WcfGlobalInvocation invocation)
        {
            var handler = (WcfGlobalInvocationEventHandler) listInvocationHandler[keyInvocation];
            if (handler != null)
            {
                handler(invocation);
            }
        }
    }
}
