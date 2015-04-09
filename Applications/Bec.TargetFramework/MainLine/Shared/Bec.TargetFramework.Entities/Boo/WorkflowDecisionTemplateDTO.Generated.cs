﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class WorkflowDecisionTemplateDTO
    {
        #region Constructors
  
        public WorkflowDecisionTemplateDTO() {
        }

        public WorkflowDecisionTemplateDTO(global::System.Guid workflowDecisionTemplateID, string name, string description, bool isTransistionStart, bool isTransistionEnd, global::System.Nullable<System.Guid> workflowDecisionTypeTemplateID, global::System.Nullable<System.Guid> workflowObjectTypeTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, List<WorkflowDecisionExecuteCommandTemplateDTO> workflowDecisionExecuteCommandTemplates, List<WorkflowDecisionParameterTemplateDTO> workflowDecisionParameterTemplates, List<WorkflowDecisionErrorTemplateDTO> workflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowDecisionErrorTemplateDTO> workflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowDecisionFailureTemplateDTO> workflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowDecisionFailureTemplateDTO> workflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowDecisionSuccessTemplateDTO> workflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, List<WorkflowDecisionSuccessTemplateDTO> workflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber, WorkflowObjectTypeTemplateDTO workflowObjectTypeTemplate, WorkflowTemplateDTO workflowTemplate, List<WorkflowTransistionWorkflowDecisionTemplateDTO> workflowTransistionWorkflowDecisionTemplates) {

          this.WorkflowDecisionTemplateID = workflowDecisionTemplateID;
          this.Name = name;
          this.Description = description;
          this.IsTransistionStart = isTransistionStart;
          this.IsTransistionEnd = isTransistionEnd;
          this.WorkflowDecisionTypeTemplateID = workflowDecisionTypeTemplateID;
          this.WorkflowObjectTypeTemplateID = workflowObjectTypeTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowDecisionExecuteCommandTemplates = workflowDecisionExecuteCommandTemplates;
          this.WorkflowDecisionParameterTemplates = workflowDecisionParameterTemplates;
          this.WorkflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowObjectTypeTemplate = workflowObjectTypeTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowTransistionWorkflowDecisionTemplates = workflowTransistionWorkflowDecisionTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowDecisionTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsTransistionStart { get; set; }

        [DataMember]
        public bool IsTransistionEnd { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowDecisionTypeTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowObjectTypeTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowDecisionExecuteCommandTemplateDTO> WorkflowDecisionExecuteCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionParameterTemplateDTO> WorkflowDecisionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowDecisionErrorTemplateDTO> WorkflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionErrorTemplateDTO> WorkflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionFailureTemplateDTO> WorkflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionFailureTemplateDTO> WorkflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionSuccessTemplateDTO> WorkflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public List<WorkflowDecisionSuccessTemplateDTO> WorkflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public WorkflowObjectTypeTemplateDTO WorkflowObjectTypeTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowDecisionTemplateDTO> WorkflowTransistionWorkflowDecisionTemplates { get; set; }

        #endregion
    }

}
