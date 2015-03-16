﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class InterfacePanelOrganisationTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelOrganisationTypeTemplateDTO() {
        }

        public InterfacePanelOrganisationTypeTemplateDTO(global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, int organisationTypeID, bool isActive, bool isDeleted, bool isVisible, global::System.Nullable<System.Guid> parentID, string interfacePanelOrganisationTypeTemplateLabel, OrganisationTypeDTO organisationType, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsVisible = isVisible;
          this.ParentID = parentID;
          this.InterfacePanelOrganisationTypeTemplateLabel = interfacePanelOrganisationTypeTemplateLabel;
          this.OrganisationType = organisationType;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public string InterfacePanelOrganisationTypeTemplateLabel { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
