﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class WorkflowTransistionHierarchyDTO
    {
        #region Constructors
  
        public WorkflowTransistionHierarchyDTO() {
        }

        public WorkflowTransistionHierarchyDTO(global::System.Guid workflowTransistionHierarchyID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid childComponentID, global::System.Nullable<System.Guid> parentComponentID, bool isWorkflowStart, bool isWorkflowEnd, WorkflowTransistionDTO workflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber, WorkflowDTO workflow, WorkflowTransistionDTO workflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber) {

          this.WorkflowTransistionHierarchyID = workflowTransistionHierarchyID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.ChildComponentID = childComponentID;
          this.ParentComponentID = parentComponentID;
          this.IsWorkflowStart = isWorkflowStart;
          this.IsWorkflowEnd = isWorkflowEnd;
          this.WorkflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber = workflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber;
          this.Workflow = workflow;
          this.WorkflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber = workflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTransistionHierarchyID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

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
        public WorkflowTransistionDTO WorkflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowTransistionDTO WorkflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber { get; set; }

        #endregion
    }

}
