﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class WorkflowTreeStructureActionTemplateDTO
    {
        #region Constructors
  
        public WorkflowTreeStructureActionTemplateDTO() {
        }

        public WorkflowTreeStructureActionTemplateDTO(global::System.Guid workflowTreeStructureActionTemplateID, global::System.Nullable<System.Guid> workflowTreeStructureTemplateID, global::System.Nullable<System.Guid> workflowActionTemplateID, global::System.Nullable<bool> isVisible, bool isActive, bool isDeleted, string conditionString) {

          this.WorkflowTreeStructureActionTemplateID = workflowTreeStructureActionTemplateID;
          this.WorkflowTreeStructureTemplateID = workflowTreeStructureTemplateID;
          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.IsVisible = isVisible;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ConditionString = conditionString;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowTreeStructureActionTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowTreeStructureTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsVisible { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string ConditionString { get; set; }

        #endregion
    }

}
