﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class VNotificationConstructGroupDTO
    {
        #region Constructors
  
        public VNotificationConstructGroupDTO() {
        }

        public VNotificationConstructGroupDTO(global::System.Guid notificationConstructGroupNotificationConstructID, int notificationConstructGroupNotificationConstructVersion, global::System.Guid notificationConstructGroupID, int notificationConstructGroupVersion, string groupName, string groupDescription, global::System.Nullable<bool> groupIsActive, global::System.Nullable<bool> groupIsDeleted, global::System.Nullable<System.Guid> userTypeID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<System.Guid> workflowID, global::System.Nullable<int> workflowVersionNumber, bool isActive, bool isDeleted, string conditionString, global::System.Nullable<int> organisationTypeID, string notificationConstructName, string notificationConstructDescription, global::System.Nullable<bool> notificationConstructIsActive, global::System.Nullable<bool> notificationConstructIsDeleted, string notificationConstructSubject, string notificationConstructTitle) {

          this.NotificationConstructGroupNotificationConstructID = notificationConstructGroupNotificationConstructID;
          this.NotificationConstructGroupNotificationConstructVersion = notificationConstructGroupNotificationConstructVersion;
          this.NotificationConstructGroupID = notificationConstructGroupID;
          this.NotificationConstructGroupVersion = notificationConstructGroupVersion;
          this.GroupName = groupName;
          this.GroupDescription = groupDescription;
          this.GroupIsActive = groupIsActive;
          this.GroupIsDeleted = groupIsDeleted;
          this.UserTypeID = userTypeID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ConditionString = conditionString;
          this.OrganisationTypeID = organisationTypeID;
          this.NotificationConstructName = notificationConstructName;
          this.NotificationConstructDescription = notificationConstructDescription;
          this.NotificationConstructIsActive = notificationConstructIsActive;
          this.NotificationConstructIsDeleted = notificationConstructIsDeleted;
          this.NotificationConstructSubject = notificationConstructSubject;
          this.NotificationConstructTitle = notificationConstructTitle;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructGroupNotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructGroupNotificationConstructVersion { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructGroupID { get; set; }

        [DataMember]
        public int NotificationConstructGroupVersion { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public global::System.Nullable<bool> GroupIsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> GroupIsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string ConditionString { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public string NotificationConstructName { get; set; }

        [DataMember]
        public string NotificationConstructDescription { get; set; }

        [DataMember]
        public global::System.Nullable<bool> NotificationConstructIsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> NotificationConstructIsDeleted { get; set; }

        [DataMember]
        public string NotificationConstructSubject { get; set; }

        [DataMember]
        public string NotificationConstructTitle { get; set; }

        #endregion
    }

}
