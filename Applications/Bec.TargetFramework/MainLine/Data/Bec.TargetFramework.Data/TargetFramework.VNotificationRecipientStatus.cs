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
    /// There are no comments for Bec.TargetFramework.Data.VNotificationRecipientStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VNotificationRecipientStatus    {

        public VNotificationRecipientStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationID
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
        /// There are no comments for NotificationStatusID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationStatusID
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
        /// There are no comments for NotificationDeliveryMethodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationDeliveryMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationExportFormatID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationExportFormatID
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
        /// There are no comments for IsAccepted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsAccepted
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

    
        /// <summary>
        /// There are no comments for IsRead in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsRead
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
        /// There are no comments for ErrorOccured in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> ErrorOccured
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SentOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> SentOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationVerificationCode in the schema.
        /// </summary>
        public virtual string NotificationVerificationCode
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
        /// There are no comments for NotificationRecipientLogID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationRecipientLogID
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
        /// There are no comments for RecipientParent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RecipientParent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RecipientToParent in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RecipientToParent
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
        /// There are no comments for FromParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> FromParentID
        {
            get;
            set;
        }


        #endregion
    }

}
