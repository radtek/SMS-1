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
    public partial class DefaultOrganisationShoppingCartBlueprintTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationShoppingCartBlueprintTemplateDTO() {
        }

        public DefaultOrganisationShoppingCartBlueprintTemplateDTO(global::System.Guid defaultOrganisationTemplateID, int defaultOrganisationTemplateVersionNumber, global::System.Guid shoppingCartBlueprintTemplateID, bool isActive, bool isDeleted, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, ShoppingCartBlueprintTemplateDTO shoppingCartBlueprintTemplate) {

          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.ShoppingCartBlueprintTemplateID = shoppingCartBlueprintTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.ShoppingCartBlueprintTemplate = shoppingCartBlueprintTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ShoppingCartBlueprintTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public ShoppingCartBlueprintTemplateDTO ShoppingCartBlueprintTemplate { get; set; }

        #endregion
    }

}
