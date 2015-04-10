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
    public partial class WorkflowTransistionHierarchyTemplateDTO
    {
        #region Constructors
  
        public WorkflowTransistionHierarchyTemplateDTO() {
        }

        public WorkflowTransistionHierarchyTemplateDTO(global::System.Guid workflowTransistionHierarchyTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, global::System.Guid childComponentID, global::System.Nullable<System.Guid> parentComponentID, bool isWorkflowStart, bool isWorkflowEnd, WorkflowTransistionTemplateDTO workflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber, WorkflowTransistionTemplateDTO workflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowTransistionHierarchyTemplateID = workflowTransistionHierarchyTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.ChildComponentID = childComponentID;
          this.ParentComponentID = parentComponentID;
          this.IsWorkflowStart = isWorkflowStart;
          this.IsWorkflowEnd = isWorkflowEnd;
          this.WorkflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = workflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionHierarchyTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ChildComponentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentComponentID { get; set; }

        [DataMember]
        public bool IsWorkflowStart { get; set; }

        [DataMember]
        public bool IsWorkflowEnd { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowTransistionTemplateDTO WorkflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public WorkflowTransistionTemplateDTO WorkflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}
