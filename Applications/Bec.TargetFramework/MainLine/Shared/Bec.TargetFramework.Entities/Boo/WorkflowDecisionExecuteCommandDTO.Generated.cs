﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class WorkflowDecisionExecuteCommandDTO
    {
        #region Constructors
  
        public WorkflowDecisionExecuteCommandDTO() {
        }

        public WorkflowDecisionExecuteCommandDTO(global::System.Guid workflowDecisionID, global::System.Guid workflowCommandID, global::System.Guid workflowID, int workflowVersionNumber, WorkflowDecisionDTO workflowDecision) {

          this.WorkflowDecisionID = workflowDecisionID;
          this.WorkflowCommandID = workflowCommandID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.WorkflowDecision = workflowDecision;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowCommandID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDecisionDTO WorkflowDecision { get; set; }

        #endregion
    }

}
