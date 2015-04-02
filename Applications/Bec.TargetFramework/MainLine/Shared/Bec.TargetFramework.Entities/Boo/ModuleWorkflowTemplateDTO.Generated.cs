﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class ModuleWorkflowTemplateDTO
    {
        #region Constructors
  
        public ModuleWorkflowTemplateDTO() {
        }

        public ModuleWorkflowTemplateDTO(global::System.Guid moduleWorkflowTemplateID, global::System.Guid moduleTemplateID, global::System.Guid workflowTemplateID, bool isActive, bool isDeleted, bool appliesToAllOrganisations, bool appliesToAllUsers, int moduleTemplateVersionNumber, int workflowTemplateVersionNumber, ModuleTemplateDTO moduleTemplate, WorkflowTemplateDTO workflowTemplate, List<ModuleWorkflowTargetTemplateDTO> moduleWorkflowTargetTemplates) {

          this.ModuleWorkflowTemplateID = moduleWorkflowTemplateID;
          this.ModuleTemplateID = moduleTemplateID;
          this.WorkflowTemplateID = workflowTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AppliesToAllOrganisations = appliesToAllOrganisations;
          this.AppliesToAllUsers = appliesToAllUsers;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.WorkflowTemplateVersionNumber = workflowTemplateVersionNumber;
          this.ModuleTemplate = moduleTemplate;
          this.WorkflowTemplate = workflowTemplate;
          this.ModuleWorkflowTargetTemplates = moduleWorkflowTargetTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleWorkflowTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool AppliesToAllOrganisations { get; set; }

        [DataMember]
        public bool AppliesToAllUsers { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public int WorkflowTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public WorkflowTemplateDTO WorkflowTemplate { get; set; }

        [DataMember]
        public List<ModuleWorkflowTargetTemplateDTO> ModuleWorkflowTargetTemplates { get; set; }

        #endregion
    }

}
