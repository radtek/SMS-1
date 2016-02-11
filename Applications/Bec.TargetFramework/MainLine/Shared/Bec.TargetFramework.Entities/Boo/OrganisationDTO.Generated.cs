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
    public partial class OrganisationDTO
    {
        #region Constructors
  
        public OrganisationDTO() {
        }

        public OrganisationDTO(global::System.Guid organisationID, int organisationTypeID, global::System.Nullable<int> organisationSubTypeID, global::System.Nullable<int> organisationCategoryID, bool isBranch, bool isHeadOffice, bool isActive, bool isDeleted, bool isUserOrganisation, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, global::System.Nullable<int> organisationSubCategoryID, global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> parentOrganisationID, global::System.Nullable<bool> isPaymentProvider, global::System.Nullable<System.Guid> primaryContactID, global::System.Nullable<bool> isCompanyVerified, global::System.Nullable<bool> isCompanyPinCreated, string returnUrl, global::System.Nullable<long> rowVersion, global::System.Nullable<int> organisationRecommendationSourceID, global::System.Nullable<int> schemeID, int filesPerMonth, global::System.Nullable<int> brokerType, global::System.Nullable<int> brokerBusinessType, ContactDTO contact, DefaultOrganisationDTO defaultOrganisation, OrganisationTypeDTO organisationType, List<AttachmentDetailDTO> attachmentDetails, List<DiscountDTO> discounts, List<InvoiceDTO> invoices, List<OrganisationInsuranceDetailDTO> organisationInsuranceDetails, List<NotificationConstructTemplateDTO> notificationConstructTemplates, List<OrganisationDetailDTO> organisationDetails, List<OrganisationLedgerAccountDTO> organisationLedgerAccounts, List<OrganisationDirectDebitMandateDTO> organisationDirectDebitMandates, List<OrganisationFinancialDetailDTO> organisationFinancialDetails, List<OrganisationBankAccountDTO> organisationBankAccounts, List<OrganisationAccountingPeriodDTO> organisationAccountingPeriods, List<OrganisationArtefactDTO> organisationArtefacts, List<OrganisationDiscountDTO> organisationDiscounts, List<OrganisationPaymentMethodDTO> organisationPaymentMethods, List<OrganisationStatusDTO> organisationStatus, List<OrganisationTradingNameDTO> organisationTradingNames, List<OrganisationRoleDTO> organisationRoles, List<OrganisationSettingDTO> organisationSettings, List<OrganisationStructureDTO> organisationStructures, List<OrganisationProductPurchaseDTO> organisationProductPurchases, List<OrganisationPlanSubscriptionDTO> organisationPlanSubscriptions, List<OrganisationShoppingCartBlueprintDTO> organisationShoppingCartBlueprints, List<OrganisationStatusTypeDTO> organisationStatusTypes, List<OrganisationTeamDTO> organisationTeams, List<OrganisationUserTypeDTO> organisationUserTypes, List<PlanSubscriptionDTO> planSubscriptions, List<ShoppingCartDTO> shoppingCarts, List<UserAccountOrganisationDTO> userAccountOrganisations, List<OrganisationUnitDTO> organisationUnits, List<OrganisationUnitStructureDTO> organisationUnitStructures, List<AccountDTO> accounts_ContactOrganisationID, List<AccountDTO> accounts_ParentOrganisationID, List<OrganisationGroupDTO> organisationGroups, List<OrganisationRoleClaimDTO> organisationRoleClaims, List<SmsTransactionDTO> smsTransactions, ClassificationTypeDTO classificationType, LegalOrganisationDetailDTO legalOrganisationDetail, List<OrganisationNoteDTO> organisationNotes, List<LenderDTO> lenders, List<ConversationFunctionParticipantDTO> conversationFunctionParticipants) {

          this.OrganisationID = organisationID;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationSubTypeID = organisationSubTypeID;
          this.OrganisationCategoryID = organisationCategoryID;
          this.IsBranch = isBranch;
          this.IsHeadOffice = isHeadOffice;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsUserOrganisation = isUserOrganisation;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.OrganisationSubCategoryID = organisationSubCategoryID;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.ParentID = parentID;
          this.ParentOrganisationID = parentOrganisationID;
          this.IsPaymentProvider = isPaymentProvider;
          this.PrimaryContactID = primaryContactID;
          this.IsCompanyVerified = isCompanyVerified;
          this.IsCompanyPinCreated = isCompanyPinCreated;
          this.ReturnUrl = returnUrl;
          this.RowVersion = rowVersion;
          this.OrganisationRecommendationSourceID = organisationRecommendationSourceID;
          this.SchemeID = schemeID;
          this.FilesPerMonth = filesPerMonth;
          this.BrokerType = brokerType;
          this.BrokerBusinessType = brokerBusinessType;
          this.Contact = contact;
          this.DefaultOrganisation = defaultOrganisation;
          this.OrganisationType = organisationType;
          this.AttachmentDetails = attachmentDetails;
          this.Discounts = discounts;
          this.Invoices = invoices;
          this.OrganisationInsuranceDetails = organisationInsuranceDetails;
          this.NotificationConstructTemplates = notificationConstructTemplates;
          this.OrganisationDetails = organisationDetails;
          this.OrganisationLedgerAccounts = organisationLedgerAccounts;
          this.OrganisationDirectDebitMandates = organisationDirectDebitMandates;
          this.OrganisationFinancialDetails = organisationFinancialDetails;
          this.OrganisationBankAccounts = organisationBankAccounts;
          this.OrganisationAccountingPeriods = organisationAccountingPeriods;
          this.OrganisationArtefacts = organisationArtefacts;
          this.OrganisationDiscounts = organisationDiscounts;
          this.OrganisationPaymentMethods = organisationPaymentMethods;
          this.OrganisationStatus = organisationStatus;
          this.OrganisationTradingNames = organisationTradingNames;
          this.OrganisationRoles = organisationRoles;
          this.OrganisationSettings = organisationSettings;
          this.OrganisationStructures = organisationStructures;
          this.OrganisationProductPurchases = organisationProductPurchases;
          this.OrganisationPlanSubscriptions = organisationPlanSubscriptions;
          this.OrganisationShoppingCartBlueprints = organisationShoppingCartBlueprints;
          this.OrganisationStatusTypes = organisationStatusTypes;
          this.OrganisationTeams = organisationTeams;
          this.OrganisationUserTypes = organisationUserTypes;
          this.PlanSubscriptions = planSubscriptions;
          this.ShoppingCarts = shoppingCarts;
          this.UserAccountOrganisations = userAccountOrganisations;
          this.OrganisationUnits = organisationUnits;
          this.OrganisationUnitStructures = organisationUnitStructures;
          this.Accounts_ContactOrganisationID = accounts_ContactOrganisationID;
          this.Accounts_ParentOrganisationID = accounts_ParentOrganisationID;
          this.OrganisationGroups = organisationGroups;
          this.OrganisationRoleClaims = organisationRoleClaims;
          this.SmsTransactions = smsTransactions;
          this.ClassificationType = classificationType;
          this.LegalOrganisationDetail = legalOrganisationDetail;
          this.OrganisationNotes = organisationNotes;
          this.Lenders = lenders;
          this.ConversationFunctionParticipants = conversationFunctionParticipants;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationCategoryID { get; set; }

        [DataMember]
        public bool IsBranch { get; set; }

        [DataMember]
        public bool IsHeadOffice { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsUserOrganisation { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationSubCategoryID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPaymentProvider { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PrimaryContactID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsCompanyVerified { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsCompanyPinCreated { get; set; }

        [DataMember]
        public string ReturnUrl { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationRecommendationSourceID { get; set; }

        [DataMember]
        public global::System.Nullable<int> SchemeID { get; set; }

        [DataMember]
        public int FilesPerMonth { get; set; }

        [DataMember]
        public global::System.Nullable<int> BrokerType { get; set; }

        [DataMember]
        public global::System.Nullable<int> BrokerBusinessType { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public List<AttachmentDetailDTO> AttachmentDetails { get; set; }

        [DataMember]
        public List<DiscountDTO> Discounts { get; set; }

        [DataMember]
        public List<InvoiceDTO> Invoices { get; set; }

        [DataMember]
        public List<OrganisationInsuranceDetailDTO> OrganisationInsuranceDetails { get; set; }

        [DataMember]
        public List<NotificationConstructTemplateDTO> NotificationConstructTemplates { get; set; }

        [DataMember]
        public List<OrganisationDetailDTO> OrganisationDetails { get; set; }

        [DataMember]
        public List<OrganisationLedgerAccountDTO> OrganisationLedgerAccounts { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateDTO> OrganisationDirectDebitMandates { get; set; }

        [DataMember]
        public List<OrganisationFinancialDetailDTO> OrganisationFinancialDetails { get; set; }

        [DataMember]
        public List<OrganisationBankAccountDTO> OrganisationBankAccounts { get; set; }

        [DataMember]
        public List<OrganisationAccountingPeriodDTO> OrganisationAccountingPeriods { get; set; }

        [DataMember]
        public List<OrganisationArtefactDTO> OrganisationArtefacts { get; set; }

        [DataMember]
        public List<OrganisationDiscountDTO> OrganisationDiscounts { get; set; }

        [DataMember]
        public List<OrganisationPaymentMethodDTO> OrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<OrganisationStatusDTO> OrganisationStatus { get; set; }

        [DataMember]
        public List<OrganisationTradingNameDTO> OrganisationTradingNames { get; set; }

        [DataMember]
        public List<OrganisationRoleDTO> OrganisationRoles { get; set; }

        [DataMember]
        public List<OrganisationSettingDTO> OrganisationSettings { get; set; }

        [DataMember]
        public List<OrganisationStructureDTO> OrganisationStructures { get; set; }

        [DataMember]
        public List<OrganisationProductPurchaseDTO> OrganisationProductPurchases { get; set; }

        [DataMember]
        public List<OrganisationPlanSubscriptionDTO> OrganisationPlanSubscriptions { get; set; }

        [DataMember]
        public List<OrganisationShoppingCartBlueprintDTO> OrganisationShoppingCartBlueprints { get; set; }

        [DataMember]
        public List<OrganisationStatusTypeDTO> OrganisationStatusTypes { get; set; }

        [DataMember]
        public List<OrganisationTeamDTO> OrganisationTeams { get; set; }

        [DataMember]
        public List<OrganisationUserTypeDTO> OrganisationUserTypes { get; set; }

        [DataMember]
        public List<PlanSubscriptionDTO> PlanSubscriptions { get; set; }

        [DataMember]
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }

        [DataMember]
        public List<UserAccountOrganisationDTO> UserAccountOrganisations { get; set; }

        [DataMember]
        public List<OrganisationUnitDTO> OrganisationUnits { get; set; }

        [DataMember]
        public List<OrganisationUnitStructureDTO> OrganisationUnitStructures { get; set; }

        [DataMember]
        public List<AccountDTO> Accounts_ContactOrganisationID { get; set; }

        [DataMember]
        public List<AccountDTO> Accounts_ParentOrganisationID { get; set; }

        [DataMember]
        public List<OrganisationGroupDTO> OrganisationGroups { get; set; }

        [DataMember]
        public List<OrganisationRoleClaimDTO> OrganisationRoleClaims { get; set; }

        [DataMember]
        public List<SmsTransactionDTO> SmsTransactions { get; set; }

        [DataMember]
        public ClassificationTypeDTO ClassificationType { get; set; }

        [DataMember]
        public LegalOrganisationDetailDTO LegalOrganisationDetail { get; set; }

        [DataMember]
        public List<OrganisationNoteDTO> OrganisationNotes { get; set; }

        [DataMember]
        public List<LenderDTO> Lenders { get; set; }

        [DataMember]
        public List<ConversationFunctionParticipantDTO> ConversationFunctionParticipants { get; set; }

        #endregion
    }

}
