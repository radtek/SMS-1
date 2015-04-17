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
    public partial class WorkflowTransistionDTO
    {
        #region Constructors
  
        public WorkflowTransistionDTO() {
        }

        public WorkflowTransistionDTO(global::System.Guid workflowTransistionID, string name, string description, bool isWorkflowStart, bool isWorkflowEnd, global::System.Guid workflowID, int workflowVersionNumber, List<WorkflowTransistionWorkflowActionDTO> workflowTransistionWorkflowActions, List<WorkflowTransistionCompleteConditionDTO> workflowTransistionCompleteConditions, List<WorkflowTransistionStartConditionDTO> workflowTransistionStartConditions, List<WorkflowTransistionWorkflowDecisionDTO> workflowTransistionWorkflowDecisions, List<WorkflowHierarchyDTO> workflowHierarchies, WorkflowDTO workflow, List<WorkflowTransistionHierarchyDTO> workflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber, List<WorkflowTransistionHierarchyDTO> workflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber, List<WorkflowTransistionParameterDTO> workflowTransistionParameters) {

          this.WorkflowTransistionID = workflowTransistionID;
          this.Name = name;
          this.Description = description;
          this.IsWorkflowStart = isWorkflowStart;
          this.IsWorkflowEnd = isWorkflowEnd;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowTransistionWorkflowActions = workflowTransistionWorkflowActions;
          this.WorkflowTransistionCompleteConditions = workflowTransistionCompleteConditions;
          this.WorkflowTransistionStartConditions = workflowTransistionStartConditions;
          this.WorkflowTransistionWorkflowDecisions = workflowTransistionWorkflowDecisions;
          this.WorkflowHierarchies = workflowHierarchies;
          this.Workflow = workflow;
          this.WorkflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber = workflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber = workflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber;
          this.WorkflowTransistionParameters = workflowTransistionParameters;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsWorkflowStart { get; set; }

        [DataMember]
        public bool IsWorkflowEnd { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowTransistionWorkflowActionDTO> WorkflowTransistionWorkflowActions { get; set; }

        [DataMember]
        public List<WorkflowTransistionCompleteConditionDTO> WorkflowTransistionCompleteConditions { get; set; }

        [DataMember]
        public List<WorkflowTransistionStartConditionDTO> WorkflowTransistionStartConditions { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowDecisionDTO> WorkflowTransistionWorkflowDecisions { get; set; }

        [DataMember]
        public List<WorkflowHierarchyDTO> WorkflowHierarchies { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public List<WorkflowTransistionHierarchyDTO> WorkflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowTransistionHierarchyDTO> WorkflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowTransistionParameterDTO> WorkflowTransistionParameters { get; set; }

        #endregion
    }

}
