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
    public partial class ShoppingCartBlueprintDTO
    {
        #region Constructors
  
        public ShoppingCartBlueprintDTO() {
        }

        public ShoppingCartBlueprintDTO(global::System.Guid shoppingCartBlueprintID, global::System.Nullable<System.Guid> parentID, bool isActive, bool isDeleted, string name, List<ShoppingCartBlueprintProductDTO> shoppingCartBlueprintProducts, List<DefaultOrganisationShoppingCartBlueprintDTO> defaultOrganisationShoppingCartBlueprints, List<OrganisationShoppingCartBlueprintDTO> organisationShoppingCartBlueprints) {

          this.ShoppingCartBlueprintID = shoppingCartBlueprintID;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Name = name;
          this.ShoppingCartBlueprintProducts = shoppingCartBlueprintProducts;
          this.DefaultOrganisationShoppingCartBlueprints = defaultOrganisationShoppingCartBlueprints;
          this.OrganisationShoppingCartBlueprints = organisationShoppingCartBlueprints;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartBlueprintID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ShoppingCartBlueprintProductDTO> ShoppingCartBlueprintProducts { get; set; }

        [DataMember]
        public List<DefaultOrganisationShoppingCartBlueprintDTO> DefaultOrganisationShoppingCartBlueprints { get; set; }

        [DataMember]
        public List<OrganisationShoppingCartBlueprintDTO> OrganisationShoppingCartBlueprints { get; set; }

        #endregion
    }

}