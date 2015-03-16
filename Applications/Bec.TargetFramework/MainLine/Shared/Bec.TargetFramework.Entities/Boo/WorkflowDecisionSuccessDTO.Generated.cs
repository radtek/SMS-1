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
    public partial class WorkflowDecisionSuccessDTO
    {
        #region Constructors
  
        public WorkflowDecisionSuccessDTO() {
        }

        public WorkflowDecisionSuccessDTO(global::System.Guid workflowDecisionID, global::System.Nullable<System.Guid> nextWorkflowActionID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Nullable<System.Guid> nextWorkflowDecisionID, global::System.Guid workflowDecisionSuccessID, WorkflowDecisionDTO workflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber, WorkflowActionDTO workflowAction, WorkflowDecisionDTO workflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber) {

          this.WorkflowDecisionID = workflowDecisionID;
          this.NextWorkflowActionID = nextWorkflowActionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.NextWorkflowDecisionID = nextWorkflowDecisionID;
          this.WorkflowDecisionSuccessID = workflowDecisionSuccessID;
          this.WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowAction = workflowAction;
          this.WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NextWorkflowActionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NextWorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowDecisionSuccessID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDecisionDTO WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public WorkflowActionDTO WorkflowAction { get; set; }

        [DataMember]
        public WorkflowDecisionDTO WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        #endregion
    }

}
