﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class ActorClaimRoleMappingDTO
    {
        #region Constructors
  
        public ActorClaimRoleMappingDTO() {
        }

        public ActorClaimRoleMappingDTO(global::System.Guid actorClaimRoleMappingID, global::System.Nullable<System.Guid> actorID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, global::System.Nullable<System.Guid> roleID, bool isActive, bool isDeleted, ActorDTO actor, OperationDTO operation, ResourceDTO resource, RoleDTO role, StateDTO state, StateItemDTO stateItem) {

          this.ActorClaimRoleMappingID = actorClaimRoleMappingID;
          this.ActorID = actorID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.RoleID = roleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Actor = actor;
          this.Operation = operation;
          this.Resource = resource;
          this.Role = role;
          this.State = state;
          this.StateItem = stateItem;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ActorClaimRoleMappingID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ActorID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ResourceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateItemID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ActorDTO Actor { get; set; }

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        #endregion
    }

}
