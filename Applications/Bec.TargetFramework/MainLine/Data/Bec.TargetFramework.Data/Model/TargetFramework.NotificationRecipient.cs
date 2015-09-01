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
    /// There are no comments for Bec.TargetFramework.Data.NotificationRecipient in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationRecipient    {

        public NotificationRecipient()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationRecipientID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationRecipientID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ToParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ToParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationID
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
        /// There are no comments for IsAccepted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsAccepted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserAccountOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AcceptedDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> AcceptedDate
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Notification in the schema.
        /// </summary>
        public virtual Notification Notification
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationRecipientLogs in the schema.
        /// </summary>
        public virtual ICollection<NotificationRecipientLog> NotificationRecipientLogs
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
        /// There are no comments for UserAccountOrganisation in the schema.
        /// </summary>
        public virtual UserAccountOrganisation UserAccountOrganisation
        {
            get;
            set;
        }

        #endregion
    }

}