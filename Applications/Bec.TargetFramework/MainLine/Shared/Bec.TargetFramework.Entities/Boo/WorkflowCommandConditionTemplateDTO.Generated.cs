﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class WorkflowCommandConditionTemplateDTO
    {
        #region Constructors
  
        public WorkflowCommandConditionTemplateDTO() {
        }

        public WorkflowCommandConditionTemplateDTO(global::System.Guid workflowCommandTemplateID, global::System.Guid workflowConditionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowCommandTemplateDTO workflowCommandTemplate, WorkflowTemplateDTO workflowTemplate, WorkflowCommandTemplate1DTO workflowCommandTemplate1) {

          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.WorkflowConditionTemplateID = workflowConditionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowCommandTemplate = workflowCommandTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowCommandTemplate1 = workflowCommandTemplate1;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowConditionTemplateID { get; set; }

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
        public WorkflowCommandTemplate1DTO WorkflowCommandTemplate1 { get; set; }

        #endregion
    }

}
