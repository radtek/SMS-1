﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ApplicationStageWorkflowDTO
    {
        #region Constructors
  
        public ApplicationStageWorkflowDTO() {
        }

        public ApplicationStageWorkflowDTO(global::System.Guid applicationStageWorkflowID, global::System.Guid applicationStageID, global::System.Guid workflowID, int versionNumber, ApplicationStageDTO applicationStage, WorkflowDTO workflow) {

          this.ApplicationStageWorkflowID = applicationStageWorkflowID;
          this.ApplicationStageID = applicationStageID;
          this.WorkflowID = workflowID;
          this.VersionNumber = versionNumber;
          this.ApplicationStage = applicationStage;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ApplicationStageWorkflowID { get; set; }

        [DataMember]
        public global::System.Guid ApplicationStageID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int VersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ApplicationStageDTO ApplicationStage { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
