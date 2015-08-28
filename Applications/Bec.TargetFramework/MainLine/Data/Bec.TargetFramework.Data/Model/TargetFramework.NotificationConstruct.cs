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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstruct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstruct    {

        public NotificationConstruct()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.CanBeIncludedInBatchNotification = false;
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

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructTemplateVersionNumber
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
        /// There are no comments for NotificationConstructSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructSubTypeID
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
        /// There are no comments for NotificationConstructSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructSubCategoryID
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
        /// There are no comments for NotificationSubject in the schema.
        /// </summary>
        public virtual string NotificationSubject
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OwnerOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OwnerOrganisationID
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
        /// There are no comments for DefaultNotificationExportFormatID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultNotificationExportFormatID
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
        /// There are no comments for NotificationConstructMutatorObjectType in the schema.
        /// </summary>
        public virtual string NotificationConstructMutatorObjectType
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationNotificationConstruct> DefaultOrganisationNotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<ModuleNotificationConstruct> ModuleNotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructClaims in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructClaim> NotificationConstructClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<ArtefactNotificationConstruct> ArtefactNotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructRoles in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructRole> NotificationConstructRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructTemplate in the schema.
        /// </summary>
        public virtual NotificationConstructTemplate NotificationConstructTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructParameters in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructParameter> NotificationConstructParameters
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructData in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructDatum> NotificationConstructData
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Notifications in the schema.
        /// </summary>
        public virtual ICollection<Notification> Notifications
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructTargets in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructTarget> NotificationConstructTargets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructGroupNotificationConstruct> NotificationConstructGroupNotificationConstructs
        {
            get;
            set;
        }

        #endregion
    }

}
