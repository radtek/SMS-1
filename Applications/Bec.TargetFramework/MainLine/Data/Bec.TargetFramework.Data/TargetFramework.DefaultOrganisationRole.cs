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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationRole    {

        public DefaultOrganisationRole()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDefaultOrganisationSpecific = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationRoleID
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
        /// There are no comments for RoleTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RoleSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RoleSubCategoryID
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
        /// There are no comments for RoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RoleID
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
        /// There are no comments for IsDefaultOrganisationSpecific in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDefaultOrganisationSpecific
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
        /// There are no comments for DefaultOrganisationRoleClaims in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRoleClaim> DefaultOrganisationRoleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleTargets in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationRoleTarget> DefaultOrganisationRoleTargets
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationGroupRoles in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroupRole> DefaultOrganisationGroupRoles
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
