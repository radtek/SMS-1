﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.Group in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Group    {

        public Group()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsGlobal = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for GroupID in the schema.
        /// </summary>
        public virtual global::System.Guid GroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupName in the schema.
        /// </summary>
        public virtual string GroupName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupDescription in the schema.
        /// </summary>
        public virtual string GroupDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupTypeID in the schema.
        /// </summary>
        public virtual int GroupTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupSubCategoryID
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
        /// There are no comments for IsGlobal in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsGlobal
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationGroupTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroupTemplate> DefaultOrganisationGroupTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationGroup> DefaultOrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for GroupRoles in the schema.
        /// </summary>
        public virtual ICollection<GroupRole> GroupRoles
        {
            get;
            set;
        }

        #endregion
    }

}
