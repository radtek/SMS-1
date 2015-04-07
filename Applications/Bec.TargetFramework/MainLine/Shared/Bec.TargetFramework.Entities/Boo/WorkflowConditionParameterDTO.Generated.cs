﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class WorkflowConditionParameterDTO
    {
        #region Constructors
  
        public WorkflowConditionParameterDTO() {
        }

        public WorkflowConditionParameterDTO(global::System.Guid workflowConditionID, global::System.Guid workflowParameterID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowParameterDTO workflowParameter) {

          this.WorkflowConditionID = workflowConditionID;
          this.WorkflowParameterID = workflowParameterID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowParameter = workflowParameter;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowConditionID { get; set; }

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

        #endregion
    }

}
