﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class WorkflowActionParameterDTO
    {
        #region Constructors
  
        public WorkflowActionParameterDTO() {
        }

        public WorkflowActionParameterDTO(global::System.Guid workflowActionID, global::System.Guid workflowParameterID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowActionDTO workflowAction, WorkflowParameterDTO workflowParameter) {

          this.WorkflowActionID = workflowActionID;
          this.WorkflowParameterID = workflowParameterID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowAction = workflowAction;
          this.WorkflowParameter = workflowParameter;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionDTO WorkflowAction { get; set; }

        [DataMember]
        public WorkflowParameterDTO WorkflowParameter { get; set; }

        #endregion
    }

}
