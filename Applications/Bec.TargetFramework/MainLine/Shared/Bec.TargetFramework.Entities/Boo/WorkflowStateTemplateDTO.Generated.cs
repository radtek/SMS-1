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
    public partial class WorkflowStateTemplateDTO
    {
        #region Constructors
  
        public WorkflowStateTemplateDTO() {
        }

        public WorkflowStateTemplateDTO(global::System.Guid workflowStateID, global::System.Guid workflowTemplateID, int workflowTemplateVersionNumber, string stateName, string stateDescription, bool isActive, bool isDeleted, List<WorkflowStateActivityTemplateDTO> workflowStateActivityTemplates, WorkflowTemplateDTO workflowTemplate, List<WorkflowStateClaimTemplateDTO> workflowStateClaimTemplates, List<WorkflowStateActivityActionHierarchyTemplateDTO> workflowStateActivityActionHierarchyTemplates) {

          this.WorkflowStateID = workflowStateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.StateName = stateName;
          this.StateDescription = stateDescription;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowStateActivityTemplates = workflowStateActivityTemplates;
          this.WorkflowTemplate = workflowTemplate;
          this.WorkflowStateClaimTemplates = workflowStateClaimTemplates;
          this.WorkflowStateActivityActionHierarchyTemplates = workflowStateActivityActionHierarchyTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowStateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string StateDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<WorkflowStateActivityTemplateDTO> WorkflowStateActivityTemplates { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<WorkflowStateClaimTemplateDTO> WorkflowStateClaimTemplates { get; set; }

        [DataMember]
        public List<WorkflowStateActivityActionHierarchyTemplateDTO> WorkflowStateActivityActionHierarchyTemplates { get; set; }

        #endregion
    }

}
