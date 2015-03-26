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
    public partial class WorkflowTransistionTemplateDTO
    {
        #region Constructors
  
        public WorkflowTransistionTemplateDTO() {
        }

        public WorkflowTransistionTemplateDTO(global::System.Guid workflowTransistionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, string name, string description, bool isWorkflowStart, bool isWorkflowEnd, List<WorkflowTransistionCompleteConditionTemplateDTO> workflowTransistionCompleteConditionTemplates, List<WorkflowTransistionStartConditionTemplateDTO> workflowTransistionStartConditionTemplates, List<WorkflowTransistionWorkflowActionTemplateDTO> workflowTransistionWorkflowActionTemplates, List<WorkflowTransistionParameterTemplateDTO> workflowTransistionParameterTemplates, List<WorkflowTransistionHierarchyTemplateDTO> workflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowTransistionHierarchyTemplateDTO> workflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowTransistionWorkflowDecisionTemplateDTO> workflowTransistionWorkflowDecisionTemplates, List<WorkflowHierarchyTemplateDTO> workflowHierarchyTemplates, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTransistionTemplateID = workflowTransistionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsWorkflowStart = isWorkflowStart;
          this.IsWorkflowEnd = isWorkflowEnd;
          this.WorkflowTransistionCompleteConditionTemplates = workflowTransistionCompleteConditionTemplates;
          this.WorkflowTransistionStartConditionTemplates = workflowTransistionStartConditionTemplates;
          this.WorkflowTransistionWorkflowActionTemplates = workflowTransistionWorkflowActionTemplates;
          this.WorkflowTransistionParameterTemplates = workflowTransistionParameterTemplates;
          this.WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowTransistionWorkflowDecisionTemplates = workflowTransistionWorkflowDecisionTemplates;
          this.WorkflowHierarchyTemplates = workflowHierarchyTemplates;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsWorkflowStart { get; set; }

        [DataMember]
        public bool IsWorkflowEnd { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowTransistionCompleteConditionTemplateDTO> WorkflowTransistionCompleteConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionStartConditionTemplateDTO> WorkflowTransistionStartConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowActionTemplateDTO> WorkflowTransistionWorkflowActionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionParameterTemplateDTO> WorkflowTransistionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionHierarchyTemplateDTO> WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowTransistionHierarchyTemplateDTO> WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowDecisionTemplateDTO> WorkflowTransistionWorkflowDecisionTemplates { get; set; }

        [DataMember]
        public List<WorkflowHierarchyTemplateDTO> WorkflowHierarchyTemplates { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
