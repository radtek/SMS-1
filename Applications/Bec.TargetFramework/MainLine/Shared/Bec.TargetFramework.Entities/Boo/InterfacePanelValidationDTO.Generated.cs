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
    public partial class InterfacePanelValidationDTO
    {
        #region Constructors
  
        public InterfacePanelValidationDTO() {
        }

        public InterfacePanelValidationDTO(global::System.Guid interfacePanelValidationID, global::System.Guid interfacePanelID, int interfacePanelVersionNumber, global::System.Nullable<int> interfacePanelValidationVersionNumber, string overrideValidationMessage, string overrideValidationMessageHTML, global::System.Nullable<int> validationType, global::System.Nullable<int> validationSubType, global::System.Nullable<int> validationCategory, global::System.Nullable<int> validationSubCategory, string sourceErrorCodes, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, global::System.Nullable<bool> overrideValidationIsHTML, string interfacePanelValidationName, InterfacePanelDTO interfacePanel) {

          this.InterfacePanelValidationID = interfacePanelValidationID;
          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.InterfacePanelValidationVersionNumber = interfacePanelValidationVersionNumber;
          this.OverrideValidationMessage = overrideValidationMessage;
          this.OverrideValidationMessageHTML = overrideValidationMessageHTML;
          this.ValidationType = validationType;
          this.ValidationSubType = validationSubType;
          this.ValidationCategory = validationCategory;
          this.ValidationSubCategory = validationSubCategory;
          this.SourceErrorCodes = sourceErrorCodes;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OverrideValidationIsHTML = overrideValidationIsHTML;
          this.InterfacePanelValidationName = interfacePanelValidationName;
          this.InterfacePanel = interfacePanel;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelValidationID { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> InterfacePanelValidationVersionNumber { get; set; }

        [DataMember]
        public string OverrideValidationMessage { get; set; }

        [DataMember]
        public string OverrideValidationMessageHTML { get; set; }

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
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OverrideValidationIsHTML { get; set; }

        [DataMember]
        public string InterfacePanelValidationName { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

        #endregion
    }

}
