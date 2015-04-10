﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VInvoiceWithCurrentTransactionOrderStatusConverter
    {

        public static VInvoiceWithCurrentTransactionOrderStatusDTO ToDto(this Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VInvoiceWithCurrentTransactionOrderStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VInvoiceWithCurrentTransactionOrderStatusDTO();

            // Properties
            target.InvoiceID = source.InvoiceID;
            target.VatNumber = source.VatNumber;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.Total = source.Total;
            target.LastReminder = source.LastReminder;
            target.Balance = source.Balance;
            target.ParentID = source.ParentID;
            target.DueDate = source.DueDate;
            target.CountryCode = source.CountryCode;
            target.NumberOfPaymentAttempts = source.NumberOfPaymentAttempts;
            target.CarriedBalance = source.CarriedBalance;
            target.InvoiceTypeID = source.InvoiceTypeID;
            target.InvoiceNumber = source.InvoiceNumber;
            target.InvoiceName = source.InvoiceName;
            target.CreatedOn = source.CreatedOn;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.InvoiceSubTotalInclTaxAndDeduct = source.InvoiceSubTotalInclTaxAndDeduct;
            target.InvoiceSubTotalExclTaxAndDeduct = source.InvoiceSubTotalExclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsInclTaxAndDeduct = source.InvoiceSubTotalDiscountsInclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsExclTaxAndDeduct = source.InvoiceSubTotalDiscountsExclTaxAndDeduct;
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartID = source.ShoppingCartID;
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.InvoiceReference = source.InvoiceReference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.InvoiceStatus = source.InvoiceStatus;
            target.TransactionOrderStatus = source.TransactionOrderStatus;
            target.InvoiceStatusTypeValueID = source.InvoiceStatusTypeValueID;
            target.TransactionOrderStatusTypeValueID = source.TransactionOrderStatusTypeValueID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.OrderSubTotalInclTaxAndDeduct = source.OrderSubTotalInclTaxAndDeduct;
            target.OrderSubTotalExclTaxAndDeduct = source.OrderSubTotalExclTaxAndDeduct;
            target.OrderSubTotalDiscountsInclTaxAndDeduct = source.OrderSubTotalDiscountsInclTaxAndDeduct;
            target.OrderSubTotalDiscountsExclTaxAndDeduct = source.OrderSubTotalDiscountsExclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesInclTaxAndDeduct = source.PaymentMethodAdditionalFeesInclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesExclTaxAndDeduct = source.PaymentMethodAdditionalFeesExclTaxAndDeduct;
            target.OrderTaxTotal = source.OrderTaxTotal;
            target.OrderDiscountTotal = source.OrderDiscountTotal;
            target.OrderTotal = source.OrderTotal;
            target.RefundedAmount = source.RefundedAmount;
            target.PaymentDate = source.PaymentDate;
            target.AuthorizationTransactionID = source.AuthorizationTransactionID;
            target.AuthorizationTransactionCode = source.AuthorizationTransactionCode;
            target.AuthorizationTransactionResult = source.AuthorizationTransactionResult;
            target.CaptureTransactionID = source.CaptureTransactionID;
            target.CaptureTransactionResult = source.CaptureTransactionResult;
            target.SubscriptionTransactionID = source.SubscriptionTransactionID;
            target.TransactionTypeID = source.TransactionTypeID;
            target.PaymentMethodTypeID = source.PaymentMethodTypeID;
            target.TransactionGatewayTypeID = source.TransactionGatewayTypeID;
            target.TransactionOrderReference = source.TransactionOrderReference;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrderDeductionTotal = source.OrderDeductionTotal;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.AccountPeriodIsCurrent = source.AccountPeriodIsCurrent;
            target.AccountingPeriodIsClosed = source.AccountingPeriodIsClosed;
            target.AccountingPeriodNumber = source.AccountingPeriodNumber;
            target.AccountingPeriodStartDay = source.AccountingPeriodStartDay;
            target.AccountingPeriodEndDay = source.AccountingPeriodEndDay;
            target.AccountingPeriodMonth = source.AccountingPeriodMonth;
            target.AccountingPeriodYear = source.AccountingPeriodYear;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus ToEntity(this VInvoiceWithCurrentTransactionOrderStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus();

            // Properties
            target.InvoiceID = source.InvoiceID;
            target.VatNumber = source.VatNumber;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.Total = source.Total;
            target.LastReminder = source.LastReminder;
            target.Balance = source.Balance;
            target.ParentID = source.ParentID;
            target.DueDate = source.DueDate;
            target.CountryCode = source.CountryCode;
            target.NumberOfPaymentAttempts = source.NumberOfPaymentAttempts;
            target.CarriedBalance = source.CarriedBalance;
            target.InvoiceTypeID = source.InvoiceTypeID;
            target.InvoiceNumber = source.InvoiceNumber;
            target.InvoiceName = source.InvoiceName;
            target.CreatedOn = source.CreatedOn;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.InvoiceSubTotalInclTaxAndDeduct = source.InvoiceSubTotalInclTaxAndDeduct;
            target.InvoiceSubTotalExclTaxAndDeduct = source.InvoiceSubTotalExclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsInclTaxAndDeduct = source.InvoiceSubTotalDiscountsInclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsExclTaxAndDeduct = source.InvoiceSubTotalDiscountsExclTaxAndDeduct;
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartID = source.ShoppingCartID;
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.InvoiceReference = source.InvoiceReference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.InvoiceStatus = source.InvoiceStatus;
            target.TransactionOrderStatus = source.TransactionOrderStatus;
            target.InvoiceStatusTypeValueID = source.InvoiceStatusTypeValueID;
            target.TransactionOrderStatusTypeValueID = source.TransactionOrderStatusTypeValueID;
            target.TransactionOrderID = source.TransactionOrderID;
            target.OrderSubTotalInclTaxAndDeduct = source.OrderSubTotalInclTaxAndDeduct;
            target.OrderSubTotalExclTaxAndDeduct = source.OrderSubTotalExclTaxAndDeduct;
            target.OrderSubTotalDiscountsInclTaxAndDeduct = source.OrderSubTotalDiscountsInclTaxAndDeduct;
            target.OrderSubTotalDiscountsExclTaxAndDeduct = source.OrderSubTotalDiscountsExclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesInclTaxAndDeduct = source.PaymentMethodAdditionalFeesInclTaxAndDeduct;
            target.PaymentMethodAdditionalFeesExclTaxAndDeduct = source.PaymentMethodAdditionalFeesExclTaxAndDeduct;
            target.OrderTaxTotal = source.OrderTaxTotal;
            target.OrderDiscountTotal = source.OrderDiscountTotal;
            target.OrderTotal = source.OrderTotal;
            target.RefundedAmount = source.RefundedAmount;
            target.PaymentDate = source.PaymentDate;
            target.AuthorizationTransactionID = source.AuthorizationTransactionID;
            target.AuthorizationTransactionCode = source.AuthorizationTransactionCode;
            target.AuthorizationTransactionResult = source.AuthorizationTransactionResult;
            target.CaptureTransactionID = source.CaptureTransactionID;
            target.CaptureTransactionResult = source.CaptureTransactionResult;
            target.SubscriptionTransactionID = source.SubscriptionTransactionID;
            target.TransactionTypeID = source.TransactionTypeID;
            target.PaymentMethodTypeID = source.PaymentMethodTypeID;
            target.TransactionGatewayTypeID = source.TransactionGatewayTypeID;
            target.TransactionOrderReference = source.TransactionOrderReference;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrderDeductionTotal = source.OrderDeductionTotal;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.AccountPeriodIsCurrent = source.AccountPeriodIsCurrent;
            target.AccountingPeriodIsClosed = source.AccountingPeriodIsClosed;
            target.AccountingPeriodNumber = source.AccountingPeriodNumber;
            target.AccountingPeriodStartDay = source.AccountingPeriodStartDay;
            target.AccountingPeriodEndDay = source.AccountingPeriodEndDay;
            target.AccountingPeriodMonth = source.AccountingPeriodMonth;
            target.AccountingPeriodYear = source.AccountingPeriodYear;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VInvoiceWithCurrentTransactionOrderStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VInvoiceWithCurrentTransactionOrderStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus> ToEntities(this IEnumerable<VInvoiceWithCurrentTransactionOrderStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus source, VInvoiceWithCurrentTransactionOrderStatusDTO target);

        static partial void OnEntityCreating(VInvoiceWithCurrentTransactionOrderStatusDTO source, Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus target);

    }

}
