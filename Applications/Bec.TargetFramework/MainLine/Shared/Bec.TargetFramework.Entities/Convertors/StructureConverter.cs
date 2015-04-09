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

    public static partial class StructureConverter
    {

        public static StructureDTO ToDto(this Bec.TargetFramework.Data.Structure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StructureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Structure source, int level)
        {
            if (source == null)
              return null;

            var target = new StructureDTO();

            // Properties
            target.RepositoryMapID = source.RepositoryMapID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.OrganisationExternalRoleID = source.OrganisationExternalRoleID;
            target.StructureID = source.StructureID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Structure ToEntity(this StructureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Structure();

            // Properties
            target.RepositoryMapID = source.RepositoryMapID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.OrganisationExternalRoleID = source.OrganisationExternalRoleID;
            target.StructureID = source.StructureID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StructureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Structure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StructureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Structure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Structure> ToEntities(this IEnumerable<StructureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Structure source, StructureDTO target);

        static partial void OnEntityCreating(StructureDTO source, Bec.TargetFramework.Data.Structure target);

    }

}
