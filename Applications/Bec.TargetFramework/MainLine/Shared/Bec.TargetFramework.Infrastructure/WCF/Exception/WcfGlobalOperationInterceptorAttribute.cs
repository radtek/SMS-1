using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    public class WcfGlobalOperationInterceptorAttribute:Attribute,IOperationBehavior
    {
        private string operationMethod;

        public WcfGlobalOperationInterceptorAttribute(string methodName)
        {
            this.operationMethod = methodName;
        }

        public void AddBindingParameters(OperationDescription operationDescription, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.ClientOperation clientOperation)
        {
            
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, System.ServiceModel.Dispatcher.DispatchOperation dispatchOperation)
        {
            IOperationInvoker invoke = dispatchOperation.Invoker;
            dispatchOperation.Invoker = CreateInvoker(invoke);
        }

        public void Validate(OperationDescription operationDescription)
        {
            
        }

        protected OperationInvoker CreateInvoker(IOperationInvoker oldInvoker)
        {
            return new OperationInvoker(oldInvoker, this.operationMethod);
        }
    }
}
