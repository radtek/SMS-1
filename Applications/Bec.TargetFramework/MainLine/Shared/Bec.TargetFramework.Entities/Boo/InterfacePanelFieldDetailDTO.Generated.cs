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
    public partial class InterfacePanelFieldDetailDTO
    {
        #region Constructors
  
        public InterfacePanelFieldDetailDTO() {
        }

        public InterfacePanelFieldDetailDTO(global::System.Guid interfacePanelID, int interfacePanelVersionNumber, global::System.Guid fieldDetailID, bool isVisible, bool isActive, bool isDeleted, bool isMandatory, bool isFilterable, string overrideDefaultValue, string overrideToolTipValue, string overrideToolTipHTML, global::System.Nullable<bool> overrideToolTipIsHTML, string overrideInformationValue, string overrideInformationHTML, global::System.Nullable<bool> overrideInformationIsHTML, string overrideHelpValue, string overrideHelpHTML, global::System.Nullable<bool> overrideHelpIsHTML, string overrideFieldLabelValue, FieldDetailDTO fieldDetail, InterfacePanelDTO interfacePanel) {

          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.FieldDetailID = fieldDetailID;
          this.IsVisible = isVisible;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsMandatory = isMandatory;
          this.IsFilterable = isFilterable;
          this.OverrideDefaultValue = overrideDefaultValue;
          this.OverrideToolTipValue = overrideToolTipValue;
          this.OverrideToolTipHTML = overrideToolTipHTML;
          this.OverrideToolTipIsHTML = overrideToolTipIsHTML;
          this.OverrideInformationValue = overrideInformationValue;
          this.OverrideInformationHTML = overrideInformationHTML;
          this.OverrideInformationIsHTML = overrideInformationIsHTML;
          this.OverrideHelpValue = overrideHelpValue;
          this.OverrideHelpHTML = overrideHelpHTML;
          this.OverrideHelpIsHTML = overrideHelpIsHTML;
          this.OverrideFieldLabelValue = overrideFieldLabelValue;
          this.FieldDetail = fieldDetail;
          this.InterfacePanel = interfacePanel;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailID { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsFilterable { get; set; }

        [DataMember]
        public string OverrideDefaultValue { get; set; }

        [DataMember]
        public string OverrideToolTipValue { get; set; }

        [DataMember]
        public string OverrideToolTipHTML { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OverrideToolTipIsHTML { get; set; }

        [DataMember]
        public string OverrideInformationValue { get; set; }

        [DataMember]
        public string OverrideInformationHTML { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OverrideInformationIsHTML { get; set; }

        [DataMember]
        public string OverrideHelpValue { get; set; }

        [DataMember]
        public string OverrideHelpHTML { get; set; }

        [DataMember]
        public global::System.Nullable<bool> OverrideHelpIsHTML { get; set; }

        [DataMember]
        public string OverrideFieldLabelValue { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public FieldDetailDTO FieldDetail { get; set; }

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

        #endregion
    }

}
