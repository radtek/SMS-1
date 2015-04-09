﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.Invoice in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Invoice    {

        public Invoice()
        {
          this.NumberOfPaymentAttempts = 0;
          this.CurrencyRate = 0m;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsClosed = false;
          this.IsFrozenPendingPayment = false;
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
        public virtual global::System.Nullable<int> OrganisationAccountingPeriodID
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
        /// There are no comments for DeductionTotal in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionTotal
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
        /// There are no comments for PaymentMethodAdditionalFeesInclTax in the schema.
        /// </summary>
        public virtual decimal PaymentMethodAdditionalFeesInclTax
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodAdditionalFeesExclTax in the schema.
        /// </summary>
        public virtual decimal PaymentMethodAdditionalFeesExclTax
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxTotal in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TaxTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTotal in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GlobalPaymentMethodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> GlobalPaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserAccountOrganisationID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InvoiceLineItems in the schema.
        /// </summary>
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrders in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrder> TransactionOrders
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual CountryCode CountryCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InvoiceProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<InvoiceProcessLog> InvoiceProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCart in the schema.
        /// </summary>
        public virtual ShoppingCart ShoppingCart
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationAccountingPeriod in the schema.
        /// </summary>
        public virtual OrganisationAccountingPeriod OrganisationAccountingPeriod
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisation in the schema.
        /// </summary>
        public virtual UserAccountOrganisation UserAccountOrganisation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }

        #endregion
    }

}
