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
    public partial class VWorkflowInstanceExecutionStatusEventDTO
    {
        #region Constructors
  
        public VWorkflowInstanceExecutionStatusEventDTO() {
        }

        public VWorkflowInstanceExecutionStatusEventDTO(int workflowInstanceExecutionStatusEventID, global::System.DateTime eventDate, string eventBy, int workflowExecutionStatusID, int workflowInstanceExecutionID, int eventOrder, string name, string actionDecision) {

          this.WorkflowInstanceExecutionStatusEventID = workflowInstanceExecutionStatusEventID;
          this.EventDate = eventDate;
          this.EventBy = eventBy;
          this.WorkflowExecutionStatusID = workflowExecutionStatusID;
          this.WorkflowInstanceExecutionID = workflowInstanceExecutionID;
          this.EventOrder = eventOrder;
          this.Name = name;
          this.ActionDecision = actionDecision;
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
        public string Name { get; set; }

        [DataMember]
        public string ActionDecision { get; set; }

        #endregion
    }

}
