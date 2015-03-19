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
    public partial class WorkflowMainExecuteCommandDTO
    {
        #region Constructors
  
        public WorkflowMainExecuteCommandDTO() {
        }

        public WorkflowMainExecuteCommandDTO(global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowCommandID, WorkflowDTO workflow, WorkflowCommandDTO workflowCommand) {

          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowCommandID = workflowCommandID;
          this.Workflow = workflow;
          this.WorkflowCommand = workflowCommand;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowCommandDTO WorkflowCommand { get; set; }

        #endregion
    }

}
