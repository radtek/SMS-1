﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructRoleTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructRoleTemplate    {

        public NotificationConstructRoleTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructRoleID
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
        /// There are no comments for RoleName in the schema.
        /// </summary>
        public virtual string RoleName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleDescription in the schema.
        /// </summary>
        public virtual string RoleDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubCategoryID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructClaimTemplate> NotificationConstructClaimTemplates
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

        #endregion
    }

}
