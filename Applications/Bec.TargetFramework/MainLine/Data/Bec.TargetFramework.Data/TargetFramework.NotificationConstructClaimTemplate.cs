﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructClaimTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructClaimTemplate    {

        public NotificationConstructClaimTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructClaimTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructClaimTemplateID
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
        /// There are no comments for NotificationConstructRoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NotificationConstructRoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResourceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ResourceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OperationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OperationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateItemID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StateItemID
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
        /// There are no comments for RoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RoleID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Operation in the schema.
        /// </summary>
        public virtual Operation Operation
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
        /// There are no comments for NotificationConstructRoleTemplate in the schema.
        /// </summary>
        public virtual NotificationConstructRoleTemplate NotificationConstructRoleTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Resource in the schema.
        /// </summary>
        public virtual Resource Resource
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for State in the schema.
        /// </summary>
        public virtual State State
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StateItem in the schema.
        /// </summary>
        public virtual StateItem StateItem
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Role in the schema.
        /// </summary>
        public virtual Role Role
        {
            get;
            set;
        }

        #endregion
    }

}
