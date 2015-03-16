﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class WorkflowCommandTemplateDTO
    {
        #region Constructors
  
        public WorkflowCommandTemplateDTO() {
        }

        public WorkflowCommandTemplateDTO(global::System.Guid workflowCommandTemplateID, string name, string description, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Nullable<System.Guid> workflowObjectTypeTemplateID, List<WorkflowCommandConditionTemplateDTO> workflowCommandConditionTemplates, List<WorkflowCommandParameterTemplateDTO> workflowCommandParameterTemplates, WorkflowObjectTypeTemplateDTO workflowObjectTypeTemplate, WorkflowTemplateDTO workflowTemplate, WorkflowMainExecuteCommandTemplateDTO workflowMainExecuteCommandTemplate, WorkflowMainPostCommandTemplateDTO workflowMainPostCommandTemplate, WorkflowMainPreCommandTemplateDTO workflowMainPreCommandTemplate, List<WorkflowActionExecuteCommandTemplateDTO> workflowActionExecuteCommandTemplates, List<WorkflowActionPostCommandTemplateDTO> workflowActionPostCommandTemplates, List<WorkflowActionPreCommandTemplateDTO> workflowActionPreCommandTemplates) {

          this.WorkflowCommandTemplateID = workflowCommandTemplateID;
          this.Name = name;
          this.Description = description;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowObjectTypeTemplateID = workflowObjectTypeTemplateID;
          this.WorkflowCommandConditionTemplates = workflowCommandConditionTemplates;
          this.WorkflowCommandParameterTemplates = workflowCommandParameterTemplates;
          this.WorkflowObjectTypeTemplate = workflowObjectTypeTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowMainExecuteCommandTemplate = workflowMainExecuteCommandTemplate;
          this.WorkflowMainPostCommandTemplate = workflowMainPostCommandTemplate;
          this.WorkflowMainPreCommandTemplate = workflowMainPreCommandTemplate;
          this.WorkflowActionExecuteCommandTemplates = workflowActionExecuteCommandTemplates;
          this.WorkflowActionPostCommandTemplates = workflowActionPostCommandTemplates;
          this.WorkflowActionPreCommandTemplates = workflowActionPreCommandTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowCommandTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowObjectTypeTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowCommandConditionTemplateDTO> WorkflowCommandConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandParameterTemplateDTO> WorkflowCommandParameterTemplates { get; set; }

        [DataMember]
        public WorkflowObjectTypeTemplateDTO WorkflowObjectTypeTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public WorkflowMainExecuteCommandTemplateDTO WorkflowMainExecuteCommandTemplate { get; set; }

        [DataMember]
        public WorkflowMainPostCommandTemplateDTO WorkflowMainPostCommandTemplate { get; set; }

        [DataMember]
        public WorkflowMainPreCommandTemplateDTO WorkflowMainPreCommandTemplate { get; set; }

        [DataMember]
        public List<WorkflowActionExecuteCommandTemplateDTO> WorkflowActionExecuteCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionPostCommandTemplateDTO> WorkflowActionPostCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionPreCommandTemplateDTO> WorkflowActionPreCommandTemplates { get; set; }

        #endregion
    }

}
