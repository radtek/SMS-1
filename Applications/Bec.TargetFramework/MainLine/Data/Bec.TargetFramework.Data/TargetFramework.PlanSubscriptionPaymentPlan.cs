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
    /// There are no comments for Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanSubscriptionPaymentPlan    {

        public PlanSubscriptionPaymentPlan()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PlanSubscriptionPaymentPlanID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionPaymentPlanID
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
        /// There are no comments for PlanSubscriptionID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionVersionNumber in the schema.
        /// </summary>
        public virtual int PlanSubscriptionVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> BillingID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Billing in the schema.
        /// </summary>
        public virtual Billing Billing
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
        /// There are no comments for PlanSubscription in the schema.
        /// </summary>
        public virtual PlanSubscription PlanSubscription
        {
            get;
            set;
        }

        #endregion
    }

}
