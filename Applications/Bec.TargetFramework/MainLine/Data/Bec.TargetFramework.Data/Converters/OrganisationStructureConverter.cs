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

    public static partial class OrganisationStructureConverter
    {

        public static OrganisationStructureDTO ToDto(this Bec.TargetFramework.Data.OrganisationStructure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationStructureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationStructure source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationStructureDTO();

            // Properties
            target.OrganisationStructureID = source.OrganisationStructureID;
            target.ParentOrganisationStructureID = source.ParentOrganisationStructureID;
            target.Name = source.Name;
            target.IsLeafNode = source.IsLeafNode;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationStructure ToEntity(this OrganisationStructureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationStructure();

            // Properties
            target.OrganisationStructureID = source.OrganisationStructureID;
            target.ParentOrganisationStructureID = source.ParentOrganisationStructureID;
            target.Name = source.Name;
            target.IsLeafNode = source.IsLeafNode;
            target.OrganisationID = source.OrganisationID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationStructureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationStructure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationStructureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationStructure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationStructure> ToEntities(this IEnumerable<OrganisationStructureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationStructure source, OrganisationStructureDTO target);

        static partial void OnEntityCreating(OrganisationStructureDTO source, Bec.TargetFramework.Data.OrganisationStructure target);

    }

}