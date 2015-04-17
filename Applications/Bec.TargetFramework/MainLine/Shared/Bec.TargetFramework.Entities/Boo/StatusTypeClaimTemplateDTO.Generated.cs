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
    public partial class StatusTypeClaimTemplateDTO
    {
        #region Constructors
  
        public StatusTypeClaimTemplateDTO() {
        }

        public StatusTypeClaimTemplateDTO(global::System.Guid statusTypeClaimTemplateID, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> statusTypeRoleTemplateID, OperationDTO operation, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role, StatusTypeRoleTemplateDTO statusTypeRoleTemplate, StatusTypeTemplateDTO statusTypeTemplate) {

          this.StatusTypeClaimTemplateID = statusTypeClaimTemplateID;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleID = roleID;
          this.StatusTypeRoleTemplateID = statusTypeRoleTemplateID;
          this.Operation = operation;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
          this.StatusTypeRoleTemplate = statusTypeRoleTemplate;
          this.StatusTypeTemplate = statusTypeTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeClaimTemplateID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

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
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StatusTypeRoleTemplateID { get; set; }

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

        [DataMember]
        public StatusTypeRoleTemplateDTO StatusTypeRoleTemplate { get; set; }

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        #endregion
    }

}
