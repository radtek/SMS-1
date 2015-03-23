using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;
using Bec.TargetFramework.Entities.DTO;

namespace Bec.TargetFramework.Presentation.Web.WCF
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        private const string HEADER_URI_NAMESPACE = "http://tempuri.org";
        private const string HEADER_SOURCE_ADDRESS = "UserIdentificationMessageDTO";

        public ClientMessageInspector()
        {
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            if (HttpContext.Current != null)
            {
                MessageHeader header = null;
                try
                {
                    header = MessageHeader.CreateHeader(HEADER_SOURCE_ADDRESS, HEADER_URI_NAMESPACE, new UserIdentificationMessageDTO{UserID = Guid.NewGuid()});
                }
                catch (Exception e)
                {
                    header = MessageHeader.CreateHeader(HEADER_SOURCE_ADDRESS, HEADER_URI_NAMESPACE, null);
                }
                request.Headers.Add(header);
            }
            else if (OperationContext.Current != null)
            {
                //If service layer does a nested call to another service layer method, ensure that original web caller IP is passed through also 
                MessageHeader header = null;
                int index = OperationContext.Current.IncomingMessageHeaders.FindHeader(HEADER_SOURCE_ADDRESS, HEADER_URI_NAMESPACE);
                if (index > -1)
                {
                    var oldHeader =
                        OperationContext.Current.IncomingMessageHeaders.GetHeader<UserIdentificationMessageDTO>(index);

                    header = MessageHeader.CreateHeader(HEADER_SOURCE_ADDRESS, HEADER_URI_NAMESPACE, oldHeader);
                }
                else
                {
                    header = MessageHeader.CreateHeader(HEADER_SOURCE_ADDRESS, HEADER_URI_NAMESPACE, null);
                }

                request.Headers.Add(header);
            }

            return null;

        }
    }

    public class EndpointBehavior : IEndpointBehavior
    {
        public EndpointBehavior() { }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            ClientMessageInspector inspector = new ClientMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher) { }

        public void Validate(ServiceEndpoint endpoint) { }

    }

    public class BehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(EndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new EndpointBehavior();
        }
    }
}