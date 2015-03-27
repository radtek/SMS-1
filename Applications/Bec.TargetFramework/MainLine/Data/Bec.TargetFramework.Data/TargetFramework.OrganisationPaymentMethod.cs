﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationPaymentMethod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationPaymentMethod    {

        public OrganisationPaymentMethod()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDirectDebit = true;
          this.IsBACS = false;
          this.IsPrimary = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
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
        /// There are no comments for OrganisationBankAccountId in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationBankAccountId
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
        /// There are no comments for IsDirectDebit in the schema.
        /// </summary>
        public virtual bool IsDirectDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsBACS in the schema.
        /// </summary>
        public virtual bool IsBACS
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationDirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimary in the schema.
        /// </summary>
        public virtual bool IsPrimary
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
        /// There are no comments for DirectDebitMonthCollectionPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitMonthCollectionPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSMonthPaymentDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSMonthPaymentDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitNumberOfNotificationDaysBeforeCollection in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitNumberOfNotificationDaysBeforeCollection
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSNumberOfNotificationDaysBeforeExpectationOfPayment in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSNumberOfNotificationDaysBeforeExpectationOfPayment
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for GlobalPaymentMethod in the schema.
        /// </summary>
        public virtual GlobalPaymentMethod GlobalPaymentMethod
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationBankAccount in the schema.
        /// </summary>
        public virtual OrganisationBankAccount OrganisationBankAccount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandate in the schema.
        /// </summary>
        public virtual OrganisationDirectDebitMandate OrganisationDirectDebitMandate
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
