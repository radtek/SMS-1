using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Entities.DaylistEnquiry20;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Entities.Engine
{
    public class DaylistEnquiryEngine20 : LRServiceEngineBase
    {
        private int m_ResponseTypeCode;

        public DaylistEnquiryEngine20(ILogger logger) : base(logger)
        {
        }

        public override void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
            var request = ServiceDefinition.CreateAndInitialiseRequest(objectDictionary) as RequestDaylistEnquiryV2_0Type;


            ServiceDefinition.ServiceRequest = request;
        }

        public override LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary)
        {
            var response = ServiceDefinition.ServiceResponse as ResponseDaylistEnquiryV2_0Type;

            var responseDto = new LRServiceResponseDTO();

            // populate response status
            CreateServiceResponseStatus();

            responseDto.ResponseStatus = this.ServiceResponseStatus;

            if (responseDto.ResponseStatus.IsRejection == false && responseDto.ResponseStatus.IsAcknowledgement == false)
            {
                
                }

            return responseDto;
        }

        public override void CloseServiceClient()
        {
            var client = ServiceDefinition.ServiceClient as DaylistEnquiryV2_0ServiceClient;

            client.Close();
        }

        public override void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
            var client = ServiceDefinition.ServiceClient as DaylistEnquiryV2_0ServiceClient;

            // set certificate and behavoir details
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, certificateSerialNumber);
            client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior(username,password));
        }

        public override void ExecuteService()
        {
            var client = ServiceDefinition.ServiceClient as DaylistEnquiryV2_0ServiceClient;
            var request = ServiceDefinition.ServiceRequest as RequestDaylistEnquiryV2_0Type;

            ServiceDefinition.ServiceResponse = client.daylistEnquiry(request);
        }

        private void CreateServiceResponseStatus()
        {
            var response = ServiceDefinition.ServiceResponse as ResponseDaylistEnquiryV2_0Type;

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
