﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class WorkflowActionNotificationTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionNotificationTemplateDTO() {
        }

        public WorkflowActionNotificationTemplateDTO(global::System.Guid workflowActionNotificationTemplateID, global::System.Guid workflowActionTemplateID, bool isConfigurable, string name, string description, bool isActive, bool isDeleted, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate) {

          this.WorkflowActionNotificationTemplateID = workflowActionNotificationTemplateID;
          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.IsConfigurable = isConfigurable;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionNotificationTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public bool IsConfigurable { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        #endregion
    }

}
