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
    public partial class WorkflowStatusTypeDTO
    {
        #region Constructors
  
        public WorkflowStatusTypeDTO() {
        }

        public WorkflowStatusTypeDTO(global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid statusTypeID, int statusTypeVersionNumber, bool isActive, bool isDeleted, StatusTypeDTO statusType, WorkflowDTO workflow) {

          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusType = statusType;
          this.Workflow = workflow;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        #endregion
    }

}
