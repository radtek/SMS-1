﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class InterfacePanelFieldDetailValidationOrganisationTypeDTO
    {
        #region Constructors
  
        public InterfacePanelFieldDetailValidationOrganisationTypeDTO() {
        }

        public InterfacePanelFieldDetailValidationOrganisationTypeDTO(global::System.Guid interfacePanelFieldDetailValidationOrganisationTypeID, int interfacePanelFieldDetailValidationOrganisationTypeVersion, global::System.Guid interfacePanelID, int interfacePanelVersionNumber, global::System.Guid fieldDetailID, int organisationTypeID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, string interfacePanelFieldDetailValidationOrganisationTypeName, global::System.Nullable<bool> isDeleted, InterfacePanelDTO interfacePanel) {

          this.InterfacePanelFieldDetailValidationOrganisationTypeID = interfacePanelFieldDetailValidationOrganisationTypeID;
          this.InterfacePanelFieldDetailValidationOrganisationTypeVersion = interfacePanelFieldDetailValidationOrganisationTypeVersion;
          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.FieldDetailID = fieldDetailID;
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
          this.InterfacePanelFieldDetailValidationOrganisationTypeName = interfacePanelFieldDetailValidationOrganisationTypeName;
          this.IsDeleted = isDeleted;
          this.InterfacePanel = interfacePanel;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelFieldDetailValidationOrganisationTypeID { get; set; }

        [DataMember]
        public int InterfacePanelFieldDetailValidationOrganisationTypeVersion { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailID { get; set; }

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
        public string InterfacePanelFieldDetailValidationOrganisationTypeName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

        #endregion
    }

}
