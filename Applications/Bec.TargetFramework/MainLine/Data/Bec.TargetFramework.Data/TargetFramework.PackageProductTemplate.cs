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
    /// There are no comments for Bec.TargetFramework.Data.PackageProductTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PackageProductTemplate    {

        public PackageProductTemplate()
        {
          this.UseProductDefaultBlueprint = true;
          this.UseDefaultProductPricing = true;
          this.IsFixedPrice = false;
          this.UserDefinableQuantity = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PackageProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageProductTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PackageTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PackageTemplateID
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
        /// There are no comments for ProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTemplateID
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
        /// There are no comments for PackageTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PackageTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RelatedProductProductAttributeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> RelatedProductProductAttributeTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipTemplates in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationshipTemplate> PackageProductRelationshipTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplate in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageTemplate in the schema.
        /// </summary>
        public virtual PackageTemplate PackageTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductFamilyProductPackageTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductFamilyProductPackageTemplate> ProductFamilyProductPackageTemplates
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
