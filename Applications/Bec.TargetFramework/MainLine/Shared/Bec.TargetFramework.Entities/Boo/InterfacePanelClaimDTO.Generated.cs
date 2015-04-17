﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class InterfacePanelClaimDTO
    {
        #region Constructors
  
        public InterfacePanelClaimDTO() {
        }

        public InterfacePanelClaimDTO(global::System.Guid claimID, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid interfacePanelID, int interfacePanelVersionNumber, global::System.Nullable<System.Guid> interfacePanelRoleID, RoleDTO role, InterfacePanelRoleDTO interfacePanelRole, InterfacePanelDTO interfacePanel, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem) {

          this.ClaimID = claimID;
          this.RoleID = roleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InterfacePanelID = interfacePanelID;
          this.InterfacePanelVersionNumber = interfacePanelVersionNumber;
          this.InterfacePanelRoleID = interfacePanelRoleID;
          this.Role = role;
          this.InterfacePanelRole = interfacePanelRole;
          this.InterfacePanel = interfacePanel;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ClaimID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

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
        public global::System.Guid InterfacePanelID { get; set; }

        [DataMember]
        public int InterfacePanelVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InterfacePanelRoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public InterfacePanelRoleDTO InterfacePanelRole { get; set; }

        [DataMember]
        public InterfacePanelDTO InterfacePanel { get; set; }

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
