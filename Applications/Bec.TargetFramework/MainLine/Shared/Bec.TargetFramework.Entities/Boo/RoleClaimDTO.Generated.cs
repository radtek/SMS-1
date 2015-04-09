﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class RoleClaimDTO
    {
        #region Constructors
  
        public RoleClaimDTO() {
        }

        public RoleClaimDTO(int roleClaimID, global::System.Guid roleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<bool> isGlobal, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role) {

          this.RoleClaimID = roleClaimID;
          this.RoleID = roleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsGlobal = isGlobal;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public int RoleClaimID { get; set; }

        [DataMember]
        public global::System.Guid RoleID { get; set; }

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
        public global::System.Nullable<bool> IsGlobal { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
