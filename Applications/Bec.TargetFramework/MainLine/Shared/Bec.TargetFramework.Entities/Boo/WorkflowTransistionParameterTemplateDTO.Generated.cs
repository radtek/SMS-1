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
    public partial class WorkflowTransistionParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowTransistionParameterTemplateDTO() {
        }

        public WorkflowTransistionParameterTemplateDTO(global::System.Guid workflowTransistionTemplateID, global::System.Guid workflowParameterTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowTransistionTemplateDTO workflowTransistionTemplate, WorkflowTemplateDTO workflowTemplate, WorkflowParameterTemplateDTO workflowParameterTemplate) {

          this.WorkflowTransistionTemplateID = workflowTransistionTemplateID;
          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTransistionTemplate = workflowTransistionTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowParameterTemplate = workflowParameterTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTransistionTemplateDTO WorkflowTransistionTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public WorkflowParameterTemplateDTO WorkflowParameterTemplate { get; set; }

        #endregion
    }

}
