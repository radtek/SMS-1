﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class ArtefactWorkflowTemplateDTO
    {
        #region Constructors
  
        public ArtefactWorkflowTemplateDTO() {
        }

        public ArtefactWorkflowTemplateDTO(global::System.Guid artefactTemplateID, int artefactTemplateVersionNumber, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Guid artefactWorkflowTemplateID, bool isActive, bool isDeleted, ArtefactTemplateDTO artefactTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.ArtefactWorkflowTemplateID = artefactWorkflowTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactTemplate = artefactTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactTemplateID { get; set; }

        [DataMember]
        public int ArtefactTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ArtefactWorkflowTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
