﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class ArtefactDTO
    {
        #region Constructors
  
        public ArtefactDTO() {
        }

        public ArtefactDTO(global::System.Guid artefactID, int artefactVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Guid artefactTemplateID, int artefactTemplateVersionNumber, List<ArtefactProductDTO> artefactProducts, List<OrganisationArtefactDTO> organisationArtefacts, ArtefactTemplateDTO artefactTemplate, List<ArtefactSubscriptionDTO> artefactSubscriptions, List<ModuleArtefactDTO> moduleArtefacts, List<DefaultOrganisationArtefactDTO> defaultOrganisationArtefacts, List<ArtefactClaimDTO> artefactClaims, List<ArtefactNotificationConstructDTO> artefactNotificationConstructs, List<ArtefactDependencyDTO> artefactDependencies_ArtefactID_ArtefactVersionNumber, List<ArtefactWorkflowDTO> artefactWorkflows, List<ArtefactRoleDTO> artefactRoles, List<StatusTypeDTO> statusTypes, List<ArtefactDependencyDTO> artefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber) {

          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.ArtefactProducts = artefactProducts;
          this.OrganisationArtefacts = organisationArtefacts;
          this.ArtefactTemplate = artefactTemplate;
          this.ArtefactSubscriptions = artefactSubscriptions;
          this.ModuleArtefacts = moduleArtefacts;
          this.DefaultOrganisationArtefacts = defaultOrganisationArtefacts;
          this.ArtefactClaims = artefactClaims;
          this.ArtefactNotificationConstructs = artefactNotificationConstructs;
          this.ArtefactDependencies_ArtefactID_ArtefactVersionNumber = artefactDependencies_ArtefactID_ArtefactVersionNumber;
          this.ArtefactWorkflows = artefactWorkflows;
          this.ArtefactRoles = artefactRoles;
          this.StatusTypes = statusTypes;
          this.ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber = artefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactID { get; set; }

        [DataMember]
        public int ArtefactVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ArtefactTemplateID { get; set; }

        [DataMember]
        public int ArtefactTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ArtefactProductDTO> ArtefactProducts { get; set; }

        [DataMember]
        public List<OrganisationArtefactDTO> OrganisationArtefacts { get; set; }

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        [DataMember]
        public List<ArtefactSubscriptionDTO> ArtefactSubscriptions { get; set; }

        [DataMember]
        public List<ModuleArtefactDTO> ModuleArtefacts { get; set; }

        [DataMember]
        public List<DefaultOrganisationArtefactDTO> DefaultOrganisationArtefacts { get; set; }

        [DataMember]
        public List<ArtefactClaimDTO> ArtefactClaims { get; set; }

        [DataMember]
        public List<ArtefactNotificationConstructDTO> ArtefactNotificationConstructs { get; set; }

        [DataMember]
        public List<ArtefactDependencyDTO> ArtefactDependencies_ArtefactID_ArtefactVersionNumber { get; set; }

        [DataMember]
        public List<ArtefactWorkflowDTO> ArtefactWorkflows { get; set; }

        [DataMember]
        public List<ArtefactRoleDTO> ArtefactRoles { get; set; }

        [DataMember]
        public List<StatusTypeDTO> StatusTypes { get; set; }

        [DataMember]
        public List<ArtefactDependencyDTO> ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber { get; set; }

        #endregion
    }

}
