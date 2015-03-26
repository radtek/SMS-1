﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class WorkflowTransistionCompleteConditionDTO
    {
        #region Constructors
  
        public WorkflowTransistionCompleteConditionDTO() {
        }

        public WorkflowTransistionCompleteConditionDTO(global::System.Guid workflowTransistionID, global::System.Guid workflowConditionID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDTO workflow, WorkflowTransistionDTO workflowTransistion) {

          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowConditionID = workflowConditionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowTransistion = workflowTransistion;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowConditionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowTransistionDTO WorkflowTransistion { get; set; }

        #endregion
    }

}
