﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.VAttachment in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VAttachment    {

        public VAttachment()
        {
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
        /// There are no comments for FileName in the schema.
        /// </summary>
        public virtual string FileName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepositoryStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid RepositoryStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Subject in the schema.
        /// </summary>
        public virtual string Subject
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MimeType in the schema.
        /// </summary>
        public virtual string MimeType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Body in the schema.
        /// </summary>
        public virtual byte[] Body
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FileSize in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> FileSize
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepositoryName in the schema.
        /// </summary>
        public virtual string RepositoryName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentID in the schema.
        /// </summary>
        public virtual global::System.Guid AttachmentID
        {
            get;
            set;
        }


        #endregion
    }

}
