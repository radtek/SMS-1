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
    public partial class WorkflowTransistionStartConditionTemplateDTO
    {
        #region Constructors
  
        public WorkflowTransistionStartConditionTemplateDTO() {
        }

        public WorkflowTransistionStartConditionTemplateDTO(global::System.Guid workflowTransistionTemplateID, global::System.Guid workflowConditionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowTransistionTemplateDTO workflowTransistionTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTransistionTemplateID = workflowTransistionTemplateID;
          this.WorkflowConditionTemplateID = workflowConditionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTransistionTemplate = workflowTransistionTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowConditionTemplateID { get; set; }

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

        #endregion
    }

}
