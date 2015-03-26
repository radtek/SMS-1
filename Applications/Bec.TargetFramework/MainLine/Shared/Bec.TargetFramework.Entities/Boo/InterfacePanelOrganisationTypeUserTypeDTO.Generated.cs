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
    public partial class InterfacePanelOrganisationTypeUserTypeDTO
    {
        #region Constructors
  
        public InterfacePanelOrganisationTypeUserTypeDTO() {
        }

        public InterfacePanelOrganisationTypeUserTypeDTO(global::System.Guid interfacePanelID, int interfacePanelVersionNumber, int organisationTypeID, global::System.Guid userTypeID, bool isActive, bool isDeleted, bool isVisible, global::System.Nullable<System.Guid> parentID, string interfacePanelOrganisationTypeUserTypeLabel, OrganisationTypeDTO organisationType, InterfacePanelDTO interfacePanel, UserTypeDTO userType) {

          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsVisible = isVisible;
          this.ParentID = parentID;
          this.InterfacePanelOrganisationTypeUserTypeLabel = interfacePanelOrganisationTypeUserTypeLabel;
          this.OrganisationType = organisationType;
          this.InterfacePanel = interfacePanel;
          this.UserType = userType;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

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
        public string InterfacePanelOrganisationTypeUserTypeLabel { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        #endregion
    }

}
