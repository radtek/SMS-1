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
    /// There are no comments for Bec.TargetFramework.Data.VNotificationConstruct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VNotificationConstruct    {

        public VNotificationConstruct()
        {
        }

        #region Properties
    
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
        /// There are no comments for DefaultNotificationDeliveryMethodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultNotificationDeliveryMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultNotificationExportFormatID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultNotificationExportFormatID
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
        /// There are no comments for NotificationTitle in the schema.
        /// </summary>
        public virtual string NotificationTitle
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationSubject in the schema.
        /// </summary>
        public virtual string NotificationSubject
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationDetails in the schema.
        /// </summary>
        public virtual string NotificationDetails
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationReference in the schema.
        /// </summary>
        public virtual string NotificationReference
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationAdditionalDetails in the schema.
        /// </summary>
        public virtual string NotificationAdditionalDetails
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CanBeIncludedInBatchNotification in the schema.
        /// </summary>
        public virtual bool CanBeIncludedInBatchNotification
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
        /// There are no comments for ExternalRelatedNotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ExternalRelatedNotificationConstructID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ExternalRelatedNotificationConstructVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ExternalRelatedNotificationConstructVersionNumber
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
        /// There are no comments for NotificationConstructTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TypeName in the schema.
        /// </summary>
        public virtual string TypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CategoryName in the schema.
        /// </summary>
        public virtual string CategoryName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ExportFormatName in the schema.
        /// </summary>
        public virtual string ExportFormatName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeliveryMethodName in the schema.
        /// </summary>
        public virtual string DeliveryMethodName
        {
            get;
            set;
        }


        #endregion
    }

}
