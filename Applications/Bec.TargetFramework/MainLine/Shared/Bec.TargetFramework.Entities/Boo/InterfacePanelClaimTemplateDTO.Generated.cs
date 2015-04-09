﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class InterfacePanelClaimTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelClaimTemplateDTO() {
        }

        public InterfacePanelClaimTemplateDTO(global::System.Guid claimID, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, global::System.Nullable<System.Guid> interfacePanelRoleTemplateID, InterfacePanelRoleTemplateDTO interfacePanelRoleTemplate, RoleDTO role, InterfacePanelTemplateDTO interfacePanelTemplate, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem) {

          this.ClaimID = claimID;
          this.RoleID = roleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.InterfacePanelRoleTemplateID = interfacePanelRoleTemplateID;
          this.InterfacePanelRoleTemplate = interfacePanelRoleTemplate;
          this.Role = role;
          this.InterfacePanelTemplate = interfacePanelTemplate;
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
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InterfacePanelRoleTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public InterfacePanelRoleTemplateDTO InterfacePanelRoleTemplate { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

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
