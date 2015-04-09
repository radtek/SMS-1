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

    public static partial class OrganisationUnitConverter
    {

        public static OrganisationUnitDTO ToDto(this Bec.TargetFramework.Data.OrganisationUnit source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationUnitDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationUnit source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationUnitDTO();

            // Properties
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.DivisionName = source.DivisionName;
            target.OrganisationID = source.OrganisationID;
            target.OrganisationUnitTypeID = source.OrganisationUnitTypeID;
            target.OrganisationUnitCategoryID = source.OrganisationUnitCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountOrganisations = source.UserAccountOrganisations.ToDtosWithRelated(level - 1);
              target.OrganisationUnitOrganisationGroups = source.OrganisationUnitOrganisationGroups.ToDtosWithRelated(level - 1);
              target.OrganisationUnitOrganisationRoles = source.OrganisationUnitOrganisationRoles.ToDtosWithRelated(level - 1);
              target.OrganisationUnitStructures = source.OrganisationUnitStructures.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationUnit ToEntity(this OrganisationUnitDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationUnit();

            // Properties
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.DivisionName = source.DivisionName;
            target.OrganisationID = source.OrganisationID;
            target.OrganisationUnitTypeID = source.OrganisationUnitTypeID;
            target.OrganisationUnitCategoryID = source.OrganisationUnitCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationUnitDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnit> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationUnitDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnit> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationUnit> ToEntities(this IEnumerable<OrganisationUnitDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationUnit source, OrganisationUnitDTO target);

        static partial void OnEntityCreating(OrganisationUnitDTO source, Bec.TargetFramework.Data.OrganisationUnit target);

    }

}
