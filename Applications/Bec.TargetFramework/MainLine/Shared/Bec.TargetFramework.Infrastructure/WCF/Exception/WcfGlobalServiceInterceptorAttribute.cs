using System;
using System.ServiceModel.Description;

namespace Bec.TargetFramework.Infrastructure.WCF.Exception
{
    [AttributeUsage(AttributeTargets.Class)]
    public class WcfGlobalServiceInterceptorAttribute:Attribute,IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            foreach (var endpoint in serviceDescription.Endpoints)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    bool flag = false;
                    foreach (var operationBehavior in operation.Behaviors)
                    {
                        if (operationBehavior is WcfGlobalOperationInterceptorAttribute)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        operation.Behaviors.Add(CreateOperationInterceptor(operation.Name));
                    }
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase)
        {
            
        }
        protected WcfGlobalOperationInterceptorAttribute CreateOperationInterceptor(string operationMethod)
        {
            return new WcfGlobalOperationInterceptorAttribute(operationMethod);
        }
    }
}
