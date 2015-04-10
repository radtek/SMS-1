﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.RepositoryStructure in the schema.
    /// </summary>
    [System.Serializable]
    public partial class RepositoryStructure    {

        public RepositoryStructure()
        {
          this.IsLeafNode = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for RepositoryStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid RepositoryStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepositoryID in the schema.
        /// </summary>
        public virtual global::System.Guid RepositoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OwnerID in the schema.
        /// </summary>
        public virtual global::System.Guid OwnerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentRepositoryStructureID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentRepositoryStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLeafNode in the schema.
        /// </summary>
        public virtual bool IsLeafNode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
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
        /// There are no comments for AttachmentDetails in the schema.
        /// </summary>
        public virtual ICollection<AttachmentDetail> AttachmentDetails
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
        /// There are no comments for RepositoryStructureRoles in the schema.
        /// </summary>
        public virtual ICollection<RepositoryStructureRole> RepositoryStructureRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Repository in the schema.
        /// </summary>
        public virtual Repository Repository
        {
            get;
            set;
        }

        #endregion
    }

}
