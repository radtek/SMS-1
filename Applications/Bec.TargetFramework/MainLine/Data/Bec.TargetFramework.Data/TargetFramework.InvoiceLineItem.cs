﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.InvoiceLineItem in the schema.
    /// </summary>
    [System.Serializable]
    public partial class InvoiceLineItem    {

        public InvoiceLineItem()
        {
          this.IsCredit = false;
          this.IsDebit = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsClosed = false;
          this.IsFrozenPendingPayment = false;
          this.IsDepositProduct = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for InvoiceLineItemID in the schema.
        /// </summary>
        public virtual global::System.Guid InvoiceLineItemID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InvoiceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateFrom in the schema.
        /// </summary>
        public virtual global::System.DateTime DateFrom
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateTo in the schema.
        /// </summary>
        public virtual global::System.DateTime DateTo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SingleProductPrice in the schema.
        /// </summary>
        public virtual decimal SingleProductPrice
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
        /// There are no comments for Price in the schema.
        /// </summary>
        public virtual decimal Price
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Quantity in the schema.
        /// </summary>
        public virtual decimal Quantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceLineItemTypeID in the schema.
        /// </summary>
        public virtual int InvoiceLineItemTypeID
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
        /// There are no comments for PriceInclTax in the schema.
        /// </summary>
        public virtual decimal PriceInclTax
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
        /// There are no comments for IsCredit in the schema.
        /// </summary>
        public virtual bool IsCredit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SingleProductPriceInclTaxAndDeduct in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SingleProductPriceInclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SingleProductPriceExclTaxAndDeduct in the schema.
        /// </summary>
        public virtual decimal SingleProductPriceExclTaxAndDeduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDebit in the schema.
        /// </summary>
        public virtual bool IsDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ProductID
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
        /// There are no comments for DiscountTotalValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountTotalValue
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
        /// There are no comments for DeductionTotalValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionTotalValue
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
        /// There are no comments for DeductionTotal in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionTotal
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
        /// There are no comments for PlanSubscriptionPeriodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PlanSubscriptionPeriodID
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
        /// There are no comments for ProductVersionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ProductVersionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceExclTax in the schema.
        /// </summary>
        public virtual decimal PriceExclTax
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
        /// There are no comments for IsDepositProduct in the schema.
        /// </summary>
        public virtual bool IsDepositProduct
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AccountID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ShoppingCartItems in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
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
        /// There are no comments for Invoice in the schema.
        /// </summary>
        public virtual Invoice Invoice
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        public virtual Product Product
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrderItems in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrderItem> TransactionOrderItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptionPeriod in the schema.
        /// </summary>
        public virtual PlanSubscriptionPeriod PlanSubscriptionPeriod
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPurchases in the schema.
        /// </summary>
        public virtual ICollection<ProductPurchase> ProductPurchases
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationProductPurchases in the schema.
        /// </summary>
        public virtual ICollection<OrganisationProductPurchase> OrganisationProductPurchases
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Account in the schema.
        /// </summary>
        public virtual Account Account
        {
            get;
            set;
        }

        #endregion
    }

}
