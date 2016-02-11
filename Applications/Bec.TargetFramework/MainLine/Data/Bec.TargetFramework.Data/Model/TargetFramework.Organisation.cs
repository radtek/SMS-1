﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.Organisation in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Organisation    {

        public Organisation()
        {
          this.IsBranch = false;
          this.IsHeadOffice = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsUserOrganisation = false;
          this.IsPaymentProvider = false;
          this.IsCompanyVerified = false;
          this.IsCompanyPinCreated = false;
          this.ReturnUrl = @"";
          this.FilesPerMonth = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsBranch in the schema.
        /// </summary>
        public virtual bool IsBranch
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsHeadOffice in the schema.
        /// </summary>
        public virtual bool IsHeadOffice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsUserOrganisation in the schema.
        /// </summary>
        public virtual bool IsUserOrganisation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ModifiedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedBy in the schema.
        /// </summary>
        public virtual string ModifiedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationVersionNumber in the schema.
        /// </summary>
        public virtual int DefaultOrganisationVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPaymentProvider in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsPaymentProvider
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PrimaryContactID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PrimaryContactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCompanyVerified in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsCompanyVerified
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCompanyPinCreated in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsCompanyPinCreated
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ReturnUrl in the schema.
        /// </summary>
        public virtual string ReturnUrl
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RowVersion in the schema.
        /// </summary>
        public virtual global::System.Nullable<long> RowVersion
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationRecommendationSourceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationRecommendationSourceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SchemeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SchemeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FilesPerMonth in the schema.
        /// </summary>
        public virtual int FilesPerMonth
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BrokerType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BrokerType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BrokerBusinessType in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BrokerBusinessType
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Contact in the schema.
        /// </summary>
        public virtual Contact Contact
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisation in the schema.
        /// </summary>
        public virtual DefaultOrganisation DefaultOrganisation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for AttachmentDetails in the schema.
        /// </summary>
        public virtual ICollection<AttachmentDetail> AttachmentDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Discounts in the schema.
        /// </summary>
        public virtual ICollection<Discount> Discounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Invoices in the schema.
        /// </summary>
        public virtual ICollection<Invoice> Invoices
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationInsuranceDetails in the schema.
        /// </summary>
        public virtual ICollection<OrganisationInsuranceDetail> OrganisationInsuranceDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for NotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<NotificationConstructTemplate> NotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDetails in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDetail> OrganisationDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationLedgerAccounts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationLedgerAccount> OrganisationLedgerAccounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandates in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDirectDebitMandate> OrganisationDirectDebitMandates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationFinancialDetails in the schema.
        /// </summary>
        public virtual ICollection<OrganisationFinancialDetail> OrganisationFinancialDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationBankAccounts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationBankAccount> OrganisationBankAccounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationAccountingPeriods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationAccountingPeriod> OrganisationAccountingPeriods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationArtefacts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationArtefact> OrganisationArtefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationDiscounts in the schema.
        /// </summary>
        public virtual ICollection<OrganisationDiscount> OrganisationDiscounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationPaymentMethod> OrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationStatus in the schema.
        /// </summary>
        public virtual ICollection<OrganisationStatus> OrganisationStatus
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationTradingNames in the schema.
        /// </summary>
        public virtual ICollection<OrganisationTradingName> OrganisationTradingNames
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationRoles in the schema.
        /// </summary>
        public virtual ICollection<OrganisationRole> OrganisationRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationSettings in the schema.
        /// </summary>
        public virtual ICollection<OrganisationSetting> OrganisationSettings
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationStructures in the schema.
        /// </summary>
        public virtual ICollection<OrganisationStructure> OrganisationStructures
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationProductPurchases in the schema.
        /// </summary>
        public virtual ICollection<OrganisationProductPurchase> OrganisationProductPurchases
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationPlanSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<OrganisationPlanSubscription> OrganisationPlanSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationShoppingCartBlueprints in the schema.
        /// </summary>
        public virtual ICollection<OrganisationShoppingCartBlueprint> OrganisationShoppingCartBlueprints
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationStatusTypes in the schema.
        /// </summary>
        public virtual ICollection<OrganisationStatusType> OrganisationStatusTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationTeams in the schema.
        /// </summary>
        public virtual ICollection<OrganisationTeam> OrganisationTeams
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUserTypes in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUserType> OrganisationUserTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscription> PlanSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCarts in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisations in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisation> UserAccountOrganisations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnits in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnit> OrganisationUnits
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnitStructures in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnitStructure> OrganisationUnitStructures
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Accounts_ContactOrganisationID in the schema.
        /// </summary>
        public virtual ICollection<Account> Accounts_ContactOrganisationID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Accounts_ParentOrganisationID in the schema.
        /// </summary>
        public virtual ICollection<Account> Accounts_ParentOrganisationID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<OrganisationGroup> OrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationRoleClaims in the schema.
        /// </summary>
        public virtual ICollection<OrganisationRoleClaim> OrganisationRoleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SmsTransactions in the schema.
        /// </summary>
        public virtual ICollection<SmsTransaction> SmsTransactions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ClassificationType in the schema.
        /// </summary>
        public virtual ClassificationType ClassificationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for LegalOrganisationDetail in the schema.
        /// </summary>
        public virtual LegalOrganisationDetail LegalOrganisationDetail
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationNotes in the schema.
        /// </summary>
        public virtual ICollection<OrganisationNote> OrganisationNotes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Lenders in the schema.
        /// </summary>
        public virtual ICollection<Lender> Lenders
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ConversationFunctionParticipants in the schema.
        /// </summary>
        public virtual ICollection<ConversationFunctionParticipant> ConversationFunctionParticipants
        {
            get;
            set;
        }

        #endregion
    }

}
