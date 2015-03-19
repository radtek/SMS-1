﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class WorkflowCommandParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowCommandParameterTemplateDTO() {
        }

        public WorkflowCommandParameterTemplateDTO(global::System.Guid workflowCommandTemplateID, global::System.Guid workflowParameterTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowCommandTemplateDTO workflowCommandTemplate, WorkflowParameterTemplateDTO workflowParameterTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowCommandTemplate = workflowCommandTemplate;
          this.WorkflowParameterTemplate = workflowParameterTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowCommandTemplateDTO WorkflowCommandTemplate { get; set; }

        [DataMember]
        public WorkflowParameterTemplateDTO WorkflowParameterTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
