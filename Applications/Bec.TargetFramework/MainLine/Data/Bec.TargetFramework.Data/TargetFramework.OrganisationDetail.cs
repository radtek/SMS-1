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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationDetail in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationDetail    {

        public OrganisationDetail()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationDetailID
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
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
        /// There are no comments for OrganisationDefaultLogoID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationDefaultLogoID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationLegalBlurb in the schema.
        /// </summary>
        public virtual string OrganisationLegalBlurb
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
