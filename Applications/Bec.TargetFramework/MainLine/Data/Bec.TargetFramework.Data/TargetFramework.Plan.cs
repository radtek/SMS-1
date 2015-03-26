﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
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
    /// There are no comments for Bec.TargetFramework.Data.Plan in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Plan    {

        public Plan()
        {
          this.Price = 0m;
          this.Period = 1;
          this.TrialPeriod = 1;
          this.FreeQuantity = 0;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsFree = false;
          this.HasInfinitePeriods = false;
          this.IsTransactionBased = false;
          this.RenewalIsPercentageOfOriginalPrice = false;
          this.HasForwardCycleFee = false;
          this.HasRenewalOffer = false;
          this.IsAutoRenew = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PlanID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanVersionNumber in the schema.
        /// </summary>
        public virtual int PlanVersionNumber
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
        /// There are no comments for Price in the schema.
        /// </summary>
        public virtual decimal Price
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Period in the schema.
        /// </summary>
        public virtual int Period
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialPeriod in the schema.
        /// </summary>
        public virtual int TrialPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TrialPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FreeQuantity in the schema.
        /// </summary>
        public virtual int FreeQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SetupCost in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SetupCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DowngradePenalty in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DowngradePenalty
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
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
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
        /// There are no comments for CancellationPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancellationPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancellationPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFree in the schema.
        /// </summary>
        public virtual bool IsFree
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasInfinitePeriods in the schema.
        /// </summary>
        public virtual bool HasInfinitePeriods
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
        /// There are no comments for PlanTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PlanTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanStatusID in the schema.
        /// </summary>
        public virtual int PlanStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransactionBased in the schema.
        /// </summary>
        public virtual bool IsTransactionBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CoolOffPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CoolOffPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CoolOffPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CoolOffPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> RenewalPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> RenewalPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalIsPercentageOfOriginalPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> RenewalIsPercentageOfOriginalPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasForwardCycleFee in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasForwardCycleFee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFee in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> ForwardCycleFee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFreeIsSameAsPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> ForwardCycleFreeIsSameAsPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalOfferPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RenewalOfferPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalOfferPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RenewalOfferPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFeePeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ForwardCycleFeePeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFeePeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ForwardCycleFeePeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasRenewalOffer in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasRenewalOffer
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceDailyProRata in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> PriceDailyProRata
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAutoRenew in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsAutoRenew
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewDecisionPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewDecisionPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewDecisionUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewDecisionUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanGroupID in the schema.
        /// </summary>
        public virtual int PlanGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PlanTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanCategoryID in the schema.
        /// </summary>
        public virtual int PlanCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ModifiedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedBy in the schema.
        /// </summary>
        public virtual string ModifiedBy
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual CountryCode CountryCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanTemplate in the schema.
        /// </summary>
        public virtual PlanTemplate PlanTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscription> PlanSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanProducts in the schema.
        /// </summary>
        public virtual ICollection<PlanProduct> PlanProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanBillings in the schema.
        /// </summary>
        public virtual ICollection<PlanBilling> PlanBillings
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanTransactions in the schema.
        /// </summary>
        public virtual ICollection<PlanTransaction> PlanTransactions
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
        /// There are no comments for PlanGlobalPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<PlanGlobalPaymentMethod> PlanGlobalPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPlans in the schema.
        /// </summary>
        public virtual ICollection<ProductPlan> ProductPlans
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanGroup in the schema.
        /// </summary>
        public virtual PlanGroup PlanGroup
        {
            get;
            set;
        }

        #endregion
    }

}
