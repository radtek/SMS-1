﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class RepositoryStructureRoleConverter
    {

        public static RepositoryStructureRoleDTO ToDto(this Bec.TargetFramework.Data.RepositoryStructureRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RepositoryStructureRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RepositoryStructureRole source, int level)
        {
            if (source == null)
              return null;

            var target = new RepositoryStructureRoleDTO();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.RepositoryStructureRoleID = source.RepositoryStructureRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationRole = source.OrganisationRole.ToDtoWithRelated(level - 1);
              target.RepositoryStructure = source.RepositoryStructure.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RepositoryStructureRole ToEntity(this RepositoryStructureRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RepositoryStructureRole();

            // Properties
            target.RepositoryStructureID = source.RepositoryStructureID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.RepositoryStructureRoleID = source.RepositoryStructureRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RepositoryStructureRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructureRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RepositoryStructureRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RepositoryStructureRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RepositoryStructureRole> ToEntities(this IEnumerable<RepositoryStructureRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RepositoryStructureRole source, RepositoryStructureRoleDTO target);

        static partial void OnEntityCreating(RepositoryStructureRoleDTO source, Bec.TargetFramework.Data.RepositoryStructureRole target);

    }

}
