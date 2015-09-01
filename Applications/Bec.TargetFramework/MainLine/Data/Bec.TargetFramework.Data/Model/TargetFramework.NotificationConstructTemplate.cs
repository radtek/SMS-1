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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructTemplate    {

        public NotificationConstructTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.NotificationSubject = @"200";
          this.CanBeIncludedInBatchNotification = false;
        }

        #region Properties
    
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
        /// There are no comments for ExternalRelatedNotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ExternalRelatedNotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ExternalRelatedNotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ExternalRelatedNotificationConstructTemplateVersionNumber
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
        /// There are no comments for NotificationTitle in the schema.
        /// </summary>
        public virtual string NotificationTitle
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
        /// There are no comments for DefaultOrganisationNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationNotificationConstructTemplate> DefaultOrganisationNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructClaimTemplate> NotificationConstructClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructDataTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructDataTemplate> NotificationConstructDataTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructParameterTemplate> NotificationConstructParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstruct> NotificationConstructs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactNotificationConstructTemplate> ArtefactNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructRoleTemplate> NotificationConstructRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructTargetTemplate> NotificationConstructTargetTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleNotificationConstructTemplate> ModuleNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructGroupNotificationConstructTemplate> NotificationConstructGroupNotificationConstructTemplates
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