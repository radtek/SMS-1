﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.VDefaultEmailAddress in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VDefaultEmailAddress    {

        public VDefaultEmailAddress()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for UserID in the schema.
        /// </summary>
        public virtual global::System.Guid UserID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Username in the schema.
        /// </summary>
        public virtual string Username
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
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> BranchOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchEmailAddress in the schema.
        /// </summary>
        public virtual string BranchEmailAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailAddress1 in the schema.
        /// </summary>
        public virtual string EmailAddress1
        {
            get;
            set;
        }


        #endregion
    }

}
