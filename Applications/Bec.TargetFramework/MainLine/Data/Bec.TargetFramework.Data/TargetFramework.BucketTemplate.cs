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
    /// There are no comments for Bec.TargetFramework.Data.BucketTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BucketTemplate    {

        public BucketTemplate()
        {
          this.IsGlobal = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BucketTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid BucketTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketName in the schema.
        /// </summary>
        public virtual string BucketName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketDescription in the schema.
        /// </summary>
        public virtual string BucketDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BucketTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BucketSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BucketCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BucketSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BucketSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsGlobal in the schema.
        /// </summary>
        public virtual bool IsGlobal
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
        /// There are no comments for DefaultOrganisationTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationTemplate> DefaultOrganisationTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisations in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisation> DefaultOrganisations
        {
            get;
            set;
        }

        #endregion
    }

}
