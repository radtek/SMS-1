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
    public partial class WorkflowDecisionDTO
    {
        #region Constructors
  
        public WorkflowDecisionDTO() {
        }

        public WorkflowDecisionDTO(global::System.Guid workflowDecisionID, string name, string description, bool isTransistionStart, bool isTransistionEnd, global::System.Nullable<System.Guid> workflowDecisionTypeID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowObjectTypeID, List<WorkflowDecisionFailureDTO> workflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber, List<WorkflowDecisionFailureDTO> workflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber, List<WorkflowDecisionSuccessDTO> workflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber, List<WorkflowDecisionSuccessDTO> workflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber, List<WorkflowDecisionErrorDTO> workflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber, List<WorkflowDecisionErrorDTO> workflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber, WorkflowDTO workflow, WorkflowObjectTypeDTO workflowObjectType, List<WorkflowDecisionExecuteCommandDTO> workflowDecisionExecuteCommands, List<WorkflowDecisionParameterDTO> workflowDecisionParameters, List<WorkflowTransistionWorkflowDecisionDTO> workflowTransistionWorkflowDecisions) {

          this.WorkflowDecisionID = workflowDecisionID;
          this.Name = name;
          this.Description = description;
          this.IsTransistionStart = isTransistionStart;
          this.IsTransistionEnd = isTransistionEnd;
          this.WorkflowDecisionTypeID = workflowDecisionTypeID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowObjectTypeID = workflowObjectTypeID;
          this.WorkflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber = workflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowObjectType = workflowObjectType;
          this.WorkflowDecisionExecuteCommands = workflowDecisionExecuteCommands;
          this.WorkflowDecisionParameters = workflowDecisionParameters;
          this.WorkflowTransistionWorkflowDecisions = workflowTransistionWorkflowDecisions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsTransistionStart { get; set; }

        [DataMember]
        public bool IsTransistionEnd { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowDecisionTypeID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowObjectTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowDecisionFailureDTO> WorkflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionFailureDTO> WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionSuccessDTO> WorkflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionSuccessDTO> WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionErrorDTO> WorkflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionErrorDTO> WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowObjectTypeDTO WorkflowObjectType { get; set; }

        [DataMember]
        public List<WorkflowDecisionExecuteCommandDTO> WorkflowDecisionExecuteCommands { get; set; }

        [DataMember]
        public List<WorkflowDecisionParameterDTO> WorkflowDecisionParameters { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowDecisionDTO> WorkflowTransistionWorkflowDecisions { get; set; }

        #endregion
    }

}
