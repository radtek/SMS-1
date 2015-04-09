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
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationAccountingPeriodConverter
    {

        public static OrganisationAccountingPeriodDTO ToDto(this Bec.TargetFramework.Data.OrganisationAccountingPeriod source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationAccountingPeriodDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationAccountingPeriod source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationAccountingPeriodDTO();

            // Properties
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.GlobalAccountingPeriodID = source.GlobalAccountingPeriodID;
            target.OrganisationID = source.OrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.Invoices = source.Invoices.ToDtosWithRelated(level - 1);
              target.GlobalAccountingPeriod = source.GlobalAccountingPeriod.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationAccountingPeriod ToEntity(this OrganisationAccountingPeriodDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationAccountingPeriod();

            // Properties
            target.OrganisationAccountingPeriodID = source.OrganisationAccountingPeriodID;
            target.GlobalAccountingPeriodID = source.GlobalAccountingPeriodID;
            target.OrganisationID = source.OrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationAccountingPeriodDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationAccountingPeriod> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationAccountingPeriodDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationAccountingPeriod> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationAccountingPeriod> ToEntities(this IEnumerable<OrganisationAccountingPeriodDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationAccountingPeriod source, OrganisationAccountingPeriodDTO target);

        static partial void OnEntityCreating(OrganisationAccountingPeriodDTO source, Bec.TargetFramework.Data.OrganisationAccountingPeriod target);

    }

}
