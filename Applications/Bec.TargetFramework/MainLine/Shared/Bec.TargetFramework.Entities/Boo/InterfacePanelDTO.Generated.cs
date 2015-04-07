﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class InterfacePanelDTO
    {
        #region Constructors
  
        public InterfacePanelDTO() {
        }

        public InterfacePanelDTO(global::System.Guid interfacePanelID, int interfacePanelVersionNumber, string name, string description, global::System.Nullable<int> interfacePanelTypeID, global::System.Nullable<int> interfacePanelSubTypeID, global::System.Nullable<int> interfacePanelCategoryID, global::System.Nullable<int> interfacePanelSubCategoryID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentIPID, global::System.Nullable<int> parentIPVersionNumber, bool isSecuredByClaim, bool isGridPanel, bool isGlobal, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, string interfacePanelLabel, List<InterfacePanelClaimDTO> interfacePanelClaims, List<InterfacePanelFieldDetailOrganisationTypeDTO> interfacePanelFieldDetailOrganisationTypes, List<InterfacePanelOrganisationTypeDTO> interfacePanelOrganisationTypes, List<InterfacePanelFDOrganisationTypeUserTypeDTO> interfacePanelFDOrganaisationTypeUserTypes, List<InterfacePanelOrganisationTypeUserTypeDTO> interfacePanelOrganisationTypeUserTypes, List<InterfacePanelFieldDetailDTO> interfacePanelFieldDetails, List<InterfacePanelDTO> interfacePanels_ParentIPID_ParentIPVersionNumber, InterfacePanelDTO interfacePanel_ParentIPID_ParentIPVersionNumber, InterfacePanelTemplateDTO interfacePanelTemplate, List<InterfacePanelRoleDTO> interfacePanelRoles, List<InterfacePanelSettingDTO> interfacePanelSettings, List<InterfacePanelValidationDTO> interfacePanelValidations, List<InterfacePanelValidationOrganisationTypeDTO> interfacePanelValidationOrganisationTypes, List<InterfacePanelValidationOrganisationTypeUserTypeDTO> interfacePanelValidationOrganisationTypeUserTypes, List<InterfacePanelFieldDetailValidationDTO> interfacePanelFieldDetailValidations, List<InterfacePanelFieldDetailValidationOrganisationTypeDTO> interfacePanelFieldDetailValidationOrganisationTypes, List<InterfacePanelFDValidationOrganisationTypeUserTypeDTO> interfacePanelFDValidationOrganisationTypeUserTypes) {

          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.Name = name;
          this.Description = description;
          this.InterfacePanelTypeID = interfacePanelTypeID;
          this.InterfacePanelSubTypeID = interfacePanelSubTypeID;
          this.InterfacePanelCategoryID = interfacePanelCategoryID;
          this.InterfacePanelSubCategoryID = interfacePanelSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentIPID = parentIPID;
          this.ParentIPVersionNumber = parentIPVersionNumber;
          this.IsSecuredByClaim = isSecuredByClaim;
          this.IsGridPanel = isGridPanel;
          this.IsGlobal = isGlobal;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.InterfacePanelLabel = interfacePanelLabel;
          this.InterfacePanelClaims = interfacePanelClaims;
          this.InterfacePanelFieldDetailOrganisationTypes = interfacePanelFieldDetailOrganisationTypes;
          this.InterfacePanelOrganisationTypes = interfacePanelOrganisationTypes;
          this.InterfacePanelFDOrganaisationTypeUserTypes = interfacePanelFDOrganaisationTypeUserTypes;
          this.InterfacePanelOrganisationTypeUserTypes = interfacePanelOrganisationTypeUserTypes;
          this.InterfacePanelFieldDetails = interfacePanelFieldDetails;
          this.InterfacePanels_ParentIPID_ParentIPVersionNumber = interfacePanels_ParentIPID_ParentIPVersionNumber;
          this.InterfacePanel_ParentIPID_ParentIPVersionNumber = interfacePanel_ParentIPID_ParentIPVersionNumber;
          this.InterfacePanelTemplate = interfacePanelTemplate;
          this.InterfacePanelRoles = interfacePanelRoles;
          this.InterfacePanelSettings = interfacePanelSettings;
          this.InterfacePanelValidations = interfacePanelValidations;
          this.InterfacePanelValidationOrganisationTypes = interfacePanelValidationOrganisationTypes;
          this.InterfacePanelValidationOrganisationTypeUserTypes = interfacePanelValidationOrganisationTypeUserTypes;
          this.InterfacePanelFieldDetailValidations = interfacePanelFieldDetailValidations;
          this.InterfacePanelFieldDetailValidationOrganisationTypes = interfacePanelFieldDetailValidationOrganisationTypes;
          this.InterfacePanelFDValidationOrganisationTypeUserTypes = interfacePanelFDValidationOrganisationTypeUserTypes;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<int> InterfacePanelTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InterfacePanelSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InterfacePanelCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InterfacePanelSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentIPID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ParentIPVersionNumber { get; set; }

        [DataMember]
        public bool IsSecuredByClaim { get; set; }

        [DataMember]
        public bool IsGridPanel { get; set; }

        [DataMember]
        public bool IsGlobal { get; set; }

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public string InterfacePanelLabel { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InterfacePanelClaimDTO> InterfacePanelClaims { get; set; }

        [DataMember]
        public List<InterfacePanelFieldDetailOrganisationTypeDTO> InterfacePanelFieldDetailOrganisationTypes { get; set; }

        [DataMember]
        public List<InterfacePanelOrganisationTypeDTO> InterfacePanelOrganisationTypes { get; set; }

        [DataMember]
        public List<InterfacePanelFDOrganisationTypeUserTypeDTO> InterfacePanelFDOrganaisationTypeUserTypes { get; set; }

        [DataMember]
        public List<InterfacePanelOrganisationTypeUserTypeDTO> InterfacePanelOrganisationTypeUserTypes { get; set; }

        [DataMember]
        public List<InterfacePanelFieldDetailDTO> InterfacePanelFieldDetails { get; set; }

        [DataMember]
        public List<InterfacePanelDTO> InterfacePanels_ParentIPID_ParentIPVersionNumber { get; set; }

        [DataMember]
        public InterfacePanelDTO InterfacePanel_ParentIPID_ParentIPVersionNumber { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        [DataMember]
        public List<InterfacePanelRoleDTO> InterfacePanelRoles { get; set; }

        [DataMember]
        public List<InterfacePanelSettingDTO> InterfacePanelSettings { get; set; }

        [DataMember]
        public List<InterfacePanelValidationDTO> InterfacePanelValidations { get; set; }

        [DataMember]
        public List<InterfacePanelValidationOrganisationTypeDTO> InterfacePanelValidationOrganisationTypes { get; set; }

        [DataMember]
        public List<InterfacePanelValidationOrganisationTypeUserTypeDTO> InterfacePanelValidationOrganisationTypeUserTypes { get; set; }

        [DataMember]
        public List<InterfacePanelFieldDetailValidationDTO> InterfacePanelFieldDetailValidations { get; set; }

        [DataMember]
        public List<InterfacePanelFieldDetailValidationOrganisationTypeDTO> InterfacePanelFieldDetailValidationOrganisationTypes { get; set; }

        [DataMember]
        public List<InterfacePanelFDValidationOrganisationTypeUserTypeDTO> InterfacePanelFDValidationOrganisationTypeUserTypes { get; set; }

        #endregion
    }

}
