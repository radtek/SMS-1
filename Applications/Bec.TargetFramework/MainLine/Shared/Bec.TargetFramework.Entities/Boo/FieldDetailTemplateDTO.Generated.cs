﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class FieldDetailTemplateDTO
    {
        #region Constructors
  
        public FieldDetailTemplateDTO() {
        }

        public FieldDetailTemplateDTO(global::System.Guid fieldDetailTemplateID, string name, string description, string fieldLabelValue, string defaultValue, bool isActive, bool isDeleted, string toolTipValue, string toolTipHTML, bool toolTipIsHTML, string informationValue, string informationHTML, bool informationIsHTML, string helpValue, string helpHTML, bool helpIsHTML, bool isSecuredByClaim, bool isGlobal, global::System.Nullable<int> fieldTypeID, global::System.Nullable<int> iconAlignmentTypeID, string iconFileName, global::System.Nullable<bool> isGridColumn, string fieldMask, List<InterfacePanelFieldDetailOrganisationTypeTemplateDTO> interfacePanelFieldDetailOrganaisationTypeTemplates, List<InterfacePanelFieldDetailTemplateDTO> interfacePanelFieldDetailTemplates, List<FieldDetailDTO> fieldDetails, List<InterfacePanelFDOrganisationTypeUserTypeTemplateDTO> interfacePanelFDOrganaisationTypeUserTypeTemplates) {

          this.FieldDetailTemplateID = fieldDetailTemplateID;
          this.Name = name;
          this.Description = description;
          this.FieldLabelValue = fieldLabelValue;
          this.DefaultValue = defaultValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ToolTipValue = toolTipValue;
          this.ToolTipHTML = toolTipHTML;
          this.ToolTipIsHTML = toolTipIsHTML;
          this.InformationValue = informationValue;
          this.InformationHTML = informationHTML;
          this.InformationIsHTML = informationIsHTML;
          this.HelpValue = helpValue;
          this.HelpHTML = helpHTML;
          this.HelpIsHTML = helpIsHTML;
          this.IsSecuredByClaim = isSecuredByClaim;
          this.IsGlobal = isGlobal;
          this.FieldTypeID = fieldTypeID;
          this.IconAlignmentTypeID = iconAlignmentTypeID;
          this.IconFileName = iconFileName;
          this.IsGridColumn = isGridColumn;
          this.FieldMask = fieldMask;
          this.InterfacePanelFieldDetailOrganaisationTypeTemplates = interfacePanelFieldDetailOrganaisationTypeTemplates;
          this.InterfacePanelFieldDetailTemplates = interfacePanelFieldDetailTemplates;
          this.FieldDetails = fieldDetails;
          this.InterfacePanelFDOrganaisationTypeUserTypeTemplates = interfacePanelFDOrganaisationTypeUserTypeTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid FieldDetailTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string FieldLabelValue { get; set; }

        [DataMember]
        public string DefaultValue { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string ToolTipValue { get; set; }

        [DataMember]
        public string ToolTipHTML { get; set; }

        [DataMember]
        public bool ToolTipIsHTML { get; set; }

        [DataMember]
        public string InformationValue { get; set; }

        [DataMember]
        public string InformationHTML { get; set; }

        [DataMember]
        public bool InformationIsHTML { get; set; }

        [DataMember]
        public string HelpValue { get; set; }

        [DataMember]
        public string HelpHTML { get; set; }

        [DataMember]
        public bool HelpIsHTML { get; set; }

        [DataMember]
        public bool IsSecuredByClaim { get; set; }

        [DataMember]
        public bool IsGlobal { get; set; }

        [DataMember]
        public global::System.Nullable<int> FieldTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> IconAlignmentTypeID { get; set; }

        [DataMember]
        public string IconFileName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsGridColumn { get; set; }

        [DataMember]
        public string FieldMask { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InterfacePanelFieldDetailOrganisationTypeTemplateDTO> InterfacePanelFieldDetailOrganaisationTypeTemplates { get; set; }

        [DataMember]
        public List<InterfacePanelFieldDetailTemplateDTO> InterfacePanelFieldDetailTemplates { get; set; }

        [DataMember]
        public List<FieldDetailDTO> FieldDetails { get; set; }

        [DataMember]
        public List<InterfacePanelFDOrganisationTypeUserTypeTemplateDTO> InterfacePanelFDOrganaisationTypeUserTypeTemplates { get; set; }

        #endregion
    }

}
