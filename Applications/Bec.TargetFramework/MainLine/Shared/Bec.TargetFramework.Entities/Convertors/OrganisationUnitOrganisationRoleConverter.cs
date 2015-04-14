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

    public static partial class OrganisationUnitOrganisationRoleConverter
    {

        public static OrganisationUnitOrganisationRoleDTO ToDto(this Bec.TargetFramework.Data.OrganisationUnitOrganisationRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationUnitOrganisationRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationUnitOrganisationRole source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationUnitOrganisationRoleDTO();

            // Properties
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationRole = source.OrganisationRole.ToDtoWithRelated(level - 1);
              target.OrganisationUnit = source.OrganisationUnit.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationUnitOrganisationRole ToEntity(this OrganisationUnitOrganisationRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationUnitOrganisationRole();

            // Properties
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationUnitOrganisationRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnitOrganisationRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationUnitOrganisationRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationUnitOrganisationRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationUnitOrganisationRole> ToEntities(this IEnumerable<OrganisationUnitOrganisationRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationUnitOrganisationRole source, OrganisationUnitOrganisationRoleDTO target);

        static partial void OnEntityCreating(OrganisationUnitOrganisationRoleDTO source, Bec.TargetFramework.Data.OrganisationUnitOrganisationRole target);

    }

}
