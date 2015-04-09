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
    public partial class StateDTO
    {
        #region Constructors
  
        public StateDTO() {
        }

        public StateDTO(global::System.Guid stateID, string stateName, string stateDescription, global::System.Nullable<int> stateTypeID, global::System.Nullable<int> stateCategoryID, global::System.Nullable<int> stateSubCategoryID, global::System.Nullable<System.Guid> parentStateID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, List<ModuleClaimDTO> moduleClaims, List<InterfacePanelClaimTemplateDTO> interfacePanelClaimTemplates, List<InterfacePanelClaimDTO> interfacePanelClaims, List<DefaultOrganisationRoleClaimDTO> defaultOrganisationRoleClaims, List<OrganisationRoleClaimDTO> organisationRoleClaims, List<WorkflowClaimTemplateDTO> workflowClaimTemplates, List<ProductClaimDTO> productClaims, List<DefaultOrganisationRoleClaimTemplateDTO> defaultOrganisationRoleClaimTemplates, List<ProductClaimTemplateDTO> productClaimTemplates, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates, List<ModuleClaimTemplateDTO> moduleClaimTemplates, List<NotificationConstructClaimDTO> notificationConstructClaims, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, List<StatusTypeClaimDTO> statusTypeClaims, List<ArtefactClaimTemplateDTO> artefactClaimTemplates, List<ArtefactClaimDTO> artefactClaims, List<StateItemDTO> stateItems, List<RoleClaimDTO> roleClaims, List<WorkflowClaimDTO> workflowClaims, List<ActorClaimRoleMappingDTO> actorClaimRoleMappings) {

          this.StateID = stateID;
          this.StateName = stateName;
          this.StateDescription = stateDescription;
          this.StateTypeID = stateTypeID;
          this.StateCategoryID = stateCategoryID;
          this.StateSubCategoryID = stateSubCategoryID;
          this.ParentStateID = parentStateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.ModuleClaims = moduleClaims;
          this.InterfacePanelClaimTemplates = interfacePanelClaimTemplates;
          this.InterfacePanelClaims = interfacePanelClaims;
          this.DefaultOrganisationRoleClaims = defaultOrganisationRoleClaims;
          this.OrganisationRoleClaims = organisationRoleClaims;
          this.WorkflowClaimTemplates = workflowClaimTemplates;
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
          this.StateItems = stateItems;
          this.RoleClaims = roleClaims;
          this.WorkflowClaims = workflowClaims;
          this.ActorClaimRoleMappings = actorClaimRoleMappings;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StateID { get; set; }

        [DataMember]
        public string StateName { get; set; }

        [DataMember]
        public string StateDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> StateTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StateCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StateSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentStateID { get; set; }

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
        public List<InterfacePanelClaimTemplateDTO> InterfacePanelClaimTemplates { get; set; }

        [DataMember]
        public List<InterfacePanelClaimDTO> InterfacePanelClaims { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleClaimDTO> DefaultOrganisationRoleClaims { get; set; }

        [DataMember]
        public List<OrganisationRoleClaimDTO> OrganisationRoleClaims { get; set; }

        [DataMember]
        public List<WorkflowClaimTemplateDTO> WorkflowClaimTemplates { get; set; }

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
        public List<StateItemDTO> StateItems { get; set; }

        [DataMember]
        public List<RoleClaimDTO> RoleClaims { get; set; }

        [DataMember]
        public List<WorkflowClaimDTO> WorkflowClaims { get; set; }

        [DataMember]
        public List<ActorClaimRoleMappingDTO> ActorClaimRoleMappings { get; set; }

        #endregion
    }

}
