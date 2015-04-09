﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class StatusTypeDTO
    {
        #region Constructors
  
        public StatusTypeDTO() {
        }

        public StatusTypeDTO(global::System.Guid statusTypeID, int statusTypeVersionNumber, string name, string description, bool isActive, bool isDeleted, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, StatusTypeTemplateDTO statusTypeTemplate, List<StatusTypeRoleDTO> statusTypeRoles, List<WorkflowStatusTypeDTO> workflowStatusTypes, List<ModuleStatusTypeDTO> moduleStatusTypes, List<DefaultOrganisationStatusTypeDTO> defaultOrganisationStatusTypes, List<StatusTypeStructureDTO> statusTypeStructures, List<UserAccountOrganisationStatusDTO> userAccountOrganisationStatus, List<OrganisationStatusDTO> organisationStatus, List<StatusTypeClaimDTO> statusTypeClaims, List<OrganisationStatusTypeDTO> organisationStatusTypes, List<StatusTypeValueDTO> statusTypeValues, List<ArtefactDTO> artefacts, List<InvoiceProcessLogDTO> invoiceProcessLogs, List<TransactionOrderProcessLogDTO> transactionOrderProcessLogs, List<PlanSubscriptionBillingProcessLogDTO> planSubscriptionBillingPeriods, List<PlanSubscriptionProcessLogDTO> planSubscriptionProcessLogs, List<OrganisationFinancialDetailDTO> organisationFinancialDetails, List<OrganisationPaymentMethodDTO> organisationPaymentMethods, List<OrganisationDirectDebitMandateProcessLogDTO> organisationDirectDebitMandateProcessLogs, List<StsInviteProcessLogDTO> stsInviteProcessLogs, List<StsSearchProcessLogDTO> stsSearchProcessLogs, List<StsSearchRelationDTO> stsSearchRelations, List<ProductPurchaseProcessLogDTO> productPurchaseProcessLogs, List<ServiceInterfaceProcessLogDTO> serviceInterfaceProcessLogs, List<BusTaskScheduleProcessLogDTO> busTaskScheduleProcessLogs, List<ProductPurchaseBusTaskProcessLogDTO> productPurchaseBusTaskProcessLogs, List<BusMessageProcessLogDTO> busMessageProcessLogs) {

          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.StatusTypeTemplate = statusTypeTemplate;
          this.StatusTypeRoles = statusTypeRoles;
          this.WorkflowStatusTypes = workflowStatusTypes;
          this.ModuleStatusTypes = moduleStatusTypes;
          this.DefaultOrganisationStatusTypes = defaultOrganisationStatusTypes;
          this.StatusTypeStructures = statusTypeStructures;
          this.UserAccountOrganisationStatus = userAccountOrganisationStatus;
          this.OrganisationStatus = organisationStatus;
          this.StatusTypeClaims = statusTypeClaims;
          this.OrganisationStatusTypes = organisationStatusTypes;
          this.StatusTypeValues = statusTypeValues;
          this.Artefacts = artefacts;
          this.InvoiceProcessLogs = invoiceProcessLogs;
          this.TransactionOrderProcessLogs = transactionOrderProcessLogs;
          this.PlanSubscriptionBillingPeriods = planSubscriptionBillingPeriods;
          this.PlanSubscriptionProcessLogs = planSubscriptionProcessLogs;
          this.OrganisationFinancialDetails = organisationFinancialDetails;
          this.OrganisationPaymentMethods = organisationPaymentMethods;
          this.OrganisationDirectDebitMandateProcessLogs = organisationDirectDebitMandateProcessLogs;
          this.StsInviteProcessLogs = stsInviteProcessLogs;
          this.StsSearchProcessLogs = stsSearchProcessLogs;
          this.StsSearchRelations = stsSearchRelations;
          this.ProductPurchaseProcessLogs = productPurchaseProcessLogs;
          this.ServiceInterfaceProcessLogs = serviceInterfaceProcessLogs;
          this.BusTaskScheduleProcessLogs = busTaskScheduleProcessLogs;
          this.ProductPurchaseBusTaskProcessLogs = productPurchaseBusTaskProcessLogs;
          this.BusMessageProcessLogs = busMessageProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        [DataMember]
        public List<StatusTypeRoleDTO> StatusTypeRoles { get; set; }

        [DataMember]
        public List<WorkflowStatusTypeDTO> WorkflowStatusTypes { get; set; }

        [DataMember]
        public List<ModuleStatusTypeDTO> ModuleStatusTypes { get; set; }

        [DataMember]
        public List<DefaultOrganisationStatusTypeDTO> DefaultOrganisationStatusTypes { get; set; }

        [DataMember]
        public List<StatusTypeStructureDTO> StatusTypeStructures { get; set; }

        [DataMember]
        public List<UserAccountOrganisationStatusDTO> UserAccountOrganisationStatus { get; set; }

        [DataMember]
        public List<OrganisationStatusDTO> OrganisationStatus { get; set; }

        [DataMember]
        public List<StatusTypeClaimDTO> StatusTypeClaims { get; set; }

        [DataMember]
        public List<OrganisationStatusTypeDTO> OrganisationStatusTypes { get; set; }

        [DataMember]
        public List<StatusTypeValueDTO> StatusTypeValues { get; set; }

        [DataMember]
        public List<ArtefactDTO> Artefacts { get; set; }

        [DataMember]
        public List<InvoiceProcessLogDTO> InvoiceProcessLogs { get; set; }

        [DataMember]
        public List<TransactionOrderProcessLogDTO> TransactionOrderProcessLogs { get; set; }

        [DataMember]
        public List<PlanSubscriptionBillingProcessLogDTO> PlanSubscriptionBillingPeriods { get; set; }

        [DataMember]
        public List<PlanSubscriptionProcessLogDTO> PlanSubscriptionProcessLogs { get; set; }

        [DataMember]
        public List<OrganisationFinancialDetailDTO> OrganisationFinancialDetails { get; set; }

        [DataMember]
        public List<OrganisationPaymentMethodDTO> OrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateProcessLogDTO> OrganisationDirectDebitMandateProcessLogs { get; set; }

        [DataMember]
        public List<StsInviteProcessLogDTO> StsInviteProcessLogs { get; set; }

        [DataMember]
        public List<StsSearchProcessLogDTO> StsSearchProcessLogs { get; set; }

        [DataMember]
        public List<StsSearchRelationDTO> StsSearchRelations { get; set; }

        [DataMember]
        public List<ProductPurchaseProcessLogDTO> ProductPurchaseProcessLogs { get; set; }

        [DataMember]
        public List<ServiceInterfaceProcessLogDTO> ServiceInterfaceProcessLogs { get; set; }

        [DataMember]
        public List<BusTaskScheduleProcessLogDTO> BusTaskScheduleProcessLogs { get; set; }

        [DataMember]
        public List<ProductPurchaseBusTaskProcessLogDTO> ProductPurchaseBusTaskProcessLogs { get; set; }

        [DataMember]
        public List<BusMessageProcessLogDTO> BusMessageProcessLogs { get; set; }

        #endregion
    }

}
