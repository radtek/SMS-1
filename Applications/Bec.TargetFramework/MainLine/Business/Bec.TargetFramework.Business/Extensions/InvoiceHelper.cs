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
    public class InvoiceHelper
    {
        private IShoppingCartLogic m_ShoppingLogic;

        public InvoiceHelper(IShoppingCartLogic sLogic)
        {
            m_ShoppingLogic = sLogic;
        }

        public void Invoice(InvoiceDTO originalInvoice)
        {
            if (IsShoppingCartInvoice(originalInvoice))
                return;

            // invoice with not products so plan subscription based so needed to fake cart
           

            //var shoppingCartDto = sLogic.CreateShoppingCart(originalInvoice.OrganisationID.GetValueOrDefault(Guid.Empty),PaymentCardTypeEnum.VisaCredit, PaymentMethodTypeEnum.CreditCard);
            

            //// add products as needed and calculate shopping cart
            //if (originalInvoice.InvoiceLineItems.Any())
            //{
            //    originalInvoice.InvoiceLineItems.ForEach(item =>
            //    {
            //        sLogic.AddProductToShoppingCartFromProductID(shoppingCartDto, item.ProductID.GetValueOrDefault(Guid.Empty), item.ProductVersionID.GetValueOrDefault(1),
            //            Convert.ToInt32(item.Quantity));
            //    });
            //}

            //// check values
            //Ensure.That(shoppingCartDto.PriceDTO.Total).Equals(originalInvoice.Total);
        }

        private bool IsShoppingCartInvoice(InvoiceDTO invoice)
        {
            return (invoice.ShoppingCartID.HasValue);
        }

        public static int TotalNumberOfInvoicesForOrganisation(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID)
        {
            return scope.DbContext.Invoices.Count(s => s.OrganisationID != null && s.OrganisationID.Value.Equals(organisationID));
        }

        [EnsureArgumentAspect]
        public static void CreateInvoiceProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid invoiceID, InvoiceStatusEnum invoiceStatusEnumValue, InvoiceAccountingStatusIDEnum accountingStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.InvoiceProcessLog.GetStringValue(),
                invoiceStatusEnumValue.GetStringValue());

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

            scope.DbContext.InvoiceProcessLogs.Add(log);
        }

        [EnsureArgumentAspect]
        public static InvoiceLineItem CreateLineItemFromShoppingCartItem(Bec.TargetFramework.Data.Invoice invoice, ShoppingCartItemDTO cartItem)
        {
            var lineItem = new InvoiceLineItem
            {
                InvoiceLineItemID = Guid.NewGuid(),
                InvoiceID = invoice.InvoiceID,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now,
                SingleProductPrice = cartItem.ProductPricingDto.PriceInclDiscountsAndDeducts,
                Quantity = cartItem.Quantity,
                Price = cartItem.ProductPricingDto.PriceInclDiscountsAndDeducts,
                Description = cartItem.ProductInformationDto.InvoiceName,
                InvoiceLineItemTypeID = InvoiceLineItemTypeIDEnum.Product.GetIntValue(),
                PriceInclTax = cartItem.ProductPricingDto.PriceInclDiscountsAndDeducts,
                CountryCode = invoice.CountryCode,
                IsCredit = false,
                IsDebit = true,
                ProductID = cartItem.ProductID,
                ProductVersionID = cartItem.ProductVersionID,
                PriceExclTax = cartItem.ProductPricingDto.PriceInclDiscounts,
                SingleProductPriceExclTaxAndDeduct = cartItem.ProductPricingDto.ProductPrice,
                DiscountTotal = cartItem.ProductPricingDto.ProductDiscounts,
                DiscountTotalPercentage = cartItem.ProductPricingDto.ProductDiscountsPercentage,
                DeductionTotalPercentage = cartItem.ProductPricingDto.ProductDeductionsPercentage,
                DeductionTotalValue = cartItem.ProductPricingDto.ProductDeductions,
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
