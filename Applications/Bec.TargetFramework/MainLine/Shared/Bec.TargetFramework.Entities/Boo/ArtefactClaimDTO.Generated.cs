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
    public partial class ArtefactClaimDTO
    {
        #region Constructors
  
        public ArtefactClaimDTO() {
        }

        public ArtefactClaimDTO(global::System.Guid artefactClaimID, global::System.Nullable<System.Guid> artefactID, global::System.Nullable<int> artefactVersionNumber, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> artefactRoleID, global::System.Nullable<System.Guid> roleID, RoleDTO role, ArtefactRoleDTO artefactRole, ArtefactDTO artefact, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem) {

          this.ArtefactClaimID = artefactClaimID;
          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactRoleID = artefactRoleID;
          this.RoleID = roleID;
          this.Role = role;
          this.ArtefactRole = artefactRole;
          this.Artefact = artefact;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactClaimID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ArtefactID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ResourceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateItemID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ArtefactRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public ArtefactRoleDTO ArtefactRole { get; set; }

        [DataMember]
        public ArtefactDTO Artefact { get; set; }

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        #endregion
    }

}