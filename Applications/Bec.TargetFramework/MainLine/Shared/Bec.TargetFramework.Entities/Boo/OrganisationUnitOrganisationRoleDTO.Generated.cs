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
    public partial class OrganisationUnitOrganisationRoleDTO
    {
        #region Constructors
  
        public OrganisationUnitOrganisationRoleDTO() {
        }

        public OrganisationUnitOrganisationRoleDTO(int organisationUnitID, global::System.Guid organisationRoleID, bool isActive, bool isDeleted, OrganisationRoleDTO organisationRole, OrganisationUnitDTO organisationUnit) {

          this.OrganisationUnitID = organisationUnitID;
          this.OrganisationRoleID = organisationRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationRole = organisationRole;
          this.OrganisationUnit = organisationUnit;
        }

        #endregion

        #region Properties

        [DataMember]
        public int OrganisationUnitID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationRoleDTO OrganisationRole { get; set; }

        [DataMember]
        public OrganisationUnitDTO OrganisationUnit { get; set; }

        #endregion
    }

}
