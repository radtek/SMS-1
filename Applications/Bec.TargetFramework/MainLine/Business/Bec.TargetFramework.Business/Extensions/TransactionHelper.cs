using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business
{
    public static class TransactionHelper
    {
        public static void CreateTransactionOrderProcessLog(IDbContextReadOnlyScope scope, Guid transactionOrderID, TransactionOrderStatusEnum transStatusEnumValue, Guid? orderPaymentID = null)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.TransactionOrderProcessLog.GetStringValue(), transStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            TransactionOrderProcessLog log = new TransactionOrderProcessLog
            {
                TransactionOrderID = transactionOrderID,
                CreatedOn =  DateTime.Now,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsPaid = false,
                IsTransactionOrderProcessed = false
            };

            if (orderPaymentID.HasValue) 
                log.TransactionOrderPaymentID = orderPaymentID;

            scope.DbContexts.Get<TargetFrameworkEntities>().TransactionOrderProcessLogs.Add(log);
        }

        [EnsureArgumentAspect]
        public static TransactionOrderItem CreateLineItemFromShoppingCartItem(Bec.TargetFramework.Data.TransactionOrder transactionOrder, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            var lineItem = new TransactionOrderItem
            {
                OrderItemID = Guid.NewGuid(),
                OrderID = transactionOrder.TransactionOrderID,
                Quantity = cartItem.Quantity,
                Price = itemPrice.ProductPrice,
                DiscountTotal = itemPrice.Discounts,
                DiscountTotalPercentage = itemPrice.ProductDiscountsPercentage,
                DiscountTotalValue = itemPrice.ProductDiscounts,
                DeductionTotalPercentage = itemPrice.ProductDeductionsPercentage,
                DeductionTotalValue = itemPrice.ProductDeductions,
                DeductionTotal = itemPrice.Deductions,
                IsActive = true,
                IsDeleted = false
            };

            cartItem.InvoiceLineItemID = lineItem.InvoiceLineItemID;

            return lineItem;
        }
    }
}
