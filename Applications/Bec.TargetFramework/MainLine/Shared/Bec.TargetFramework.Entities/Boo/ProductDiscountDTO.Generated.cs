﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class ProductDiscountDTO
    {
        #region Constructors
  
        public ProductDiscountDTO() {
        }

        public ProductDiscountDTO(global::System.Guid productID, int productVersionID, global::System.Guid discountID, int discountVersionNumber, bool isActive, bool isDeleted, DiscountDTO discount, ProductDTO product) {

          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.DiscountID = discountID;
          this.DiscountVersionNumber = discountVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Discount = discount;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid DiscountID { get; set; }

        [DataMember]
        public int DiscountVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DiscountDTO Discount { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
