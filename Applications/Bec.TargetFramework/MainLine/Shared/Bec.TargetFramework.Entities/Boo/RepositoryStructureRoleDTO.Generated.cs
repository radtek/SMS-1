﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class RepositoryStructureRoleDTO
    {
        #region Constructors
  
        public RepositoryStructureRoleDTO() {
        }

        public RepositoryStructureRoleDTO(global::System.Guid repositoryStructureID, global::System.Nullable<System.Guid> organisationRoleID, int repositoryStructureRoleID, bool isActive, bool isDeleted, OrganisationRoleDTO organisationRole, RepositoryStructureDTO repositoryStructure) {

          this.RepositoryStructureID = repositoryStructureID;
          this.OrganisationRoleID = organisationRoleID;
          this.RepositoryStructureRoleID = repositoryStructureRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationRole = organisationRole;
          this.RepositoryStructure = repositoryStructure;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RepositoryStructureID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationRoleID { get; set; }

        [DataMember]
        public int RepositoryStructureRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationRoleDTO OrganisationRole { get; set; }

        [DataMember]
        public RepositoryStructureDTO RepositoryStructure { get; set; }

        #endregion
    }

}
