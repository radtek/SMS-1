﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class WorkflowTransistionWorkflowActionTemplateDTO
    {
        #region Constructors
  
        public WorkflowTransistionWorkflowActionTemplateDTO() {
        }

        public WorkflowTransistionWorkflowActionTemplateDTO(global::System.Guid workflowTransistionTemplateID, global::System.Guid workflowActionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowTransistionTemplateDTO workflowTransistionTemplate, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTransistionTemplateID = workflowTransistionTemplateID;
          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTransistionTemplate = workflowTransistionTemplate;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTransistionTemplateDTO WorkflowTransistionTemplate { get; set; }

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
