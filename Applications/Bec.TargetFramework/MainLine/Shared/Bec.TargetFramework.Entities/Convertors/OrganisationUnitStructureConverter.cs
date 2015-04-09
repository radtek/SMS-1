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

    public static partial class OrganisationUnitStructureConverter
    {

        public static OrganisationUnitStructureDTO ToDto(this Bec.TargetFramework.Data.OrganisationUnitStructure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationUnitStructureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationUnitStructure source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationUnitStructureDTO();

            // Properties
            target.OrganisationUnitStructureID = source.OrganisationUnitStructureID;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationID = source.OrganisationID;
            target.ParentOrganisationUnitStructureID = source.ParentOrganisationUnitStructureID;
            target.IsLeafNode = source.IsLeafNode;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationUnit = source.OrganisationUnit.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationUnitStructure ToEntity(this OrganisationUnitStructureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationUnitStructure();

            // Properties
            target.OrganisationUnitStructureID = source.OrganisationUnitStructureID;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationID = source.OrganisationID;
            target.ParentOrganisationUnitStructureID = source.ParentOrganisationUnitStructureID;
            target.IsLeafNode = source.IsLeafNode;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationUnitStructureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnitStructure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationUnitStructureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnitStructure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationUnitStructure> ToEntities(this IEnumerable<OrganisationUnitStructureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationUnitStructure source, OrganisationUnitStructureDTO target);

        static partial void OnEntityCreating(OrganisationUnitStructureDTO source, Bec.TargetFramework.Data.OrganisationUnitStructure target);

    }

}
