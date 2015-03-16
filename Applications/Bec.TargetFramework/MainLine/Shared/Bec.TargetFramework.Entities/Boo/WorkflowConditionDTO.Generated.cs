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
    public partial class WorkflowConditionDTO
    {
        #region Constructors
  
        public WorkflowConditionDTO() {
        }

        public WorkflowConditionDTO(global::System.Guid workflowConditionID, string name, string description, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowObjectTypeID, List<WorkflowActionCompleteConditionDTO> workflowActionCompleteConditions, List<WorkflowActionStartConditionDTO> workflowActionStartConditions, WorkflowDTO workflow, List<WorkflowConditionParameterDTO> workflowConditionParameters, WorkflowMainCompleteConditionDTO workflowMainCompleteCondition, WorkflowMainStartConditionDTO workflowMainStartCondition, List<WorkflowTransistionCompleteConditionDTO> workflowTransistionCompleteConditions, List<WorkflowTransistionStartConditionDTO> workflowTransistionStartConditions, List<WorkflowCommandConditionDTO> workflowCommandConditions) {

          this.WorkflowConditionID = workflowConditionID;
          this.Name = name;
          this.Description = description;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowObjectTypeID = workflowObjectTypeID;
          this.WorkflowActionCompleteConditions = workflowActionCompleteConditions;
          this.WorkflowActionStartConditions = workflowActionStartConditions;
          this.Workflow = workflow;
          this.WorkflowConditionParameters = workflowConditionParameters;
          this.WorkflowMainCompleteCondition = workflowMainCompleteCondition;
          this.WorkflowMainStartCondition = workflowMainStartCondition;
          this.WorkflowTransistionCompleteConditions = workflowTransistionCompleteConditions;
          this.WorkflowTransistionStartConditions = workflowTransistionStartConditions;
          this.WorkflowCommandConditions = workflowCommandConditions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowConditionID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowObjectTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowActionCompleteConditionDTO> WorkflowActionCompleteConditions { get; set; }

        [DataMember]
        public List<WorkflowActionStartConditionDTO> WorkflowActionStartConditions { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public List<WorkflowConditionParameterDTO> WorkflowConditionParameters { get; set; }

        [DataMember]
        public WorkflowMainCompleteConditionDTO WorkflowMainCompleteCondition { get; set; }

        [DataMember]
        public WorkflowMainStartConditionDTO WorkflowMainStartCondition { get; set; }

        [DataMember]
        public List<WorkflowTransistionCompleteConditionDTO> WorkflowTransistionCompleteConditions { get; set; }

        [DataMember]
        public List<WorkflowTransistionStartConditionDTO> WorkflowTransistionStartConditions { get; set; }

        [DataMember]
        public List<WorkflowCommandConditionDTO> WorkflowCommandConditions { get; set; }

        #endregion
    }

}
