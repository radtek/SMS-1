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
    /// There are no comments for Bec.TargetFramework.Data.VTemporaryUsersNotLoggedIn in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VTemporaryUsersNotLoggedIn    {

        public VTemporaryUsersNotLoggedIn()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for Created in the schema.
        /// </summary>
        public virtual global::System.DateTime Created
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountClosed in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> AccountClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedLoginCount in the schema.
        /// </summary>
        public virtual int FailedLoginCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailedPasswordResetCount in the schema.
        /// </summary>
        public virtual int FailedPasswordResetCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual global::System.Guid ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAccountClosed in the schema.
        /// </summary>
        public virtual bool IsAccountClosed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAccountVerified in the schema.
        /// </summary>
        public virtual bool IsAccountVerified
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
        /// There are no comments for LastLogin in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastLogin
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastFailedPasswordReset in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LastFailedPasswordReset
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastUpdated in the schema.
        /// </summary>
        public virtual global::System.DateTime LastUpdated
        {
            get;
            set;
        }


        #endregion
    }

}
