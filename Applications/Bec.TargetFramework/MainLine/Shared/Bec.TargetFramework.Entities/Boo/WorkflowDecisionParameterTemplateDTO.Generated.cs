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
    public partial class WorkflowDecisionParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowDecisionParameterTemplateDTO() {
        }

        public WorkflowDecisionParameterTemplateDTO(global::System.Guid workflowDecisionTemplateID, global::System.Guid workflowParameterTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowDecisionTemplateDTO workflowDecisionTemplate, WorkflowParameterTemplateDTO workflowParameterTemplate) {

          this.WorkflowDecisionTemplateID = workflowDecisionTemplateID;
          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowDecisionTemplate = workflowDecisionTemplate;
          this.WorkflowParameterTemplate = workflowParameterTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDecisionTemplateDTO WorkflowDecisionTemplate { get; set; }

        [DataMember]
        public WorkflowParameterTemplateDTO WorkflowParameterTemplate { get; set; }

        #endregion
    }

}
