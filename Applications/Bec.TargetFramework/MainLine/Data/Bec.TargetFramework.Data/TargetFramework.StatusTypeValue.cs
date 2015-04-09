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
    /// There are no comments for Bec.TargetFramework.Data.StatusTypeValue in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StatusTypeValue    {

        public StatusTypeValue()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
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
        /// There are no comments for DefaultOrganisationStatusTypes in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationStatusType> DefaultOrganisationStatusTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeStructures in the schema.
        /// </summary>
        public virtual ICollection<StatusTypeStructure> StatusTypeStructures
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationStatus in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisationStatus> UserAccountOrganisationStatus
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationStatus in the schema.
        /// </summary>
        public virtual ICollection<OrganisationStatus> OrganisationStatus
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
        /// There are no comments for InvoiceProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<InvoiceProcessLog> InvoiceProcessLogs
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
        /// There are no comments for PlanSubscriptionBillingPeriods in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscriptionBillingProcessLog> PlanSubscriptionBillingPeriods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptionProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscriptionProcessLog> PlanSubscriptionProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationFinancialDetails in the schema.
        /// </summary>
        public virtual ICollection<OrganisationFinancialDetail> OrganisationFinancialDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationPaymentMethod> OrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDirectDebitMandateProcessLog> OrganisationDirectDebitMandateProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsInviteProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<StsInviteProcessLog> StsInviteProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<StsSearchProcessLog> StsSearchProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchRelations in the schema.
        /// </summary>
        public virtual ICollection<StsSearchRelation> StsSearchRelations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPurchaseProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<ProductPurchaseProcessLog> ProductPurchaseProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ServiceInterfaceProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<ServiceInterfaceProcessLog> ServiceInterfaceProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTaskScheduleProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<BusTaskScheduleProcessLog> BusTaskScheduleProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPurchaseBusTaskProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<ProductPurchaseBusTaskProcessLog> ProductPurchaseBusTaskProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusMessageProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<BusMessageProcessLog> BusMessageProcessLogs
        {
            get;
            set;
        }

        #endregion
    }

}
