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
    public partial class InterfacePanelFDOrganisationTypeUserTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelFDOrganisationTypeUserTypeTemplateDTO() {
        }

        public InterfacePanelFDOrganisationTypeUserTypeTemplateDTO(global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, global::System.Guid fieldDetailTemplateID, int organisationTypeID, global::System.Guid userTypeID, bool isVisible, bool isActive, bool isDeleted, bool isMandatory, bool isFilterable, string overrideDefaultValue, string overrideToolTipValue, string overrideToolTipHTML, global::System.Nullable<bool> overrideToolTipIsHTML, string overrideInformationValue, string overrideInformationHTML, global::System.Nullable<bool> overrideInformationIsHTML, string overrideHelpValue, string overrideHelpHTML, global::System.Nullable<bool> overrideHelpIsHTML, string overrideFieldLabelValue, OrganisationTypeDTO organisationType, FieldDetailTemplateDTO fieldDetailTemplate, InterfacePanelTemplateDTO interfacePanelTemplate, UserTypeDTO userType) {

          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.FieldDetailTemplateID = fieldDetailTemplateID;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
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
          this.OrganisationType = organisationType;
          this.FieldDetailTemplate = fieldDetailTemplate;
          this.InterfacePanelTemplate = interfacePanelTemplate;
          this.UserType = userType;
        }

        #endregion

        #region Properties

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
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public FieldDetailTemplateDTO FieldDetailTemplate { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        #endregion
    }

}
