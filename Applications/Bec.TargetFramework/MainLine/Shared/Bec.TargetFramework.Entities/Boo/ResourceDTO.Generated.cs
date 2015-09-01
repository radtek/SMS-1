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
    public partial class ResourceDTO
    {
        #region Constructors
  
        public ResourceDTO() {
        }

        public ResourceDTO(global::System.Guid resourceID, string resourceName, string resourceDescription, global::System.Nullable<System.Guid> sourceID, global::System.Nullable<int> resourceTypeID, global::System.Nullable<int> resourceCategoryID, global::System.Nullable<int> resourceSubCategoryID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, List<ModuleClaimDTO> moduleClaims, List<DefaultOrganisationRoleClaimDTO> defaultOrganisationRoleClaims, List<OrganisationRoleClaimDTO> organisationRoleClaims, List<ProductClaimDTO> productClaims, List<DefaultOrganisationRoleClaimTemplateDTO> defaultOrganisationRoleClaimTemplates, List<ProductClaimTemplateDTO> productClaimTemplates, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates, List<ModuleClaimTemplateDTO> moduleClaimTemplates, List<NotificationConstructClaimDTO> notificationConstructClaims, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, List<StatusTypeClaimDTO> statusTypeClaims, List<ArtefactClaimTemplateDTO> artefactClaimTemplates, List<ArtefactClaimDTO> artefactClaims, List<RoleClaimDTO> roleClaims, List<OperationDTO> operations, List<ActorClaimRoleMappingDTO> actorClaimRoleMappings, List<ResourceOperationTargetDTO> resourceOperationTargets) {

          this.ResourceID = resourceID;
          this.ResourceName = resourceName;
          this.ResourceDescription = resourceDescription;
          this.SourceID = sourceID;
          this.ResourceTypeID = resourceTypeID;
          this.ResourceCategoryID = resourceCategoryID;
          this.ResourceSubCategoryID = resourceSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.ModuleClaims = moduleClaims;
          this.DefaultOrganisationRoleClaims = defaultOrganisationRoleClaims;
          this.OrganisationRoleClaims = organisationRoleClaims;
          this.ProductClaims = productClaims;
          this.DefaultOrganisationRoleClaimTemplates = defaultOrganisationRoleClaimTemplates;
          this.ProductClaimTemplates = productClaimTemplates;
          this.StatusTypeClaimTemplates = statusTypeClaimTemplates;
          this.ModuleClaimTemplates = moduleClaimTemplates;
          this.NotificationConstructClaims = notificationConstructClaims;
          this.NotificationConstructClaimTemplates = notificationConstructClaimTemplates;
          this.StatusTypeClaims = statusTypeClaims;
          this.ArtefactClaimTemplates = artefactClaimTemplates;
          this.ArtefactClaims = artefactClaims;
          this.RoleClaims = roleClaims;
          this.Operations = operations;
          this.ActorClaimRoleMappings = actorClaimRoleMappings;
          this.ResourceOperationTargets = resourceOperationTargets;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ResourceID { get; set; }

        [DataMember]
        public string ResourceName { get; set; }

        [DataMember]
        public string ResourceDescription { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> SourceID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ModuleClaimDTO> ModuleClaims { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleClaimDTO> DefaultOrganisationRoleClaims { get; set; }

        [DataMember]
        public List<OrganisationRoleClaimDTO> OrganisationRoleClaims { get; set; }

        [DataMember]
        public List<ProductClaimDTO> ProductClaims { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleClaimTemplateDTO> DefaultOrganisationRoleClaimTemplates { get; set; }

        [DataMember]
        public List<ProductClaimTemplateDTO> ProductClaimTemplates { get; set; }

        [DataMember]
        public List<StatusTypeClaimTemplateDTO> StatusTypeClaimTemplates { get; set; }

        [DataMember]
        public List<ModuleClaimTemplateDTO> ModuleClaimTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructClaimDTO> NotificationConstructClaims { get; set; }

        [DataMember]
        public List<NotificationConstructClaimTemplateDTO> NotificationConstructClaimTemplates { get; set; }

        [DataMember]
        public List<StatusTypeClaimDTO> StatusTypeClaims { get; set; }

        [DataMember]
        public List<ArtefactClaimTemplateDTO> ArtefactClaimTemplates { get; set; }

        [DataMember]
        public List<ArtefactClaimDTO> ArtefactClaims { get; set; }

        [DataMember]
        public List<RoleClaimDTO> RoleClaims { get; set; }

        [DataMember]
        public List<OperationDTO> Operations { get; set; }

        [DataMember]
        public List<ActorClaimRoleMappingDTO> ActorClaimRoleMappings { get; set; }

        [DataMember]
        public List<ResourceOperationTargetDTO> ResourceOperationTargets { get; set; }

        #endregion
    }

}