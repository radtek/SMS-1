﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationGroupRoleTemplateConverter
    {

        public static DefaultOrganisationGroupRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationGroupRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationGroupRoleTemplateDTO();

            // Properties
            target.DefaultOrganisationGroupTemplateID = source.DefaultOrganisationGroupTemplateID;
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationGroupTemplate = source.DefaultOrganisationGroupTemplate.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationRoleTemplate = source.DefaultOrganisationRoleTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate ToEntity(this DefaultOrganisationGroupRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate();

            // Properties
            target.DefaultOrganisationGroupTemplateID = source.DefaultOrganisationGroupTemplateID;
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationGroupRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationGroupRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate> ToEntities(this IEnumerable<DefaultOrganisationGroupRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate source, DefaultOrganisationGroupRoleTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationGroupRoleTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate target);

    }

}
