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
    public partial class WorkflowInstanceSessionDTO
    {
        #region Constructors
  
        public WorkflowInstanceSessionDTO() {
        }

        public WorkflowInstanceSessionDTO(global::System.Guid workflowInstanceSessionID, global::System.DateTime sessionStartedOn, global::System.DateTime sessionEndedOn, global::System.Guid workflowInstanceID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowInstanceDTO workflowInstance, List<WorkflowInstanceExecutionDTO> workflowInstanceExecutions) {

          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.SessionStartedOn = sessionStartedOn;
          this.SessionEndedOn = sessionEndedOn;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowInstance = workflowInstance;
          this.WorkflowInstanceExecutions = workflowInstanceExecutions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.DateTime SessionStartedOn { get; set; }

        [DataMember]
        public global::System.DateTime SessionEndedOn { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceDTO WorkflowInstance { get; set; }

        [DataMember]
        public List<WorkflowInstanceExecutionDTO> WorkflowInstanceExecutions { get; set; }

        #endregion
    }

}
