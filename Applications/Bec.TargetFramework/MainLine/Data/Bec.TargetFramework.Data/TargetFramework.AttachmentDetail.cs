﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.AttachmentDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class AttachmentDetail    {

        public AttachmentDetail()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for AttachmentDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid AttachmentDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentTypeID in the schema.
        /// </summary>
        public virtual int AttachmentTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AttachmentSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AttachmentCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepositoryStructureID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RepositoryStructureID
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for AttachmentDetailRoles in the schema.
        /// </summary>
        public virtual ICollection<AttachmentDetailRole> AttachmentDetailRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RepositoryStructure in the schema.
        /// </summary>
        public virtual RepositoryStructure RepositoryStructure
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDetails in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDetail> OrganisationDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Attachments in the schema.
        /// </summary>
        public virtual ICollection<Attachment> Attachments
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
