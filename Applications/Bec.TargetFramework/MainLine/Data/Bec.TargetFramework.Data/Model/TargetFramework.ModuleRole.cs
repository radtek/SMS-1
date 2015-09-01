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
    /// There are no comments for Bec.TargetFramework.Data.ModuleRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleRole    {

        public ModuleRole()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.ModuleVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for RoleID in the schema.
        /// </summary>
        public virtual global::System.Guid RoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleID
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
        /// There are no comments for ModuleVersionNumber in the schema.
        /// </summary>
        public virtual int ModuleVersionNumber
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ModuleClaims in the schema.
        /// </summary>
        public virtual ICollection<ModuleClaim> ModuleClaims
        {
            get;
            set;
        }

        #endregion
    }

}