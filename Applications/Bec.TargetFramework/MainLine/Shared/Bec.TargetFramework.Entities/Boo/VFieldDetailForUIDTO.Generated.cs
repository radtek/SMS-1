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
    public partial class VFieldDetailForUIDTO
    {
        #region Constructors
  
        public VFieldDetailForUIDTO() {
        }

        public VFieldDetailForUIDTO(string interfacePanelName, global::System.Guid fieldDetailID, string name, string description, string overrideFieldLabelValue, string overrideDefaultValue, bool isActive, bool isDeleted, string overrideToolTipValue, string overrideToolTipHTML, global::System.Nullable<bool> overrideToolTipIsHTML, string overrideInformationValue, string overrideInformationHTML, global::System.Nullable<bool> overrideInformationIsHTML, string overrideHelpValue, string overrideHelpHTML, global::System.Nullable<bool> overrideHelpIsHTML, bool isSecuredByClaim, bool isGlobal, global::System.Guid fieldDetailTemplateID, global::System.Nullable<int> fieldTypeID, string iconAlignment, string iconFileName, global::System.Nullable<bool> isGridColumn, string fieldMask, bool isVisible, bool isMandatory, bool isFilterable, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, global::System.Guid iD) {

          this.InterfacePanelName = interfacePanelName;
          this.FieldDetailID = fieldDetailID;
          this.Name = name;
          this.Description = description;
          this.OverrideFieldLabelValue = overrideFieldLabelValue;
          this.OverrideDefaultValue = overrideDefaultValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OverrideToolTipValue = overrideToolTipValue;
          this.OverrideToolTipHTML = overrideToolTipHTML;
          this.OverrideToolTipIsHTML = overrideToolTipIsHTML;
          this.OverrideInformationValue = overrideInformationValue;
          this.OverrideInformationHTML = overrideInformationHTML;
          this.OverrideInformationIsHTML = overrideInformationIsHTML;
          this.OverrideHelpValue = overrideHelpValue;
          this.OverrideHelpHTML = overrideHelpHTML;
          this.OverrideHelpIsHTML = overrideHelpIsHTML;
          this.IsSecuredByClaim = isSecuredByClaim;
          this.IsGlobal = isGlobal;
          this.FieldDetailTemplateID = fieldDetailTemplateID;
          this.FieldTypeID = fieldTypeID;
          this.IconAlignment = iconAlignment;
          this.IconFileName = iconFileName;
          this.IsGridColumn = isGridColumn;
          this.FieldMask = fieldMask;
          this.IsVisible = isVisible;
          this.IsMandatory = isMandatory;
          this.IsFilterable = isFilterable;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.ID = iD;
        }

        #endregion

        #region Properties

        [DataMember]
        public string InterfacePanelName { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string OverrideFieldLabelValue { get; set; }

        [DataMember]
        public string OverrideDefaultValue { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

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
        public bool IsSecuredByClaim { get; set; }

        [DataMember]
        public bool IsGlobal { get; set; }

        [DataMember]
        public global::System.Guid FieldDetailTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> FieldTypeID { get; set; }

        [DataMember]
        public string IconAlignment { get; set; }

        [DataMember]
        public string IconFileName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsGridColumn { get; set; }

        [DataMember]
        public string FieldMask { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsFilterable { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public global::System.Guid ID { get; set; }

        #endregion
    }

}
