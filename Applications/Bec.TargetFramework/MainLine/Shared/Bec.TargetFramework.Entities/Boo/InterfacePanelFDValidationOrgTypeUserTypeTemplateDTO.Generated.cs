﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class InterfacePanelFDValidationOrgTypeUserTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelFDValidationOrgTypeUserTypeTemplateDTO() {
        }

        public InterfacePanelFDValidationOrgTypeUserTypeTemplateDTO(global::System.Guid interfacePanelFDValidationOrgTypeUserTypeTemplateID, int interfacePanelFDValidationOrgTypeUserTypeTemplateVersion, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, global::System.Guid fieldDetailTemplateID, int organisationTypeID, global::System.Guid userTypeID, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<bool> overrideValidationIsHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, string interfacePanelFDValidationOrgTypeUserTypeTemplateName, global::System.Nullable<bool> isDeleted, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelFDValidationOrgTypeUserTypeTemplateID = interfacePanelFDValidationOrgTypeUserTypeTemplateID;
          this.InterfacePanelFDValidationOrgTypeUserTypeTemplateVersion = interfacePanelFDValidationOrgTypeUserTypeTemplateVersion;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.FieldDetailTemplateID = fieldDetailTemplateID;
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
          this.InterfacePanelFDValidationOrgTypeUserTypeTemplateName = interfacePanelFDValidationOrgTypeUserTypeTemplateName;
          this.IsDeleted = isDeleted;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelFDValidationOrgTypeUserTypeTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelFDValidationOrgTypeUserTypeTemplateVersion { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailTemplateID { get; set; }

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
        public string InterfacePanelFDValidationOrgTypeUserTypeTemplateName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
