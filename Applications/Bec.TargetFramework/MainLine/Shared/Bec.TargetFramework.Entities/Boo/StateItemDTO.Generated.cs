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
    public partial class StateItemDTO
    {
        #region Constructors
  
        public StateItemDTO() {
        }

        public StateItemDTO(global::System.Guid stateItemID, string stateItemName, string stateItemDescription, global::System.Guid stateID, string sourceTableName, string sourceTableField, string sourceTableFieldValue, global::System.Nullable<System.Guid> parentStateItemID, global::System.Nullable<int> stateItemOrder, bool isActive, bool isDeleted, List<ModuleClaimDTO> moduleClaims, List<InterfacePanelClaimTemplateDTO> interfacePanelClaimTemplates, List<InterfacePanelClaimDTO> interfacePanelClaims, List<DefaultOrganisationRoleClaimDTO> defaultOrganisationRoleClaims, List<OrganisationRoleClaimDTO> organisationRoleClaims, List<WorkflowClaimTemplateDTO> workflowClaimTemplates, List<ProductClaimDTO> productClaims, List<DefaultOrganisationRoleClaimTemplateDTO> defaultOrganisationRoleClaimTemplates, List<ProductClaimTemplateDTO> productClaimTemplates, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates, List<ModuleClaimTemplateDTO> moduleClaimTemplates, List<NotificationConstructClaimDTO> notificationConstructClaims, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, List<StatusTypeClaimDTO> statusTypeClaims, List<ArtefactClaimTemplateDTO> artefactClaimTemplates, List<ArtefactClaimDTO> artefactClaims, StateDTO state, List<RoleClaimDTO> roleClaims, List<WorkflowClaimDTO> workflowClaims, List<ActorClaimRoleMappingDTO> actorClaimRoleMappings) {

          this.StateItemID = stateItemID;
          this.StateItemName = stateItemName;
          this.StateItemDescription = stateItemDescription;
          this.StateID = stateID;
          this.SourceTableName = sourceTableName;
          this.SourceTableField = sourceTableField;
          this.SourceTableFieldValue = sourceTableFieldValue;
          this.ParentStateItemID = parentStateItemID;
          this.StateItemOrder = stateItemOrder;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
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
          this.State = state;
          this.RoleClaims = roleClaims;
          this.WorkflowClaims = workflowClaims;
          this.ActorClaimRoleMappings = actorClaimRoleMappings;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StateItemID { get; set; }

        [DataMember]
        public string StateItemName { get; set; }

        [DataMember]
        public string StateItemDescription { get; set; }

        [DataMember]
        public global::System.Guid StateID { get; set; }

        [DataMember]
        public string SourceTableName { get; set; }

        [DataMember]
        public string SourceTableField { get; set; }

        [DataMember]
        public string SourceTableFieldValue { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentStateItemID { get; set; }

        [DataMember]
        public global::System.Nullable<int> StateItemOrder { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

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
        public StateDTO State { get; set; }

        [DataMember]
        public List<RoleClaimDTO> RoleClaims { get; set; }

        [DataMember]
        public List<WorkflowClaimDTO> WorkflowClaims { get; set; }

        [DataMember]
        public List<ActorClaimRoleMappingDTO> ActorClaimRoleMappings { get; set; }

        #endregion
    }

}
