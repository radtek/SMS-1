﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class ShoppingCartBlueprintProductDTO
    {
        #region Constructors
  
        public ShoppingCartBlueprintProductDTO() {
        }

        public ShoppingCartBlueprintProductDTO(global::System.Guid shoppingCartBlueprintID, global::System.Guid productID, int productVersionID, int quantity, bool isActive, bool isDeleted, ProductDTO product, ShoppingCartBlueprintDTO shoppingCartBlueprint) {

          this.ShoppingCartBlueprintID = shoppingCartBlueprintID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.Quantity = quantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Product = product;
          this.ShoppingCartBlueprint = shoppingCartBlueprint;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartBlueprintID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public ShoppingCartBlueprintDTO ShoppingCartBlueprint { get; set; }

        #endregion
    }

}
