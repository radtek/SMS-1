﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.SpecificationAttribute in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SpecificationAttribute    {

        public SpecificationAttribute()
        {
          this.DisplayOrder = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecificationAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeTemplateID
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
        /// There are no comments for DisplayOrder in the schema.
        /// </summary>
        public virtual int DisplayOrder
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
        /// There are no comments for SpecificationAttributeTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecificationAttributeTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecificationAttributeCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecificationAttributeSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationAttributeSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecificationAttributeSubCategoryID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributes in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeTemplate in the schema.
        /// </summary>
        public virtual SpecificationAttributeTemplate SpecificationAttributeTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeRelationships_ParentSpecificationAttributeID in the schema.
        /// </summary>
        public virtual ICollection<SpecificationAttributeRelationship> SpecificationAttributeRelationships_ParentSpecificationAttributeID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeRelationships_SpecificationAttributeID in the schema.
        /// </summary>
        public virtual ICollection<SpecificationAttributeRelationship> SpecificationAttributeRelationships_SpecificationAttributeID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificiationAttributeOptions in the schema.
        /// </summary>
        public virtual ICollection<SpecificiationAttributeOption> SpecificiationAttributeOptions
        {
            get;
            set;
        }

        #endregion
    }

}
