﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
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
    public partial class WorkflowParameterTemplateDTO
    {
        #region Constructors
  
        public WorkflowParameterTemplateDTO() {
        }

        public WorkflowParameterTemplateDTO(global::System.Guid workflowParameterTemplateID, string name, string description, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, string objectType, string objectValue, WorkflowTemplateDTO workflowTemplate, List<WorkflowActionParameterTemplateDTO> workflowActionParameterTemplates, List<WorkflowCommandParameterTemplateDTO> workflowCommandParameterTemplates, List<WorkflowConditionParameterTemplateDTO> workflowConditionParameterTemplates, List<WorkflowDecisionParameterTemplateDTO> workflowDecisionParameterTemplates, List<WorkflowTransistionParameterTemplateDTO> workflowTransistionParameterTemplates, WorkflowMainParameterTemplateDTO workflowMainParameterTemplate) {

          this.WorkflowParameterTemplateID = workflowParameterTemplateID;
          this.Name = name;
          this.Description = description;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.ObjectType = objectType;
          this.ObjectValue = objectValue;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowActionParameterTemplates = workflowActionParameterTemplates;
          this.WorkflowCommandParameterTemplates = workflowCommandParameterTemplates;
          this.WorkflowConditionParameterTemplates = workflowConditionParameterTemplates;
          this.WorkflowDecisionParameterTemplates = workflowDecisionParameterTemplates;
          this.WorkflowTransistionParameterTemplates = workflowTransistionParameterTemplates;
          this.WorkflowMainParameterTemplate = workflowMainParameterTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowParameterTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public string ObjectType { get; set; }

        [DataMember]
        public string ObjectValue { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<WorkflowActionParameterTemplateDTO> WorkflowActionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandParameterTemplateDTO> WorkflowCommandParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowConditionParameterTemplateDTO> WorkflowConditionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionParameterTemplateDTO> WorkflowDecisionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionParameterTemplateDTO> WorkflowTransistionParameterTemplates { get; set; }

        [DataMember]
        public WorkflowMainParameterTemplateDTO WorkflowMainParameterTemplate { get; set; }

        #endregion
    }

}
