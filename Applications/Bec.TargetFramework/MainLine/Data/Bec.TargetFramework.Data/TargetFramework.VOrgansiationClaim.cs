﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.VOrgansiationClaim in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VOrgansiationClaim    {

        public VOrgansiationClaim()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationRoleID
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
        /// There are no comments for ClaimType in the schema.
        /// </summary>
        public virtual string ClaimType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ClaimID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimName in the schema.
        /// </summary>
        public virtual string ClaimName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimDescription in the schema.
        /// </summary>
        public virtual string ClaimDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubType in the schema.
        /// </summary>
        public virtual string ClaimSubType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ClaimSubID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubName in the schema.
        /// </summary>
        public virtual string ClaimSubName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimSubDescription in the schema.
        /// </summary>
        public virtual string ClaimSubDescription
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
        /// There are no comments for RoleSource in the schema.
        /// </summary>
        public virtual string RoleSource
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ClaimTypeName in the schema.
        /// </summary>
        public virtual string ClaimTypeName
        {
            get;
            set;
        }


        #endregion
    }

}
