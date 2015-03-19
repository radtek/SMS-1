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
    public partial class InterfacePanelOrganisationTypeUserTypeTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelOrganisationTypeUserTypeTemplateDTO() {
        }

        public InterfacePanelOrganisationTypeUserTypeTemplateDTO(global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, int organisationTypeID, global::System.Guid userTypeID, bool isActive, bool isDeleted, bool isVisible, global::System.Nullable<System.Guid> parentID, string interfacePanelOrganisationTypeUserTypeTemplateLabel, OrganisationTypeDTO organisationType, InterfacePanelTemplateDTO interfacePanelTemplate, UserTypeDTO userType) {

          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsVisible = isVisible;
          this.ParentID = parentID;
          this.InterfacePanelOrganisationTypeUserTypeTemplateLabel = interfacePanelOrganisationTypeUserTypeTemplateLabel;
          this.OrganisationType = organisationType;
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
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public string InterfacePanelOrganisationTypeUserTypeTemplateLabel { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        #endregion
    }

}
