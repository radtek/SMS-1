﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class VWorkflowInstanceStatusDTO
    {
        #region Constructors
  
        public VWorkflowInstanceStatusDTO() {
        }

        public VWorkflowInstanceStatusDTO(string stepName, string stepStatus, global::System.Guid workflowInstanceID, global::System.Nullable<int> workflowInstanceExecutionStatusEventID) {

          this.StepName = stepName;
          this.StepStatus = stepStatus;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceExecutionStatusEventID = workflowInstanceExecutionStatusEventID;
        }

        #endregion

        #region Properties

        [DataMember]
        public string StepName { get; set; }

        [DataMember]
        public string StepStatus { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceExecutionStatusEventID { get; set; }

        #endregion
    }

}
