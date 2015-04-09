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
    public partial class ProductVariantAttributeValueDTO
    {
        #region Constructors
  
        public ProductVariantAttributeValueDTO() {
        }

        public ProductVariantAttributeValueDTO(global::System.Guid productVariantAttributeValueID, global::System.Nullable<System.Guid> productProductAttributeID, global::System.Nullable<int> attributeValueTypeID, string name, global::System.Nullable<decimal> priceAdjustment, global::System.Nullable<decimal> weightAdjustement, decimal cost, int quantity, bool isPreSelected, int displayOrder, bool isActive, bool isDeleted, ProductProductAttributeDTO productProductAttribute, List<ShoppingCartItemProductAttributeDTO> shoppingCartItemProductAttributes) {

          this.ProductVariantAttributeValueID = productVariantAttributeValueID;
          this.ProductProductAttributeID = productProductAttributeID;
          this.AttributeValueTypeID = attributeValueTypeID;
          this.Name = name;
          this.PriceAdjustment = priceAdjustment;
          this.WeightAdjustement = weightAdjustement;
          this.Cost = cost;
          this.Quantity = quantity;
          this.IsPreSelected = isPreSelected;
          this.DisplayOrder = displayOrder;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductProductAttribute = productProductAttribute;
          this.ShoppingCartItemProductAttributes = shoppingCartItemProductAttributes;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductVariantAttributeValueID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductProductAttributeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AttributeValueTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> PriceAdjustment { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> WeightAdjustement { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public bool IsPreSelected { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductProductAttributeDTO ProductProductAttribute { get; set; }

        [DataMember]
        public List<ShoppingCartItemProductAttributeDTO> ShoppingCartItemProductAttributes { get; set; }

        #endregion
    }

}
