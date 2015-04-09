﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class ProductProductAttributeDTO
    {
        #region Constructors
  
        public ProductProductAttributeDTO() {
        }

        public ProductProductAttributeDTO(global::System.Guid productProductAttributeID, global::System.Guid productID, global::System.Guid productAttributeID, bool isRequired, int displayOrder, int productVersionID, bool isActive, bool isDeleted, List<ProductVariantAttributeValueDTO> productVariantAttributeValues, ProductAttributeDTO productAttribute, ProductDTO product) {

          this.ProductProductAttributeID = productProductAttributeID;
          this.ProductID = productID;
          this.ProductAttributeID = productAttributeID;
          this.IsRequired = isRequired;
          this.DisplayOrder = displayOrder;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVariantAttributeValues = productVariantAttributeValues;
          this.ProductAttribute = productAttribute;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductProductAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public global::System.Guid ProductAttributeID { get; set; }

        [DataMember]
        public bool IsRequired { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductVariantAttributeValueDTO> ProductVariantAttributeValues { get; set; }

        [DataMember]
        public ProductAttributeDTO ProductAttribute { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
