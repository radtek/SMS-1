using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Service.LR.Entities.EnquiryByPropertyDescription20;
using Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21;
using Bec.TargetFramework.Service.LR.Infrastructure;
using Bec.TargetFramework.Service.LR.Infrastructure.Base;

using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;
using Bec.TargetFramework.Entities;
using EnsureThat;
using Ionic.Zip;
using ProductResponseCodeContentType = Bec.TargetFramework.Service.LR.Entities.OfficialCopyWithSummary21.ProductResponseCodeContentType;
using ServiceStack.Text;


namespace Bec.TargetFramework.Service.LR.Entities.Engine
{
    public class OfficialCopyWithSummaryEngine21 : LRServiceEngineBase
    {
        private int m_ResponseTypeCode;

        public OfficialCopyWithSummaryEngine21(ILogger logger)
            : base(logger)
        {
            
        }

        public override void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
            var request = ServiceDefinition.CreateAndInitialiseRequest(objectDictionary) as RequestOCWithSummaryV2_0Type;

            Ensure.That(request).IsNotNull();
            Ensure.That(objectDictionary["LRTitleDTO"]).IsNotNull();
            Ensure.That(objectDictionary["AddressDTO"]).IsNotNull();

            var address = objectDictionary["AddressDTO"] as AddressDTO;
            var titleDto = objectDictionary["LRTitleDTO"] as LRTitleDTO;

            request.Product.SubjectProperty.TitleNumber = new Q2TextType();
            request.Product.SubjectProperty.TitleNumber.Value = titleDto.TitleNumber;

            request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.ContinueIfActualFeeExceedsExpectedFeeIndicator.Value = true;
            request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.ContinueIfTitleIsClosedAndContinuedIndicator.Value = true;
            request.Product.TitleKnownOfficialCopy.IncludeTitlePlanIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.IncludeTitlePlanIndicator.Value = true;
            request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.NotifyIfPendingApplicationIndicator.Value = true;
            request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.NotifyIfPendingFirstRegistrationIndicator.Value = true;
            request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator = new IndicatorType();
            request.Product.TitleKnownOfficialCopy.SendBackDatedIndicator.Value = true;

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

            if (responseDto.ResponseStatus.IsRejection == false && responseDto.ResponseStatus.IsAcknowledgement == false)
            {
                var registerExtract = new LRRegisterExtractDTO();

                registerExtract.CreatedOn = DateTime.Now;
                registerExtract.CreatedBy = "System";
                registerExtract.LRRegisterExtractID = Guid.NewGuid();
                registerExtract.RegisterExtractData = response.GatewayResponse.Results.ToJson();
                registerExtract.LRTitleID = titleDto.LRTitleID;

                // determine attachments if any and process
                if (response.GatewayResponse.Results.Attachment != null)
                {
                    var documents = new List<LRDocumentDTO>();

                    if (response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.format.Equals("ZIP"))
                    {
                        using (
                        var ms =
                            new MemoryStream(response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.Value)
                        )
                        {
                            using (var zip = ZipFile.Read(ms))
                            {
                                zip.Entries.ToList()
                                    .ForEach(ze =>
                                    {
                                        MemoryStream extractStream = new MemoryStream();

                                        // extract to stream
                                        ze.Extract(extractStream);
                                        
                                        var dto = new AttachmentDTO();
                                        dto.AttachmentID = Guid.NewGuid();
                                        dto.FileName = ze.FileName;
                                        dto.Body = extractStream.ToArray();

                                        var lrDocumentDto = new LRDocumentDTO();
                                        lrDocumentDto.Attachment = dto;
                                        lrDocumentDto.LRDocumentID = Guid.NewGuid();
                                        lrDocumentDto.LRTitleID = titleDto.LRTitleID;

                                        documents.Add(lrDocumentDto);

                                        extractStream.Close();
                                    });
                            }

                            ms.Close();
                        }
                    }
                    else if (response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.format.Equals("PDF"))
                    {
                        var dto = new AttachmentDTO();
                        dto.AttachmentID = Guid.NewGuid();
                        dto.FileName = response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.filename;
                        dto.Body = response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.Value;
                        dto.MimeType = response.GatewayResponse.Results.Attachment.EmbeddedFileBinaryObject.mimeCode;

                        var lrDocumentDto = new LRDocumentDTO();
                        lrDocumentDto.Attachment = dto;
                        lrDocumentDto.LRDocumentID = Guid.NewGuid();
                        lrDocumentDto.LRTitleID = titleDto.LRTitleID;

                        documents.Add(lrDocumentDto);
                    }

                    responseDto.ResponseDictionary.TryAdd("LRDocumentDTOList", documents);
                }

                responseDto.ResponseDictionary.TryAdd("LRRegisterExtractDTO", registerExtract);
            }

            return responseDto;
        }

        public override void CloseServiceClient()
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1ServiceClient;

            client.Close();
        }

        public override void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1ServiceClient;

            // set certificate and behavoir details
            client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.Root, X509FindType.FindBySerialNumber, certificateSerialNumber);
            client.ChannelFactory.Endpoint.Behaviors.Add(new LREndpointBehavior(username,password));
        }

        public override void ExecuteService()
        {
            var client = ServiceDefinition.ServiceClient as OCWithSummaryV2_1ServiceClient;
            var request = ServiceDefinition.ServiceRequest as RequestOCWithSummaryV2_0Type;

            ServiceDefinition.ServiceResponse = client.performOCWithSummary(request);
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
