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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructGroupTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructGroupTemplate    {

        public NotificationConstructGroupTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructGroupTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructGroupTemplateVersion in the schema.
        /// </summary>
        public virtual int NotificationConstructGroupTemplateVersion
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
        public virtual global::System.Nullable<bool> IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDeleted
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
        /// There are no comments for NotificationConstructGroupTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructGroupTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructGroupCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructGroupCategoryID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructGroups in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructGroup> NotificationConstructGroups
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

        #endregion
    }

}
