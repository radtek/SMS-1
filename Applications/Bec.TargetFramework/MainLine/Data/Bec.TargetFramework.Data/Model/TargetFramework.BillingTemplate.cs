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
    /// There are no comments for Bec.TargetFramework.Data.BillingTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BillingTemplate    {

        public BillingTemplate()
        {
          this.HasDelayedBilling = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BillingTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid BillingTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriod in the schema.
        /// </summary>
        public virtual int BillingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriodUnitID in the schema.
        /// </summary>
        public virtual int BillingPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriodDayOfMonth in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingPeriodDayOfMonth
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DelayedBillingPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DelayedBillingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DelayedBillingPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DelayedBillingPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasDelayedBilling in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasDelayedBilling
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfBillingPeriods in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NumberOfBillingPeriods
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceToProcessingDelayPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceToProcessingDelayPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceToProcessingDelayPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceToProcessingDelayPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InvoiceNotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceNotificationConstructTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EstimatedProcessingPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> EstimatedProcessingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EstimatedProcessingPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> EstimatedProcessingPeriodUnitID
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
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingLagPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingLagPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingLagPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingLagPeriodUnitID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PlanBillingTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanBillingTemplate> PlanBillingTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanGlobalPaymentMethodTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanGlobalPaymentMethodTemplate> PlanGlobalPaymentMethodTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Billings in the schema.
        /// </summary>
        public virtual ICollection<Billing> Billings
        {
            get;
            set;
        }

        #endregion
    }

}
