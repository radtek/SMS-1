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
    public partial class ProductVariantAttributeCombinationTemplateDTO
    {
        #region Constructors
  
        public ProductVariantAttributeCombinationTemplateDTO() {
        }

        public ProductVariantAttributeCombinationTemplateDTO(global::System.Guid productVariantAttributeCombinationTemplateID, global::System.Guid productTemplateID, bool allowOutOfStockOrders, int stockQuantity, string sku, string manufacturerPartNumber, string gtin, decimal overriddenPrice, bool isActive, bool isDeleted, int productVersionID, ProductTemplateDTO productTemplate) {

          this.ProductVariantAttributeCombinationTemplateID = productVariantAttributeCombinationTemplateID;
          this.ProductTemplateID = productTemplateID;
          this.AllowOutOfStockOrders = allowOutOfStockOrders;
          this.StockQuantity = stockQuantity;
          this.Sku = sku;
          this.ManufacturerPartNumber = manufacturerPartNumber;
          this.Gtin = gtin;
          this.OverriddenPrice = overriddenPrice;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVersionID = productVersionID;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductVariantAttributeCombinationTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public bool AllowOutOfStockOrders { get; set; }

        [DataMember]
        public int StockQuantity { get; set; }

        [DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string ManufacturerPartNumber { get; set; }

        [DataMember]
        public string Gtin { get; set; }

        [DataMember]
        public decimal OverriddenPrice { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
