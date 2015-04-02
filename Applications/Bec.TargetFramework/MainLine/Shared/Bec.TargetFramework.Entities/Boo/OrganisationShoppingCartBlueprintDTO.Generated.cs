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
    public partial class OrganisationShoppingCartBlueprintDTO
    {
        #region Constructors
  
        public OrganisationShoppingCartBlueprintDTO() {
        }

        public OrganisationShoppingCartBlueprintDTO(global::System.Nullable<System.Guid> organisationID, global::System.Nullable<System.Guid> shoppingCartBlueprintID, bool isActive, bool isDeleted, ShoppingCartBlueprintDTO shoppingCartBlueprint, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.ShoppingCartBlueprintID = shoppingCartBlueprintID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ShoppingCartBlueprint = shoppingCartBlueprint;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ShoppingCartBlueprintID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ShoppingCartBlueprintDTO ShoppingCartBlueprint { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
