﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class WorkflowCommandParameterDTO
    {
        #region Constructors
  
        public WorkflowCommandParameterDTO() {
        }

        public WorkflowCommandParameterDTO(global::System.Guid workflowCommandID, global::System.Guid workflowParameterID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowParameterDTO workflowParameter, WorkflowCommandDTO workflowCommand) {

          this.WorkflowCommandID = workflowCommandID;
          this.WorkflowParameterID = workflowParameterID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowParameter = workflowParameter;
          this.WorkflowCommand = workflowCommand;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowParameterDTO WorkflowParameter { get; set; }

        [DataMember]
        public WorkflowCommandDTO WorkflowCommand { get; set; }

        #endregion
    }

}
