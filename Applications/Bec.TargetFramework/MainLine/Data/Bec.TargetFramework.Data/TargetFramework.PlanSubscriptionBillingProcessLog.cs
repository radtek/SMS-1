﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.PlanSubscriptionBillingProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanSubscriptionBillingProcessLog    {

        public PlanSubscriptionBillingProcessLog()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsClosed = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BillingPeriodNumber in the schema.
        /// </summary>
        public virtual int BillingPeriodNumber
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionBillingPeriodID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionBillingPeriodID
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
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
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
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptionPeriods in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscriptionPeriod> PlanSubscriptionPeriods
        {
            get;
            set;
        }

        #endregion
    }

}
