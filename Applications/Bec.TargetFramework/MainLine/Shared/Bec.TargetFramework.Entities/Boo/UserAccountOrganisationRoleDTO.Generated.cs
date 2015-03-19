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
    public partial class UserAccountOrganisationRoleDTO
    {
        #region Constructors
  
        public UserAccountOrganisationRoleDTO() {
        }

        public UserAccountOrganisationRoleDTO(global::System.Guid organisationRoleID, bool isActive, bool isDeleted, global::System.Guid userAccountOrganisationID, OrganisationRoleDTO organisationRole, UserAccountOrganisationDTO userAccountOrganisation) {

          this.OrganisationRoleID = organisationRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.OrganisationRole = organisationRole;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationRoleDTO OrganisationRole { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
