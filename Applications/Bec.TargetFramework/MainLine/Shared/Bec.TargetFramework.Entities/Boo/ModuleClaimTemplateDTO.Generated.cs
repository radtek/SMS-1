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
    public partial class ModuleClaimTemplateDTO
    {
        #region Constructors
  
        public ModuleClaimTemplateDTO() {
        }

        public ModuleClaimTemplateDTO(global::System.Guid claimID, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Nullable<System.Guid> moduleRoleID, ModuleTemplateDTO moduleTemplate, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, ModuleRoleTemplateDTO moduleRoleTemplate, RoleDTO role, OperationDTO operation) {

          this.ClaimID = claimID;
          this.RoleID = roleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.ModuleRoleID = moduleRoleID;
          this.ModuleTemplate = moduleTemplate;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.ModuleRoleTemplate = moduleRoleTemplate;
          this.Role = role;
          this.Operation = operation;
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
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ModuleRoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public ModuleRoleTemplateDTO ModuleRoleTemplate { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public OperationDTO Operation { get; set; }

        #endregion
    }

}
