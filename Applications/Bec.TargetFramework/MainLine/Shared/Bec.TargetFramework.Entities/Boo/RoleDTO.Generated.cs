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
    public partial class RoleDTO
    {
        #region Constructors
  
        public RoleDTO() {
        }

        public RoleDTO(global::System.Guid roleID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, global::System.Nullable<bool> isGlobal, List<ModuleClaimDTO> moduleClaims, List<InterfacePanelClaimTemplateDTO> interfacePanelClaimTemplates, List<DefaultOrganisationRoleTemplateDTO> defaultOrganisationRoleTemplates, List<InterfacePanelClaimDTO> interfacePanelClaims, List<WorkflowClaimTemplateDTO> workflowClaimTemplates, List<ProductClaimDTO> productClaims, List<ProductClaimTemplateDTO> productClaimTemplates, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates, List<DefaultOrganisationRoleDTO> defaultOrganisationRoles, List<ModuleClaimTemplateDTO> moduleClaimTemplates, List<NotificationConstructClaimDTO> notificationConstructClaims, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, List<ArtefactClaimTemplateDTO> artefactClaimTemplates, List<ArtefactClaimDTO> artefactClaims, List<GroupRoleDTO> groupRoles, List<RoleClaimDTO> roleClaims, List<WorkflowClaimDTO> workflowClaims, List<ActorClaimRoleMappingDTO> actorClaimRoleMappings) {

          this.RoleID = roleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsGlobal = isGlobal;
          this.ModuleClaims = moduleClaims;
          this.InterfacePanelClaimTemplates = interfacePanelClaimTemplates;
          this.DefaultOrganisationRoleTemplates = defaultOrganisationRoleTemplates;
          this.InterfacePanelClaims = interfacePanelClaims;
          this.WorkflowClaimTemplates = workflowClaimTemplates;
          this.ProductClaims = productClaims;
          this.ProductClaimTemplates = productClaimTemplates;
          this.StatusTypeClaimTemplates = statusTypeClaimTemplates;
          this.DefaultOrganisationRoles = defaultOrganisationRoles;
          this.ModuleClaimTemplates = moduleClaimTemplates;
          this.NotificationConstructClaims = notificationConstructClaims;
          this.NotificationConstructClaimTemplates = notificationConstructClaimTemplates;
          this.ArtefactClaimTemplates = artefactClaimTemplates;
          this.ArtefactClaims = artefactClaims;
          this.GroupRoles = groupRoles;
          this.RoleClaims = roleClaims;
          this.WorkflowClaims = workflowClaims;
          this.ActorClaimRoleMappings = actorClaimRoleMappings;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsGlobal { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ModuleClaimDTO> ModuleClaims { get; set; }

        [DataMember]
        public List<InterfacePanelClaimTemplateDTO> InterfacePanelClaimTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleTemplateDTO> DefaultOrganisationRoleTemplates { get; set; }

        [DataMember]
        public List<InterfacePanelClaimDTO> InterfacePanelClaims { get; set; }

        [DataMember]
        public List<WorkflowClaimTemplateDTO> WorkflowClaimTemplates { get; set; }

        [DataMember]
        public List<ProductClaimDTO> ProductClaims { get; set; }

        [DataMember]
        public List<ProductClaimTemplateDTO> ProductClaimTemplates { get; set; }

        [DataMember]
        public List<StatusTypeClaimTemplateDTO> StatusTypeClaimTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleDTO> DefaultOrganisationRoles { get; set; }

        [DataMember]
        public List<ModuleClaimTemplateDTO> ModuleClaimTemplates { get; set; }

        [DataMember]
        public List<NotificationConstructClaimDTO> NotificationConstructClaims { get; set; }

        [DataMember]
        public List<NotificationConstructClaimTemplateDTO> NotificationConstructClaimTemplates { get; set; }

        [DataMember]
        public List<ArtefactClaimTemplateDTO> ArtefactClaimTemplates { get; set; }

        [DataMember]
        public List<ArtefactClaimDTO> ArtefactClaims { get; set; }

        [DataMember]
        public List<GroupRoleDTO> GroupRoles { get; set; }

        [DataMember]
        public List<RoleClaimDTO> RoleClaims { get; set; }

        [DataMember]
        public List<WorkflowClaimDTO> WorkflowClaims { get; set; }

        [DataMember]
        public List<ActorClaimRoleMappingDTO> ActorClaimRoleMappings { get; set; }

        #endregion
    }

}
