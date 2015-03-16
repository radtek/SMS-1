﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InvoiceLineItemConverter
    {

        public static InvoiceLineItemDTO ToDto(this Bec.TargetFramework.Data.InvoiceLineItem source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InvoiceLineItemDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InvoiceLineItem source, int level)
        {
            if (source == null)
              return null;

            var target = new InvoiceLineItemDTO();

            // Properties
            target.InvoiceLineItemID = source.InvoiceLineItemID;
            target.InvoiceID = source.InvoiceID;
            target.DateFrom = source.DateFrom;
            target.DateTo = source.DateTo;
            target.SingleProductPrice = source.SingleProductPrice;
            target.TaxTotal = source.TaxTotal;
            target.Price = source.Price;
            target.Quantity = source.Quantity;
            target.Description = source.Description;
            target.InvoiceLineItemTypeID = source.InvoiceLineItemTypeID;
            target.ParentID = source.ParentID;
            target.PriceInclTax = source.PriceInclTax;
            target.CountryCode = source.CountryCode;
            target.IsCredit = source.IsCredit;
            target.SingleProductPriceInclTaxAndDeduct = source.SingleProductPriceInclTaxAndDeduct;
            target.SingleProductPriceExclTaxAndDeduct = source.SingleProductPriceExclTaxAndDeduct;
            target.IsDebit = source.IsDebit;
            target.ProductID = source.ProductID;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotal = source.DeductionTotal;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.PlanSubscriptionPeriodID = source.PlanSubscriptionPeriodID;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.ProductVersionID = source.ProductVersionID;
            target.PriceExclTax = source.PriceExclTax;
            target.DiscountTotal = source.DiscountTotal;
            target.IsDepositProduct = source.IsDepositProduct;
            target.AccountID = source.AccountID;

            // Navigation Properties
            if (level > 0) {
              target.ShoppingCartItems = source.ShoppingCartItems.ToDtosWithRelated(level - 1);
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.Invoice = source.Invoice.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.TransactionOrderItems = source.TransactionOrderItems.ToDtosWithRelated(level - 1);
              target.PlanSubscriptionPeriod = source.PlanSubscriptionPeriod.ToDtoWithRelated(level - 1);
              target.ProductPurchases = source.ProductPurchases.ToDtosWithRelated(level - 1);
              target.OrganisationProductPurchases = source.OrganisationProductPurchases.ToDtosWithRelated(level - 1);
              target.Account = source.Account.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InvoiceLineItem ToEntity(this InvoiceLineItemDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InvoiceLineItem();

            // Properties
            target.InvoiceLineItemID = source.InvoiceLineItemID;
            target.InvoiceID = source.InvoiceID;
            target.DateFrom = source.DateFrom;
            target.DateTo = source.DateTo;
            target.SingleProductPrice = source.SingleProductPrice;
            target.TaxTotal = source.TaxTotal;
            target.Price = source.Price;
            target.Quantity = source.Quantity;
            target.Description = source.Description;
            target.InvoiceLineItemTypeID = source.InvoiceLineItemTypeID;
            target.ParentID = source.ParentID;
            target.PriceInclTax = source.PriceInclTax;
            target.CountryCode = source.CountryCode;
            target.IsCredit = source.IsCredit;
            target.SingleProductPriceInclTaxAndDeduct = source.SingleProductPriceInclTaxAndDeduct;
            target.SingleProductPriceExclTaxAndDeduct = source.SingleProductPriceExclTaxAndDeduct;
            target.IsDebit = source.IsDebit;
            target.ProductID = source.ProductID;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotal = source.DeductionTotal;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.PlanSubscriptionPeriodID = source.PlanSubscriptionPeriodID;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.ProductVersionID = source.ProductVersionID;
            target.PriceExclTax = source.PriceExclTax;
            target.DiscountTotal = source.DiscountTotal;
            target.IsDepositProduct = source.IsDepositProduct;
            target.AccountID = source.AccountID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InvoiceLineItemDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InvoiceLineItem> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InvoiceLineItemDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InvoiceLineItem> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InvoiceLineItem> ToEntities(this IEnumerable<InvoiceLineItemDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InvoiceLineItem source, InvoiceLineItemDTO target);

        static partial void OnEntityCreating(InvoiceLineItemDTO source, Bec.TargetFramework.Data.InvoiceLineItem target);

    }

}
