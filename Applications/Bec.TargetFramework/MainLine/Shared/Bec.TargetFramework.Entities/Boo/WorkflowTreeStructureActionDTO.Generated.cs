﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class WorkflowTreeStructureActionDTO
    {
        #region Constructors
  
        public WorkflowTreeStructureActionDTO() {
        }

        public WorkflowTreeStructureActionDTO(global::System.Guid workflowTreeStructureActionID, global::System.Nullable<System.Guid> workflowTreeStructureID, global::System.Nullable<System.Guid> workflowActionID, global::System.Nullable<bool> isVisible, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, string conditionString) {

          this.WorkflowTreeStructureActionID = workflowTreeStructureActionID;
          this.WorkflowTreeStructureID = workflowTreeStructureID;
          this.WorkflowActionID = workflowActionID;
          this.IsVisible = isVisible;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ConditionString = conditionString;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTreeStructureActionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowTreeStructureID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowActionID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsVisible { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public string ConditionString { get; set; }

        #endregion
    }

}
