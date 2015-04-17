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
    /// There are no comments for Bec.TargetFramework.Data.PackageProduct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PackageProduct    {

        public PackageProduct()
        {
          this.UseProductDefaultBlueprint = false;
          this.UseDefaultProductPricing = false;
          this.IsFixedPrice = false;
          this.DefaultQuantity = 0;
          this.UserDefinableQuantity = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PackageProductID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UseProductDefaultBlueprint in the schema.
        /// </summary>
        public virtual bool UseProductDefaultBlueprint
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UseDefaultProductPricing in the schema.
        /// </summary>
        public virtual bool UseDefaultProductPricing
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFixedPrice in the schema.
        /// </summary>
        public virtual bool IsFixedPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductPriceModifierPercentage in the schema.
        /// </summary>
        public virtual decimal ProductPriceModifierPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductPriceModifierValue in the schema.
        /// </summary>
        public virtual decimal ProductPriceModifierValue
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
        /// There are no comments for UserDefinableQuantity in the schema.
        /// </summary>
        public virtual bool UserDefinableQuantity
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
        /// There are no comments for ProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductVersionID in the schema.
        /// </summary>
        public virtual int ProductVersionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageVersionNumber in the schema.
        /// </summary>
        public virtual int PackageVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RelatedProductProductAttributeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RelatedProductProductAttributeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PackageProductRelationships in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationship> PackageProductRelationships
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductSpecificationBlueprints in the schema.
        /// </summary>
        public virtual ICollection<PackageProductSpecificationBlueprint> PackageProductSpecificationBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductFamilyProductPackages in the schema.
        /// </summary>
        public virtual ICollection<ProductFamilyProductPackage> ProductFamilyProductPackages
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        public virtual Product Product
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Package in the schema.
        /// </summary>
        public virtual Package Package
        {
            get;
            set;
        }

        #endregion
    }

}
