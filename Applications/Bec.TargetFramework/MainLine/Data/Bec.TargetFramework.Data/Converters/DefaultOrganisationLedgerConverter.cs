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

    public static partial class DefaultOrganisationLedgerConverter
    {

        public static DefaultOrganisationLedgerDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationLedger source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationLedgerDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationLedger source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationLedgerDTO();

            // Properties
            target.DefaultOrganisationLedgerID = source.DefaultOrganisationLedgerID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountName = source.LedgerAccountName;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationLedger ToEntity(this DefaultOrganisationLedgerDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationLedger();

            // Properties
            target.DefaultOrganisationLedgerID = source.DefaultOrganisationLedgerID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountName = source.LedgerAccountName;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationLedgerDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationLedger> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationLedgerDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationLedger> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationLedger> ToEntities(this IEnumerable<DefaultOrganisationLedgerDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationLedger source, DefaultOrganisationLedgerDTO target);

        static partial void OnEntityCreating(DefaultOrganisationLedgerDTO source, Bec.TargetFramework.Data.DefaultOrganisationLedger target);

    }

}