﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class NotificationConstructGroupNotificationConstructDTO
    {
        #region Constructors
  
        public NotificationConstructGroupNotificationConstructDTO() {
        }

        public NotificationConstructGroupNotificationConstructDTO(global::System.Guid notificationConstructGroupNotificationConstructID, int notificationConstructGroupNotificationConstructVersion, global::System.Nullable<System.Guid> notificationConstructGroupID, global::System.Nullable<int> notificationConstructGroupVersion, global::System.Nullable<System.Guid> userTypeID, global::System.Guid notificationConstructID, global::System.Nullable<System.Guid> workflowID, global::System.Nullable<int> workflowVersionNumber, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, string conditionString, int notificationConstructVersionNumber, global::System.Nullable<int> organisationTypeID, NotificationConstructGroupDTO notificationConstructGroup, UserTypeDTO userType, OrganisationTypeDTO organisationType, NotificationConstructDTO notificationConstruct) {

          this.NotificationConstructGroupNotificationConstructID = notificationConstructGroupNotificationConstructID;
          this.NotificationConstructGroupNotificationConstructVersion = notificationConstructGroupNotificationConstructVersion;
          this.NotificationConstructGroupID = notificationConstructGroupID;
          this.NotificationConstructGroupVersion = notificationConstructGroupVersion;
          this.UserTypeID = userTypeID;
          this.NotificationConstructID = notificationConstructID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ConditionString = conditionString;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.NotificationConstructGroup = notificationConstructGroup;
          this.UserType = userType;
          this.OrganisationType = organisationType;
          this.NotificationConstruct = notificationConstruct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructGroupNotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructGroupNotificationConstructVersion { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationConstructGroupID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructGroupVersion { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public string ConditionString { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationConstructGroupDTO NotificationConstructGroup { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        #endregion
    }

}
