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
    public partial class ProductSpecificationBlueprintDTO
    {
        #region Constructors
  
        public ProductSpecificationBlueprintDTO() {
        }

        public ProductSpecificationBlueprintDTO(global::System.Guid productSpecificationBlueprintID, global::System.Guid productID, global::System.Guid productSpecificationAttributeID, global::System.Guid defaultProductSpecificationAttributeOptionID, bool isActive, bool isDeleted, int productVersionID, ProductSpecificationAttributeDTO productSpecificationAttribute, ProductSpecificationAttributeOptionDTO productSpecificationAttributeOption, ProductDTO product) {

          this.ProductSpecificationBlueprintID = productSpecificationBlueprintID;
          this.ProductID = productID;
          this.ProductSpecificationAttributeID = productSpecificationAttributeID;
          this.DefaultProductSpecificationAttributeOptionID = defaultProductSpecificationAttributeOptionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVersionID = productVersionID;
          this.ProductSpecificationAttribute = productSpecificationAttribute;
          this.ProductSpecificationAttributeOption = productSpecificationAttributeOption;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductSpecificationBlueprintID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeID { get; set; }

        [DataMember]
        public global::System.Guid DefaultProductSpecificationAttributeOptionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeDTO ProductSpecificationAttribute { get; set; }

        [DataMember]
        public ProductSpecificationAttributeOptionDTO ProductSpecificationAttributeOption { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
