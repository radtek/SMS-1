﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class WorkflowInstanceDTO
    {
        #region Constructors
  
        public WorkflowInstanceDTO() {
        }

        public WorkflowInstanceDTO(global::System.Guid workflowInstanceID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid parentID, int workflowInstanceStatusID, global::System.Nullable<int> workflowInstanceTypeID, global::System.Nullable<int> workflowInstanceSubTypeID, global::System.Nullable<int> workflowInstanceCategoryID, global::System.Nullable<int> workflowInstanceSubCategoryID, string workflowInstanceTempData, WorkflowDTO workflow, List<WorkflowInstanceRestrictionDTO> workflowInstanceRestrictions, List<WorkflowInstanceSessionDTO> workflowInstanceSessions) {

          this.WorkflowInstanceID = workflowInstanceID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.ParentID = parentID;
          this.WorkflowInstanceStatusID = workflowInstanceStatusID;
          this.WorkflowInstanceTypeID = workflowInstanceTypeID;
          this.WorkflowInstanceSubTypeID = workflowInstanceSubTypeID;
          this.WorkflowInstanceCategoryID = workflowInstanceCategoryID;
          this.WorkflowInstanceSubCategoryID = workflowInstanceSubCategoryID;
          this.WorkflowInstanceTempData = workflowInstanceTempData;
          this.Workflow = workflow;
          this.WorkflowInstanceRestrictions = workflowInstanceRestrictions;
          this.WorkflowInstanceSessions = workflowInstanceSessions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowInstanceID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public int WorkflowInstanceStatusID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> WorkflowInstanceSubCategoryID { get; set; }

        [DataMember]
        public string WorkflowInstanceTempData { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public List<WorkflowInstanceRestrictionDTO> WorkflowInstanceRestrictions { get; set; }

        [DataMember]
        public List<WorkflowInstanceSessionDTO> WorkflowInstanceSessions { get; set; }

        #endregion
    }

}
