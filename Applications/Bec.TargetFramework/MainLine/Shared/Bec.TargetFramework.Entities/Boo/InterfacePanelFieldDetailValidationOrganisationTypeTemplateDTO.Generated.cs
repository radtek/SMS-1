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
    public partial class InterfacePanelFieldDetailValidationOrganisationTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelFieldDetailValidationOrganisationTypeTemplateDTO() {
        }

        public InterfacePanelFieldDetailValidationOrganisationTypeTemplateDTO(global::System.Guid interfacePanelFieldDetailValidationOrganisationTypeTemplateID, int interfacePanelFieldDetailValidationOrganisationTypeTemplateVers, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, global::System.Guid fieldDetailTemplateID, int organisationTypeID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, string interfacePanelFieldDetailValidationOrganisationTypeTemplateName, global::System.Nullable<bool> isDeleted, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelFieldDetailValidationOrganisationTypeTemplateID = interfacePanelFieldDetailValidationOrganisationTypeTemplateID;
          this.InterfacePanelFieldDetailValidationOrganisationTypeTemplateVers = interfacePanelFieldDetailValidationOrganisationTypeTemplateVers;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.FieldDetailTemplateID = fieldDetailTemplateID;
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
          this.InterfacePanelFieldDetailValidationOrganisationTypeTemplateName = interfacePanelFieldDetailValidationOrganisationTypeTemplateName;
          this.IsDeleted = isDeleted;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelFieldDetailValidationOrganisationTypeTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelFieldDetailValidationOrganisationTypeTemplateVers { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailTemplateID { get; set; }

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
        public string InterfacePanelFieldDetailValidationOrganisationTypeTemplateName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
