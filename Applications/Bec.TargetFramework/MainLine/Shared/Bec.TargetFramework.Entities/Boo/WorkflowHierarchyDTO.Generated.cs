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
    public partial class WorkflowHierarchyDTO
    {
        #region Constructors
  
        public WorkflowHierarchyDTO() {
        }

        public WorkflowHierarchyDTO(global::System.Guid workflowHierarchyID, global::System.Guid childComponentID, global::System.Nullable<System.Guid> parentComponentID, global::System.Nullable<bool> isTransistionStart, global::System.Nullable<bool> isTranistionEnd, global::System.Guid workflowTransistionID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Nullable<bool> isChildDependentOnParent, WorkflowDTO workflow, WorkflowTransistionDTO workflowTransistion) {

          this.WorkflowHierarchyID = workflowHierarchyID;
          this.ChildComponentID = childComponentID;
          this.ParentComponentID = parentComponentID;
          this.IsTransistionStart = isTransistionStart;
          this.IsTranistionEnd = isTranistionEnd;
          this.WorkflowTransistionID = workflowTransistionID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.IsChildDependentOnParent = isChildDependentOnParent;
          this.Workflow = workflow;
          this.WorkflowTransistion = workflowTransistion;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowHierarchyID { get; set; }

        [DataMember]
        public global::System.Guid ChildComponentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentComponentID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsTransistionStart { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsTranistionEnd { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTransistionID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsChildDependentOnParent { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public WorkflowTransistionDTO WorkflowTransistion { get; set; }

        #endregion
    }

}
