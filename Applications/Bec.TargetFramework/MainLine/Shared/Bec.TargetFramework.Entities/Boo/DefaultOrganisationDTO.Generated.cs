﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class DefaultOrganisationDTO
    {
        #region Constructors
  
        public DefaultOrganisationDTO() {
        }

        public DefaultOrganisationDTO(global::System.Guid defaultOrganisationID, string name, string description, bool isActive, bool isDeleted, int defaultOrganisationVersionNumber, global::System.Nullable<System.Guid> defaultOrganisationTemplateID, global::System.Nullable<int> defaultOrganisationTemplateVersionNumber, int organisationTypeID, List<DefaultOrganisationLedgerDTO> defaultOrganisationLedgers, List<DefaultOrganisationModuleDTO> defaultOrganisationModules, List<DefaultOrganisationStatusTypeDTO> defaultOrganisationStatusTypes, List<DefaultOrganisationProductDTO> defaultOrganisationProducts, List<DefaultOrganisationTargetDTO> defaultOrganisationTargets, List<DefaultOrganisationUserTargetDTO> defaultOrganisationUserTargets, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, OrganisationTypeDTO organisationType, List<DefaultOrganisationNotificationConstructDTO> defaultOrganisationNotificationConstructs, List<DefaultOrganisationWorkflowDTO> defaultOrganisationWorkflows, List<DefaultOrganisationUserTypeDTO> defaultOrganisationUserTypes, List<DefaultOrganisationBranchDTO> defaultOrganisationBranches, List<DefaultOrganisationArtefactDTO> defaultOrganisationArtefacts, List<DefaultOrganisationGroupDTO> defaultOrganisationGroups, List<DefaultOrganisationRoleDTO> defaultOrganisationRoles, List<BucketTemplateDTO> bucketTemplates, List<DefaultOrganisationShoppingCartBlueprintDTO> defaultOrganisationShoppingCartBlueprints, List<DefaultOrganisationPaymentMethodDTO> defaultOrganisationPaymentMethods, List<OrganisationDTO> organisations) {

          this.DefaultOrganisationID = defaultOrganisationID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.DefaultOrganisationLedgers = defaultOrganisationLedgers;
          this.DefaultOrganisationModules = defaultOrganisationModules;
          this.DefaultOrganisationStatusTypes = defaultOrganisationStatusTypes;
          this.DefaultOrganisationProducts = defaultOrganisationProducts;
          this.DefaultOrganisationTargets = defaultOrganisationTargets;
          this.DefaultOrganisationUserTargets = defaultOrganisationUserTargets;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.OrganisationType = organisationType;
          this.DefaultOrganisationNotificationConstructs = defaultOrganisationNotificationConstructs;
          this.DefaultOrganisationWorkflows = defaultOrganisationWorkflows;
          this.DefaultOrganisationUserTypes = defaultOrganisationUserTypes;
          this.DefaultOrganisationBranches = defaultOrganisationBranches;
          this.DefaultOrganisationArtefacts = defaultOrganisationArtefacts;
          this.DefaultOrganisationGroups = defaultOrganisationGroups;
          this.DefaultOrganisationRoles = defaultOrganisationRoles;
          this.BucketTemplates = bucketTemplates;
          this.DefaultOrganisationShoppingCartBlueprints = defaultOrganisationShoppingCartBlueprints;
          this.DefaultOrganisationPaymentMethods = defaultOrganisationPaymentMethods;
          this.Organisations = organisations;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationLedgerDTO> DefaultOrganisationLedgers { get; set; }

        [DataMember]
        public List<DefaultOrganisationModuleDTO> DefaultOrganisationModules { get; set; }

        [DataMember]
        public List<DefaultOrganisationStatusTypeDTO> DefaultOrganisationStatusTypes { get; set; }

        [DataMember]
        public List<DefaultOrganisationProductDTO> DefaultOrganisationProducts { get; set; }

        [DataMember]
        public List<DefaultOrganisationTargetDTO> DefaultOrganisationTargets { get; set; }

        [DataMember]
        public List<DefaultOrganisationUserTargetDTO> DefaultOrganisationUserTargets { get; set; }

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public List<DefaultOrganisationNotificationConstructDTO> DefaultOrganisationNotificationConstructs { get; set; }

        [DataMember]
        public List<DefaultOrganisationWorkflowDTO> DefaultOrganisationWorkflows { get; set; }

        [DataMember]
        public List<DefaultOrganisationUserTypeDTO> DefaultOrganisationUserTypes { get; set; }

        [DataMember]
        public List<DefaultOrganisationBranchDTO> DefaultOrganisationBranches { get; set; }

        [DataMember]
        public List<DefaultOrganisationArtefactDTO> DefaultOrganisationArtefacts { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupDTO> DefaultOrganisationGroups { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleDTO> DefaultOrganisationRoles { get; set; }

        [DataMember]
        public List<BucketTemplateDTO> BucketTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationShoppingCartBlueprintDTO> DefaultOrganisationShoppingCartBlueprints { get; set; }

        [DataMember]
        public List<DefaultOrganisationPaymentMethodDTO> DefaultOrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<OrganisationDTO> Organisations { get; set; }

        #endregion
    }

}
