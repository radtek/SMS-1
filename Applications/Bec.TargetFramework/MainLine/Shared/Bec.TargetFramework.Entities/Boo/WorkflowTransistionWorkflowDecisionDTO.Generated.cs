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
    public partial class WorkflowTransistionWorkflowDecisionDTO
    {
        #region Constructors
  
        public WorkflowTransistionWorkflowDecisionDTO() {
        }

        public WorkflowTransistionWorkflowDecisionDTO(global::System.Guid workflowTransistionID, global::System.Guid workflowDecisionID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowDecisionDTO workflowDecision, WorkflowTransistionDTO workflowTransistion) {

          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowDecisionID = workflowDecisionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowDecision = workflowDecision;
          this.WorkflowTransistion = workflowTransistion;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowDecisionDTO WorkflowDecision { get; set; }

        [DataMember]
        public WorkflowTransistionDTO WorkflowTransistion { get; set; }

        #endregion
    }

}
