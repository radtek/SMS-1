﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.VInvoiceWithCurrentTransactionOrderStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VInvoiceWithCurrentTransactionOrderStatus    {

        public VInvoiceWithCurrentTransactionOrderStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InvoiceID in the schema.
        /// </summary>
        public virtual global::System.Guid InvoiceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VatNumber in the schema.
        /// </summary>
        public virtual string VatNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StartDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> StartDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EndDate in the schema.
        /// </summary>
        public virtual global::System.DateTime EndDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Total in the schema.
        /// </summary>
        public virtual decimal Total
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastReminder in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastReminder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Balance in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> Balance
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DueDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> DueDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfPaymentAttempts in the schema.
        /// </summary>
        public virtual int NumberOfPaymentAttempts
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CarriedBalance in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> CarriedBalance
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceName in the schema.
        /// </summary>
        public virtual string InvoiceName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyCode in the schema.
        /// </summary>
        public virtual string CurrencyCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyRateDate in the schema.
        /// </summary>
        public virtual global::System.DateTime CurrencyRateDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyRate in the schema.
        /// </summary>
        public virtual decimal CurrencyRate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyRateToGBP in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> CurrencyRateToGBP
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyRateToUSD in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> CurrencyRateToUSD
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSubTotalInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal InvoiceSubTotalInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSubTotalExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal InvoiceSubTotalExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSubTotalDiscountsInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal InvoiceSubTotalDiscountsInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceSubTotalDiscountsExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal InvoiceSubTotalDiscountsExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ShoppingCartID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ShoppingCartID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationAccountingPeriodID in the schema.
        /// </summary>
        public virtual int OrganisationAccountingPeriodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceReference in the schema.
        /// </summary>
        public virtual string InvoiceReference
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsClosed in the schema.
        /// </summary>
        public virtual bool IsClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFrozenPendingPayment in the schema.
        /// </summary>
        public virtual bool IsFrozenPendingPayment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceStatus in the schema.
        /// </summary>
        public virtual string InvoiceStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderStatus in the schema.
        /// </summary>
        public virtual string TransactionOrderStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InvoiceStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> TransactionOrderStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderSubTotalInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal OrderSubTotalInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderSubTotalExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal OrderSubTotalExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderSubTotalDiscountsInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> OrderSubTotalDiscountsInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderSubTotalDiscountsExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> OrderSubTotalDiscountsExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodAdditionalFeesInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> PaymentMethodAdditionalFeesInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodAdditionalFeesExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> PaymentMethodAdditionalFeesExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderTaxTotal in the schema.
        /// </summary>
        public virtual decimal OrderTaxTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderDiscountTotal in the schema.
        /// </summary>
        public virtual decimal OrderDiscountTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderTotal in the schema.
        /// </summary>
        public virtual decimal OrderTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RefundedAmount in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> RefundedAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PaymentDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AuthorizationTransactionID in the schema.
        /// </summary>
        public virtual string AuthorizationTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AuthorizationTransactionCode in the schema.
        /// </summary>
        public virtual string AuthorizationTransactionCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AuthorizationTransactionResult in the schema.
        /// </summary>
        public virtual string AuthorizationTransactionResult
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CaptureTransactionID in the schema.
        /// </summary>
        public virtual string CaptureTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CaptureTransactionResult in the schema.
        /// </summary>
        public virtual string CaptureTransactionResult
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SubscriptionTransactionID in the schema.
        /// </summary>
        public virtual string SubscriptionTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionTypeID in the schema.
        /// </summary>
        public virtual int TransactionTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodTypeID in the schema.
        /// </summary>
        public virtual int PaymentMethodTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionGatewayTypeID in the schema.
        /// </summary>
        public virtual int TransactionGatewayTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderReference in the schema.
        /// </summary>
        public virtual string TransactionOrderReference
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GlobalPaymentMethodID in the schema.
        /// </summary>
        public virtual global::System.Guid GlobalPaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrderDeductionTotal in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> OrderDeductionTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxTotalPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TaxTotalPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxTotalValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TaxTotalValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionTotalPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionTotalPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionTotalValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionTotalValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTotalPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountTotalPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTotalValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountTotalValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountPeriodIsCurrent in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> AccountPeriodIsCurrent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodIsClosed in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> AccountingPeriodIsClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountingPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodStartDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountingPeriodStartDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodEndDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountingPeriodEndDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodMonth in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountingPeriodMonth
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountingPeriodYear in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountingPeriodYear
        {
            get;
            set;
        }


        #endregion
    }

}
