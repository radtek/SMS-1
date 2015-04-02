﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class VWorkflowInstanceRetryDTO
    {
        #region Constructors
  
        public VWorkflowInstanceRetryDTO() {
        }

        public VWorkflowInstanceRetryDTO(global::System.Guid workflowID, int workflowVersionNumber, string name, global::System.Guid workflowInstanceID, global::System.Guid workflowInstanceSessionID, global::System.Nullable<System.Guid> previousStepID, string previousStepName, global::System.Nullable<System.Guid> stepID, string stepName, global::System.DateTime sessionStartedOn, global::System.Nullable<long> count) {

          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Name = name;
          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowInstanceSessionID = workflowInstanceSessionID;
          this.PreviousStepID = previousStepID;
          this.PreviousStepName = previousStepName;
          this.StepID = stepID;
          this.StepName = stepName;
          this.SessionStartedOn = sessionStartedOn;
          this.Count = count;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowInstanceSessionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PreviousStepID { get; set; }

        [DataMember]
        public string PreviousStepName { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StepID { get; set; }

        [DataMember]
        public string StepName { get; set; }

        [DataMember]
        public global::System.DateTime SessionStartedOn { get; set; }

        [DataMember]
        public global::System.Nullable<long> Count { get; set; }

        #endregion
    }

}
