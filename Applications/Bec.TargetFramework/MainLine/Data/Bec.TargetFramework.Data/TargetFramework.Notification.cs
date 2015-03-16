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
    /// There are no comments for Bec.TargetFramework.Data.Notification in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Notification    {

        public Notification()
        {
          this.IsSent = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsInternal = false;
          this.IsExternal = false;
          this.IsVisible = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FromParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> FromParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateSent in the schema.
        /// </summary>
        public virtual global::System.DateTime DateSent
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
        /// There are no comments for NotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ModuleNotificationConstructID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ModuleNotificationConstructVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSent in the schema.
        /// </summary>
        public virtual bool IsSent
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
        /// There are no comments for IsInternal in the schema.
        /// </summary>
        public virtual bool IsInternal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsExternal in the schema.
        /// </summary>
        public virtual bool IsExternal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsVisible in the schema.
        /// </summary>
        public virtual bool IsVisible
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationData in the schema.
        /// </summary>
        public virtual string NotificationData
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationStatusID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationStatusID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationRecipients in the schema.
        /// </summary>
        public virtual ICollection<NotificationRecipient> NotificationRecipients
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstruct in the schema.
        /// </summary>
        public virtual NotificationConstruct NotificationConstruct
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
        /// There are no comments for OrganisationDirectDebitMandates in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDirectDebitMandate> OrganisationDirectDebitMandates
        {
            get;
            set;
        }

        #endregion
    }

}
