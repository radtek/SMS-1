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
    public partial class ShoppingCartBlueprintTemplateDTO
    {
        #region Constructors
  
        public ShoppingCartBlueprintTemplateDTO() {
        }

        public ShoppingCartBlueprintTemplateDTO(global::System.Guid shoppingCartBlueprintTemplateID, global::System.Nullable<System.Guid> parentID, bool isActive, bool isDeleted, string name, List<DefaultOrganisationShoppingCartBlueprintTemplateDTO> defaultOrganisationShoppingCartBlueprintTemplates, List<ShoppingCartBlueprintProductTemplateDTO> shoppingCartBlueprintProductTemplates) {

          this.ShoppingCartBlueprintTemplateID = shoppingCartBlueprintTemplateID;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Name = name;
          this.DefaultOrganisationShoppingCartBlueprintTemplates = defaultOrganisationShoppingCartBlueprintTemplates;
          this.ShoppingCartBlueprintProductTemplates = shoppingCartBlueprintProductTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ShoppingCartBlueprintTemplateID { get; set; }

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
        public List<DefaultOrganisationShoppingCartBlueprintTemplateDTO> DefaultOrganisationShoppingCartBlueprintTemplates { get; set; }

        [DataMember]
        public List<ShoppingCartBlueprintProductTemplateDTO> ShoppingCartBlueprintProductTemplates { get; set; }

        #endregion
    }

}
