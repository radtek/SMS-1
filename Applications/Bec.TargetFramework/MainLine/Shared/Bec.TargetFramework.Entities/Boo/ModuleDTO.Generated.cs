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
    public partial class ModuleDTO
    {
        #region Constructors
  
        public ModuleDTO() {
        }

        public ModuleDTO(global::System.Guid moduleID, int moduleVersionNumber, string name, string description, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, bool isActive, bool isDeleted, ModuleTemplateDTO moduleTemplate, List<ModuleSubscriptionDTO> moduleSubscriptions, List<ModuleClaimDTO> moduleClaims, List<ModuleSettingDTO> moduleSettings, List<ModuleProductDTO> moduleProducts, List<ModuleWorkflowDTO> moduleWorkflows, List<ModuleDependencyDTO> moduleDependencies_DependencyID_DependencyVersionNumber, List<ModuleDependencyDTO> moduleDependencies_ModuleID_ModuleVersionNumber, List<ModuleStatusTypeDTO> moduleStatusTypes, List<DefaultOrganisationModuleDTO> defaultOrganisationModules, List<ModulePluginDTO> modulePlugins, List<ModuleArtefactDTO> moduleArtefacts, List<ModuleNotificationConstructDTO> moduleNotificationConstructs) {

          this.ModuleID = moduleID;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.Name = name;
          this.Description = description;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplate = moduleTemplate;
          this.ModuleSubscriptions = moduleSubscriptions;
          this.ModuleClaims = moduleClaims;
          this.ModuleSettings = moduleSettings;
          this.ModuleProducts = moduleProducts;
          this.ModuleWorkflows = moduleWorkflows;
          this.ModuleDependencies_DependencyID_DependencyVersionNumber = moduleDependencies_DependencyID_DependencyVersionNumber;
          this.ModuleDependencies_ModuleID_ModuleVersionNumber = moduleDependencies_ModuleID_ModuleVersionNumber;
          this.ModuleStatusTypes = moduleStatusTypes;
          this.DefaultOrganisationModules = defaultOrganisationModules;
          this.ModulePlugins = modulePlugins;
          this.ModuleArtefacts = moduleArtefacts;
          this.ModuleNotificationConstructs = moduleNotificationConstructs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

        [DataMember]
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public List<ModuleSubscriptionDTO> ModuleSubscriptions { get; set; }

        [DataMember]
        public List<ModuleClaimDTO> ModuleClaims { get; set; }

        [DataMember]
        public List<ModuleSettingDTO> ModuleSettings { get; set; }

        [DataMember]
        public List<ModuleProductDTO> ModuleProducts { get; set; }

        [DataMember]
        public List<ModuleWorkflowDTO> ModuleWorkflows { get; set; }

        [DataMember]
        public List<ModuleDependencyDTO> ModuleDependencies_DependencyID_DependencyVersionNumber { get; set; }

        [DataMember]
        public List<ModuleDependencyDTO> ModuleDependencies_ModuleID_ModuleVersionNumber { get; set; }

        [DataMember]
        public List<ModuleStatusTypeDTO> ModuleStatusTypes { get; set; }

        [DataMember]
        public List<DefaultOrganisationModuleDTO> DefaultOrganisationModules { get; set; }

        [DataMember]
        public List<ModulePluginDTO> ModulePlugins { get; set; }

        [DataMember]
        public List<ModuleArtefactDTO> ModuleArtefacts { get; set; }

        [DataMember]
        public List<ModuleNotificationConstructDTO> ModuleNotificationConstructs { get; set; }

        #endregion
    }

}
