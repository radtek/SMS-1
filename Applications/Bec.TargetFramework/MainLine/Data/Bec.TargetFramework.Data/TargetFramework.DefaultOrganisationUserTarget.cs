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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationUserTarget in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationUserTarget    {

        public DefaultOrganisationUserTarget()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDefault = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTargetID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationUserTargetID
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
        /// There are no comments for DefaultOrganisationVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserSubCategoryID
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
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid UserTypeID
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
        /// There are no comments for IsDefault in the schema.
        /// </summary>
        public virtual bool IsDefault
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisation in the schema.
        /// </summary>
        public virtual DefaultOrganisation DefaultOrganisation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationStatusType in the schema.
        /// </summary>
        public virtual DefaultOrganisationStatusType DefaultOrganisationStatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual UserType UserType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationGroupTargets in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroupTarget> DefaultOrganisationGroupTargets
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

        #endregion
    }

}
