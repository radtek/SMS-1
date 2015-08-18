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
    public static class InvoiceHelper
    {
        public static int TotalNumberOfInvoicesForOrganisation(IDbContextReadOnlyScope scope, Guid organisationID)
        {
            return scope.DbContexts.Get<TargetFrameworkEntities>().Invoices.Count(s => s.OrganisationID != null && s.OrganisationID.Value.Equals(organisationID));
        }

        [EnsureArgumentAspect]
        public static void CreateInvoiceProcessLog(IDbContextReadOnlyScope scope, Guid invoiceID, InvoiceStatusEnum invoiceStatusEnumValue, InvoiceAccountingStatusIDEnum accountingStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.InvoiceProcessLog.GetStringValue(), invoiceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            InvoiceProcessLog log = new InvoiceProcessLog
            {
                CreatedOn = DateTime.Now,
                InvoiceID = invoiceID,
                IsInvoiceProcessed = false,
                IsPaid = false,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsClosed = false,
                InvoiceAccountingStatusID = accountingStatusEnumValue.GetIntValue()
            };

            scope.DbContexts.Get<TargetFrameworkEntities>().InvoiceProcessLogs.Add(log);
        }

        [EnsureArgumentAspect]
        public static InvoiceLineItem CreateLineItemFromShoppingCartItem(Bec.TargetFramework.Data.Invoice invoice, ShoppingCartItem cartItem, CartItemPricingDTO priceInfo)
        {
            var prodInfo = cartItem.Product.ProductDetails.First();
            var lineItem = new InvoiceLineItem
            {
                InvoiceLineItemID = Guid.NewGuid(),
                InvoiceID = invoice.InvoiceID,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                SingleProductPrice = priceInfo.PriceInclDiscountsAndDeducts,
                Quantity = cartItem.Quantity,
                Price = priceInfo.PriceInclDiscountsAndDeducts,
                Description = prodInfo.InvoiceName,
                InvoiceLineItemTypeID = InvoiceLineItemTypeIDEnum.Product.GetIntValue(),
                PriceInclTax = priceInfo.PriceInclDiscountsAndDeducts,
                CountryCode = invoice.CountryCode,
                IsCredit = false,
                IsDebit = true,
                ProductID = cartItem.ProductID,
                ProductVersionID = cartItem.ProductVersionID,
                PriceExclTax = priceInfo.PriceInclDiscounts,
                SingleProductPriceExclTaxAndDeduct = priceInfo.ProductPrice,
                DiscountTotal = priceInfo.ProductDiscounts,
                DiscountTotalPercentage = priceInfo.ProductDiscountsPercentage,
                DeductionTotalPercentage = priceInfo.ProductDeductionsPercentage,
                DeductionTotalValue = priceInfo.ProductDeductions,
                IsActive = true,
                IsDeleted = false,
                IsClosed = false,
                IsFrozenPendingPayment = true,
                ParentID = cartItem.ShoppingCartItemID
            };

            cartItem.InvoiceLineItemID = lineItem.InvoiceLineItemID;

            return lineItem;
        }
    }
}
