using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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

namespace Bec.TargetFramework.Business
{
    public class TransactionHelper
    {
        private ITransactionOrderLogic m_TransactionLogic;

        public TransactionHelper(ITransactionOrderLogic sLogic)
        {
            m_TransactionLogic = sLogic;
        }

        public static void CreateTransactionOrderProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid transactionOrderID, TransactionOrderStatusEnum transStatusEnumValue,Guid? orderPaymentID = null)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.TransactionOrderProcessLog.GetStringValue(),
                transStatusEnumValue.GetStringValue());

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

            scope.DbContext.TransactionOrderProcessLogs.Add(log);
        }

        [EnsureArgumentAspect]
        public static TransactionOrderItem CreateLineItemFromShoppingCartItem(Bec.TargetFramework.Data.TransactionOrder transactionOrder, ShoppingCartItemDTO cartItem)
        {
            var lineItem = new TransactionOrderItem
            {
                OrderItemID = Guid.NewGuid(),
                OrderID = transactionOrder.TransactionOrderID,
                Quantity = cartItem.Quantity,
                Price = cartItem.ProductPricingDto.ProductPrice,
                DiscountTotal = cartItem.ProductPricingDto.Discounts,
                DiscountTotalPercentage = cartItem.ProductPricingDto.ProductDiscountsPercentage,
                DiscountTotalValue = cartItem.ProductPricingDto.ProductDiscounts,
                DeductionTotalPercentage = cartItem.ProductPricingDto.ProductDeductionsPercentage,
                DeductionTotalValue = cartItem.ProductPricingDto.ProductDeductions,
                DeductionTotal = cartItem.ProductPricingDto.Deductions,
                IsActive = true,
                IsDeleted = false
            };

            cartItem.InvoiceLineItemID = lineItem.InvoiceLineItemID;

            return lineItem;
        }
    }
}
