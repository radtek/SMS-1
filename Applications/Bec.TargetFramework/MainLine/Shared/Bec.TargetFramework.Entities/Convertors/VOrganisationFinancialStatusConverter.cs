﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VOrganisationFinancialStatusConverter
    {

        public static VOrganisationFinancialStatusDTO ToDto(this Bec.TargetFramework.Data.VOrganisationFinancialStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationFinancialStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationFinancialStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationFinancialStatusDTO();

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
            target.Name = source.Name;
            target.FinancialStatus = source.FinancialStatus;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationFinancialStatus ToEntity(this VOrganisationFinancialStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationFinancialStatus();

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
            target.Name = source.Name;
            target.FinancialStatus = source.FinancialStatus;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationFinancialStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationFinancialStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationFinancialStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationFinancialStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationFinancialStatus> ToEntities(this IEnumerable<VOrganisationFinancialStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationFinancialStatus source, VOrganisationFinancialStatusDTO target);

        static partial void OnEntityCreating(VOrganisationFinancialStatusDTO source, Bec.TargetFramework.Data.VOrganisationFinancialStatus target);

    }

}
