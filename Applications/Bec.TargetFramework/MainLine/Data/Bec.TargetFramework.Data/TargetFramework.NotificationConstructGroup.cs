﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructGroup in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructGroup    {

        public NotificationConstructGroup()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructGroupID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructGroupVersion in the schema.
        /// </summary>
        public virtual int NotificationConstructGroupVersion
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
        /// There are no comments for NotificationConstructGroupTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NotificationConstructGroupTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructGroupTemplateVersion in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NotificationConstructGroupTemplateVersion
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
        /// There are no comments for NotificationConstructGroupTemplate in the schema.
        /// </summary>
        public virtual NotificationConstructGroupTemplate NotificationConstructGroupTemplate
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
