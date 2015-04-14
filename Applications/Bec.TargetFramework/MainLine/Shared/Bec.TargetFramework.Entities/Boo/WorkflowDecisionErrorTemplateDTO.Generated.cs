﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class WorkflowDecisionErrorTemplateDTO
    {
        #region Constructors
  
        public WorkflowDecisionErrorTemplateDTO() {
        }

        public WorkflowDecisionErrorTemplateDTO(global::System.Guid workflowDecisionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Nullable<System.Guid> nextWorkflowActionTemplateID, global::System.Nullable<System.Guid> nextWorkflowDecisionTemplateID, global::System.Guid workflowDecisionErrorTemplateID, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowDecisionTemplateDTO workflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, WorkflowDecisionTemplateDTO workflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber) {

          this.WorkflowDecisionTemplateID = workflowDecisionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.NextWorkflowActionTemplateID = nextWorkflowActionTemplateID;
          this.NextWorkflowDecisionTemplateID = nextWorkflowDecisionTemplateID;
          this.WorkflowDecisionErrorTemplateID = workflowDecisionErrorTemplateID;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NextWorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NextWorkflowDecisionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowDecisionErrorTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowDecisionTemplateDTO WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public WorkflowDecisionTemplateDTO WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        #endregion
    }

}
