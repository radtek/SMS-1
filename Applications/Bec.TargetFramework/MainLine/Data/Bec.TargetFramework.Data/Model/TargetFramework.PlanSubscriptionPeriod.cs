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
    /// There are no comments for Bec.TargetFramework.Data.PlanSubscriptionPeriod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanSubscriptionPeriod    {

        public PlanSubscriptionPeriod()
        {
          this.IsCancellationPeriod = false;
          this.IsTrialPeriod = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsClosed = false;
        }

        #region Properties
    
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StartDate in the schema.
        /// </summary>
        public virtual global::System.DateTime StartDate
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
        /// There are no comments for IsCancellationPeriod in the schema.
        /// </summary>
        public virtual bool IsCancellationPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancellationPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PeriodNumber in the schema.
        /// </summary>
        public virtual int PeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTrialPeriod in the schema.
        /// </summary>
        public virtual bool IsTrialPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TrialPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialStartDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> TrialStartDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialEndDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> TrialEndDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationStartDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CancellationStartDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationEndDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CancellationEndDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionPeriodID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionPeriodID
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
        /// There are no comments for PlanSubscriptionBillingPeriodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PlanSubscriptionBillingPeriodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClosedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ClosedOn
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PlanSubscription in the schema.
        /// </summary>
        public virtual PlanSubscription PlanSubscription
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InvoiceLineItems in the schema.
        /// </summary>
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptionBillingProcessLog in the schema.
        /// </summary>
        public virtual PlanSubscriptionBillingProcessLog PlanSubscriptionBillingProcessLog
        {
            get;
            set;
        }

        #endregion
    }

}