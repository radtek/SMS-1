﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO() {
        }

        public InterfacePanelValidationOrganisationTypeUserTypeTemplateDTO(global::System.Guid interfacePanelValidationOrganisationTypeUserTypeTemplateID, int interfacePanelValidationOrganisationTypeUserTypeTemplateVersion, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, int organisationTypeID, global::System.Guid userTypeID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, string interfacePanelValidationOrganisationTypeUserTypeTemplateName, global::System.Nullable<bool> isDeleted, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelValidationOrganisationTypeUserTypeTemplateID = interfacePanelValidationOrganisationTypeUserTypeTemplateID;
          this.InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion = interfacePanelValidationOrganisationTypeUserTypeTemplateVersion;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.OverrideValidationMessage = overrideValidationMessage;
          this.OverrideValidationMessageHTML = overrideValidationMessageHTML;
          this.OverrideValidationIsHTML = overrideValidationIsHTML;
          this.ValidationType = validationType;
          this.ValidationSubType = validationSubType;
          this.ValidationCategory = validationCategory;
          this.ValidationSubCategory = validationSubCategory;
          this.SourceErrorCodes = sourceErrorCodes;
          this.IsActive = isActive;
          this.InterfacePanelValidationOrganisationTypeUserTypeTemplateName = interfacePanelValidationOrganisationTypeUserTypeTemplateName;
          this.IsDeleted = isDeleted;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelValidationOrganisationTypeUserTypeTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelValidationOrganisationTypeUserTypeTemplateVersion { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

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
        public string InterfacePanelValidationOrganisationTypeUserTypeTemplateName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
