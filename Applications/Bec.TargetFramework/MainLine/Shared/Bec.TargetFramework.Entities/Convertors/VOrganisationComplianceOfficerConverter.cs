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

    public static partial class VOrganisationComplianceOfficerConverter
    {

        public static VOrganisationComplianceOfficerDTO ToDto(this Bec.TargetFramework.Data.VOrganisationComplianceOfficer source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationComplianceOfficerDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationComplianceOfficer source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationComplianceOfficerDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.COEmail = source.COEmail;
            target.COFirstName = source.COFirstName;
            target.COLastName = source.COLastName;
            target.CompanyName = source.CompanyName;
            target.TradingName = source.TradingName;
            target.BranchName = source.BranchName;
            target.BranchRegulatorID = source.BranchRegulatorID;
            target.BranchRegulator = source.BranchRegulator;
            target.BranchRegulatorNumber = source.BranchRegulatorNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationComplianceOfficer ToEntity(this VOrganisationComplianceOfficerDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationComplianceOfficer();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.COEmail = source.COEmail;
            target.COFirstName = source.COFirstName;
            target.COLastName = source.COLastName;
            target.CompanyName = source.CompanyName;
            target.TradingName = source.TradingName;
            target.BranchName = source.BranchName;
            target.BranchRegulatorID = source.BranchRegulatorID;
            target.BranchRegulator = source.BranchRegulator;
            target.BranchRegulatorNumber = source.BranchRegulatorNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationComplianceOfficerDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationComplianceOfficer> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationComplianceOfficerDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationComplianceOfficer> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationComplianceOfficer> ToEntities(this IEnumerable<VOrganisationComplianceOfficerDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationComplianceOfficer source, VOrganisationComplianceOfficerDTO target);

        static partial void OnEntityCreating(VOrganisationComplianceOfficerDTO source, Bec.TargetFramework.Data.VOrganisationComplianceOfficer target);

    }

}
