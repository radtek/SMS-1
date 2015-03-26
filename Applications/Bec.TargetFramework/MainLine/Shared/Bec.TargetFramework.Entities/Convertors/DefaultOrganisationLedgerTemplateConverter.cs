﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationLedgerTemplateConverter
    {

        public static DefaultOrganisationLedgerTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationLedgerTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationLedgerTemplateDTO();

            // Properties
            target.DefaultOrganisationLedgerTemplateID = source.DefaultOrganisationLedgerTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountName = source.LedgerAccountName;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate ToEntity(this DefaultOrganisationLedgerTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate();

            // Properties
            target.DefaultOrganisationLedgerTemplateID = source.DefaultOrganisationLedgerTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.LedgerAccountTypeID = source.LedgerAccountTypeID;
            target.LedgerAccountName = source.LedgerAccountName;
            target.HandlesCredit = source.HandlesCredit;
            target.HandlesDebit = source.HandlesDebit;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationLedgerTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationLedgerTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate> ToEntities(this IEnumerable<DefaultOrganisationLedgerTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate source, DefaultOrganisationLedgerTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationLedgerTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationLedgerTemplate target);

    }

}
