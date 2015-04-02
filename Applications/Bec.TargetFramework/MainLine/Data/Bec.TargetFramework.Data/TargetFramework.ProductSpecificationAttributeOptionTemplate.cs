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
    /// There are no comments for Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductSpecificationAttributeOptionTemplate    {

        public ProductSpecificationAttributeOptionTemplate()
        {
          this.PriceAdjustement = 0m;
          this.Cost = 0m;
          this.DefaultValue = 0m;
          this.DisplayOrder = 0;
          this.IsActive = false;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SpecificationAttributeOptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecificationAttributeOptionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceAdjustement in the schema.
        /// </summary>
        public virtual decimal PriceAdjustement
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WeightAdjustment in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> WeightAdjustment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Cost in the schema.
        /// </summary>
        public virtual decimal Cost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultValue in the schema.
        /// </summary>
        public virtual decimal DefaultValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultQuantity in the schema.
        /// </summary>
        public virtual decimal DefaultQuantity
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
        /// There are no comments for ProductSpecificationAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeOptionTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeTemplate in the schema.
        /// </summary>
        public virtual ProductSpecificationAttributeTemplate ProductSpecificationAttributeTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificationAttributeOptionTemplate in the schema.
        /// </summary>
        public virtual SpecificationAttributeOptionTemplate SpecificationAttributeOptionTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationBlueprintTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationBlueprintTemplate> ProductSpecificationBlueprintTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductSpecificationBlueprintTemplates in the schema.
        /// </summary>
        public virtual ICollection<PackageProductSpecificationBlueprintTemplate> PackageProductSpecificationBlueprintTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
