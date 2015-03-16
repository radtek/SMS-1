using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities.Enums;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using Bec.TargetFramework.Entities;

    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/TransactionOrderLogic")]
    public interface ITransactionOrderLogic : IBusinessLogicService

    {
         [OperationContract]
        TransactionOrderDTO GetTransactionForInvoice(Guid invoiceId);

        [OperationContract]
        bool DoesTransactionExistForInvoice(Guid invoiceId);

        [OperationContract]

        /// <summary>
        /// Get orders by identifiers
        /// </summary>
        /// <param name="orderIds">Order identifiers</param>
        /// <returns>Order</returns>
        IList<TransactionOrderDTO> GetOrdersByIds(List<Guid> orderIds);

         [OperationContract]

        /// <summary>
        /// Gets an order
        /// </summary>
        /// <param name="orderGuid">The order identifier</param>
        /// <returns>Order</returns>
        TransactionOrderDTO GetOrderByGuid(Guid orderGuid);

         [OperationContract]

        /// <summary>
        /// Deletes an order
        /// </summary>
        /// <param name="order">The order</param>
        void DeleteOrder(TransactionOrderDTO order);

         [OperationContract]
        List<TransactionOrderDTO> SearchOrders(Guid? parentID,Guid? productID,
            int? orderStatusID, int? paymentStatusID);

         [OperationContract]

        /// <summary>
        /// Inserts an order
        /// </summary>
        /// <param name="order">Order</param>
        void InsertOrder(TransactionOrderDTO order);

         [OperationContract]

        /// <summary>
        /// Updates the order
        /// </summary>
        /// <param name="order">The order</param>
        void UpdateOrder(TransactionOrderDTO order);

         [OperationContract]

        /// <summary>
        /// Get an order by authorization transaction ID and payment method system name
        /// </summary>
        /// <param name="authorizationTransactionId">Authorization transaction ID</param>
        /// <param name="paymentMethodSystemName">Payment method system name</param>
        /// <returns>Order</returns>
        TransactionOrderDTO GetOrderByAuthorizationTransactionIdAndPaymentMethod(string authorizationTransactionId, string paymentMethodSystemName);

        #region Orders items

        /// <summary>
        /// Gets an order item
        /// </summary>
        /// <param name="orderItemGuid">Order item identifier</param>
        /// <returns>Order item</returns>
        TransactionOrderItemDTO GetOrderItemByGuid(Guid orderItemGuid);

         [OperationContract]

        /// <summary>
        /// Gets all order items
        /// </summary>
        /// <param name="orderId">Order identifier; null to load all records</param>
        /// <param name="customerId">Customer identifier; null to load all records</param>
        /// <param name="createdFromUtc">Order created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Order created date to (UTC); null to load all records</param>
        /// <param name="os">Order status; null to load all records</param>
        /// <param name="ps">Order payment status; null to load all records</param>
        /// <param name="ss">Order shippment status; null to load all records</param>
        /// <param name="loadDownloableProductsOnly">Value indicating whether to load downloadable products only</param>
        /// <returns>Order items</returns>
        IList<TransactionOrderItemDTO> GetAllOrderItems(Guid? orderId,
           Guid? parentID,
            int? orderStatusID, int? paymentStatusID);

         [OperationContract]

        /// <summary>
        /// Delete an order item
        /// </summary>
        /// <param name="orderItem">The order item</param>
        void DeleteOrderItem(TransactionOrderItemDTO orderItem);

        [OperationContract]
        TransactionOrderDTO CreateAndSaveTransactionOrderFromShoppingCartDTO(VUserAccountOrganisationDTO clientUaoDto,
            ShoppingCartDTO dto, InvoiceDTO invoiceDto, TransactionTypeIDEnum typeEnumValue);

        #endregion Orders items
    }
}