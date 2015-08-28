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
    public partial class VInvoiceWithCurrentTransactionOrderStatusDTO
    {
        #region Constructors
  
        public VInvoiceWithCurrentTransactionOrderStatusDTO() {
        }

        public VInvoiceWithCurrentTransactionOrderStatusDTO(global::System.Guid invoiceID, string vatNumber, global::System.Nullable<System.DateTime> startDate, global::System.DateTime endDate, decimal total, global::System.Nullable<System.DateTime> lastReminder, global::System.Nullable<decimal> balance, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.DateTime> dueDate, string countryCode, int numberOfPaymentAttempts, global::System.Nullable<decimal> carriedBalance, global::System.Nullable<int> invoiceTypeID, global::System.Nullable<int> invoiceNumber, string invoiceName, global::System.DateTime createdOn, string currencyCode, global::System.DateTime currencyRateDate, decimal currencyRate, global::System.Nullable<decimal> currencyRateToGBP, global::System.Nullable<decimal> currencyRateToUSD, decimal invoiceSubTotalInclTaxAndDeduct, decimal invoiceSubTotalExclTaxAndDeduct, decimal invoiceSubTotalDiscountsInclTaxAndDeduct, decimal invoiceSubTotalDiscountsExclTaxAndDeduct, global::System.Nullable<System.Guid> organisationID, global::System.Nullable<System.Guid> shoppingCartID, int organisationAccountingPeriodID, string invoiceReference, bool isActive, bool isDeleted, bool isClosed, bool isFrozenPendingPayment, string invoiceStatus, string transactionOrderStatus, global::System.Nullable<System.Guid> invoiceStatusTypeValueID, global::System.Nullable<System.Guid> transactionOrderStatusTypeValueID, global::System.Guid transactionOrderID, decimal orderSubTotalInclTaxAndDeduct, decimal orderSubTotalExclTaxAndDeduct, global::System.Nullable<decimal> orderSubTotalDiscountsInclTaxAndDeduct, global::System.Nullable<decimal> orderSubTotalDiscountsExclTaxAndDeduct, global::System.Nullable<decimal> paymentMethodAdditionalFeesInclTaxAndDeduct, global::System.Nullable<decimal> paymentMethodAdditionalFeesExclTaxAndDeduct, decimal orderTaxTotal, decimal orderDiscountTotal, decimal orderTotal, global::System.Nullable<decimal> refundedAmount, global::System.Nullable<System.DateTime> paymentDate, string authorizationTransactionID, string authorizationTransactionCode, string authorizationTransactionResult, string captureTransactionID, string captureTransactionResult, string subscriptionTransactionID, int transactionTypeID, int paymentMethodTypeID, int transactionGatewayTypeID, string transactionOrderReference, global::System.Guid globalPaymentMethodID, global::System.Nullable<decimal> orderDeductionTotal, global::System.Nullable<decimal> taxTotalPercentage, global::System.Nullable<decimal> taxTotalValue, global::System.Nullable<decimal> deductionTotalPercentage, global::System.Nullable<decimal> deductionTotalValue, global::System.Nullable<decimal> discountTotalPercentage, global::System.Nullable<decimal> discountTotalValue, global::System.Nullable<bool> accountPeriodIsCurrent, global::System.Nullable<bool> accountingPeriodIsClosed, global::System.Nullable<int> accountingPeriodNumber, global::System.Nullable<int> accountingPeriodStartDay, global::System.Nullable<int> accountingPeriodEndDay, global::System.Nullable<int> accountingPeriodMonth, global::System.Nullable<int> accountingPeriodYear) {

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
          this.CurrencyRate = currencyRate;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
          this.InvoiceSubTotalInclTaxAndDeduct = invoiceSubTotalInclTaxAndDeduct;
          this.InvoiceSubTotalExclTaxAndDeduct = invoiceSubTotalExclTaxAndDeduct;
          this.InvoiceSubTotalDiscountsInclTaxAndDeduct = invoiceSubTotalDiscountsInclTaxAndDeduct;
          this.InvoiceSubTotalDiscountsExclTaxAndDeduct = invoiceSubTotalDiscountsExclTaxAndDeduct;
          this.OrganisationID = organisationID;
          this.ShoppingCartID = shoppingCartID;
          this.OrganisationAccountingPeriodID = organisationAccountingPeriodID;
          this.InvoiceReference = invoiceReference;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsClosed = isClosed;
          this.IsFrozenPendingPayment = isFrozenPendingPayment;
          this.InvoiceStatus = invoiceStatus;
          this.TransactionOrderStatus = transactionOrderStatus;
          this.InvoiceStatusTypeValueID = invoiceStatusTypeValueID;
          this.TransactionOrderStatusTypeValueID = transactionOrderStatusTypeValueID;
          this.TransactionOrderID = transactionOrderID;
          this.OrderSubTotalInclTaxAndDeduct = orderSubTotalInclTaxAndDeduct;
          this.OrderSubTotalExclTaxAndDeduct = orderSubTotalExclTaxAndDeduct;
          this.OrderSubTotalDiscountsInclTaxAndDeduct = orderSubTotalDiscountsInclTaxAndDeduct;
          this.OrderSubTotalDiscountsExclTaxAndDeduct = orderSubTotalDiscountsExclTaxAndDeduct;
          this.PaymentMethodAdditionalFeesInclTaxAndDeduct = paymentMethodAdditionalFeesInclTaxAndDeduct;
          this.PaymentMethodAdditionalFeesExclTaxAndDeduct = paymentMethodAdditionalFeesExclTaxAndDeduct;
          this.OrderTaxTotal = orderTaxTotal;
          this.OrderDiscountTotal = orderDiscountTotal;
          this.OrderTotal = orderTotal;
          this.RefundedAmount = refundedAmount;
          this.PaymentDate = paymentDate;
          this.AuthorizationTransactionID = authorizationTransactionID;
          this.AuthorizationTransactionCode = authorizationTransactionCode;
          this.AuthorizationTransactionResult = authorizationTransactionResult;
          this.CaptureTransactionID = captureTransactionID;
          this.CaptureTransactionResult = captureTransactionResult;
          this.SubscriptionTransactionID = subscriptionTransactionID;
          this.TransactionTypeID = transactionTypeID;
          this.PaymentMethodTypeID = paymentMethodTypeID;
          this.TransactionGatewayTypeID = transactionGatewayTypeID;
          this.TransactionOrderReference = transactionOrderReference;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.OrderDeductionTotal = orderDeductionTotal;
          this.TaxTotalPercentage = taxTotalPercentage;
          this.TaxTotalValue = taxTotalValue;
          this.DeductionTotalPercentage = deductionTotalPercentage;
          this.DeductionTotalValue = deductionTotalValue;
          this.DiscountTotalPercentage = discountTotalPercentage;
          this.DiscountTotalValue = discountTotalValue;
          this.AccountPeriodIsCurrent = accountPeriodIsCurrent;
          this.AccountingPeriodIsClosed = accountingPeriodIsClosed;
          this.AccountingPeriodNumber = accountingPeriodNumber;
          this.AccountingPeriodStartDay = accountingPeriodStartDay;
          this.AccountingPeriodEndDay = accountingPeriodEndDay;
          this.AccountingPeriodMonth = accountingPeriodMonth;
          this.AccountingPeriodYear = accountingPeriodYear;
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
        public decimal CurrencyRate { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToGBP { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToUSD { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalExclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalDiscountsInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal InvoiceSubTotalDiscountsExclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ShoppingCartID { get; set; }

        [DataMember]
        public int OrganisationAccountingPeriodID { get; set; }

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
        public string InvoiceStatus { get; set; }

        [DataMember]
        public string TransactionOrderStatus { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InvoiceStatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TransactionOrderStatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Guid TransactionOrderID { get; set; }

        [DataMember]
        public decimal OrderSubTotalInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal OrderSubTotalExclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> OrderSubTotalDiscountsInclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> OrderSubTotalDiscountsExclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> PaymentMethodAdditionalFeesInclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> PaymentMethodAdditionalFeesExclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal OrderTaxTotal { get; set; }

        [DataMember]
        public decimal OrderDiscountTotal { get; set; }

        [DataMember]
        public decimal OrderTotal { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> RefundedAmount { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> PaymentDate { get; set; }

        [DataMember]
        public string AuthorizationTransactionID { get; set; }

        [DataMember]
        public string AuthorizationTransactionCode { get; set; }

        [DataMember]
        public string AuthorizationTransactionResult { get; set; }

        [DataMember]
        public string CaptureTransactionID { get; set; }

        [DataMember]
        public string CaptureTransactionResult { get; set; }

        [DataMember]
        public string SubscriptionTransactionID { get; set; }

        [DataMember]
        public int TransactionTypeID { get; set; }

        [DataMember]
        public int PaymentMethodTypeID { get; set; }

        [DataMember]
        public int TransactionGatewayTypeID { get; set; }

        [DataMember]
        public string TransactionOrderReference { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> OrderDeductionTotal { get; set; }

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
        public global::System.Nullable<bool> AccountPeriodIsCurrent { get; set; }

        [DataMember]
        public global::System.Nullable<bool> AccountingPeriodIsClosed { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodStartDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodEndDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodMonth { get; set; }

        [DataMember]
        public global::System.Nullable<int> AccountingPeriodYear { get; set; }

        #endregion
    }

}
