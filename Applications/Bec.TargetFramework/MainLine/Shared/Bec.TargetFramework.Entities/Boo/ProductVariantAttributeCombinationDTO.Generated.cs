﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class ProductVariantAttributeCombinationDTO
    {
        #region Constructors
  
        public ProductVariantAttributeCombinationDTO() {
        }

        public ProductVariantAttributeCombinationDTO(global::System.Guid productVariantAttributeCombinationID, global::System.Guid productID, bool allowOutOfStockOrders, int stockQuantity, string sku, string manufacturerPartNumber, string gtin, decimal overridenPrice, bool isActive, bool isDeleted, int productVersionID, ProductDTO product) {

          this.ProductVariantAttributeCombinationID = productVariantAttributeCombinationID;
          this.ProductID = productID;
          this.AllowOutOfStockOrders = allowOutOfStockOrders;
          this.StockQuantity = stockQuantity;
          this.Sku = sku;
          this.ManufacturerPartNumber = manufacturerPartNumber;
          this.Gtin = gtin;
          this.OverridenPrice = overridenPrice;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVersionID = productVersionID;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductVariantAttributeCombinationID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

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
        public decimal OverridenPrice { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
