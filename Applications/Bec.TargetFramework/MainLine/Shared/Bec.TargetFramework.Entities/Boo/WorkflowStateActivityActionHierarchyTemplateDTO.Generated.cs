//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 6/10/2014 2:36:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{

    [DataContractAttribute(IsReference=true)]
    public partial class WorkflowStateActivityActionHierarchyTemplateDTO
    {
        #region Constructors
  
        public WorkflowStateActivityActionHierarchyTemplateDTO() {
        }

        public WorkflowStateActivityActionHierarchyTemplateDTO(global::System.Guid workflowStateActivityActionHierarchyTemplateID, global::System.Guid workflowActivityTemplateID, global::System.Guid workflowActionStateID, global::System.Guid workflowStateTemplateID, int order, bool isActive, bool isDeleted, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, WorkflowStateTemplateDTO workflowStateTemplate, WorkflowActionTemplateDTO workflowActionTemplate, WorkflowActivityTemplateDTO workflowActivityTemplate, WorkflowTemplateDTO workflowTemplate) {

          this.WorkflowStateActivityActionHierarchyTemplateID = workflowStateActivityActionHierarchyTemplateID;
          this.WorkflowActivityTemplateID = workflowActivityTemplateID;
          this.WorkflowActionStateID = workflowActionStateID;
          this.WorkflowStateTemplateID = workflowStateTemplateID;
          this.Order = order;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.WorkflowStateTemplate = workflowStateTemplate;
          this.WorkflowActionTemplate = workflowActionTemplate;
          this.WorkflowActivityTemplate = workflowActivityTemplate;
          this.WorkflowTemplate = workflowTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowStateActivityActionHierarchyTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowActivityTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowActionStateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowStateTemplateID { get; set; }

        [DataMember]
        public int Order { get; set; }

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
        public WorkflowStateTemplateDTO WorkflowStateTemplate { get; set; }

        [DataMember]
        public WorkflowActionTemplateDTO WorkflowActionTemplate { get; set; }

        [DataMember]
        public WorkflowActivityTemplateDTO WorkflowActivityTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        #endregion
    }

}