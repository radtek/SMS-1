﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class ModuleWorkflowDTO
    {
        #region Constructors
  
        public ModuleWorkflowDTO() {
        }

        public ModuleWorkflowDTO(global::System.Guid moduleWorkflowID, global::System.Guid workflowID, int workflowVersionNumber, global::System.Guid moduleID, bool isActive, bool isDeleted, bool appliesToAllOrganisations, bool appliesToAllUsers, int moduleVersionNumber, ModuleDTO module, WorkflowDTO workflow, List<ModuleWorkflowTargetDTO> moduleWorkflowTargets) {

          this.ModuleWorkflowID = moduleWorkflowID;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.ModuleID = moduleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.AppliesToAllOrganisations = appliesToAllOrganisations;
          this.AppliesToAllUsers = appliesToAllUsers;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.Module = module;
          this.Workflow = workflow;
          this.ModuleWorkflowTargets = moduleWorkflowTargets;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleWorkflowID { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool AppliesToAllOrganisations { get; set; }

        [DataMember]
        public bool AppliesToAllUsers { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleDTO Module { get; set; }

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public List<ModuleWorkflowTargetDTO> ModuleWorkflowTargets { get; set; }

        #endregion
    }

}
