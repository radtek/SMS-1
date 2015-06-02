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
    public partial class InterfacePanelTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelTemplateDTO() {
        }

        public InterfacePanelTemplateDTO(global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, string name, string description, global::System.Nullable<int> interfacePanelTypeID, global::System.Nullable<int> interfacePanelSubTypeID, global::System.Nullable<int> interfacePanelCategoryID, global::System.Nullable<int> interfacePanelSubCategoryID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentIPTemplateID, global::System.Nullable<int> parentIPTemplateVersionNumber, bool isSecuredByClaim, bool isGridPanel, bool isGlobal, string interfacePanelTemplateLabel, List<InterfacePanelTemplateDTO> interfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber, InterfacePanelTemplateDTO interfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber) {

          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.InterfacePanelTypeID = interfacePanelTypeID;
          this.InterfacePanelSubTypeID = interfacePanelSubTypeID;
          this.InterfacePanelCategoryID = interfacePanelCategoryID;
          this.InterfacePanelSubCategoryID = interfacePanelSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentIPTemplateID = parentIPTemplateID;
          this.ParentIPTemplateVersionNumber = parentIPTemplateVersionNumber;
          this.IsSecuredByClaim = isSecuredByClaim;
          this.IsGridPanel = isGridPanel;
          this.IsGlobal = isGlobal;
          this.InterfacePanelTemplateLabel = interfacePanelTemplateLabel;
          this.InterfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber = interfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber;
          this.InterfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber = interfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

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
        public global::System.Nullable<System.Guid> ParentIPTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ParentIPTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsSecuredByClaim { get; set; }

        [DataMember]
        public bool IsGridPanel { get; set; }

        [DataMember]
        public bool IsGlobal { get; set; }

        [DataMember]
        public string InterfacePanelTemplateLabel { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InterfacePanelTemplateDTO> InterfacePanelTemplates_ParentIPTemplateID_ParentIPTemplateVersionNumber { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate_ParentIPTemplateID_ParentIPTemplateVersionNumber { get; set; }

        #endregion
    }

}
