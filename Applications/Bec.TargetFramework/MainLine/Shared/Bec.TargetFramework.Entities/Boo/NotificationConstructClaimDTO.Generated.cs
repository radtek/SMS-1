﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class NotificationConstructClaimDTO
    {
        #region Constructors
  
        public NotificationConstructClaimDTO() {
        }

        public NotificationConstructClaimDTO(global::System.Guid notificationConstructClaimID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<System.Guid> notificationRoleConstructID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> roleID, OperationDTO operation, NotificationConstructDTO notificationConstruct, ResourceDTO resource, StateDTO state, StateItemDTO stateItem, RoleDTO role, NotificationConstructRoleDTO notificationConstructRole) {

          this.NotificationConstructClaimID = notificationConstructClaimID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.NotificationRoleConstructID = notificationRoleConstructID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleID = roleID;
          this.Operation = operation;
          this.NotificationConstruct = notificationConstruct;
          this.Resource = resource;
          this.State = state;
          this.StateItem = stateItem;
          this.Role = role;
          this.NotificationConstructRole = notificationConstructRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructClaimID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationRoleConstructID { get; set; }

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
        public NotificationConstructDTO NotificationConstruct { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public NotificationConstructRoleDTO NotificationConstructRole { get; set; }

        #endregion
    }

}
