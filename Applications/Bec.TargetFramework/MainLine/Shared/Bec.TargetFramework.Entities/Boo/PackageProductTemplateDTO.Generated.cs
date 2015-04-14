﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class PackageProductTemplateDTO
    {
        #region Constructors
  
        public PackageProductTemplateDTO() {
        }

        public PackageProductTemplateDTO(global::System.Guid packageProductTemplateID, global::System.Guid packageTemplateID, bool useProductDefaultBlueprint, bool useDefaultProductPricing, bool isFixedPrice, decimal productPriceModifierPercentage, decimal productPriceModifierValue, int defaultQuantity, bool userDefinableQuantity, bool isActive, bool isDeleted, global::System.Guid productTemplateID, int productVersionID, int packageTemplateVersionNumber, global::System.Nullable<System.Guid> relatedProductProductAttributeTemplateID, List<PackageProductRelationshipTemplateDTO> packageProductRelationshipTemplates, ProductTemplateDTO productTemplate, PackageTemplateDTO packageTemplate, List<ProductFamilyProductPackageTemplateDTO> productFamilyProductPackageTemplates, List<PackageProductSpecificationBlueprintTemplateDTO> packageProductSpecificationBlueprintTemplates) {

          this.PackageProductTemplateID = packageProductTemplateID;
          this.PackageTemplateID = packageTemplateID;
          this.UseProductDefaultBlueprint = useProductDefaultBlueprint;
          this.UseDefaultProductPricing = useDefaultProductPricing;
          this.IsFixedPrice = isFixedPrice;
          this.ProductPriceModifierPercentage = productPriceModifierPercentage;
          this.ProductPriceModifierValue = productPriceModifierValue;
          this.DefaultQuantity = defaultQuantity;
          this.UserDefinableQuantity = userDefinableQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.PackageTemplateVersionNumber = packageTemplateVersionNumber;
          this.RelatedProductProductAttributeTemplateID = relatedProductProductAttributeTemplateID;
          this.PackageProductRelationshipTemplates = packageProductRelationshipTemplates;
          this.ProductTemplate = productTemplate;
          this.PackageTemplate = packageTemplate;
          this.ProductFamilyProductPackageTemplates = productFamilyProductPackageTemplates;
          this.PackageProductSpecificationBlueprintTemplates = packageProductSpecificationBlueprintTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid PackageTemplateID { get; set; }

        [DataMember]
        public bool UseProductDefaultBlueprint { get; set; }

        [DataMember]
        public bool UseDefaultProductPricing { get; set; }

        [DataMember]
        public bool IsFixedPrice { get; set; }

        [DataMember]
        public decimal ProductPriceModifierPercentage { get; set; }

        [DataMember]
        public decimal ProductPriceModifierValue { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool UserDefinableQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int PackageTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RelatedProductProductAttributeTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PackageProductRelationshipTemplateDTO> PackageProductRelationshipTemplates { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public PackageTemplateDTO PackageTemplate { get; set; }

        [DataMember]
        public List<ProductFamilyProductPackageTemplateDTO> ProductFamilyProductPackageTemplates { get; set; }

        [DataMember]
        public List<PackageProductSpecificationBlueprintTemplateDTO> PackageProductSpecificationBlueprintTemplates { get; set; }

        #endregion
    }

}
