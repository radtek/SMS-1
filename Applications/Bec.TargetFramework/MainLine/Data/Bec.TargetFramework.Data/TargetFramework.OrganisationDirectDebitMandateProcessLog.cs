﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationDirectDebitMandateProcessLog    {

        public OrganisationDirectDebitMandateProcessLog()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationDirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationRecipientID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationRecipientID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationRecipient in the schema.
        /// </summary>
        public virtual NotificationRecipient NotificationRecipient
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

        #endregion
    }

}
