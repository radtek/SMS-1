﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class WorkflowMainParameterDTO
    {
        #region Constructors
  
        public WorkflowMainParameterDTO() {
        }

        public WorkflowMainParameterDTO(global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid workflowParameterID, WorkflowDTO workflow, WorkflowParameterDTO workflowParameter) {

          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowParameterID = workflowParameterID;
          this.Workflow = workflow;
          this.WorkflowParameter = workflowParameter;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowParameterDTO WorkflowParameter { get; set; }

        #endregion
    }

}
