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
    /// There are no comments for Bec.TargetFramework.Data.LinkedAccount in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LinkedAccount    {

        public LinkedAccount()
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
        /// There are no comments for ProviderName in the schema.
        /// </summary>
        public virtual string ProviderName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProviderAccountID in the schema.
        /// </summary>
        public virtual string ProviderAccountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastLogin in the schema.
        /// </summary>
        public virtual global::System.DateTime LastLogin
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
    
        /// <summary>
        /// There are no comments for LinkedAccountClaims in the schema.
        /// </summary>
        public virtual ICollection<LinkedAccountClaim> LinkedAccountClaims
        {
            get;
            set;
        }

        #endregion
    }

}
