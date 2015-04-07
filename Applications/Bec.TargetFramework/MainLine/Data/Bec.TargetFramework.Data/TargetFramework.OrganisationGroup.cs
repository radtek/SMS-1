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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationGroup in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationGroup    {

        public OrganisationGroup()
        {
          this.IsManaged = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationGroupID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationGroupID
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
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
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
        /// There are no comments for ParentOrganisationGroupID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentOrganisationGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentRootGroupID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentRootGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsManaged in the schema.
        /// </summary>
        public virtual bool IsManaged
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GroupTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> GroupTypeID
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
        /// There are no comments for GroupDescription in the schema.
        /// </summary>
        public virtual string GroupDescription
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationGroupRoles in the schema.
        /// </summary>
        public virtual ICollection<OrganisationGroupRole> OrganisationGroupRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnitOrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnitOrganisationGroup> OrganisationUnitOrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RepositoryStructureGroups in the schema.
        /// </summary>
        public virtual ICollection<RepositoryStructureGroup> RepositoryStructureGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisationGroup> UserAccountOrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AttachmentDetailGroups in the schema.
        /// </summary>
        public virtual ICollection<AttachmentDetailGroup> AttachmentDetailGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }

        #endregion
    }

}
