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
    /// There are no comments for Bec.TargetFramework.Data.ProductTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductTemplate    {

        public ProductTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsPackage = false;
          this.IsDefaultTemplate = false;
          this.CanBeResold = false;
          this.IsDeductionProduct = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTemplateID
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
        /// There are no comments for IsPackage in the schema.
        /// </summary>
        public virtual bool IsPackage
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OwnerOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OwnerOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultTemplate in the schema.
        /// </summary>
        public virtual bool IsDefaultTemplate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CanBeResold in the schema.
        /// </summary>
        public virtual bool CanBeResold
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeductionProduct in the schema.
        /// </summary>
        public virtual bool IsDeductionProduct
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ArtefactProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ArtefactProductTemplate> ArtefactProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationProductTemplate> DefaultOrganisationProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanProductTemplate> PlanProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationshipTemplate> PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationshipTemplate> PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<PackageProductTemplate> PackageProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDiscountTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductDiscountTemplate> ProductDiscountTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPlanTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductPlanTemplate> ProductPlanTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleProductTemplate> ModuleProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductClaimTemplate> ProductClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductRoleTemplate> ProductRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDetailTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductDetailTemplate> ProductDetailTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationAttributeTemplate> ProductSpecificationAttributeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTagTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductTagTemplate> ProductTagTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductVariantAttributeCombinationTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductVariantAttributeCombinationTemplate> ProductVariantAttributeCombinationTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<ProductRelationshipTemplate> ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<ProductRelationshipTemplate> ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductDeductionTemplate> ProductDeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        public virtual ICollection<Product> Products
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageTemplates in the schema.
        /// </summary>
        public virtual ICollection<PackageTemplate> PackageTemplates
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
        /// There are no comments for ProductProductAttributeTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductProductAttributeTemplate> ProductProductAttributeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DiscountRelatedProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<DiscountRelatedProductTemplate> DiscountRelatedProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartBlueprintProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartBlueprintProductTemplate> ShoppingCartBlueprintProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<DeductionTemplate> DeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTierTemplates in the schema.
        /// </summary>
        public virtual ICollection<ComponentTierTemplate> ComponentTierTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductBusTaskTemplates in the schema.
        /// </summary>
        public virtual ICollection<ProductBusTaskTemplate> ProductBusTaskTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
