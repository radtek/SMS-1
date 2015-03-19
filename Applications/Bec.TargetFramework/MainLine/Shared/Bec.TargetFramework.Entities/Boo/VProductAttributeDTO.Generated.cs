﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class VProductAttributeDTO
    {
        #region Constructors
  
        public VProductAttributeDTO() {
        }

        public VProductAttributeDTO(global::System.Guid productID, int productVersionID, string productAttributeName, string productAttributeDescription, global::System.Nullable<bool> isProductAttributeRequired, global::System.Nullable<int> productAttributeDisplayOrder, decimal priceAdjustment, decimal weightAdjustement, decimal cost, int quantity, bool isPreSelected, global::System.Guid productVariantAttributeValueID, string attributeName, global::System.Guid productProductAttributeID, global::System.Guid productAttributeID) {

          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.ProductAttributeName = productAttributeName;
          this.ProductAttributeDescription = productAttributeDescription;
          this.IsProductAttributeRequired = isProductAttributeRequired;
          this.ProductAttributeDisplayOrder = productAttributeDisplayOrder;
          this.PriceAdjustment = priceAdjustment;
          this.WeightAdjustement = weightAdjustement;
          this.Cost = cost;
          this.Quantity = quantity;
          this.IsPreSelected = isPreSelected;
          this.ProductVariantAttributeValueID = productVariantAttributeValueID;
          this.AttributeName = attributeName;
          this.ProductProductAttributeID = productProductAttributeID;
          this.ProductAttributeID = productAttributeID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public string ProductAttributeName { get; set; }

        [DataMember]
        public string ProductAttributeDescription { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsProductAttributeRequired { get; set; }

        [DataMember]
        public global::System.Nullable<int> ProductAttributeDisplayOrder { get; set; }

        [DataMember]
        public decimal PriceAdjustment { get; set; }

        [DataMember]
        public decimal WeightAdjustement { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public bool IsPreSelected { get; set; }

        [DataMember]
        public global::System.Guid ProductVariantAttributeValueID { get; set; }

        [DataMember]
        public string AttributeName { get; set; }

        [DataMember]
        public global::System.Guid ProductProductAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ProductAttributeID { get; set; }

        #endregion
    }

}
