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
    public partial class StructureDTO
    {
        #region Constructors
  
        public StructureDTO() {
        }

        public StructureDTO(global::System.Guid repositoryMapID, global::System.Nullable<System.Guid> organisationRoleID, global::System.Nullable<System.Guid> organisationExternalRoleID, int structureID, bool isActive, bool isDeleted) {

          this.RepositoryMapID = repositoryMapID;
          this.OrganisationRoleID = organisationRoleID;
          this.OrganisationExternalRoleID = organisationExternalRoleID;
          this.StructureID = structureID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RepositoryMapID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationExternalRoleID { get; set; }

        [DataMember]
        public int StructureID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}