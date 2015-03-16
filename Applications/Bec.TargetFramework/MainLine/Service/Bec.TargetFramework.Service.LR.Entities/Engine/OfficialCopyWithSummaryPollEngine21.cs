using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummaryPoll21;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;

using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using Bec.TargetFramework.Entities;
using EnsureThat;
using Ionic.Zip;

using ServiceStack.Text;


namespace Bec.TargetFramework.Service.LR.Entities.Engine
{
    public class OfficialCopyWithSummaryEnginePoll21 : LRServiceEngineBase
    {
        private int m_ResponseTypeCode;

        public OfficialCopyWithSummaryEnginePoll21(ILogger logger)
            : base(logger)
        {
            
        }

        public override void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
            var request = ServiceDefinition.CreateAndInitialiseRequest(objectDictionary) as PollRequestType;

            ServiceDefinition.ServiceRequest = request;
        }

        public override LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary)
        {
            var response = ServiceDefinition.ServiceResponse as ResponseOCWithSummaryV2_1Type;

            var titleDto = objectDictionary["LRTitleDTO"] as LRTitleDTO;

            var responseDto = new LRServiceResponseDTO();

            // populate response status
            CreateServiceResponseStatus();

            responseDto.ResponseStatus = this.ServiceResponseStatus;

            return responseDto;
        }

        public override void CloseServiceClient()
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1PollServiceClient;

            client.Close();
        }

        public override void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1PollServiceClient;

            // set certificate and behavoir details
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, certificateSerialNumber);
            client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior(username,password));
        }

        public override void ExecuteService()
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1PollServiceClient;
            var request = ServiceDefinition.ServiceRequest as PollRequestType;

            ServiceDefinition.ServiceResponse = client.getResponse(request);
        }

        private void CreateServiceResponseStatus()
        {
            var response = ServiceDefinition.ServiceResponse as ResponseOCWithSummaryV2_1Type;

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
