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
    public partial class WorkflowConditionParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowConditionParameterTemplateDTO() {
        }

        public WorkflowConditionParameterTemplateDTO(global::System.Guid workflowConditionTemplateID, global::System.Guid workflowParameterTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowTemplateDTO workflowTemplate, WorkflowParameterTemplateDTO workflowParameterTemplate) {

          this.WorkflowConditionTemplateID = workflowConditionTemplateID;
          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowParameterTemplate = workflowParameterTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowConditionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowParameterTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public WorkflowParameterTemplateDTO WorkflowParameterTemplate { get; set; }

        #endregion
    }

}
