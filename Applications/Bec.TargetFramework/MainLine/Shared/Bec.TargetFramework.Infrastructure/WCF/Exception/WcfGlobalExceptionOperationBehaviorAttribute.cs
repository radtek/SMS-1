using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    //BehaviorExtensionElement
    public class WcfGlobalExceptionOperationBehaviorAttribute:Attribute,IServiceBehavior
    {
        //public override Type BehaviorType
        //{
        //    get { return typeof (WcfGlobalExceptionOpreationBehavior); }
        //}

        //protected override object CreateBehavior()
        //{
        //    return new WcfGlobalExceptionOpreationBehavior();
        //}

        private readonly Type _errorHandlerType;
        public WcfGlobalExceptionOperationBehaviorAttribute(Type handlerType)
        {
            _errorHandlerType = handlerType;
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
           
        }
        /// <summary>
        /// 注入自定义异常处理程序
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            var handler = (IErrorHandler) Activator.CreateInstance(_errorHandlerType);
            foreach (ChannelDispatcher dis in serviceHostBase.ChannelDispatchers)
            {
                dis.ErrorHandlers.Add(handler);
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            
        }

    }
}
