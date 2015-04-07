﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class WorkflowNotificationConstructTemplateDTO
    {
        #region Constructors
  
        public WorkflowNotificationConstructTemplateDTO() {
        }

        public WorkflowNotificationConstructTemplateDTO(global::System.Guid workflowNotificationConstructTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, bool isActive, bool isDeleted, WorkflowTemplateDTO workflowTemplate, NotificationConstructTemplateDTO notificationConstructTemplate) {

          this.WorkflowNotificationConstructTemplateID = workflowNotificationConstructTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowTemplate = workflowTemplate;
          this.NotificationConstructTemplate = notificationConstructTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowNotificationConstructTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        #endregion
    }

}
