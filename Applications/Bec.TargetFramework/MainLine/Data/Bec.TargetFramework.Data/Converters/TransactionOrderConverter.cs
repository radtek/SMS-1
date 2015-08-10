﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class TransactionOrderConverter
    {

        public static TransactionOrderDTO ToDto(this Bec.TargetFramework.Data.TransactionOrder source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TransactionOrderDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TransactionOrder source, int level)
        {
            if (source == null)
              return null;

            var target = new TransactionOrderDTO();

            // Properties
            target.TransactionOrderID = source.TransactionOrderID;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.OrderSubTotalInclTaxAndDeduct = source.OrderSubTotalInclTaxAndDeduct;
            target.OrderSubTotalExclTaxAndDeduct = source.OrderSubTotalExclTaxAndDeduct;
            target.OrderSubTotalDiscountsInclTaxAndDeduct = source.OrderSubTotalDiscountsInclTaxAndDeduct;
            target.OrderSubTotalDiscountsExclTaxAndDeduct = source.OrderSubTotalDiscountsExclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesInclTaxAndDeduct = source.PaymentMethodAdditionalFeesInclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesExclTaxAndDeduct = source.PaymentMethodAdditionalFeesExclTaxAndDeduct;
            target.OrderTaxTotal = source.OrderTaxTotal;
            target.OrderDiscountTotal = source.OrderDiscountTotal;
            target.VatNumber = source.VatNumber;
            target.OrderTotal = source.OrderTotal;
            target.RefundedAmount = source.RefundedAmount;
            target.PaymentDate = source.PaymentDate;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.AuthorizationTransactionID = source.AuthorizationTransactionID;
            target.AuthorizationTransactionCode = source.AuthorizationTransactionCode;
            target.AuthorizationTransactionResult = source.AuthorizationTransactionResult;
            target.CaptureTransactionID = source.CaptureTransactionID;
            target.TransactionOrderReference = source.TransactionOrderReference;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrderDeductionTotal = source.OrderDeductionTotal;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.ParentTransactionOrderID = source.ParentTransactionOrderID;
            target.IsHierachicalTransactionOrder = source.IsHierachicalTransactionOrder;
            target.CaptureTransactionResult = source.CaptureTransactionResult;
            target.SubscriptionTransactionID = source.SubscriptionTransactionID;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.CountryCode = source.CountryCode;
            target.TransactionTypeID = source.TransactionTypeID;
            target.PaymentMethodTypeID = source.PaymentMethodTypeID;
            target.TransactionGatewayTypeID = source.TransactionGatewayTypeID;
            target.InvoiceID = source.InvoiceID;

            // Navigation Properties
            if (level > 0) {
              target.TransactionOrderItems = source.TransactionOrderItems.ToDtosWithRelated(level - 1);
              target.Invoice = source.Invoice.ToDtoWithRelated(level - 1);
              target.TransactionOrderProcessLogs = source.TransactionOrderProcessLogs.ToDtosWithRelated(level - 1);
              target.GlobalPaymentMethod = source.GlobalPaymentMethod.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TransactionOrder ToEntity(this TransactionOrderDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TransactionOrder();

            // Properties
            target.TransactionOrderID = source.TransactionOrderID;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.OrderSubTotalInclTaxAndDeduct = source.OrderSubTotalInclTaxAndDeduct;
            target.OrderSubTotalExclTaxAndDeduct = source.OrderSubTotalExclTaxAndDeduct;
            target.OrderSubTotalDiscountsInclTaxAndDeduct = source.OrderSubTotalDiscountsInclTaxAndDeduct;
            target.OrderSubTotalDiscountsExclTaxAndDeduct = source.OrderSubTotalDiscountsExclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesInclTaxAndDeduct = source.PaymentMethodAdditionalFeesInclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesExclTaxAndDeduct = source.PaymentMethodAdditionalFeesExclTaxAndDeduct;
            target.OrderTaxTotal = source.OrderTaxTotal;
            target.OrderDiscountTotal = source.OrderDiscountTotal;
            target.VatNumber = source.VatNumber;
            target.OrderTotal = source.OrderTotal;
            target.RefundedAmount = source.RefundedAmount;
            target.PaymentDate = source.PaymentDate;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.AuthorizationTransactionID = source.AuthorizationTransactionID;
            target.AuthorizationTransactionCode = source.AuthorizationTransactionCode;
            target.AuthorizationTransactionResult = source.AuthorizationTransactionResult;
            target.CaptureTransactionID = source.CaptureTransactionID;
            target.TransactionOrderReference = source.TransactionOrderReference;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrderDeductionTotal = source.OrderDeductionTotal;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.ParentTransactionOrderID = source.ParentTransactionOrderID;
            target.IsHierachicalTransactionOrder = source.IsHierachicalTransactionOrder;
            target.CaptureTransactionResult = source.CaptureTransactionResult;
            target.SubscriptionTransactionID = source.SubscriptionTransactionID;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.CountryCode = source.CountryCode;
            target.TransactionTypeID = source.TransactionTypeID;
            target.PaymentMethodTypeID = source.PaymentMethodTypeID;
            target.TransactionGatewayTypeID = source.TransactionGatewayTypeID;
            target.InvoiceID = source.InvoiceID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TransactionOrderDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TransactionOrder> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TransactionOrderDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TransactionOrder> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TransactionOrder> ToEntities(this IEnumerable<TransactionOrderDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TransactionOrder source, TransactionOrderDTO target);

        static partial void OnEntityCreating(TransactionOrderDTO source, Bec.TargetFramework.Data.TransactionOrder target);

    }

}
