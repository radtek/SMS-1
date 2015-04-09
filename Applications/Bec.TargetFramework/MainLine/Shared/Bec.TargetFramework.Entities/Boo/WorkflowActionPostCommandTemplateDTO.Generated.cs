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
    public partial class WorkflowActionPostCommandTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionPostCommandTemplateDTO() {
        }

        public WorkflowActionPostCommandTemplateDTO(global::System.Guid workflowActionTemplateID, global::System.Guid workflowCommandTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowCommandTemplateDTO workflowCommandTemplate, WorkflowCommandTemplate1DTO workflowCommandTemplate1) {

          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowCommandTemplate = workflowCommandTemplate;
          this.WorkflowCommandTemplate1 = workflowCommandTemplate1;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowCommandTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowCommandTemplateDTO WorkflowCommandTemplate { get; set; }

        [DataMember]
        public WorkflowCommandTemplate1DTO WorkflowCommandTemplate1 { get; set; }

        #endregion
    }

}
