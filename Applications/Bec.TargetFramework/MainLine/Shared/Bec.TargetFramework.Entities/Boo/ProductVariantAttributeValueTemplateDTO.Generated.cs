﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class ProductVariantAttributeValueTemplateDTO
    {
        #region Constructors
  
        public ProductVariantAttributeValueTemplateDTO() {
        }

        public ProductVariantAttributeValueTemplateDTO(global::System.Guid productVariantAttributeValueTemplateID, global::System.Guid productProductAttributeTemplateID, global::System.Nullable<int> attributeValueTypeID, string name, global::System.Nullable<decimal> priceAdjustment, global::System.Nullable<decimal> weightAdjustment, decimal cost, int quantity, bool isPreSelected, int displayOrder, bool isActive, bool isDeleted, ProductProductAttributeTemplateDTO productProductAttributeTemplate) {

          this.ProductVariantAttributeValueTemplateID = productVariantAttributeValueTemplateID;
          this.ProductProductAttributeTemplateID = productProductAttributeTemplateID;
          this.AttributeValueTypeID = attributeValueTypeID;
          this.Name = name;
          this.PriceAdjustment = priceAdjustment;
          this.WeightAdjustment = weightAdjustment;
          this.Cost = cost;
          this.Quantity = quantity;
          this.IsPreSelected = isPreSelected;
          this.DisplayOrder = displayOrder;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductProductAttributeTemplate = productProductAttributeTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductVariantAttributeValueTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductProductAttributeTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AttributeValueTypeID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> PriceAdjustment { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> WeightAdjustment { get; set; }

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
        public ProductProductAttributeTemplateDTO ProductProductAttributeTemplate { get; set; }

        #endregion
    }

}
