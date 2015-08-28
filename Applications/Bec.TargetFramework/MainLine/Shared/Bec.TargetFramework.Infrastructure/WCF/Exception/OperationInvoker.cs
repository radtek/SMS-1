using System;
using System.Diagnostics;
using System.ServiceModel.Dispatcher;
using Bec.TargetFramework.Infrastructure.WCF.Exception;
using Bec.TargetFramework.Infrastructure.WCF.Event;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    /// <summary>
    /// 使用消息提取的对象以及参数数组，并利用对该对象调用方法，然后返回该方法的返回值和输出参数
    /// </summary>
    public class OperationInvoker:IOperationInvoker
    {
        private string operationMethod;//方法名称
        private IOperationInvoker invoker;//原invoker
        private Stopwatch sw;//用于计时

        public OperationInvoker(IOperationInvoker oldInvoker, string operationMethod)
        {
            this.invoker = oldInvoker;
            this.operationMethod = operationMethod;
            sw = new Stopwatch();
        }

        public object[] AllocateInputs()
        {
            return this.invoker.AllocateInputs();
        }
        /// <summary>
        /// 从一个实例和输入对象的集合返回一个对象和输出对象的集合
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="inputs"></param>
        /// <param name="outputs"></param>
        /// <returns></returns>
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            this.PreInvoke(instance, inputs);
            object returnValue = null;
            object invokeValue;
            object[] objArray = new object[0];
            System.Exception ex = null;
            try
            {
                invokeValue = this.invoker.Invoke(instance, inputs, out objArray);
                returnValue = invokeValue;
                outputs = objArray;
            }
            catch (System.Exception e)
            {
                ex = e;
                returnValue = null;
                outputs = null;
            }
            finally
            {
                this.PostInvoke(instance,returnValue,objArray,ex);
            }
            return returnValue;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            this.PreInvoke(instance,inputs);
            return this.invoker.InvokeBegin(instance, inputs, callback, state);
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            object returnValue = null;
            object invokeValue;
            object[] objArray = new object[0];
            System.Exception ex = null;
            try
            {
                invokeValue = this.invoker.InvokeEnd(instance,out outputs,result);
                returnValue = invokeValue;
                outputs = objArray;
            }
            catch (System.Exception e)
            {
                ex = e;
                returnValue = null;
                outputs = null;
            }
            finally
            {
                this.PostInvoke(instance, returnValue, objArray, ex);
            }
            return returnValue;
        }

        public bool IsSynchronous
        {
            get { return this.invoker.IsSynchronous; }
        }

        private void PreInvoke(object instance, object[] inputs)
        {
            sw.Start();
        }

        private void PostInvoke(object instane, object returnValue, object[] outputs, System.Exception ex)
        {
            this.sw.Stop();
            if (ex == null)//没有发生异常
            {
                WcfGlobalInvocation invocation = new WcfGlobalInvocation(instane,this.operationMethod,this.sw.ElapsedMilliseconds);
                WcfGlobalEventHelper.FireInvocation(invocation);
            }
            else //发生异常
            {
                WcfGlobalException we = new WcfGlobalException(ex.Message, ex.StackTrace, instane, this.operationMethod);
                WcfGlobalEventHelper.FireException(we);
                throw ex;
            }
        }
    }
}
