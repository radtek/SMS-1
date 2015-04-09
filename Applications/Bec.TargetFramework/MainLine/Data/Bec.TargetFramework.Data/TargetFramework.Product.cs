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
    /// There are no comments for Bec.TargetFramework.Data.Product in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Product    {

        public Product()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsPackage = false;
          this.IsDeposit = false;
          this.CanBeResold = false;
          this.IsDeductionProduct = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductID
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
        /// There are no comments for IsDeposit in the schema.
        /// </summary>
        public virtual bool IsDeposit
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
        /// There are no comments for ProductTemplateVersionID in the schema.
        /// </summary>
        public virtual int ProductTemplateVersionID
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
        /// There are no comments for ProductDetails in the schema.
        /// </summary>
        public virtual ICollection<ProductDetail> ProductDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ArtefactProducts in the schema.
        /// </summary>
        public virtual ICollection<ArtefactProduct> ArtefactProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductRelationships_ParentProductID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationship> PackageProductRelationships_ParentProductID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PackageProductRelationships_ChildProductID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<PackageProductRelationship> PackageProductRelationships_ChildProductID_ChildProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleProducts in the schema.
        /// </summary>
        public virtual ICollection<ModuleProduct> ModuleProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItems in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDeductions in the schema.
        /// </summary>
        public virtual ICollection<ProductDeduction> ProductDeductions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InvoiceLineItems in the schema.
        /// </summary>
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationProducts in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationProduct> DefaultOrganisationProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductDiscounts in the schema.
        /// </summary>
        public virtual ICollection<ProductDiscount> ProductDiscounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Packages in the schema.
        /// </summary>
        public virtual ICollection<Package> Packages
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanProducts in the schema.
        /// </summary>
        public virtual ICollection<PlanProduct> PlanProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductClaims in the schema.
        /// </summary>
        public virtual ICollection<ProductClaim> ProductClaims
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
        /// There are no comments for ProductTags in the schema.
        /// </summary>
        public virtual ICollection<ProductTag> ProductTags
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributes in the schema.
        /// </summary>
        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductVariantAttributeCombinations in the schema.
        /// </summary>
        public virtual ICollection<ProductVariantAttributeCombination> ProductVariantAttributeCombinations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRoles in the schema.
        /// </summary>
        public virtual ICollection<ProductRole> ProductRoles
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
        /// There are no comments for ProductProductAttributes in the schema.
        /// </summary>
        public virtual ICollection<ProductProductAttribute> ProductProductAttributes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRelationships_ParentProductID_ParentProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<ProductRelationship> ProductRelationships_ParentProductID_ParentProductVersionID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductRelationships_ChildProductID_ChildProductVersionID in the schema.
        /// </summary>
        public virtual ICollection<ProductRelationship> ProductRelationships_ChildProductID_ChildProductVersionID
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
        /// There are no comments for PackageProducts in the schema.
        /// </summary>
        public virtual ICollection<PackageProduct> PackageProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartBlueprintProducts in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartBlueprintProduct> ShoppingCartBlueprintProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationProductPurchases in the schema.
        /// </summary>
        public virtual ICollection<OrganisationProductPurchase> OrganisationProductPurchases
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DiscountRelatedProducts in the schema.
        /// </summary>
        public virtual ICollection<DiscountRelatedProduct> DiscountRelatedProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTiers in the schema.
        /// </summary>
        public virtual ICollection<ComponentTier> ComponentTiers
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Deductions in the schema.
        /// </summary>
        public virtual ICollection<Deduction> Deductions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPlans in the schema.
        /// </summary>
        public virtual ICollection<ProductPlan> ProductPlans
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductBusTasks in the schema.
        /// </summary>
        public virtual ICollection<ProductBusTask> ProductBusTasks
        {
            get;
            set;
        }

        #endregion
    }

}
