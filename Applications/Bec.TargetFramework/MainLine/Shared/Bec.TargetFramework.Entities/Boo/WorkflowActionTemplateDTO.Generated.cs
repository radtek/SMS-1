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
    public partial class WorkflowActionTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionTemplateDTO() {
        }

        public WorkflowActionTemplateDTO(global::System.Guid workflowActionTemplateID, string name, string description, bool isTransistionStart, bool isTransistionEnd, global::System.Nullable<System.Guid> workflowActionTypeTemplateID, bool isManual, global::System.Nullable<System.Guid> workflowObjectTypeTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, List<WorkflowTransistionWorkflowActionTemplateDTO> workflowTransistionWorkflowActionTemplates, List<WorkflowActionExecuteCommandTemplateDTO> workflowActionExecuteCommandTemplates, List<WorkflowActionCompleteConditionTemplateDTO> workflowActionCompleteConditionTemplates, List<WorkflowActionPostCommandTemplateDTO> workflowActionPostCommandTemplates, List<WorkflowActionPreCommandTemplateDTO> workflowActionPreCommandTemplates, List<WorkflowActionParameterTemplateDTO> workflowActionParameterTemplates, List<WorkflowDecisionErrorTemplateDTO> workflowDecisionErrorTemplates, List<WorkflowActionExecutionTemplateDTO> workflowActionExecutionTemplates, List<WorkflowActionNotificationTemplateDTO> workflowActionNotificationTemplates, List<WorkflowActionProductPlaceholderDTO> workflowActionProductPlaceholders, List<WorkflowActionStartConditionTemplateDTO> workflowActionStartConditionTemplates, List<WorkflowActionValidationTemplateDTO> workflowActionValidationTemplates, List<WorkflowDecisionFailureTemplateDTO> workflowDecisionFailureTemplates, List<WorkflowDecisionSuccessTemplateDTO> workflowDecisionSuccessTemplates, WorkflowObjectTypeTemplateDTO workflowObjectTypeTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.Name = name;
          this.Description = description;
          this.IsTransistionStart = isTransistionStart;
          this.IsTransistionEnd = isTransistionEnd;
          this.WorkflowActionTypeTemplateID = workflowActionTypeTemplateID;
          this.IsManual = isManual;
          this.WorkflowObjectTypeTemplateID = workflowObjectTypeTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowTransistionWorkflowActionTemplates = workflowTransistionWorkflowActionTemplates;
          this.WorkflowActionExecuteCommandTemplates = workflowActionExecuteCommandTemplates;
          this.WorkflowActionCompleteConditionTemplates = workflowActionCompleteConditionTemplates;
          this.WorkflowActionPostCommandTemplates = workflowActionPostCommandTemplates;
          this.WorkflowActionPreCommandTemplates = workflowActionPreCommandTemplates;
          this.WorkflowActionParameterTemplates = workflowActionParameterTemplates;
          this.WorkflowDecisionErrorTemplates = workflowDecisionErrorTemplates;
          this.WorkflowActionExecutionTemplates = workflowActionExecutionTemplates;
          this.WorkflowActionNotificationTemplates = workflowActionNotificationTemplates;
          this.WorkflowActionProductPlaceholders = workflowActionProductPlaceholders;
          this.WorkflowActionStartConditionTemplates = workflowActionStartConditionTemplates;
          this.WorkflowActionValidationTemplates = workflowActionValidationTemplates;
          this.WorkflowDecisionFailureTemplates = workflowDecisionFailureTemplates;
          this.WorkflowDecisionSuccessTemplates = workflowDecisionSuccessTemplates;
          this.WorkflowObjectTypeTemplate = workflowObjectTypeTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsTransistionStart { get; set; }

        [DataMember]
        public bool IsTransistionEnd { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowActionTypeTemplateID { get; set; }

        [DataMember]
        public bool IsManual { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowObjectTypeTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowTransistionWorkflowActionTemplateDTO> WorkflowTransistionWorkflowActionTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionExecuteCommandTemplateDTO> WorkflowActionExecuteCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionCompleteConditionTemplateDTO> WorkflowActionCompleteConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionPostCommandTemplateDTO> WorkflowActionPostCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionPreCommandTemplateDTO> WorkflowActionPreCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionParameterTemplateDTO> WorkflowActionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionErrorTemplateDTO> WorkflowDecisionErrorTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionExecutionTemplateDTO> WorkflowActionExecutionTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionNotificationTemplateDTO> WorkflowActionNotificationTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionProductPlaceholderDTO> WorkflowActionProductPlaceholders { get; set; }

        [DataMember]
        public List<WorkflowActionStartConditionTemplateDTO> WorkflowActionStartConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionValidationTemplateDTO> WorkflowActionValidationTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionFailureTemplateDTO> WorkflowDecisionFailureTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionSuccessTemplateDTO> WorkflowDecisionSuccessTemplates { get; set; }

        [DataMember]
        public WorkflowObjectTypeTemplateDTO WorkflowObjectTypeTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
