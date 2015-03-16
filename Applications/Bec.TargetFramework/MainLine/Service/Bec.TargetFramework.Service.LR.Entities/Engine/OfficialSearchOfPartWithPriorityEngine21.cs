using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Entities.EarlyCompletionPoll20;
using Bec.TargetFramework.Service.LR.Entities.OfficialSearchOfPartWithPriority21;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;

using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using ProductResponseCodeContentType = Bec.TargetFramework.Service.LR.Entities.OfficialSearchOfPartWithPriority21.ProductResponseCodeContentType;

namespace Bec.TargetFramework.Service.LR.Entities.Engine
{
    public class OfficialSearchOfPartWithPriorityEngine21 : LRServiceEngineBase
    {
        private int m_ResponseTypeCode;

        public OfficialSearchOfPartWithPriorityEngine21(ILogger logger)
            : base(logger)
        {
            
        }

        public override void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
            var request = ServiceDefinition.CreateAndInitialiseRequest(objectDictionary) as RequestOfficialSearchOfPartWithPriorityV2_1Type;

           // request.Product.SubjectProperty.Address.PostcodeZone = "BR1 2FE";
            //request.Product.SubjectProperty.Address.BuildingNumber = "1";

            ServiceDefinition.ServiceRequest = request;
        }

        public override LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary)
        {
            // populate response status
            CreateServiceResponseStatus();

            return new LRServiceResponseDTO();
        }

        public override void CloseServiceClient()
        {
            var client = ServiceDefinition.ServiceClient as OfficialSearchOfPartWithPriority21.OfficialSearchOfPartV2_1ServiceClient;

            client.Close();
        }

        public override void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
            var client = ServiceDefinition.ServiceClient as OfficialSearchOfPartWithPriority21.OfficialSearchOfPartV2_1ServiceClient;

            // set certificate and behavoir details
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, certificateSerialNumber);
            client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior(username,password));
        }

        public override void ExecuteService()
        {
            var client = ServiceDefinition.ServiceClient as OfficialSearchOfPartWithPriority21.OfficialSearchOfPartV2_1ServiceClient;
            var request = ServiceDefinition.ServiceRequest as RequestOfficialSearchOfPartWithPriorityV2_1Type;

            ServiceDefinition.ServiceResponse = client.processOS2Request(request);
        }

        private void CreateServiceResponseStatus()
        {
            var response = ServiceDefinition.ServiceResponse as OfficialSearchOfPartWithPriorityResponseV2_0Type;

            ServiceResponseStatus = new LRServiceResponseStatusDTO();

            if (response.GatewayResponse.TypeCode.Value == ProductResponseCodeContentType.Item10)
            {
                ServiceResponseStatus.IsAcknowledgement = true;
                ServiceResponseStatus.IsRejection = false;

                ServiceResponseStatus.Acknowledgement = new AcknowledgementDTO
                {
                    Date =
                        response.GatewayResponse.Acknowledgement.AcknowledgementDetails.ExpectedResponseDateTime.Value,
                    ID = response.GatewayResponse.Acknowledgement.AcknowledgementDetails.UniqueID.Value,
                    Message = response.GatewayResponse.Acknowledgement.AcknowledgementDetails.MessageDescription.Value
                };
            }
            else if (response.GatewayResponse.TypeCode.Value == ProductResponseCodeContentType.Item20)
            {
                ServiceResponseStatus.IsAcknowledgement = false;
                ServiceResponseStatus.IsRejection = true;
                ServiceResponseStatus.ExternalReference =
                    response.GatewayResponse.Rejection.ExternalReference.Reference.Value;

                ServiceResponseStatus.Rejection = new RejectionDTO
                {
                    Code = response.GatewayResponse.Rejection.RejectionResponse.Code.Value,
                    Reason = response.GatewayResponse.Rejection.RejectionResponse.Reason.Value,
                    ValidationErrors = new List<ValidationErrorDTO>()
                };

                if (response.GatewayResponse.Rejection.RejectionResponse.ValidationErrors != null
                    && response.GatewayResponse.Rejection.RejectionResponse.ValidationErrors.Length > 0)
                {
                    response.GatewayResponse.Rejection.RejectionResponse.ValidationErrors.ToList()
                        .ForEach(item =>
                        {
                            var dto = new ValidationErrorDTO
                            {
                                Code = item.Code.Value,
                                Description = item.Description.Value
                            };

                             ServiceResponseStatus.Rejection.ValidationErrors.Add(dto);
                        });
                }
            }

        }
    }
}
