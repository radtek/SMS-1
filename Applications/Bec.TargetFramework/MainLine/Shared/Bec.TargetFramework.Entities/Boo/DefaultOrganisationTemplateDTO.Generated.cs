﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class DefaultOrganisationTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationTemplateDTO() {
        }

        public DefaultOrganisationTemplateDTO(global::System.Guid defaultOrganisationTemplateID, int defaultOrganisationTemplateVersionNumber, string name, string description, bool isActive, bool isDeleted, int organisationTypeID, List<DefaultOrganisationProductTemplateDTO> defaultOrganisationProductTemplates, List<DefaultOrganisationUserTypeTemplateDTO> defaultOrganisationUserTypeTemplates, List<DefaultOrganisationLedgerTemplateDTO> defaultOrganisationLedgerTemplates, OrganisationTypeDTO organisationType, List<DefaultOrganisationNotificationConstructTemplateDTO> defaultOrganisationNotificationConstructTemplates, List<DefaultOrganisationModuleTemplateDTO> defaultOrganisationModuleTemplates, List<DefaultOrganisationBranchTemplateDTO> defaultOrganisationBranchTemplates, List<DefaultOrganisationArtefactTemplateDTO> defaultOrganisationArtefactTemplates, List<DefaultOrganisationWorkflowTemplateDTO> defaultOrganisationWorkflowTemplates, List<DefaultOrganisationRoleTemplateDTO> defaultOrganisationRoleTemplates, List<DefaultOrganisationTargetTemplateDTO> defaultOrganisationTargetTemplates, List<DefaultOrganisationStatusTypeTemplateDTO> defaultOrganisationStatusTypeTemplates, List<DefaultOrganisationUserTargetTemplateDTO> defaultOrganisationUserTargetTemplates, List<DefaultOrganisationGroupTemplateDTO> defaultOrganisationGroupTemplates, List<DefaultOrganisationDTO> defaultOrganisations, List<BucketTemplateDTO> bucketTemplates, List<DefaultOrganisationShoppingCartBlueprintTemplateDTO> defaultOrganisationShoppingCartBlueprintTemplates, List<DefaultOrganisationPaymentMethodTemplateDTO> defaultOrganisationPaymentMethodTemplates) {

          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationTypeID = organisationTypeID;
          this.DefaultOrganisationProductTemplates = defaultOrganisationProductTemplates;
          this.DefaultOrganisationUserTypeTemplates = defaultOrganisationUserTypeTemplates;
          this.DefaultOrganisationLedgerTemplates = defaultOrganisationLedgerTemplates;
          this.OrganisationType = organisationType;
          this.DefaultOrganisationNotificationConstructTemplates = defaultOrganisationNotificationConstructTemplates;
          this.DefaultOrganisationModuleTemplates = defaultOrganisationModuleTemplates;
          this.DefaultOrganisationBranchTemplates = defaultOrganisationBranchTemplates;
          this.DefaultOrganisationArtefactTemplates = defaultOrganisationArtefactTemplates;
          this.DefaultOrganisationWorkflowTemplates = defaultOrganisationWorkflowTemplates;
          this.DefaultOrganisationRoleTemplates = defaultOrganisationRoleTemplates;
          this.DefaultOrganisationTargetTemplates = defaultOrganisationTargetTemplates;
          this.DefaultOrganisationStatusTypeTemplates = defaultOrganisationStatusTypeTemplates;
          this.DefaultOrganisationUserTargetTemplates = defaultOrganisationUserTargetTemplates;
          this.DefaultOrganisationGroupTemplates = defaultOrganisationGroupTemplates;
          this.DefaultOrganisations = defaultOrganisations;
          this.BucketTemplates = bucketTemplates;
          this.DefaultOrganisationShoppingCartBlueprintTemplates = defaultOrganisationShoppingCartBlueprintTemplates;
          this.DefaultOrganisationPaymentMethodTemplates = defaultOrganisationPaymentMethodTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

        [DataMember]
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationProductTemplateDTO> DefaultOrganisationProductTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationUserTypeTemplateDTO> DefaultOrganisationUserTypeTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationLedgerTemplateDTO> DefaultOrganisationLedgerTemplates { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public List<DefaultOrganisationNotificationConstructTemplateDTO> DefaultOrganisationNotificationConstructTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationModuleTemplateDTO> DefaultOrganisationModuleTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationBranchTemplateDTO> DefaultOrganisationBranchTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationArtefactTemplateDTO> DefaultOrganisationArtefactTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationWorkflowTemplateDTO> DefaultOrganisationWorkflowTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleTemplateDTO> DefaultOrganisationRoleTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationTargetTemplateDTO> DefaultOrganisationTargetTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationStatusTypeTemplateDTO> DefaultOrganisationStatusTypeTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationUserTargetTemplateDTO> DefaultOrganisationUserTargetTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupTemplateDTO> DefaultOrganisationGroupTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationDTO> DefaultOrganisations { get; set; }

        [DataMember]
        public List<BucketTemplateDTO> BucketTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationShoppingCartBlueprintTemplateDTO> DefaultOrganisationShoppingCartBlueprintTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationPaymentMethodTemplateDTO> DefaultOrganisationPaymentMethodTemplates { get; set; }

        #endregion
    }

}
