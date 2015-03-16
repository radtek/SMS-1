using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Bec.TargetFramework.Data;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/InvoiceLogic")]
    public interface IInvoiceLogic : IBusinessLogicService
    {
        [OperationContract]
        VOrganisationDetailDTO GetPaymentProviderOrganisationDetail();

        [OperationContract]
        VInvoiceWithCurrentTransactionOrderStatusDTO GetInvoiceWithCurrentTransactionOrderStatus(Guid invoiceID);

         [OperationContract]
        InvoiceDTO GetInvoiceExistForShoppingCart(Guid shoppingCartId);

        [OperationContract]
        bool DoesInvoiceExistForShoppingCart(Guid shoppingCartId);

        [OperationContract]
        InvoiceDTO CreateAndSaveInvoiceFromShoppingCart(ShoppingCartDTO cartDto);
        [OperationContract]
        void DeleteInvoice(Guid invoiceID);
         [OperationContract]
        void FreezeInvoice(Guid invoiceID);
         [OperationContract]
        void CloseInvoice(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsPaid(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsUnpaid(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsCancelled(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsProcessing(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsPaymentDue(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsActive(Guid invoiceID);
         [OperationContract]
        void MarkInvoiceAsPaymentScheduled(Guid invoiceID);
         [OperationContract]
        void AddLineItemToInvoice(InvoiceLineItemDTO dto);
         [OperationContract]
        void RemoveLineItemToInvoice(InvoiceLineItemDTO dto);
         [OperationContract]
         void MarkInvoiceWithAccountingStatus(Guid invoiceID, InvoiceAccountingStatusIDEnum value);
    }
}
