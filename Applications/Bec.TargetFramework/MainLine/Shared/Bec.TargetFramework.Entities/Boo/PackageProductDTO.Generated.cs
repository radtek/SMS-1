﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class PackageProductDTO
    {
        #region Constructors
  
        public PackageProductDTO() {
        }

        public PackageProductDTO(global::System.Guid packageProductID, global::System.Guid packageID, bool useProductDefaultBlueprint, bool useDefaultProductPricing, bool isFixedPrice, decimal productPriceModifierPercentage, decimal productPriceModifierValue, int defaultQuantity, bool userDefinableQuantity, bool isActive, bool isDeleted, global::System.Guid productID, int productVersionID, int packageVersionNumber, global::System.Nullable<System.Guid> relatedProductProductAttributeID, List<PackageProductRelationshipDTO> packageProductRelationships, List<PackageProductSpecificationBlueprintDTO> packageProductSpecificationBlueprints, List<ProductFamilyProductPackageDTO> productFamilyProductPackages, ProductDTO product, PackageDTO package) {

          this.PackageProductID = packageProductID;
          this.PackageID = packageID;
          this.UseProductDefaultBlueprint = useProductDefaultBlueprint;
          this.UseDefaultProductPricing = useDefaultProductPricing;
          this.IsFixedPrice = isFixedPrice;
          this.ProductPriceModifierPercentage = productPriceModifierPercentage;
          this.ProductPriceModifierValue = productPriceModifierValue;
          this.DefaultQuantity = defaultQuantity;
          this.UserDefinableQuantity = userDefinableQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.PackageVersionNumber = packageVersionNumber;
          this.RelatedProductProductAttributeID = relatedProductProductAttributeID;
          this.PackageProductRelationships = packageProductRelationships;
          this.PackageProductSpecificationBlueprints = packageProductSpecificationBlueprints;
          this.ProductFamilyProductPackages = productFamilyProductPackages;
          this.Product = product;
          this.Package = package;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductID { get; set; }

        [DataMember]
        public global::System.Guid PackageID { get; set; }

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
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int PackageVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RelatedProductProductAttributeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PackageProductRelationshipDTO> PackageProductRelationships { get; set; }

        [DataMember]
        public List<PackageProductSpecificationBlueprintDTO> PackageProductSpecificationBlueprints { get; set; }

        [DataMember]
        public List<ProductFamilyProductPackageDTO> ProductFamilyProductPackages { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public PackageDTO Package { get; set; }

        #endregion
    }

}
