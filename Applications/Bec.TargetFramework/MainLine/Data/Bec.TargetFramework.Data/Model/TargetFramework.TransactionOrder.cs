﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.TransactionOrder in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TransactionOrder    {

        public TransactionOrder()
        {
          this.RefundedAmount = 0m;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsHierachicalTransactionOrder = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderID
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
        /// There are no comments for CurrencyRateToGBP in the schema.
        /// </summary>
        public virtual decimal CurrencyRateToGBP
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
        /// There are no comments for VatNumber in the schema.
        /// </summary>
        public virtual string VatNumber
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentID
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
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
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
        /// There are no comments for ParentTransactionOrderID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentTransactionOrderID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsHierachicalTransactionOrder in the schema.
        /// </summary>
        public virtual bool IsHierachicalTransactionOrder
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
        /// There are no comments for CurrencyRateToUSD in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> CurrencyRateToUSD
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
        /// There are no comments for InvoiceID in the schema.
        /// </summary>
        public virtual global::System.Guid InvoiceID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderItems in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrderItem> TransactionOrderItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Invoice in the schema.
        /// </summary>
        public virtual Invoice Invoice
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrderProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrderProcessLog> TransactionOrderProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GlobalPaymentMethod in the schema.
        /// </summary>
        public virtual GlobalPaymentMethod GlobalPaymentMethod
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationLedgerTransactions in the schema.
        /// </summary>
        public virtual ICollection<OrganisationLedgerTransaction> OrganisationLedgerTransactions
        {
            get;
            set;
        }

        #endregion
    }

}