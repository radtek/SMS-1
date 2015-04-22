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
    public partial class WorkflowActionProductPlaceholderDTO
    {
        #region Constructors
  
        public WorkflowActionProductPlaceholderDTO() {
        }

        public WorkflowActionProductPlaceholderDTO(global::System.Guid workflowActionProductPlaceholderID, global::System.Guid workflowActionTemplateID, global::System.Guid productTypeID, global::System.Nullable<int> order, bool isActive, bool isDeleted, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowActionTemplateDTO workflowActionTemplate) {

          this.WorkflowActionProductPlaceholderID = workflowActionProductPlaceholderID;
          this.WorkflowActionTemplateID = workflowActionTemplateID;
          this.ProductTypeID = productTypeID;
          this.Order = order;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowActionTemplate = workflowActionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowActionProductPlaceholderID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowActionTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> Order { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

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
