﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class InterfacePanelValidationOrganisationTypeDTO
    {
        #region Constructors
  
        public InterfacePanelValidationOrganisationTypeDTO() {
        }

        public InterfacePanelValidationOrganisationTypeDTO(global::System.Guid interfacePanelValidationOrganisationTypeID, int interfacePanelValidationOrganisationTypeVersion, global::System.Guid interfacePanelID, int interfacePanelVersionNumber, int organisationTypeID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, string interfacePanelValidationOrganisationTypeName, global::System.Nullable<bool> isDeleted, InterfacePanelDTO interfacePanel) {

          this.InterfacePanelValidationOrganisationTypeID = interfacePanelValidationOrganisationTypeID;
          this.InterfacePanelValidationOrganisationTypeVersion = interfacePanelValidationOrganisationTypeVersion;
          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.OverrideValidationMessage = overrideValidationMessage;
          this.OverrideValidationMessageHTML = overrideValidationMessageHTML;
          this.OverrideValidationIsHTML = overrideValidationIsHTML;
          this.ValidationType = validationType;
          this.ValidationSubType = validationSubType;
          this.ValidationCategory = validationCategory;
          this.ValidationSubCategory = validationSubCategory;
          this.SourceErrorCodes = sourceErrorCodes;
          this.IsActive = isActive;
          this.InterfacePanelValidationOrganisationTypeName = interfacePanelValidationOrganisationTypeName;
          this.IsDeleted = isDeleted;
          this.InterfacePanel = interfacePanel;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelValidationOrganisationTypeID { get; set; }

        [DataMember]
        public int InterfacePanelValidationOrganisationTypeVersion { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public string OverrideValidationMessage { get; set; }

        [DataMember]
        public string OverrideValidationMessageHTML { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OverrideValidationIsHTML { get; set; }

        [DataMember]
        public global::System.Nullable<int> ValidationType { get; set; }

        [DataMember]
        public global::System.Nullable<int> ValidationSubType { get; set; }

        [DataMember]
        public global::System.Nullable<int> ValidationCategory { get; set; }

        [DataMember]
        public global::System.Nullable<int> ValidationSubCategory { get; set; }

        [DataMember]
        public string SourceErrorCodes { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public string InterfacePanelValidationOrganisationTypeName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

        #endregion
    }

}
