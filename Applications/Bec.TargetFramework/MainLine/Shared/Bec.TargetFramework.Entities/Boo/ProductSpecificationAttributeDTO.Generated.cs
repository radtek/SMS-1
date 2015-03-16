﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class ProductSpecificationAttributeDTO
    {
        #region Constructors
  
        public ProductSpecificationAttributeDTO() {
        }

        public ProductSpecificationAttributeDTO(global::System.Guid productSpecificationAttributeID, global::System.Guid productID, bool isMultiSelect, int displayOrder, bool isPreSelected, int minimumSelectionLimit, int maximumSelectionLimit, bool isUserDefined, bool isPriceDriven, global::System.Guid specificationAttributeID, bool isActive, bool isDeleted, int productVersionID, bool isMandatory, List<PackageProductSpecificationBlueprintDTO> packageProductSpecificationBlueprints, List<ProductSpecificationBlueprintDTO> productSpecificationBlueprints, SpecificationAttributeDTO specificationAttribute, ProductDTO product, List<ProductSpecificationAttributeOptionDTO> productSpecificationAttributeOptions, List<ShoppingCartItemProductSpecificationDTO> shoppingCartItemProductSpecifications) {

          this.ProductSpecificationAttributeID = productSpecificationAttributeID;
          this.ProductID = productID;
          this.IsMultiSelect = isMultiSelect;
          this.DisplayOrder = displayOrder;
          this.IsPreSelected = isPreSelected;
          this.MinimumSelectionLimit = minimumSelectionLimit;
          this.MaximumSelectionLimit = maximumSelectionLimit;
          this.IsUserDefined = isUserDefined;
          this.IsPriceDriven = isPriceDriven;
          this.SpecificationAttributeID = specificationAttributeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVersionID = productVersionID;
          this.IsMandatory = isMandatory;
          this.PackageProductSpecificationBlueprints = packageProductSpecificationBlueprints;
          this.ProductSpecificationBlueprints = productSpecificationBlueprints;
          this.SpecificationAttribute = specificationAttribute;
          this.Product = product;
          this.ProductSpecificationAttributeOptions = productSpecificationAttributeOptions;
          this.ShoppingCartItemProductSpecifications = shoppingCartItemProductSpecifications;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public bool IsMultiSelect { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public bool IsPreSelected { get; set; }

        [DataMember]
        public int MinimumSelectionLimit { get; set; }

        [DataMember]
        public int MaximumSelectionLimit { get; set; }

        [DataMember]
        public bool IsUserDefined { get; set; }

        [DataMember]
        public bool IsPriceDriven { get; set; }

        [DataMember]
        public global::System.Guid SpecificationAttributeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PackageProductSpecificationBlueprintDTO> PackageProductSpecificationBlueprints { get; set; }

        [DataMember]
        public List<ProductSpecificationBlueprintDTO> ProductSpecificationBlueprints { get; set; }

        [DataMember]
        public SpecificationAttributeDTO SpecificationAttribute { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public List<ProductSpecificationAttributeOptionDTO> ProductSpecificationAttributeOptions { get; set; }

        [DataMember]
        public List<ShoppingCartItemProductSpecificationDTO> ShoppingCartItemProductSpecifications { get; set; }

        #endregion
    }

}
