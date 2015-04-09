﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class WorkflowTemplateDTO
    {
        #region Constructors
  
        public WorkflowTemplateDTO() {
        }

        public WorkflowTemplateDTO(global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, string name, string description, global::System.Nullable<int> workflowTypeID, global::System.Nullable<int> workflowSubTypeID, global::System.Nullable<int> workflowCategoryID, global::System.Nullable<int> workflowSubCategoryID, List<DefaultOrganisationWorkflowTemplateDTO> defaultOrganisationWorkflowTemplates, List<WorflowParameterTemplateDTO> worflowParameterTemplates, List<WorkflowClaimTemplateDTO> workflowClaimTemplates, List<WorkflowCommandConditionTemplateDTO> workflowCommandConditionTemplates, List<WorkflowCommandParameterTemplateDTO> workflowCommandParameterTemplates, List<WorkflowCommandTemplateDTO> workflowCommandTemplates, List<WorkflowTransistionCompleteConditionTemplateDTO> workflowTransistionCompleteConditionTemplates, List<WorkflowTransistionStartConditionTemplateDTO> workflowTransistionStartConditionTemplates, List<WorkflowTransistionWorkflowActionTemplateDTO> workflowTransistionWorkflowActionTemplates, List<WorkflowStatusTypeTemplateDTO> workflowStatusTypeTemplates, List<DefaultOrganisationUserTargetTemplateDTO> defaultOrganisationUserTargetTemplates, List<ModuleWorkflowTemplateDTO> moduleWorkflowTemplates, List<WorkflowConditionParameterTemplateDTO> workflowConditionParameterTemplates, List<WorkflowTransistionParameterTemplateDTO> workflowTransistionParameterTemplates, List<WorkflowTransistionHierarchyTemplateDTO> workflowTransistionHierarchyTemplates, List<WorkflowDTO> workflows, List<WorkflowDecisionTemplateDTO> workflowDecisionTemplates, List<WorkflowHierarchyTemplateDTO> workflowHierarchyTemplates, List<WorkflowObjectTypeTemplateDTO> workflowObjectTypeTemplates, List<WorkflowActionTemplateDTO> workflowActionTemplates, List<WorkflowTransistionTemplateDTO> workflowTransistionTemplates, List<WorkflowRoleTemplateDTO> workflowRoleTemplates, List<WorkflowNotificationConstructTemplateDTO> workflowNotificationConstructTemplates, List<ArtefactWorkflowTemplateDTO> artefactWorkflowTemplates, List<NotificationConstructGroupNotificationConstructTemplateDTO> notificationConstructGroupNotificationConstructTemplates, List<WorkflowParameterTemplateDTO> workflowParameterTemplates, List<WorkflowCommandTemplate1DTO> workflowCommandTemplate1s, List<WorkflowMainParameterTemplateDTO> workflowMainParameterTemplates) {

          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.WorkflowTypeID = workflowTypeID;
          this.WorkflowSubTypeID = workflowSubTypeID;
          this.WorkflowCategoryID = workflowCategoryID;
          this.WorkflowSubCategoryID = workflowSubCategoryID;
          this.DefaultOrganisationWorkflowTemplates = defaultOrganisationWorkflowTemplates;
          this.WorflowParameterTemplates = worflowParameterTemplates;
          this.WorkflowClaimTemplates = workflowClaimTemplates;
          this.WorkflowCommandConditionTemplates = workflowCommandConditionTemplates;
          this.WorkflowCommandParameterTemplates = workflowCommandParameterTemplates;
          this.WorkflowCommandTemplates = workflowCommandTemplates;
          this.WorkflowTransistionCompleteConditionTemplates = workflowTransistionCompleteConditionTemplates;
          this.WorkflowTransistionStartConditionTemplates = workflowTransistionStartConditionTemplates;
          this.WorkflowTransistionWorkflowActionTemplates = workflowTransistionWorkflowActionTemplates;
          this.WorkflowStatusTypeTemplates = workflowStatusTypeTemplates;
          this.DefaultOrganisationUserTargetTemplates = defaultOrganisationUserTargetTemplates;
          this.ModuleWorkflowTemplates = moduleWorkflowTemplates;
          this.WorkflowConditionParameterTemplates = workflowConditionParameterTemplates;
          this.WorkflowTransistionParameterTemplates = workflowTransistionParameterTemplates;
          this.WorkflowTransistionHierarchyTemplates = workflowTransistionHierarchyTemplates;
          this.Workflows = workflows;
          this.WorkflowDecisionTemplates = workflowDecisionTemplates;
          this.WorkflowHierarchyTemplates = workflowHierarchyTemplates;
          this.WorkflowObjectTypeTemplates = workflowObjectTypeTemplates;
          this.WorkflowActionTemplates = workflowActionTemplates;
          this.WorkflowTransistionTemplates = workflowTransistionTemplates;
          this.WorkflowRoleTemplates = workflowRoleTemplates;
          this.WorkflowNotificationConstructTemplates = workflowNotificationConstructTemplates;
          this.ArtefactWorkflowTemplates = artefactWorkflowTemplates;
          this.NotificationConstructGroupNotificationConstructTemplates = notificationConstructGroupNotificationConstructTemplates;
          this.WorkflowParameterTemplates = workflowParameterTemplates;
          this.WorkflowCommandTemplate1s = workflowCommandTemplate1s;
          this.WorkflowMainParameterTemplates = workflowMainParameterTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationWorkflowTemplateDTO> DefaultOrganisationWorkflowTemplates { get; set; }

        [DataMember]
        public List<WorflowParameterTemplateDTO> WorflowParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowClaimTemplateDTO> WorkflowClaimTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandConditionTemplateDTO> WorkflowCommandConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandParameterTemplateDTO> WorkflowCommandParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandTemplateDTO> WorkflowCommandTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionCompleteConditionTemplateDTO> WorkflowTransistionCompleteConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionStartConditionTemplateDTO> WorkflowTransistionStartConditionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionWorkflowActionTemplateDTO> WorkflowTransistionWorkflowActionTemplates { get; set; }

        [DataMember]
        public List<WorkflowStatusTypeTemplateDTO> WorkflowStatusTypeTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationUserTargetTemplateDTO> DefaultOrganisationUserTargetTemplates { get; set; }

        [DataMember]
        public List<ModuleWorkflowTemplateDTO> ModuleWorkflowTemplates { get; set; }

        [DataMember]
        public List<WorkflowConditionParameterTemplateDTO> WorkflowConditionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionParameterTemplateDTO> WorkflowTransistionParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionHierarchyTemplateDTO> WorkflowTransistionHierarchyTemplates { get; set; }

        [DataMember]
        public List<WorkflowDTO> Workflows { get; set; }

        [DataMember]
        public List<WorkflowDecisionTemplateDTO> WorkflowDecisionTemplates { get; set; }

        [DataMember]
        public List<WorkflowHierarchyTemplateDTO> WorkflowHierarchyTemplates { get; set; }

        [DataMember]
        public List<WorkflowObjectTypeTemplateDTO> WorkflowObjectTypeTemplates { get; set; }

        [DataMember]
        public List<WorkflowActionTemplateDTO> WorkflowActionTemplates { get; set; }

        [DataMember]
        public List<WorkflowTransistionTemplateDTO> WorkflowTransistionTemplates { get; set; }

        [DataMember]
        public List<WorkflowRoleTemplateDTO> WorkflowRoleTemplates { get; set; }

        [DataMember]
        public List<WorkflowNotificationConstructTemplateDTO> WorkflowNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<ArtefactWorkflowTemplateDTO> ArtefactWorkflowTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructGroupNotificationConstructTemplateDTO> NotificationConstructGroupNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<WorkflowParameterTemplateDTO> WorkflowParameterTemplates { get; set; }

        [DataMember]
        public List<WorkflowCommandTemplate1DTO> WorkflowCommandTemplate1s { get; set; }

        [DataMember]
        public List<WorkflowMainParameterTemplateDTO> WorkflowMainParameterTemplates { get; set; }

        #endregion
    }

}
