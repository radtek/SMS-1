﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.Discount in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Discount    {

        public Discount()
        {
          this.DiscountVersionNumber = 1;
          this.MaxRedemptions = 1;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsRecurring = false;
          this.IsPercentage = true;
          this.IsSingleProductDiscount = false;
          this.IsCheckoutDiscount = false;
          this.IsSingleProductQuantityDiscount = false;
          this.SingleProductQuantityDiscountDivisor = 0;
          this.IsSingleProductQuantityDiscountPercentageBased = false;
          this.IsSingleProductQuantityDiscountAdditionalQuantityBased = false;
          this.SingleProductQuantityDiscountAdditionalQuantity = 0;
          this.IsMultipleProductCombinationDiscount = false;
          this.IsMultipleProductCombinationDiscountPercentageBased = false;
          this.IsMultipleProductCombinationDiscountCheapestFreeBased = false;
          this.HasTiers = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DiscountID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountVersionNumber in the schema.
        /// </summary>
        public virtual int DiscountVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
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
        /// There are no comments for InvoiceName in the schema.
        /// </summary>
        public virtual string InvoiceName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountTypeID in the schema.
        /// </summary>
        public virtual int DiscountTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountAmount in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DiscountAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountQuantity in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DiscountQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DiscountPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DisocuntPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DisocuntPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ValidTill in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ValidTill
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaxRedemptions in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> MaxRedemptions
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountApplyOnID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DiscountApplyOnID
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
        /// There are no comments for IsRecurring in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsRecurring
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPercentage in the schema.
        /// </summary>
        public virtual bool IsPercentage
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
        /// There are no comments for DiscountStatusID in the schema.
        /// </summary>
        public virtual int DiscountStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSingleProductDiscount in the schema.
        /// </summary>
        public virtual bool IsSingleProductDiscount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCheckoutDiscount in the schema.
        /// </summary>
        public virtual bool IsCheckoutDiscount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSingleProductQuantityDiscount in the schema.
        /// </summary>
        public virtual bool IsSingleProductQuantityDiscount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SingleProductQuantityDiscountDivisor in the schema.
        /// </summary>
        public virtual int SingleProductQuantityDiscountDivisor
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSingleProductQuantityDiscountPercentageBased in the schema.
        /// </summary>
        public virtual bool IsSingleProductQuantityDiscountPercentageBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSingleProductQuantityDiscountAdditionalQuantityBased in the schema.
        /// </summary>
        public virtual bool IsSingleProductQuantityDiscountAdditionalQuantityBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SingleProductQuantityDiscountAdditionalQuantity in the schema.
        /// </summary>
        public virtual int SingleProductQuantityDiscountAdditionalQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMultipleProductCombinationDiscount in the schema.
        /// </summary>
        public virtual bool IsMultipleProductCombinationDiscount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMultipleProductCombinationDiscountPercentageBased in the schema.
        /// </summary>
        public virtual bool IsMultipleProductCombinationDiscountPercentageBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMultipleProductCombinationDiscountCheapestFreeBased in the schema.
        /// </summary>
        public virtual bool IsMultipleProductCombinationDiscountCheapestFreeBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasTiers in the schema.
        /// </summary>
        public virtual bool HasTiers
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ParentVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OwnerOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OwnerOrganisationID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductDiscounts in the schema.
        /// </summary>
        public virtual ICollection<ProductDiscount> ProductDiscounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDiscounts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDiscount> OrganisationDiscounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanDiscounts in the schema.
        /// </summary>
        public virtual ICollection<PlanDiscount> PlanDiscounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DiscountRelatedProducts in the schema.
        /// </summary>
        public virtual ICollection<DiscountRelatedProduct> DiscountRelatedProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual UserType UserType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTiers in the schema.
        /// </summary>
        public virtual ICollection<ComponentTier> ComponentTiers
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
