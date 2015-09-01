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

    public static partial class OrganisationFinancialDetailConverter
    {

        public static OrganisationFinancialDetailDTO ToDto(this Bec.TargetFramework.Data.OrganisationFinancialDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationFinancialDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationFinancialDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationFinancialDetailDTO();

            // Properties
            target.OrganisationFinancialDetailID = source.OrganisationFinancialDetailID;
            target.FinancialStatusTypeID = source.FinancialStatusTypeID;
            target.FinancialStatusTypeVersionNumber = source.FinancialStatusTypeVersionNumber;
            target.FinancialStatusTypeValueID = source.FinancialStatusTypeValueID;
            target.HasACreditLimit = source.HasACreditLimit;
            target.CreditLimit = source.CreditLimit;
            target.NumberOfLatePayments = source.NumberOfLatePayments;
            target.HasLatePayments = source.HasLatePayments;
            target.OrganisationID = source.OrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationFinancialDetail ToEntity(this OrganisationFinancialDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationFinancialDetail();

            // Properties
            target.OrganisationFinancialDetailID = source.OrganisationFinancialDetailID;
            target.FinancialStatusTypeID = source.FinancialStatusTypeID;
            target.FinancialStatusTypeVersionNumber = source.FinancialStatusTypeVersionNumber;
            target.FinancialStatusTypeValueID = source.FinancialStatusTypeValueID;
            target.HasACreditLimit = source.HasACreditLimit;
            target.CreditLimit = source.CreditLimit;
            target.NumberOfLatePayments = source.NumberOfLatePayments;
            target.HasLatePayments = source.HasLatePayments;
            target.OrganisationID = source.OrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationFinancialDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationFinancialDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationFinancialDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationFinancialDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationFinancialDetail> ToEntities(this IEnumerable<OrganisationFinancialDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationFinancialDetail source, OrganisationFinancialDetailDTO target);

        static partial void OnEntityCreating(OrganisationFinancialDetailDTO source, Bec.TargetFramework.Data.OrganisationFinancialDetail target);

    }

}