﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class InterfacePanelFieldDetailValidationTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelFieldDetailValidationTemplateDTO() {
        }

        public InterfacePanelFieldDetailValidationTemplateDTO(global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, int interfacePanelFieldDetailValidationTemplateVersion, global::System.Guid fieldDetailTemplateID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, global::System.Guid interfacePanelFieldDetailValidationTemplateID, global::System.Nullable<int> validationSubCategory, string interfacePanelFieldDetailValidationTemplateName, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.InterfacePanelFieldDetailValidationTemplateVersion = interfacePanelFieldDetailValidationTemplateVersion;
          this.FieldDetailTemplateID = fieldDetailTemplateID;
          this.OverrideValidationMessage = overrideValidationMessage;
          this.OverrideValidationMessageHTML = overrideValidationMessageHTML;
          this.OverrideValidationIsHTML = overrideValidationIsHTML;
          this.ValidationType = validationType;
          this.ValidationSubType = validationSubType;
          this.ValidationCategory = validationCategory;
          this.SourceErrorCodes = sourceErrorCodes;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InterfacePanelFieldDetailValidationTemplateID = interfacePanelFieldDetailValidationTemplateID;
          this.ValidationSubCategory = validationSubCategory;
          this.InterfacePanelFieldDetailValidationTemplateName = interfacePanelFieldDetailValidationTemplateName;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public int InterfacePanelFieldDetailValidationTemplateVersion { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailTemplateID { get; set; }

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
        public string SourceErrorCodes { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelFieldDetailValidationTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ValidationSubCategory { get; set; }

        [DataMember]
        public string InterfacePanelFieldDetailValidationTemplateName { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
