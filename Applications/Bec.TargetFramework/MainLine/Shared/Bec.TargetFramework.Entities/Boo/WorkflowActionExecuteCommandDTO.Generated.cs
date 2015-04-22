﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class WorkflowActionExecuteCommandDTO
    {
        #region Constructors
  
        public WorkflowActionExecuteCommandDTO() {
        }

        public WorkflowActionExecuteCommandDTO(global::System.Guid workflowActionID, global::System.Guid workflowCommandID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowActionDTO workflowAction, WorkflowCommandDTO workflowCommand) {

          this.WorkflowActionID = workflowActionID;
          this.WorkflowCommandID = workflowCommandID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowAction = workflowAction;
          this.WorkflowCommand = workflowCommand;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionDTO WorkflowAction { get; set; }

        [DataMember]
        public WorkflowCommandDTO WorkflowCommand { get; set; }

        #endregion
    }

}
