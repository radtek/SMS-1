﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.ProductSpecificationAttributeOption in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductSpecificationAttributeOption    {

        public ProductSpecificationAttributeOption()
        {
          this.PriceAdjustment = 0m;
          this.Cost = 0m;
          this.DefaultValue = 0m;
          this.DefaultQuantity = 0;
          this.DisplayOrder = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptionID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeOptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecficiationAttributeOptionID in the schema.
        /// </summary>
        public virtual global::System.Guid SpecficiationAttributeOptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceAdjustment in the schema.
        /// </summary>
        public virtual decimal PriceAdjustment
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
        public virtual int DefaultQuantity
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PackageProductSpecificationBlueprints in the schema.
        /// </summary>
        public virtual ICollection<PackageProductSpecificationBlueprint> PackageProductSpecificationBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationBlueprints in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationBlueprint> ProductSpecificationBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttribute in the schema.
        /// </summary>
        public virtual ProductSpecificationAttribute ProductSpecificationAttribute
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SpecificiationAttributeOption in the schema.
        /// </summary>
        public virtual SpecificiationAttributeOption SpecificiationAttributeOption
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItemProductSpecifications in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItemProductSpecification> ShoppingCartItemProductSpecifications
        {
            get;
            set;
        }

        #endregion
    }

}
