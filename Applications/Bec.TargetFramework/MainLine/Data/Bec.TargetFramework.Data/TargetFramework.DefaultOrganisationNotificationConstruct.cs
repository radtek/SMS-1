﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationNotificationConstruct    {

        public DefaultOrganisationNotificationConstruct()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationNotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationNotificationConstructID
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
        /// There are no comments for DefaultOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationID
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for NotificationConstruct in the schema.
        /// </summary>
        public virtual NotificationConstruct NotificationConstruct
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisation in the schema.
        /// </summary>
        public virtual DefaultOrganisation DefaultOrganisation
        {
            get;
            set;
        }

        #endregion
    }

}
