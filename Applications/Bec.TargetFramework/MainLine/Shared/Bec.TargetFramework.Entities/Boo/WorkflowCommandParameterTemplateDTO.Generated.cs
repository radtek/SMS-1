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
    public partial class WorkflowCommandParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowCommandParameterTemplateDTO() {
        }

        public WorkflowCommandParameterTemplateDTO(global::System.Guid workflowCommandTemplateID, global::System.Guid workflowParameterTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowCommandTemplateDTO workflowCommandTemplate, WorkflowTemplateDTO workflowTemplate, WorkflowParameterTemplateDTO workflowParameterTemplate, WorkflowCommandTemplate1DTO workflowCommandTemplate1) {

          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowCommandTemplate = workflowCommandTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowParameterTemplate = workflowParameterTemplate;
          this.WorkflowCommandTemplate1 = workflowCommandTemplate1;
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
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public WorkflowParameterTemplateDTO WorkflowParameterTemplate { get; set; }

        [DataMember]
        public WorkflowCommandTemplate1DTO WorkflowCommandTemplate1 { get; set; }

        #endregion
    }

}
