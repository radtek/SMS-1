﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class ShoppingCartBlueprintProductTemplateDTO
    {
        #region Constructors
  
        public ShoppingCartBlueprintProductTemplateDTO() {
        }

        public ShoppingCartBlueprintProductTemplateDTO(global::System.Guid shoppingCartBlueprintTemplateID, global::System.Guid productTemplateID, int productVersionID, int quantity, bool isActive, bool isDeleted, ProductTemplateDTO productTemplate, ShoppingCartBlueprintTemplateDTO shoppingCartBlueprintTemplate) {

          this.ShoppingCartBlueprintTemplateID = shoppingCartBlueprintTemplateID;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.Quantity = quantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductTemplate = productTemplate;
          this.ShoppingCartBlueprintTemplate = shoppingCartBlueprintTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartBlueprintTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

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
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public ShoppingCartBlueprintTemplateDTO ShoppingCartBlueprintTemplate { get; set; }

        #endregion
    }

}
