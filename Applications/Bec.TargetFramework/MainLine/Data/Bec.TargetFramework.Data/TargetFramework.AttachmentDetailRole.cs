﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.AttachmentDetailRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class AttachmentDetailRole    {

        public AttachmentDetailRole()
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
        /// There are no comments for OrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationRoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationExternalRoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationExternalRoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentDetailRoleID in the schema.
        /// </summary>
        public virtual int AttachmentDetailRoleID
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
        /// There are no comments for AttachmentDetail in the schema.
        /// </summary>
        public virtual AttachmentDetail AttachmentDetail
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationRole in the schema.
        /// </summary>
        public virtual OrganisationRole OrganisationRole
        {
            get;
            set;
        }

        #endregion
    }

}
