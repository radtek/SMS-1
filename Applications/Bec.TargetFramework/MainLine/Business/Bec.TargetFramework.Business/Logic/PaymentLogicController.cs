﻿using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.FirstData;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Entities.Settings;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.SB.Client.Interfaces;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.SB.Entities;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class PaymentLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public ProductLogicController ProductLogic { get; set; }
        public ShoppingCartLogicController ShoppingCartLogic { get; set; }
        public InvoiceLogicController InvoiceLogic { get; set; }
        public TransactionOrderLogicController TransactionOrderLogic { get; set; }
        public OrganisationLogicController OrganisationLogic { get; set; }
        public ClassificationDataLogicController ClassificationLogic { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }

        private CreditCardTxTypeType ConvertChargeType(PaymentChargeTypeEnum enumValue)
        {
            if (enumValue == PaymentChargeTypeEnum.Sale)
                return CreditCardTxTypeType.sale;
            else if (enumValue == PaymentChargeTypeEnum.PreAuth)
                return CreditCardTxTypeType.preAuth;
            else
                throw new ArgumentException("No PaymentChargeType mapping exists");
        }

        private ErrorCodeDTO GetErrorCodeDto(ErrorCodeTypeIDEnum typeEnum, ErrorCodeCategoryIDEnum categoryEnum, string code)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                int categoryId = categoryEnum.GetIntValue();
                int typeId = typeEnum.GetIntValue();

                var errorCodes = scope.DbContexts.Get<TargetFrameworkEntities>().ErrorCodes.Where(s => s.ErrorCodeCategoryID == categoryId && s.ErrorCodeTypeID == typeId && s.ErrorCode1 == code).ToList();

                if (errorCodes.Count > 0)
                    return errorCodes.First().ToDto();
                else
                    return scope.DbContexts.Get<TargetFrameworkEntities>().ErrorCodes.Single(s => s.ErrorCode1.Equals("5999")).ToDto();
            }
        }

        public TransactionOrderPaymentDTO GetTheSuccessfulOrderPaymentForTransactionOrder(Guid transactionOrderId)
        {
            TransactionOrderPaymentDTO dto = null;

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get successful status type
                var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.TransactionOrderProcessLog.GetStringValue(), TransactionOrderStatusEnum.Successful.GetStringValue());

                var logs = scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderProcessLogs.Where(s =>
                    s.TransactionOrderID == transactionOrderId &&
                    s.StatusTypeID == statusType.StatusTypeID &&
                    s.StatusTypeValueID == statusType.StatusTypeValueID).ToList();

                if (logs.Count > 0)
                {
                    var paymentId = logs.First().TransactionOrderPaymentID;
                    dto = scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderPayments.Single(s => s.TransactionOrderPaymentID.Equals(paymentId.Value)).ToDto();
                }
            }

            return dto;
        }

        public bool DoesASuccessfulOrderPaymentExistForTransactionOrder(Guid transactionOrderId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // get successful status type
                var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.TransactionOrderProcessLog.GetStringValue(), TransactionOrderStatusEnum.Successful.GetStringValue());

                return scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderProcessLogs.Any(s =>
                     s.TransactionOrderID.Equals(transactionOrderId) &&
                     s.StatusTypeID == statusType.StatusTypeID &&
                     s.StatusTypeValueID == statusType.StatusTypeValueID);
            }
        }

        [EnsureArgumentAspect]
        public async Task<TransactionOrderPaymentDTO> ProcessPaymentTransaction(OrderRequestDTO request)
        {
            TransactionOrderDTO transactionOrderDto;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                transactionOrderDto = scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrders.Single(x => x.TransactionOrderID == request.TransactionOrderID).ToDto();
            }
            TransactionOrderPaymentDTO responseDto = new TransactionOrderPaymentDTO();

            IPGApiOrderService o = new IPGApiOrderService();
            X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var paymentSettings = Settings.GetSettings().AsSettings<PaymentSettings>();

            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, paymentSettings.KeySerialNumber, false);

            NetworkCredential nc = new NetworkCredential(paymentSettings.KeyID, paymentSettings.Password);
            o.Credentials = nc;

            Guid orderPaymentID = Guid.NewGuid();

            if (col.Count == 1)
            {
                ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
                o.ClientCertificates.Add(col[0]);

                try
                {
                    var orderRequest = new IPGApiOrderRequest();

                    var cct = new CreditCardTxType() { Type = ConvertChargeType(request.PaymentChargeType) };

                    var ccData = new CreditCardData();

                    ItemsChoiceType[] choices = new ItemsChoiceType[] { ItemsChoiceType.CardNumber, ItemsChoiceType.ExpMonth, ItemsChoiceType.ExpYear, ItemsChoiceType.CardCodeValue };
                    string[] values = new string[] { request.CardNumber, request.CardExpiryMonth.ToString(), request.CardExpiryYear.ToString(), request.CVVNumber.ToString() };

                    ccData.ItemsElementName = choices;
                    ccData.Items = values;

                    orderRequest.Item = new Transaction();
                    orderRequest.Item.Items = new object[] { cct, ccData };
                    orderRequest.Item.Payment = new Payment();
                    orderRequest.Item.Payment.SubTotal = Math.Round(transactionOrderDto.OrderSubTotalExclTaxAndDeduct + transactionOrderDto.OrderDeductionTotal.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero);
                    orderRequest.Item.Payment.ValueAddedTax = Math.Round(transactionOrderDto.OrderTaxTotal, 2, MidpointRounding.AwayFromZero);
                    orderRequest.Item.Payment.ValueAddedTaxSpecified = transactionOrderDto.OrderTaxTotal == 0 ? false : true;

                    orderRequest.Item.Payment.ChargeTotal = Math.Round(transactionOrderDto.OrderTotal, 2, MidpointRounding.AwayFromZero);
                    orderRequest.Item.Payment.Currency = "GBP";

                    orderRequest.Item.TransactionDetails = new TransactionDetails();
                    orderRequest.Item.TransactionDetails.OrderId = orderPaymentID.ToString();

                    var b = new FirstData.Billing();

                    b.Zip = request.PostalCode;
                    b.Country = request.CountryCode;
                    b.Address1 = request.Line1;
                    b.Address2 = request.Line2;
                    b.City = request.Town;
                    b.Email = request.Email;
                    b.State = request.County;

                    orderRequest.Item.Billing = b;

                    IPGApiOrderResponse orderResponse = o.IPGApiOrder(orderRequest);

                    responseDto = ConvertFDResponseToOrderResponseDto(orderResponse);
                }
                catch (Exception e)
                {
                    Ensure.That(e.Message).IsNotNull();

                    // if processing exception
                    if (e.Message.ToString() == "ProcessingException")
                    {
                        string xml = (((System.Web.Services.Protocols.SoapException)(e)).Detail).InnerXml;

                        XmlSerializer serializer = new XmlSerializer(typeof(IPGApiOrderResponse), "http://ipg-online.com/ipgapi/schemas/ipgapi");

                        IPGApiOrderResponse orderResponse = (IPGApiOrderResponse)serializer.Deserialize(new StringReader(xml));

                        Ensure.That(orderResponse).IsNotNull();

                        // get error code
                        string errorCode = DetermineErrorCodeFromApprovalCode(orderResponse.ApprovalCode);

                        // determine whether its gateway or cardissuer basically a - in the code
                        bool isCardIssuerError = !errorCode.StartsWith("-");

                        ErrorCodeDTO errorDto = null;

                        // get errorDTO
                        if (isCardIssuerError)
                            errorDto = GetErrorCodeDto(ErrorCodeTypeIDEnum.FirstData_Card_Issuer, ErrorCodeCategoryIDEnum.FirstData,
                            errorCode.Replace("-", ""));
                        else
                            errorDto = GetErrorCodeDto(ErrorCodeTypeIDEnum.FirstData_Gateway, ErrorCodeCategoryIDEnum.FirstData,
                                errorCode.Replace("-", ""));

                        TransactionOrderPaymentErrorDTO error = new TransactionOrderPaymentErrorDTO
                        {
                            CreatedOn = DateTime.Now,
                            IsMerchantError = true,
                            ErrorDetail = JsonHelper.SerialiseXMLToJson(xml),
                            ErrorMessage = errorDto.ErrorMessage,
                            ErrorCodeDto = errorDto,
                            ErrorCode = errorCode.Replace("-", "")
                        };

                        responseDto = ConvertFDResponseToOrderResponseDto(orderResponse, error);
                    }
                    else if (e.Message.ToString() == "MerchantException")
                    {
                        var xml = (((System.Web.Services.Protocols.SoapException)(e)).Detail).OuterXml;

                        // check whether detail exists or not
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xml);

                        XmlNodeList detailElements = doc.GetElementsByTagName("detail");

                        bool hasMessage = false;

                        if (detailElements.Count > 0)
                            hasMessage = !string.IsNullOrEmpty(detailElements[0].InnerXml) ? true : false;

                        TransactionOrderPaymentErrorDTO error = new TransactionOrderPaymentErrorDTO
                        {
                            CreatedOn = DateTime.Now,
                            IsMerchantError = true,
                            ErrorDetail = JsonHelper.SerialiseXMLToJson(xml)
                        };

                        if (hasMessage)
                            error.ErrorCode = 20003.ToString();
                        else
                            error.ErrorCode = 5999.ToString();

                        // get error dto
                        var errorDto = GetErrorCodeDto(ErrorCodeTypeIDEnum.FirstData_Gateway, ErrorCodeCategoryIDEnum.FirstData,
                            error.ErrorCode);

                        error.ErrorMessage = errorDto.ErrorMessage;
                        error.ErrorCodeDto = errorDto;

                        responseDto = ConvertFDResponseToOrderResponseDto(null, error);

                    }
                    else
                    {
                        var errorDto = GetErrorCodeDto(ErrorCodeTypeIDEnum.FirstData_Gateway, ErrorCodeCategoryIDEnum.FirstData, "5999");

                        TransactionOrderPaymentErrorDTO error = new TransactionOrderPaymentErrorDTO
                        {
                            CreatedOn = DateTime.Now,
                            IsMerchantError = false,
                            ErrorMessage = errorDto.ErrorMessage,
                            ErrorDetail = e.Message + ":" + e.StackTrace,
                            ErrorCodeDto = errorDto
                        };

                        responseDto = ConvertFDResponseToOrderResponseDto(null, error);
                    }
                }
            }

            // persist transaction order payment
            using (var scope = DbContextScopeFactory.Create())
            {
                // persist transactionorderpayment
                var transactionOrderPayment = TransactionOrderPaymentConverter.ToEntity(responseDto);
                transactionOrderPayment.TransactionOrderPaymentID = orderPaymentID;

                // add payment
                scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderPayments.Add(transactionOrderPayment);

                responseDto.TransactionOrderPaymentID = orderPaymentID;

                // deal with error
                if (!responseDto.IsPaymentSuccessful)
                {
                    if (responseDto.TransactionOrderPaymentErrors != null && responseDto.TransactionOrderPaymentErrors.Count > 0)
                    {
                        var transOrderPaymentError = TransactionOrderPaymentErrorConverter.ToEntity(responseDto.TransactionOrderPaymentErrors.First());
                        transOrderPaymentError.TransactionOrderPaymentID = transactionOrderPayment.TransactionOrderPaymentID;
                        transOrderPaymentError.TransactionOrderPaymentErrorID = Guid.NewGuid();

                        scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderPaymentErrors.Add(transOrderPaymentError);
                    }
                    TransactionHelper.CreateTransactionOrderProcessLog(scope, transactionOrderDto.TransactionOrderID, TransactionOrderStatusEnum.Failed, transactionOrderPayment.TransactionOrderPaymentID);
                }
                else
                {
                    // no errors add payment successful log entry
                    TransactionHelper.CreateTransactionOrderProcessLog(scope, request.TransactionOrderID, TransactionOrderStatusEnum.Successful, transactionOrderPayment.TransactionOrderPaymentID);

                    //process credit type product events
                    var txOrder = scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrders.Single(x => x.TransactionOrderID == request.TransactionOrderID);
                    var creditProd = ProductLogic.GetTopUpProduct();

                    foreach (var cartItem in txOrder.Invoice.ShoppingCart.ShoppingCartItems)
                    {
                        if (cartItem.ProductID == creditProd.ProductID)
                        {
                            await AddCreditAsync(
                                txOrder.Invoice.ShoppingCart.UserAccountOrganisation.OrganisationID,
                                request.TransactionOrderID,
                                txOrder.Invoice.ShoppingCart.UserAccountOrganisation.UserAccountOrganisationID,
                                cartItem.CustomerPrice.Value);
                        }
                    }
                }

                await scope.SaveChangesAsync();
            }

            return responseDto;
        }

        private async Task AddCreditAsync(Guid orgID, Guid transactionOrderID, Guid uaoID, decimal amount, long? rowVersion = null)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var creditType = ClassificationLogic.GetClassificationDataForTypeName("OrganisationLedgerType", "Credit Account");
                var account = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationLedgerAccounts.Single(x =>
                    x.OrganisationID == orgID &&
                    x.LedgerAccountTypeID == creditType);
                if (rowVersion.HasValue && account.RowVersion != rowVersion) throw new Exception("The credit account has been updated by another user. Please go back and try again");

                account.OrganisationLedgerTransactions.Add(new OrganisationLedgerTransaction
                {
                    TransactionOrderID = transactionOrderID,
                    BalanceOn = DateTime.Now,
                    Amount = amount,
                    CreatedBy = uaoID
                });
                account.Balance += amount; //using rowversion for concurrency
                account.UpdatedOn = DateTime.Now;
                await scope.SaveChangesAsync();
            }
        }

        private string DetermineErrorCodeFromApprovalCode(string approvalCode)
        {
            Ensure.That(approvalCode).IsNotNullOrEmpty();

            string[] splitList = approvalCode.Split(':');

            Ensure.That(splitList.Length > 1).IsTrue();

            string errorCode = splitList[1];

            Ensure.That(errorCode).IsNotNullOrEmpty();

            return errorCode;
        }

        private TransactionOrderPaymentDTO ConvertFDResponseToOrderResponseDto(IPGApiOrderResponse res, TransactionOrderPaymentErrorDTO errorDto = null)
        {
            TransactionOrderPaymentDTO dto = new TransactionOrderPaymentDTO();

            if (res != null)
            {
                dto.AVSResponseCode = res.AVSResponse;
                dto.ApprovalCode = res.ApprovalCode;
                dto.IsPaymentSuccessful = !string.IsNullOrEmpty(res.TransactionResult)
                    ? (res.TransactionResult.Equals("APPROVED"))
                    : false;
                dto.PaymentType = res.PaymentType;
                dto.ProcessorApprovalCode = res.ProcessorApprovalCode;
                dto.ProcessorCCVResponse = res.ProcessorCCVResponse;
                dto.ProcessorReceiptCode = res.ProcessorReceiptNumber;
                dto.ProcessorReferenceNumber = res.ProcessorReferenceNumber;
                dto.ProcessorResponseCode = res.ProcessorResponseCode;
                dto.TransactionResult = res.TransactionResult;
                dto.PaymentDate = DateTime.Now;
                dto.ResponseData = JsonHelper.SerializeData(res);
            }
            else
            {
                dto.IsPaymentSuccessful = false;
                dto.PaymentDate = DateTime.Now;
            }

            if (errorDto != null)
            {
                dto.ErrorMessage = errorDto.ErrorMessage;
                dto.TransactionOrderPaymentErrors = new List<TransactionOrderPaymentErrorDTO>();
                dto.TransactionOrderPaymentErrors.Add(errorDto);
            }

            return dto;
        }
    }
}
