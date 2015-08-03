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

    public static partial class OrganisationLedgerAccountConverter
    {

        public static OrganisationLedgerAccountDTO ToDto(this Bec.TargetFramework.Data.OrganisationLedgerAccount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationLedgerAccountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationLedgerAccount source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationLedgerAccountDTO();

            // Properties
            target.OrganisationLedgerAccountID = source.OrganisationLedgerAccountID;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountCategoryID = source.LedgerAccountCategoryID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ParentID = source.ParentID;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.Balance = source.Balance;
            target.UpdatedOn = source.UpdatedOn;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.OpenedOn = source.OpenedOn;
            target.ClosedOn = source.ClosedOn;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.AccountingTypeID = source.AccountingTypeID;
            target.IsPrimaryAccount = source.IsPrimaryAccount;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountLedgerAccounts = source.UserAccountLedgerAccounts.ToDtosWithRelated(level - 1);
              target.LedgerAccountBalances = source.LedgerAccountBalances.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
              target.OrganisationLedgerTransactions = source.OrganisationLedgerTransactions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationLedgerAccount ToEntity(this OrganisationLedgerAccountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationLedgerAccount();

            // Properties
            target.OrganisationLedgerAccountID = source.OrganisationLedgerAccountID;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountCategoryID = source.LedgerAccountCategoryID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ParentID = source.ParentID;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.Balance = source.Balance;
            target.UpdatedOn = source.UpdatedOn;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.OpenedOn = source.OpenedOn;
            target.ClosedOn = source.ClosedOn;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.AccountingTypeID = source.AccountingTypeID;
            target.IsPrimaryAccount = source.IsPrimaryAccount;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationLedgerAccountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationLedgerAccount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationLedgerAccountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationLedgerAccount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationLedgerAccount> ToEntities(this IEnumerable<OrganisationLedgerAccountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationLedgerAccount source, OrganisationLedgerAccountDTO target);

        static partial void OnEntityCreating(OrganisationLedgerAccountDTO source, Bec.TargetFramework.Data.OrganisationLedgerAccount target);

    }

}
