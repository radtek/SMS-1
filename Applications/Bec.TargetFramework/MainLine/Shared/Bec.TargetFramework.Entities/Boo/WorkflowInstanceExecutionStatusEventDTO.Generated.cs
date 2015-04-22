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
    public partial class WorkflowInstanceExecutionStatusEventDTO
    {
        #region Constructors
  
        public WorkflowInstanceExecutionStatusEventDTO() {
        }

        public WorkflowInstanceExecutionStatusEventDTO(int workflowInstanceExecutionStatusEventID, global::System.DateTime eventDate, string eventBy, int workflowExecutionStatusID, int workflowInstanceExecutionID, int eventOrder, global::System.Guid workflowInstanceSessionID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowInstanceID, WorkflowInstanceExecutionDTO workflowInstanceExecution, WorkflowExecutionStatusDTO workflowExecutionStatus, List<WorkflowInstanceExecutionDataItemDTO> workflowInstanceExecutionDataItems) {

          this.WorkflowInstanceExecutionStatusEventID = workflowInstanceExecutionStatusEventID;
          this.EventDate = eventDate;
          this.EventBy = eventBy;
          this.WorkflowExecutionStatusID = workflowExecutionStatusID;
          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.EventOrder = eventOrder;
          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceExecution = workflowInstanceExecution;
          this.WorkflowExecutionStatus = workflowExecutionStatus;
          this.WorkflowInstanceExecutionDataItems = workflowInstanceExecutionDataItems;
        }

        #endregion

        #region Properties

        [DataMember]
        public int WorkflowInstanceExecutionStatusEventID { get; set; }

        [DataMember]
        public global::System.DateTime EventDate { get; set; }

        [DataMember]
        public string EventBy { get; set; }

        [DataMember]
        public int WorkflowExecutionStatusID { get; set; }

        [DataMember]
        public int WorkflowInstanceExecutionID { get; set; }

        [DataMember]
        public int EventOrder { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowInstanceExecutionDTO WorkflowInstanceExecution { get; set; }

        [DataMember]
        public WorkflowExecutionStatusDTO WorkflowExecutionStatus { get; set; }

        [DataMember]
        public List<WorkflowInstanceExecutionDataItemDTO> WorkflowInstanceExecutionDataItems { get; set; }

        #endregion
    }

}
