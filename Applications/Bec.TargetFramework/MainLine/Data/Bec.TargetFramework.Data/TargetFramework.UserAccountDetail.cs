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
    /// There are no comments for Bec.TargetFramework.Data.UserAccountDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class UserAccountDetail    {

        public UserAccountDetail()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid UserDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserID in the schema.
        /// </summary>
        public virtual global::System.Guid UserID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Salutation in the schema.
        /// </summary>
        public virtual string Salutation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirstName in the schema.
        /// </summary>
        public virtual string FirstName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MiddleName in the schema.
        /// </summary>
        public virtual string MiddleName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LastName in the schema.
        /// </summary>
        public virtual string LastName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HomePhone in the schema.
        /// </summary>
        public virtual string HomePhone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HomeMobile in the schema.
        /// </summary>
        public virtual string HomeMobile
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
