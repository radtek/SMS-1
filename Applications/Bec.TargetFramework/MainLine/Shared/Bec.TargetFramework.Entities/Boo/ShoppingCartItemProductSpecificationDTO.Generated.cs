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
    public partial class ShoppingCartItemProductSpecificationDTO
    {
        #region Constructors
  
        public ShoppingCartItemProductSpecificationDTO() {
        }

        public ShoppingCartItemProductSpecificationDTO(global::System.Guid shoppingCartItemProductSpecificationID, global::System.Guid productSpecificationAttributeID, global::System.Guid productSpecificationAttributeOptionID, decimal quantity, global::System.Guid shoppingCartItemID, ProductSpecificationAttributeOptionDTO productSpecificationAttributeOption, ShoppingCartItemDTO shoppingCartItem, ProductSpecificationAttributeDTO productSpecificationAttribute) {

          this.ShoppingCartItemProductSpecificationID = shoppingCartItemProductSpecificationID;
          this.ProductSpecificationAttributeID = productSpecificationAttributeID;
          this.ProductSpecificationAttributeOptionID = productSpecificationAttributeOptionID;
          this.Quantity = quantity;
          this.ShoppingCartItemID = shoppingCartItemID;
          this.ProductSpecificationAttributeOption = productSpecificationAttributeOption;
          this.ShoppingCartItem = shoppingCartItem;
          this.ProductSpecificationAttribute = productSpecificationAttribute;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartItemProductSpecificationID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeOptionID { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public global::System.Guid ShoppingCartItemID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeOptionDTO ProductSpecificationAttributeOption { get; set; }

        [DataMember]
        public ShoppingCartItemDTO ShoppingCartItem { get; set; }

        [DataMember]
        public ProductSpecificationAttributeDTO ProductSpecificationAttribute { get; set; }

        #endregion
    }

}