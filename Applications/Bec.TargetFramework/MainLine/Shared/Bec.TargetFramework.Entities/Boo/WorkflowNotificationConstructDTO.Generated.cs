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
    public partial class WorkflowNotificationConstructDTO
    {
        #region Constructors
  
        public WorkflowNotificationConstructDTO() {
        }

        public WorkflowNotificationConstructDTO(global::System.Guid workflowNotificationConstructID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Guid workflowID, int workflowVersionNumber, bool isActive, bool isDeleted, NotificationConstructDTO notificationConstruct, WorkflowDTO workflow) {

          this.WorkflowNotificationConstructID = workflowNotificationConstructID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstruct = notificationConstruct;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowNotificationConstructID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
