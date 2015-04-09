﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ProductTemplateDTO
    {
        #region Constructors
  
        public ProductTemplateDTO() {
        }

        public ProductTemplateDTO(global::System.Guid productTemplateID, bool isActive, bool isDeleted, bool isPackage, int productVersionID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> ownerOrganisationID, bool isDefaultTemplate, bool canBeResold, bool isDeductionProduct, List<ArtefactProductTemplateDTO> artefactProductTemplates, List<DefaultOrganisationProductTemplateDTO> defaultOrganisationProductTemplates, List<PlanProductTemplateDTO> planProductTemplates, List<PackageProductRelationshipTemplateDTO> packageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID, List<PackageProductRelationshipTemplateDTO> packageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID, List<PackageProductTemplateDTO> packageProductTemplates, List<ProductDiscountTemplateDTO> productDiscountTemplates, List<ProductPlanTemplateDTO> productPlanTemplates, List<ModuleProductTemplateDTO> moduleProductTemplates, List<ProductClaimTemplateDTO> productClaimTemplates, List<ProductRoleTemplateDTO> productRoleTemplates, List<ProductDetailTemplateDTO> productDetailTemplates, List<ProductSpecificationAttributeTemplateDTO> productSpecificationAttributeTemplates, List<ProductTagTemplateDTO> productTagTemplates, List<ProductVariantAttributeCombinationTemplateDTO> productVariantAttributeCombinationTemplates, List<ProductRelationshipTemplateDTO> productRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID, List<ProductRelationshipTemplateDTO> productRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID, List<ProductDeductionTemplateDTO> productDeductionTemplates, List<ProductDTO> products, List<PackageTemplateDTO> packageTemplates, List<ProductFamilyProductPackageTemplateDTO> productFamilyProductPackageTemplates, List<ProductProductAttributeTemplateDTO> productProductAttributeTemplates, List<DiscountRelatedProductTemplateDTO> discountRelatedProductTemplates, List<ShoppingCartBlueprintProductTemplateDTO> shoppingCartBlueprintProductTemplates, List<DeductionTemplateDTO> deductionTemplates, List<ComponentTierTemplateDTO> componentTierTemplates, List<ProductBusTaskTemplateDTO> productBusTaskTemplates) {

          this.ProductTemplateID = productTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsPackage = isPackage;
          this.ProductVersionID = productVersionID;
          this.ParentID = parentID;
          this.OwnerOrganisationID = ownerOrganisationID;
          this.IsDefaultTemplate = isDefaultTemplate;
          this.CanBeResold = canBeResold;
          this.IsDeductionProduct = isDeductionProduct;
          this.ArtefactProductTemplates = artefactProductTemplates;
          this.DefaultOrganisationProductTemplates = defaultOrganisationProductTemplates;
          this.PlanProductTemplates = planProductTemplates;
          this.PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID = packageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID;
          this.PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID = packageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID;
          this.PackageProductTemplates = packageProductTemplates;
          this.ProductDiscountTemplates = productDiscountTemplates;
          this.ProductPlanTemplates = productPlanTemplates;
          this.ModuleProductTemplates = moduleProductTemplates;
          this.ProductClaimTemplates = productClaimTemplates;
          this.ProductRoleTemplates = productRoleTemplates;
          this.ProductDetailTemplates = productDetailTemplates;
          this.ProductSpecificationAttributeTemplates = productSpecificationAttributeTemplates;
          this.ProductTagTemplates = productTagTemplates;
          this.ProductVariantAttributeCombinationTemplates = productVariantAttributeCombinationTemplates;
          this.ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID = productRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID;
          this.ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID = productRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID;
          this.ProductDeductionTemplates = productDeductionTemplates;
          this.Products = products;
          this.PackageTemplates = packageTemplates;
          this.ProductFamilyProductPackageTemplates = productFamilyProductPackageTemplates;
          this.ProductProductAttributeTemplates = productProductAttributeTemplates;
          this.DiscountRelatedProductTemplates = discountRelatedProductTemplates;
          this.ShoppingCartBlueprintProductTemplates = shoppingCartBlueprintProductTemplates;
          this.DeductionTemplates = deductionTemplates;
          this.ComponentTierTemplates = componentTierTemplates;
          this.ProductBusTaskTemplates = productBusTaskTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsPackage { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OwnerOrganisationID { get; set; }

        [DataMember]
        public bool IsDefaultTemplate { get; set; }

        [DataMember]
        public bool CanBeResold { get; set; }

        [DataMember]
        public bool IsDeductionProduct { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ArtefactProductTemplateDTO> ArtefactProductTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationProductTemplateDTO> DefaultOrganisationProductTemplates { get; set; }

        [DataMember]
        public List<PlanProductTemplateDTO> PlanProductTemplates { get; set; }

        [DataMember]
        public List<PackageProductRelationshipTemplateDTO> PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID { get; set; }

        [DataMember]
        public List<PackageProductRelationshipTemplateDTO> PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID { get; set; }

        [DataMember]
        public List<PackageProductTemplateDTO> PackageProductTemplates { get; set; }

        [DataMember]
        public List<ProductDiscountTemplateDTO> ProductDiscountTemplates { get; set; }

        [DataMember]
        public List<ProductPlanTemplateDTO> ProductPlanTemplates { get; set; }

        [DataMember]
        public List<ModuleProductTemplateDTO> ModuleProductTemplates { get; set; }

        [DataMember]
        public List<ProductClaimTemplateDTO> ProductClaimTemplates { get; set; }

        [DataMember]
        public List<ProductRoleTemplateDTO> ProductRoleTemplates { get; set; }

        [DataMember]
        public List<ProductDetailTemplateDTO> ProductDetailTemplates { get; set; }

        [DataMember]
        public List<ProductSpecificationAttributeTemplateDTO> ProductSpecificationAttributeTemplates { get; set; }

        [DataMember]
        public List<ProductTagTemplateDTO> ProductTagTemplates { get; set; }

        [DataMember]
        public List<ProductVariantAttributeCombinationTemplateDTO> ProductVariantAttributeCombinationTemplates { get; set; }

        [DataMember]
        public List<ProductRelationshipTemplateDTO> ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID { get; set; }

        [DataMember]
        public List<ProductRelationshipTemplateDTO> ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID { get; set; }

        [DataMember]
        public List<ProductDeductionTemplateDTO> ProductDeductionTemplates { get; set; }

        [DataMember]
        public List<ProductDTO> Products { get; set; }

        [DataMember]
        public List<PackageTemplateDTO> PackageTemplates { get; set; }

        [DataMember]
        public List<ProductFamilyProductPackageTemplateDTO> ProductFamilyProductPackageTemplates { get; set; }

        [DataMember]
        public List<ProductProductAttributeTemplateDTO> ProductProductAttributeTemplates { get; set; }

        [DataMember]
        public List<DiscountRelatedProductTemplateDTO> DiscountRelatedProductTemplates { get; set; }

        [DataMember]
        public List<ShoppingCartBlueprintProductTemplateDTO> ShoppingCartBlueprintProductTemplates { get; set; }

        [DataMember]
        public List<DeductionTemplateDTO> DeductionTemplates { get; set; }

        [DataMember]
        public List<ComponentTierTemplateDTO> ComponentTierTemplates { get; set; }

        [DataMember]
        public List<ProductBusTaskTemplateDTO> ProductBusTaskTemplates { get; set; }

        #endregion
    }

}
