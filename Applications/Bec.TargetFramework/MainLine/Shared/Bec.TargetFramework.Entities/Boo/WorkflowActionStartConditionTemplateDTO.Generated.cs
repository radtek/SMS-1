﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class WorkflowActionStartConditionTemplateDTO
    {
        #region Constructors
  
        public WorkflowActionStartConditionTemplateDTO() {
        }

        public WorkflowActionStartConditionTemplateDTO(global::System.Guid workflowActionTemplateID, global::System.Guid workflowConditionTemplateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate) {

          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.WorkflowConditionTemplateID = workflowConditionTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowConditionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        #endregion
    }

}
