﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class VWorkflowInstanceExecutionNotCompletedDTO
    {
        #region Constructors
  
        public VWorkflowInstanceExecutionNotCompletedDTO() {
        }

        public VWorkflowInstanceExecutionNotCompletedDTO(string stepName, string stepStatus, global::System.Nullable<System.DateTime> stepDate, string stepExecutedBy, global::System.Nullable<int> stepOrder, string stepType, global::System.Nullable<int> stepIsManual, global::System.Nullable<bool> stepIsStart, global::System.Nullable<bool> stepIsEnd, string transistionName, global::System.Nullable<bool> isWorkflowStart, global::System.Nullable<bool> isWorkflowEnd, global::System.Nullable<System.Guid> workflowTransistionID, global::System.Guid workflowInstanceID, int workflowInstanceExecutionStatusEventID, global::System.Nullable<int> workflowExecutionStatusID, int workflowInstanceExecutionID, global::System.Guid workflowInstanceSessionID, global::System.DateTime sessionStartedOn, global::System.DateTime sessionEndedOn, global::System.Nullable<System.Guid> stepID, string actionAction, string actionArea, string actionController, global::System.Guid workflowID, int workflowVersionNumber, string jsonContent, global::System.Nullable<int> workflowTypeID, string workflowtypename, global::System.Nullable<int> workflowCategoryID, string workflowcategoryname, global::System.Nullable<int> workflowInstanceStatusID, string workflowinstancestatusname) {

          this.StepName = stepName;
          this.StepStatus = stepStatus;
          this.StepDate = stepDate;
          this.StepExecutedBy = stepExecutedBy;
          this.StepOrder = stepOrder;
          this.StepType = stepType;
          this.StepIsManual = stepIsManual;
          this.StepIsStart = stepIsStart;
          this.StepIsEnd = stepIsEnd;
          this.TransistionName = transistionName;
          this.IsWorkflowStart = isWorkflowStart;
          this.IsWorkflowEnd = isWorkflowEnd;
          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceExecutionStatusEventID = workflowInstanceExecutionStatusEventID;
          this.WorkflowExecutionStatusID = workflowExecutionStatusID;
          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.SessionStartedOn = sessionStartedOn;
          this.SessionEndedOn = sessionEndedOn;
          this.StepID = stepID;
          this.ActionAction = actionAction;
          this.ActionArea = actionArea;
          this.ActionController = actionController;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.JsonContent = jsonContent;
          this.WorkflowTypeID = workflowTypeID;
          this.Workflowtypename = workflowtypename;
          this.WorkflowCategoryID = workflowCategoryID;
          this.Workflowcategoryname = workflowcategoryname;
          this.WorkflowInstanceStatusID = workflowInstanceStatusID;
          this.Workflowinstancestatusname = workflowinstancestatusname;
        }

        #endregion

        #region Properties

        [DataMember]
        public string StepName { get; set; }

        [DataMember]
        public string StepStatus { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> StepDate { get; set; }

        [DataMember]
        public string StepExecutedBy { get; set; }

        [DataMember]
        public global::System.Nullable<int> StepOrder { get; set; }

        [DataMember]
        public string StepType { get; set; }

        [DataMember]
        public global::System.Nullable<int> StepIsManual { get; set; }

        [DataMember]
        public global::System.Nullable<bool> StepIsStart { get; set; }

        [DataMember]
        public global::System.Nullable<bool> StepIsEnd { get; set; }

        [DataMember]
        public string TransistionName { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsWorkflowStart { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsWorkflowEnd { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowExecutionStatusID { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.DateTime SessionStartedOn { get; set; }

        [DataMember]
        public global::System.DateTime SessionEndedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StepID { get; set; }

        [DataMember]
        public string ActionAction { get; set; }

        [DataMember]
        public string ActionArea { get; set; }

        [DataMember]
        public string ActionController { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public string JsonContent { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowTypeID { get; set; }

        [DataMember]
        public string Workflowtypename { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowCategoryID { get; set; }

        [DataMember]
        public string Workflowcategoryname { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceStatusID { get; set; }

        [DataMember]
        public string Workflowinstancestatusname { get; set; }

        #endregion
    }

}
