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
    public partial class WorkflowCommandDTO
    {
        #region Constructors
  
        public WorkflowCommandDTO() {
        }

        public WorkflowCommandDTO(global::System.Guid workflowCommandID, string name, string description, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowObjectTypeID, List<WorkflowActionExecuteCommandDTO> workflowActionExecuteCommands, List<WorkflowActionPostCommandDTO> workflowActionPostCommands, WorkflowDTO workflow, WorkflowObjectTypeDTO workflowObjectType, List<WorkflowCommandParameterDTO> workflowCommandParameters, WorkflowMainExecuteCommandDTO workflowMainExecuteCommand, WorkflowMainPostCommandDTO workflowMainPostCommand, WorkflowMainPreCommandDTO workflowMainPreCommand, List<WorkflowCommandConditionDTO> workflowCommandConditions, List<WorkflowActionPreCommandDTO> workflowActionPreCommands) {

          this.WorkflowCommandID = workflowCommandID;
          this.Name = name;
          this.Description = description;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowObjectTypeID = workflowObjectTypeID;
          this.WorkflowActionExecuteCommands = workflowActionExecuteCommands;
          this.WorkflowActionPostCommands = workflowActionPostCommands;
          this.Workflow = workflow;
          this.WorkflowObjectType = workflowObjectType;
          this.WorkflowCommandParameters = workflowCommandParameters;
          this.WorkflowMainExecuteCommand = workflowMainExecuteCommand;
          this.WorkflowMainPostCommand = workflowMainPostCommand;
          this.WorkflowMainPreCommand = workflowMainPreCommand;
          this.WorkflowCommandConditions = workflowCommandConditions;
          this.WorkflowActionPreCommands = workflowActionPreCommands;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

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
        public List<WorkflowActionExecuteCommandDTO> WorkflowActionExecuteCommands { get; set; }

        [DataMember]
        public List<WorkflowActionPostCommandDTO> WorkflowActionPostCommands { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowObjectTypeDTO WorkflowObjectType { get; set; }

        [DataMember]
        public List<WorkflowCommandParameterDTO> WorkflowCommandParameters { get; set; }

        [DataMember]
        public WorkflowMainExecuteCommandDTO WorkflowMainExecuteCommand { get; set; }

        [DataMember]
        public WorkflowMainPostCommandDTO WorkflowMainPostCommand { get; set; }

        [DataMember]
        public WorkflowMainPreCommandDTO WorkflowMainPreCommand { get; set; }

        [DataMember]
        public List<WorkflowCommandConditionDTO> WorkflowCommandConditions { get; set; }

        [DataMember]
        public List<WorkflowActionPreCommandDTO> WorkflowActionPreCommands { get; set; }

        #endregion
    }

}
