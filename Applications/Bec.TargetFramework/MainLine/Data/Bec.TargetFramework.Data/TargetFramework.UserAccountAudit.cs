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
    /// There are no comments for Bec.TargetFramework.Data.UserAccountAudit in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserAccountAudit    {

        public UserAccountAudit()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserAccountID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSessionID in the schema.
        /// </summary>
        public virtual string UserSessionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AuditID in the schema.
        /// </summary>
        public virtual global::System.Guid AuditID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserIPAddress in the schema.
        /// </summary>
        public virtual string UserIPAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for URLAccessed in the schema.
        /// </summary>
        public virtual string URLAccessed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TimeAccessed in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> TimeAccessed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Data in the schema.
        /// </summary>
        public virtual string Data
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
    }

}
