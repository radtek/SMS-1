﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class ArtefactWorkflowDTO
    {
        #region Constructors
  
        public ArtefactWorkflowDTO() {
        }

        public ArtefactWorkflowDTO(global::System.Guid artefactID, int artefactVersionNumber, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid artefactWorkflowID, bool isActive, bool isDeleted, ArtefactDTO artefact, WorkflowDTO workflow) {

          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.ArtefactWorkflowID = artefactWorkflowID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Artefact = artefact;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactID { get; set; }

        [DataMember]
        public int ArtefactVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ArtefactWorkflowID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactDTO Artefact { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
