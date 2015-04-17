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
    public partial class WorkflowInstanceExecutionTraceDTO
    {
        #region Constructors
  
        public WorkflowInstanceExecutionTraceDTO() {
        }

        public WorkflowInstanceExecutionTraceDTO(global::System.Guid workflowInstanceExecutionTraceID, int workflowInstanceExecutionID, global::System.Guid workflowInstanceSessionID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Nullable<System.Guid> workflowInstanceID, global::System.Nullable<System.Guid> workflowTransistionID, global::System.Nullable<System.Guid> workflowActionID, global::System.Nullable<System.Guid> workflowDecisionID, global::System.Nullable<System.Guid> workflowConditionID, global::System.Nullable<System.Guid> workflowCommandID, string traceDetail, string traceStackTrace, bool hasError, global::System.DateTime executedOn, string executedBy, string additionalContent, int numberOfRetries, WorkflowInstanceExecutionDTO workflowInstanceExecution) {

          this.WorkflowInstanceExecutionTraceID = workflowInstanceExecutionTraceID;
          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowActionID = workflowActionID;
          this.WorkflowDecisionID = workflowDecisionID;
          this.WorkflowConditionID = workflowConditionID;
          this.WorkflowCommandID = workflowCommandID;
          this.TraceDetail = traceDetail;
          this.TraceStackTrace = traceStackTrace;
          this.HasError = hasError;
          this.ExecutedOn = executedOn;
          this.ExecutedBy = executedBy;
          this.AdditionalContent = additionalContent;
          this.NumberOfRetries = numberOfRetries;
          this.WorkflowInstanceExecution = workflowInstanceExecution;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowInstanceExecutionTraceID { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowConditionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowCommandID { get; set; }

        [DataMember]
        public string TraceDetail { get; set; }

        [DataMember]
        public string TraceStackTrace { get; set; }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public global::System.DateTime ExecutedOn { get; set; }

        [DataMember]
        public string ExecutedBy { get; set; }

        [DataMember]
        public string AdditionalContent { get; set; }

        [DataMember]
        public int NumberOfRetries { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceExecutionDTO WorkflowInstanceExecution { get; set; }

        #endregion
    }

}
