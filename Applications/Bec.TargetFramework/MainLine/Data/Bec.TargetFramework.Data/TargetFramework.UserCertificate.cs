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
    /// There are no comments for Bec.TargetFramework.Data.UserCertificate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserCertificate    {

        public UserCertificate()
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
        /// There are no comments for Thumbprint in the schema.
        /// </summary>
        public virtual string Thumbprint
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Subject in the schema.
        /// </summary>
        public virtual string Subject
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
