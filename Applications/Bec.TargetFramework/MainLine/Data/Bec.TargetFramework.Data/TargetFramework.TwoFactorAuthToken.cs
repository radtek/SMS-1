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
    /// There are no comments for Bec.TargetFramework.Data.TwoFactorAuthToken in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TwoFactorAuthToken    {

        public TwoFactorAuthToken()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for Token in the schema.
        /// </summary>
        public virtual string Token
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Issued in the schema.
        /// </summary>
        public virtual global::System.DateTime Issued
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountID
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
        /// There are no comments for UserAccount in the schema.
        /// </summary>
        public virtual UserAccount UserAccount
        {
            get;
            set;
        }

        #endregion
    }

}
