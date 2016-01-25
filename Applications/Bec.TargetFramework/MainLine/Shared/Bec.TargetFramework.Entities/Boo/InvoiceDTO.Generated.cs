﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class InvoiceDTO
    {
        #region Constructors
  
        public InvoiceDTO() {
        }

        public InvoiceDTO(global::System.Guid invoiceID, string vatNumber, global::System.Nullable<System.DateTime> startDate, global::System.DateTime endDate, decimal total, global::System.Nullable<System.DateTime> lastReminder, global::System.Nullable<decimal> balance, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.DateTime> dueDate, string countryCode, int numberOfPaymentAttempts, global::System.Nullable<decimal> carriedBalance, global::System.Nullable<int> invoiceTypeID, global::System.Nullable<int> invoiceNumber, string invoiceName, global::System.DateTime createdOn, string currencyCode, global::System.DateTime currencyRateDate, decimal invoiceSubTotalInclTaxAndDeduct, decimal invoiceSubTotalExclTaxAndDeduct, decimal invoiceSubTotalDiscountsInclTaxAndDeduct, decimal invoiceSubTotalDiscountsExclTaxAndDeduct, decimal currencyRate, global::System.Nullable<decimal> currencyRateToGBP, global::System.Nullable<decimal> currencyRateToUSD, global::System.Nullable<System.Guid> organisationID, global::System.Nullable<System.Guid> shoppingCartID, global::System.Nullable<int> organisationAccountingPeriodID, global::System.Nullable<decimal> taxTotalPercentage, global::System.Nullable<decimal> taxTotalValue, global::System.Nullable<decimal> deductionTotalPercentage, global::System.Nullable<decimal> deductionTotalValue, global::System.Nullable<decimal> discountTotalPercentage, global::System.Nullable<decimal> discountTotalValue, global::System.Nullable<decimal> deductionTotal, string invoiceReference, bool isActive, bool isDeleted, bool isClosed, bool isFrozenPendingPayment, decimal paymentMethodAdditionalFeesInclTax, decimal paymentMethodAdditionalFeesExclTax, global::System.Nullable<decimal> taxTotal, global::System.Nullable<decimal> discountTotal, global::System.Nullable<System.Guid> globalPaymentMethodID, global::System.Nullable<System.Guid> userAccountOrganisationID, List<InvoiceLineItemDTO> invoiceLineItems, List<TransactionOrderDTO> transactionOrders, CountryCodeDTO countryCode1, List<InvoiceProcessLogDTO> invoiceProcessLogs, ShoppingCartDTO shoppingCart, OrganisationAccountingPeriodDTO organisationAccountingPeriod, UserAccountOrganisationDTO userAccountOrganisation, OrganisationDTO organisation, List<SmsTransactionDTO> smsTransactions) {

          this.InvoiceID = invoiceID;
          this.VatNumber = vatNumber;
          this.StartDate = startDate;
          this.EndDate = endDate;
          this.Total = total;
          this.LastReminder = lastReminder;
          this.Balance = balance;
          this.ParentID = parentID;
          this.DueDate = dueDate;
          this.CountryCode = countryCode;
          this.NumberOfPaymentAttempts = numberOfPaymentAttempts;
          this.CarriedBalance = carriedBalance;
          this.InvoiceTypeID = invoiceTypeID;
          this.InvoiceNumber = invoiceNumber;
          this.InvoiceName = invoiceName;
          this.CreatedOn = createdOn;
          this.CurrencyCode = currencyCode;
          this.CurrencyRateDate = currencyRateDate;
          this.InvoiceSubTotalInclTaxAndDeduct = invoiceSubTotalInclTaxAndDeduct;
          this.InvoiceSubTotalExclTaxAndDeduct = invoiceSubTotalExclTaxAndDeduct;
          this.InvoiceSubTotalDiscountsInclTaxAndDeduct = invoiceSubTotalDiscountsInclTaxAndDeduct;
          this.InvoiceSubTotalDiscountsExclTaxAndDeduct = invoiceSubTotalDiscountsExclTaxAndDeduct;
          this.CurrencyRate = currencyRate;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
          this.OrganisationID = organisationID;
          this.ShoppingCartID = shoppingCartID;
          this.OrganisationAccountingPeriodID = organisationAccountingPeriodID;
          this.TaxTotalPercentage = taxTotalPercentage;
          this.TaxTotalValue = taxTotalValue;
          this.DeductionTotalPercentage = deductionTotalPercentage;
          this.DeductionTotalValue = deductionTotalValue;
          this.DiscountTotalPercentage = discountTotalPercentage;
          this.DiscountTotalValue = discountTotalValue;
          this.DeductionTotal = deductionTotal;
          this.InvoiceReference = invoiceReference;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsClosed = isClosed;
          this.IsFrozenPendingPayment = isFrozenPendingPayment;
          this.PaymentMethodAdditionalFeesInclTax = paymentMethodAdditionalFeesInclTax;
          this.PaymentMethodAdditionalFeesExclTax = paymentMethodAdditionalFeesExclTax;
          this.TaxTotal = taxTotal;
          this.DiscountTotal = discountTotal;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.InvoiceLineItems = invoiceLineItems;
          this.TransactionOrders = transactionOrders;
          this.CountryCode1 = countryCode1;
          this.InvoiceProcessLogs = invoiceProcessLogs;
          this.ShoppingCart = shoppingCart;
          this.OrganisationAccountingPeriod = organisationAccountingPeriod;
          this.UserAccountOrganisation = userAccountOrganisation;
          this.Organisation = organisation;
          this.SmsTransactions = smsTransactions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InvoiceID { get; set; }

        [DataMember]
        public string VatNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> StartDate { get; set; }

        [DataMember]
        public global::System.DateTime EndDate { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> LastReminder { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> Balance { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> DueDate { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public int NumberOfPaymentAttempts { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CarriedBalance { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceNumber { get; set; }

        [DataMember]
        public string InvoiceName { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public global::System.DateTime CurrencyRateDate { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalExclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalDiscountsInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalDiscountsExclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal CurrencyRate { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToGBP { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToUSD { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ShoppingCartID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationAccountingPeriodID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotal { get; set; }

        [DataMember]
        public string InvoiceReference { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public bool IsFrozenPendingPayment { get; set; }

        [DataMember]
        public decimal PaymentMethodAdditionalFeesInclTax { get; set; }

        [DataMember]
        public decimal PaymentMethodAdditionalFeesExclTax { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotal { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotal { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> GlobalPaymentMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserAccountOrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InvoiceLineItemDTO> InvoiceLineItems { get; set; }

        [DataMember]
        public List<TransactionOrderDTO> TransactionOrders { get; set; }

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public List<InvoiceProcessLogDTO> InvoiceProcessLogs { get; set; }

        [DataMember]
        public ShoppingCartDTO ShoppingCart { get; set; }

        [DataMember]
        public OrganisationAccountingPeriodDTO OrganisationAccountingPeriod { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public List<SmsTransactionDTO> SmsTransactions { get; set; }

        #endregion
    }

}
