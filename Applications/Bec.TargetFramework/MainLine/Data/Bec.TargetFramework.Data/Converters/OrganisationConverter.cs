﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationConverter
    {

        public static OrganisationDTO ToDto(this Bec.TargetFramework.Data.Organisation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Organisation source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ParentID = source.ParentID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.PrimaryContactID = source.PrimaryContactID;
            target.IsCompanyVerified = source.IsCompanyVerified;
            target.IsCompanyPinCreated = source.IsCompanyPinCreated;
            target.ReturnUrl = source.ReturnUrl;
            target.RowVersion = source.RowVersion;

            // Navigation Properties
            if (level > 0) {
              target.Contact = source.Contact.ToDtoWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.AttachmentDetails = source.AttachmentDetails.ToDtosWithRelated(level - 1);
              target.Discounts = source.Discounts.ToDtosWithRelated(level - 1);
              target.Invoices = source.Invoices.ToDtosWithRelated(level - 1);
              target.OrganisationInsuranceDetails = source.OrganisationInsuranceDetails.ToDtosWithRelated(level - 1);
              target.NotificationConstructTemplates = source.NotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.OrganisationDetails = source.OrganisationDetails.ToDtosWithRelated(level - 1);
              target.OrganisationLedgerAccounts = source.OrganisationLedgerAccounts.ToDtosWithRelated(level - 1);
              target.OrganisationDirectDebitMandates = source.OrganisationDirectDebitMandates.ToDtosWithRelated(level - 1);
              target.OrganisationFinancialDetails = source.OrganisationFinancialDetails.ToDtosWithRelated(level - 1);
              target.OrganisationBankAccounts = source.OrganisationBankAccounts.ToDtosWithRelated(level - 1);
              target.OrganisationAccountingPeriods = source.OrganisationAccountingPeriods.ToDtosWithRelated(level - 1);
              target.OrganisationArtefacts = source.OrganisationArtefacts.ToDtosWithRelated(level - 1);
              target.OrganisationDiscounts = source.OrganisationDiscounts.ToDtosWithRelated(level - 1);
              target.OrganisationPaymentMethods = source.OrganisationPaymentMethods.ToDtosWithRelated(level - 1);
              target.OrganisationStatus = source.OrganisationStatus.ToDtosWithRelated(level - 1);
              target.OrganisationTradingNames = source.OrganisationTradingNames.ToDtosWithRelated(level - 1);
              target.OrganisationRoles = source.OrganisationRoles.ToDtosWithRelated(level - 1);
              target.OrganisationSettings = source.OrganisationSettings.ToDtosWithRelated(level - 1);
              target.OrganisationStructures = source.OrganisationStructures.ToDtosWithRelated(level - 1);
              target.OrganisationProductPurchases = source.OrganisationProductPurchases.ToDtosWithRelated(level - 1);
              target.OrganisationPlanSubscriptions = source.OrganisationPlanSubscriptions.ToDtosWithRelated(level - 1);
              target.OrganisationShoppingCartBlueprints = source.OrganisationShoppingCartBlueprints.ToDtosWithRelated(level - 1);
              target.OrganisationStatusTypes = source.OrganisationStatusTypes.ToDtosWithRelated(level - 1);
              target.OrganisationTeams = source.OrganisationTeams.ToDtosWithRelated(level - 1);
              target.OrganisationUserTypes = source.OrganisationUserTypes.ToDtosWithRelated(level - 1);
              target.PlanSubscriptions = source.PlanSubscriptions.ToDtosWithRelated(level - 1);
              target.ShoppingCarts = source.ShoppingCarts.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisations = source.UserAccountOrganisations.ToDtosWithRelated(level - 1);
              target.OrganisationUnits = source.OrganisationUnits.ToDtosWithRelated(level - 1);
              target.OrganisationUnitStructures = source.OrganisationUnitStructures.ToDtosWithRelated(level - 1);
              target.Accounts_ContactOrganisationID = source.Accounts_ContactOrganisationID.ToDtosWithRelated(level - 1);
              target.Accounts_ParentOrganisationID = source.Accounts_ParentOrganisationID.ToDtosWithRelated(level - 1);
              target.OrganisationGroups = source.OrganisationGroups.ToDtosWithRelated(level - 1);
              target.OrganisationRoleClaims = source.OrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.SmsTransactions = source.SmsTransactions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Organisation ToEntity(this OrganisationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Organisation();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ParentID = source.ParentID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.PrimaryContactID = source.PrimaryContactID;
            target.IsCompanyVerified = source.IsCompanyVerified;
            target.IsCompanyPinCreated = source.IsCompanyPinCreated;
            target.ReturnUrl = source.ReturnUrl;
            target.RowVersion = source.RowVersion;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Organisation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Organisation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Organisation> ToEntities(this IEnumerable<OrganisationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Organisation source, OrganisationDTO target);

        static partial void OnEntityCreating(OrganisationDTO source, Bec.TargetFramework.Data.Organisation target);

    }

}
