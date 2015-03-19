﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class NotificationConstructClaimTemplateDTO
    {
        #region Constructors
  
        public NotificationConstructClaimTemplateDTO() {
        }

        public NotificationConstructClaimTemplateDTO(global::System.Guid notificationConstructClaimTemplateID, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, global::System.Nullable<System.Guid> notificationConstructRoleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> roleID, OperationDTO operation, NotificationConstructTemplateDTO notificationConstructTemplate, NotificationConstructRoleTemplateDTO notificationConstructRoleTemplate, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role) {

          this.NotificationConstructClaimTemplateID = notificationConstructClaimTemplateID;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.NotificationConstructRoleID = notificationConstructRoleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleID = roleID;
          this.Operation = operation;
          this.NotificationConstructTemplate = notificationConstructTemplate;
          this.NotificationConstructRoleTemplate = notificationConstructRoleTemplate;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructClaimTemplateID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationConstructRoleID { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        [DataMember]
        public NotificationConstructRoleTemplateDTO NotificationConstructRoleTemplate { get; set; }

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
