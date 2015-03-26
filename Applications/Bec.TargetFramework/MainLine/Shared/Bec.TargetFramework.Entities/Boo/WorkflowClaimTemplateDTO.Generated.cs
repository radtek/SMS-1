﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class WorkflowClaimTemplateDTO
    {
        #region Constructors
  
        public WorkflowClaimTemplateDTO() {
        }

        public WorkflowClaimTemplateDTO(global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Guid workflowClaimTemplateID, global::System.Nullable<System.Guid> workflowRoleTemplateID, global::System.Nullable<System.Guid> roleID, WorkflowRoleTemplateDTO workflowRoleTemplate, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowClaimTemplateID = workflowClaimTemplateID;
          this.WorkflowRoleTemplateID = workflowRoleTemplateID;
          this.RoleID = roleID;
          this.WorkflowRoleTemplate = workflowRoleTemplate;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

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
        public global::System.Guid WorkflowClaimTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowRoleTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowRoleTemplateDTO WorkflowRoleTemplate { get; set; }

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

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
