﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationBranchConverter
    {

        public static DefaultOrganisationBranchDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationBranch source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationBranchDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationBranch source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationBranchDTO();

            // Properties
            target.DefaultOrganisationBranchID = source.DefaultOrganisationBranchID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.BranchName = source.BranchName;
            target.BranchSubType = source.BranchSubType;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationBranch ToEntity(this DefaultOrganisationBranchDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationBranch();

            // Properties
            target.DefaultOrganisationBranchID = source.DefaultOrganisationBranchID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.BranchName = source.BranchName;
            target.BranchSubType = source.BranchSubType;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationBranchDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationBranch> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationBranchDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationBranch> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationBranch> ToEntities(this IEnumerable<DefaultOrganisationBranchDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationBranch source, DefaultOrganisationBranchDTO target);

        static partial void OnEntityCreating(DefaultOrganisationBranchDTO source, Bec.TargetFramework.Data.DefaultOrganisationBranch target);

    }

}
