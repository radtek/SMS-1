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
    public partial class WorkflowActionExecuteCommandTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionExecuteCommandTemplateDTO() {
        }

        public WorkflowActionExecuteCommandTemplateDTO(global::System.Guid workflowActionTemplateID, global::System.Guid workflowCommandTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowCommandTemplateDTO workflowCommandTemplate) {

          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowCommandTemplate = workflowCommandTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowCommandTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowCommandTemplateDTO WorkflowCommandTemplate { get; set; }

        #endregion
    }

}
