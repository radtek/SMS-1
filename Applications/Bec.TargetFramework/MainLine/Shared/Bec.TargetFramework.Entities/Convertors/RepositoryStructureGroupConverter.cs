﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class RepositoryStructureGroupConverter
    {

        public static RepositoryStructureGroupDTO ToDto(this Bec.TargetFramework.Data.RepositoryStructureGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RepositoryStructureGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RepositoryStructureGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new RepositoryStructureGroupDTO();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.OrganisationExternalGroupID = source.OrganisationExternalGroupID;
            target.RepositoryStructureGroupID = source.RepositoryStructureGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationGroup = source.OrganisationGroup.ToDtoWithRelated(level - 1);
              target.RepositoryStructure = source.RepositoryStructure.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RepositoryStructureGroup ToEntity(this RepositoryStructureGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RepositoryStructureGroup();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.OrganisationExternalGroupID = source.OrganisationExternalGroupID;
            target.RepositoryStructureGroupID = source.RepositoryStructureGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RepositoryStructureGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructureGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RepositoryStructureGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructureGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RepositoryStructureGroup> ToEntities(this IEnumerable<RepositoryStructureGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RepositoryStructureGroup source, RepositoryStructureGroupDTO target);

        static partial void OnEntityCreating(RepositoryStructureGroupDTO source, Bec.TargetFramework.Data.RepositoryStructureGroup target);

    }

}
