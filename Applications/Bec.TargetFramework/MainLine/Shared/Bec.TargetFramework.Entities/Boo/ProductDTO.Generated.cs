﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class ProductDTO
    {
        #region Constructors
  
        public ProductDTO() {
        }

        public ProductDTO(global::System.Guid productID, global::System.Guid productTemplateID, bool isActive, bool isDeleted, bool isPackage, bool isDeposit, int productVersionID, int productTemplateVersionID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> ownerOrganisationID, bool canBeResold, bool isDeductionProduct, List<ProductDetailDTO> productDetails, List<ArtefactProductDTO> artefactProducts, List<PackageProductRelationshipDTO> packageProductRelationships_ParentProductID_ParentProductVersionID, List<PackageProductRelationshipDTO> packageProductRelationships_ChildProductID_ChildProductVersionID, List<ModuleProductDTO> moduleProducts, List<ShoppingCartItemDTO> shoppingCartItems, List<ProductDeductionDTO> productDeductions, List<InvoiceLineItemDTO> invoiceLineItems, List<DefaultOrganisationProductDTO> defaultOrganisationProducts, List<ProductDiscountDTO> productDiscounts, List<PackageDTO> packages, List<PlanProductDTO> planProducts, List<ProductClaimDTO> productClaims, List<ProductSpecificationBlueprintDTO> productSpecificationBlueprints, List<ProductTagDTO> productTags, List<ProductSpecificationAttributeDTO> productSpecificationAttributes, List<ProductVariantAttributeCombinationDTO> productVariantAttributeCombinations, List<ProductRoleDTO> productRoles, List<ProductFamilyProductPackageDTO> productFamilyProductPackages, List<ProductProductAttributeDTO> productProductAttributes, List<ProductRelationshipDTO> productRelationships_ParentProductID_ParentProductVersionID, List<ProductRelationshipDTO> productRelationships_ChildProductID_ChildProductVersionID, ProductTemplateDTO productTemplate, List<PackageProductDTO> packageProducts, List<ShoppingCartBlueprintProductDTO> shoppingCartBlueprintProducts, List<OrganisationProductPurchaseDTO> organisationProductPurchases, List<DiscountRelatedProductDTO> discountRelatedProducts, List<ComponentTierDTO> componentTiers, List<DeductionDTO> deductions, List<ProductPlanDTO> productPlans, List<ProductBusTaskDTO> productBusTasks) {

          this.ProductID = productID;
          this.ProductTemplateID = productTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsPackage = isPackage;
          this.IsDeposit = isDeposit;
          this.ProductVersionID = productVersionID;
          this.ProductTemplateVersionID = productTemplateVersionID;
          this.ParentID = parentID;
          this.OwnerOrganisationID = ownerOrganisationID;
          this.CanBeResold = canBeResold;
          this.IsDeductionProduct = isDeductionProduct;
          this.ProductDetails = productDetails;
          this.ArtefactProducts = artefactProducts;
          this.PackageProductRelationships_ParentProductID_ParentProductVersionID = packageProductRelationships_ParentProductID_ParentProductVersionID;
          this.PackageProductRelationships_ChildProductID_ChildProductVersionID = packageProductRelationships_ChildProductID_ChildProductVersionID;
          this.ModuleProducts = moduleProducts;
          this.ShoppingCartItems = shoppingCartItems;
          this.ProductDeductions = productDeductions;
          this.InvoiceLineItems = invoiceLineItems;
          this.DefaultOrganisationProducts = defaultOrganisationProducts;
          this.ProductDiscounts = productDiscounts;
          this.Packages = packages;
          this.PlanProducts = planProducts;
          this.ProductClaims = productClaims;
          this.ProductSpecificationBlueprints = productSpecificationBlueprints;
          this.ProductTags = productTags;
          this.ProductSpecificationAttributes = productSpecificationAttributes;
          this.ProductVariantAttributeCombinations = productVariantAttributeCombinations;
          this.ProductRoles = productRoles;
          this.ProductFamilyProductPackages = productFamilyProductPackages;
          this.ProductProductAttributes = productProductAttributes;
          this.ProductRelationships_ParentProductID_ParentProductVersionID = productRelationships_ParentProductID_ParentProductVersionID;
          this.ProductRelationships_ChildProductID_ChildProductVersionID = productRelationships_ChildProductID_ChildProductVersionID;
          this.ProductTemplate = productTemplate;
          this.PackageProducts = packageProducts;
          this.ShoppingCartBlueprintProducts = shoppingCartBlueprintProducts;
          this.OrganisationProductPurchases = organisationProductPurchases;
          this.DiscountRelatedProducts = discountRelatedProducts;
          this.ComponentTiers = componentTiers;
          this.Deductions = deductions;
          this.ProductPlans = productPlans;
          this.ProductBusTasks = productBusTasks;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsPackage { get; set; }

        [DataMember]
        public bool IsDeposit { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int ProductTemplateVersionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OwnerOrganisationID { get; set; }

        [DataMember]
        public bool CanBeResold { get; set; }

        [DataMember]
        public bool IsDeductionProduct { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductDetailDTO> ProductDetails { get; set; }

        [DataMember]
        public List<ArtefactProductDTO> ArtefactProducts { get; set; }

        [DataMember]
        public List<PackageProductRelationshipDTO> PackageProductRelationships_ParentProductID_ParentProductVersionID { get; set; }

        [DataMember]
        public List<PackageProductRelationshipDTO> PackageProductRelationships_ChildProductID_ChildProductVersionID { get; set; }

        [DataMember]
        public List<ModuleProductDTO> ModuleProducts { get; set; }

        [DataMember]
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }

        [DataMember]
        public List<ProductDeductionDTO> ProductDeductions { get; set; }

        [DataMember]
        public List<InvoiceLineItemDTO> InvoiceLineItems { get; set; }

        [DataMember]
        public List<DefaultOrganisationProductDTO> DefaultOrganisationProducts { get; set; }

        [DataMember]
        public List<ProductDiscountDTO> ProductDiscounts { get; set; }

        [DataMember]
        public List<PackageDTO> Packages { get; set; }

        [DataMember]
        public List<PlanProductDTO> PlanProducts { get; set; }

        [DataMember]
        public List<ProductClaimDTO> ProductClaims { get; set; }

        [DataMember]
        public List<ProductSpecificationBlueprintDTO> ProductSpecificationBlueprints { get; set; }

        [DataMember]
        public List<ProductTagDTO> ProductTags { get; set; }

        [DataMember]
        public List<ProductSpecificationAttributeDTO> ProductSpecificationAttributes { get; set; }

        [DataMember]
        public List<ProductVariantAttributeCombinationDTO> ProductVariantAttributeCombinations { get; set; }

        [DataMember]
        public List<ProductRoleDTO> ProductRoles { get; set; }

        [DataMember]
        public List<ProductFamilyProductPackageDTO> ProductFamilyProductPackages { get; set; }

        [DataMember]
        public List<ProductProductAttributeDTO> ProductProductAttributes { get; set; }

        [DataMember]
        public List<ProductRelationshipDTO> ProductRelationships_ParentProductID_ParentProductVersionID { get; set; }

        [DataMember]
        public List<ProductRelationshipDTO> ProductRelationships_ChildProductID_ChildProductVersionID { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public List<PackageProductDTO> PackageProducts { get; set; }

        [DataMember]
        public List<ShoppingCartBlueprintProductDTO> ShoppingCartBlueprintProducts { get; set; }

        [DataMember]
        public List<OrganisationProductPurchaseDTO> OrganisationProductPurchases { get; set; }

        [DataMember]
        public List<DiscountRelatedProductDTO> DiscountRelatedProducts { get; set; }

        [DataMember]
        public List<ComponentTierDTO> ComponentTiers { get; set; }

        [DataMember]
        public List<DeductionDTO> Deductions { get; set; }

        [DataMember]
        public List<ProductPlanDTO> ProductPlans { get; set; }

        [DataMember]
        public List<ProductBusTaskDTO> ProductBusTasks { get; set; }

        #endregion
    }

}
