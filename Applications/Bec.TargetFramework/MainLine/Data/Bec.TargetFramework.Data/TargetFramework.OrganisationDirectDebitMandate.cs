﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationDirectDebitMandate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationDirectDebitMandate    {

        public OrganisationDirectDebitMandate()
        {
          this.IsSigned = false;
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
        /// There are no comments for DirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Guid DirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMandateVersionNumber in the schema.
        /// </summary>
        public virtual int DirectDebitMandateVersionNumber
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
        /// There are no comments for DirectDebitMandateStatusID in the schema.
        /// </summary>
        public virtual int DirectDebitMandateStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSigned in the schema.
        /// </summary>
        public virtual bool IsSigned
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SignedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> SignedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationDirectDebitMandateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DirectDebitMandate in the schema.
        /// </summary>
        public virtual DirectDebitMandate DirectDebitMandate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Notification in the schema.
        /// </summary>
        public virtual Notification Notification
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
