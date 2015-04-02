﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class WorkflowInstanceExecutionDTO
    {
        #region Constructors
  
        public WorkflowInstanceExecutionDTO() {
        }

        public WorkflowInstanceExecutionDTO(int workflowInstanceExecutionID, global::System.Guid workflowInstanceID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowTransistionID, global::System.Nullable<System.Guid> workflowActionID, global::System.Nullable<System.Guid> workflowDecisionID, global::System.Nullable<System.Guid> workflowConditionID, global::System.Nullable<System.Guid> workflowCommandID, global::System.Guid workflowInstanceSessionID, global::System.Nullable<System.DateTime> createdOn, global::System.Nullable<int> numberOfRetries, WorkflowInstanceSessionDTO workflowInstanceSession, List<WorkflowInstanceExecutionStatusEventDTO> workflowInstanceExecutionStatusEvents, List<WorkflowInstanceExecutionTraceDTO> workflowInstanceExecutionTraces) {

          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowActionID = workflowActionID;
          this.WorkflowDecisionID = workflowDecisionID;
          this.WorkflowConditionID = workflowConditionID;
          this.WorkflowCommandID = workflowCommandID;
          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.CreatedOn = createdOn;
          this.NumberOfRetries = numberOfRetries;
          this.WorkflowInstanceSession = workflowInstanceSession;
          this.WorkflowInstanceExecutionStatusEvents = workflowInstanceExecutionStatusEvents;
          this.WorkflowInstanceExecutionTraces = workflowInstanceExecutionTraces;
        }

        #endregion

        #region Properties

        [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowConditionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowCommandID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<int> NumberOfRetries { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceSessionDTO WorkflowInstanceSession { get; set; }

        [DataMember]
        public List<WorkflowInstanceExecutionStatusEventDTO> WorkflowInstanceExecutionStatusEvents { get; set; }

        [DataMember]
        public List<WorkflowInstanceExecutionTraceDTO> WorkflowInstanceExecutionTraces { get; set; }

        #endregion
    }

}
