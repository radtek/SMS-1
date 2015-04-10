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

    public static partial class InvoiceConverter
    {

        public static InvoiceDTO ToDto(this Bec.TargetFramework.Data.Invoice source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InvoiceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Invoice source, int level)
        {
            if (source == null)
              return null;

            var target = new InvoiceDTO();

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
            target.InvoiceSubTotalInclTaxAndDeduct = source.InvoiceSubTotalInclTaxAndDeduct;
            target.InvoiceSubTotalExclTaxAndDeduct = source.InvoiceSubTotalExclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsInclTaxAndDeduct = source.InvoiceSubTotalDiscountsInclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsExclTaxAndDeduct = source.InvoiceSubTotalDiscountsExclTaxAndDeduct;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartID = source.ShoppingCartID;
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.DeductionTotal = source.DeductionTotal;
            target.InvoiceReference = source.InvoiceReference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.PaymentMethodAdditionalFeesInclTax = source.PaymentMethodAdditionalFeesInclTax;
            target.PaymentMethodAdditionalFeesExclTax = source.PaymentMethodAdditionalFeesExclTax;
            target.TaxTotal = source.TaxTotal;
            target.DiscountTotal = source.DiscountTotal;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.InvoiceLineItems = source.InvoiceLineItems.ToDtosWithRelated(level - 1);
              target.TransactionOrders = source.TransactionOrders.ToDtosWithRelated(level - 1);
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.InvoiceProcessLogs = source.InvoiceProcessLogs.ToDtosWithRelated(level - 1);
              target.ShoppingCart = source.ShoppingCart.ToDtoWithRelated(level - 1);
              target.OrganisationAccountingPeriod = source.OrganisationAccountingPeriod.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Invoice ToEntity(this InvoiceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Invoice();

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
            target.InvoiceSubTotalInclTaxAndDeduct = source.InvoiceSubTotalInclTaxAndDeduct;
            target.InvoiceSubTotalExclTaxAndDeduct = source.InvoiceSubTotalExclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsInclTaxAndDeduct = source.InvoiceSubTotalDiscountsInclTaxAndDeduct;
            target.InvoiceSubTotalDiscountsExclTaxAndDeduct = source.InvoiceSubTotalDiscountsExclTaxAndDeduct;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.OrganisationID = source.OrganisationID;
            target.ShoppingCartID = source.ShoppingCartID;
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.TaxTotalPercentage = source.TaxTotalPercentage;
            target.TaxTotalValue = source.TaxTotalValue;
            target.DeductionTotalPercentage = source.DeductionTotalPercentage;
            target.DeductionTotalValue = source.DeductionTotalValue;
            target.DiscountTotalPercentage = source.DiscountTotalPercentage;
            target.DiscountTotalValue = source.DiscountTotalValue;
            target.DeductionTotal = source.DeductionTotal;
            target.InvoiceReference = source.InvoiceReference;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.IsFrozenPendingPayment = source.IsFrozenPendingPayment;
            target.PaymentMethodAdditionalFeesInclTax = source.PaymentMethodAdditionalFeesInclTax;
            target.PaymentMethodAdditionalFeesExclTax = source.PaymentMethodAdditionalFeesExclTax;
            target.TaxTotal = source.TaxTotal;
            target.DiscountTotal = source.DiscountTotal;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InvoiceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Invoice> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InvoiceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Invoice> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Invoice> ToEntities(this IEnumerable<InvoiceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Invoice source, InvoiceDTO target);

        static partial void OnEntityCreating(InvoiceDTO source, Bec.TargetFramework.Data.Invoice target);

    }

}
