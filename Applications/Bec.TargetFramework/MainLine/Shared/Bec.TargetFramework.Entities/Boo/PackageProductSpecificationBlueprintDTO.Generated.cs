﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class PackageProductSpecificationBlueprintDTO
    {
        #region Constructors
  
        public PackageProductSpecificationBlueprintDTO() {
        }

        public PackageProductSpecificationBlueprintDTO(global::System.Guid packageProductSpecificationBlueprintID, global::System.Guid packageProductID, global::System.Guid productSpecificationAttributeID, bool isActive, bool isDeleted, global::System.Guid defaultProductSpecificationAttributeOptionID, global::System.Guid packageID, int packageVersionNumber, ProductSpecificationAttributeOptionDTO productSpecificationAttributeOption, ProductSpecificationAttributeDTO productSpecificationAttribute, PackageProductDTO packageProduct) {

          this.PackageProductSpecificationBlueprintID = packageProductSpecificationBlueprintID;
          this.PackageProductID = packageProductID;
          this.ProductSpecificationAttributeID = productSpecificationAttributeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultProductSpecificationAttributeOptionID = defaultProductSpecificationAttributeOptionID;
          this.PackageID = packageID;
          this.PackageVersionNumber = packageVersionNumber;
          this.ProductSpecificationAttributeOption = productSpecificationAttributeOption;
          this.ProductSpecificationAttribute = productSpecificationAttribute;
          this.PackageProduct = packageProduct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductSpecificationBlueprintID { get; set; }

        [DataMember]
        public global::System.Guid PackageProductID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid DefaultProductSpecificationAttributeOptionID { get; set; }

        [DataMember]
        public global::System.Guid PackageID { get; set; }

        [DataMember]
        public int PackageVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeOptionDTO ProductSpecificationAttributeOption { get; set; }

        [DataMember]
        public ProductSpecificationAttributeDTO ProductSpecificationAttribute { get; set; }

        [DataMember]
        public PackageProductDTO PackageProduct { get; set; }

        #endregion
    }

}
