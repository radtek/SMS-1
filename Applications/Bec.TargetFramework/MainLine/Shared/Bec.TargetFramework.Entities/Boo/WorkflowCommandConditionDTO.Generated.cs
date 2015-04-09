﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class WorkflowCommandConditionDTO
    {
        #region Constructors
  
        public WorkflowCommandConditionDTO() {
        }

        public WorkflowCommandConditionDTO(global::System.Guid workflowCommandID, global::System.Guid workflowConditionID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowCommandDTO workflowCommand) {

          this.WorkflowCommandID = workflowCommandID;
          this.WorkflowConditionID = workflowConditionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowCommand = workflowCommand;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowConditionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowCommandDTO WorkflowCommand { get; set; }

        #endregion
    }

}
