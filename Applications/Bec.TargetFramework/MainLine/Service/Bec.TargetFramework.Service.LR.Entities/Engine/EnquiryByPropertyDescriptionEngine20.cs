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
using Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Entities.Engine
{
    public class EnquiryByPropertyDescriptionEngine20 : LRServiceEngineBase
    {
        private int m_ResponseTypeCode;

        public EnquiryByPropertyDescriptionEngine20(ILogger logger) : base(logger)
        {
        }

        public override void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
            var request = ServiceDefinition.CreateAndInitialiseRequest(objectDictionary) as RequestSearchByPropertyDescriptionV2_0Type;

            request.Product.SubjectProperty.Address.PostcodeZone = "BR1 2FE";
            request.Product.SubjectProperty.Address.BuildingNumber = "1";

            ServiceDefinition.ServiceRequest = request;
        }

        public override LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary)
        {
            var response = ServiceDefinition.ServiceResponse as ResponseSearchByPropertyDescriptionV2_0Type;

            var responseDto = new LRServiceResponseDTO();

            // populate response status
            CreateServiceResponseStatus();

            responseDto.ResponseStatus = this.ServiceResponseStatus;

            if (responseDto.ResponseStatus.IsRejection == false && responseDto.ResponseStatus.IsAcknowledgement == false)
            {
                if (response.GatewayResponse.Results.Title != null && response.GatewayResponse.Results.Title.Length > 0)
                {
                    var titleList = new List<LRTitleDTO>();

                    response.GatewayResponse.Results.Title.ToList()
                        .ForEach(item =>
                        {
                            var titleDto = new LRTitleDTO();

                            titleDto.CreatedOn = DateTime.Now;
                            titleDto.LRTitleID = Guid.NewGuid();
                            titleDto.CreatedBy = "System";

                            if (item.Description != null)
                                titleDto.Description = item.Description.Value;

                            if (item.TitleNumber != null)
                                titleDto.TitleNumber = item.TitleNumber.Value;

                            if (item.TenureInformation != null)
                            {
                                if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item0)
                                    titleDto.LRPropertyTenureTypeID = 2100002;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item10)
                                    titleDto.LRPropertyTenureTypeID = 2100001;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item20)
                                    titleDto.LRPropertyTenureTypeID = 2100003;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item30)
                                    titleDto.LRPropertyTenureTypeID = 2100004;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item40)
                                    titleDto.LRPropertyTenureTypeID = 2100005;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item100)
                                    titleDto.LRPropertyTenureTypeID = 2100006;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item110)
                                    titleDto.LRPropertyTenureTypeID = 2100007;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item120)
                                    titleDto.LRPropertyTenureTypeID = 2100008;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item130)
                                    titleDto.LRPropertyTenureTypeID = 2100009;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item140)
                                    titleDto.LRPropertyTenureTypeID = 2100010;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item150)
                                    titleDto.LRPropertyTenureTypeID = 2100011;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item160)
                                    titleDto.LRPropertyTenureTypeID = 2100012;
                                else if (item.TenureInformation.TenureTypeCode.Value == TenureCodeContentType.Item170)
                                    titleDto.LRPropertyTenureTypeID = 2100013;
                            }

                            if (item.Address != null)
                            {
                                var addressDto = new AddressDTO();
                                addressDto.AddressID = Guid.NewGuid();
                                addressDto.AddressTypeID = AddressTypeIDEnum.Home.GetIntValue();
                                addressDto.AddressNumber = 0;
                                addressDto.ParentID = titleDto.LRTitleID;

                                if (item.Address.BuildingNumber != null)
                                    addressDto.Line1 = item.Address.BuildingNumber.Value;

                                if (item.Address.BuildingName != null)
                                    addressDto.BuildingName = item.Address.BuildingName.Value;

                                if (item.Address.CityName != null)
                                    addressDto.City = item.Address.CityName.Value;

                                if (item.Address.PostcodeZone.Postcode != null)
                                    addressDto.PostalCode = item.Address.PostcodeZone.Postcode.Value;

                                if (item.Address.SubBuildingName != null)
                                    addressDto.AdditionalAddressInformation = item.Address.SubBuildingName.Value;

                                titleDto.Address = addressDto;
                            }

                            titleList.Add(titleDto);
                        });

                    responseDto.ResponseDictionary.TryAdd("LRTitleDTOList", titleList);
                }

                return responseDto;
            }

            return new LRServiceResponseDTO();
        }

        public override void CloseServiceClient()
        {
            var client = ServiceDefinition.ServiceClient as PropertyDescriptionEnquiryV2_0ServiceClient;

            client.Close();
        }

        public override void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
            var client = ServiceDefinition.ServiceClient as PropertyDescriptionEnquiryV2_0ServiceClient;

            // set certificate and behavoir details
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, certificateSerialNumber);
            client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior(username,password));
        }

        public override void ExecuteService()
        {
            var client = ServiceDefinition.ServiceClient as PropertyDescriptionEnquiryV2_0ServiceClient;
            var request = ServiceDefinition.ServiceRequest as RequestSearchByPropertyDescriptionV2_0Type;

            ServiceDefinition.ServiceResponse = client.searchProperties(request);
        }

        private void CreateServiceResponseStatus()
        {
            var response = ServiceDefinition.ServiceResponse as ResponseSearchByPropertyDescriptionV2_0Type;

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
