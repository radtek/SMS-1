﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationRoleTargetConverter
    {

        public static DefaultOrganisationRoleTargetDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationRoleTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationRoleTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationRoleTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationRoleTargetDTO();

            // Properties
            target.DefaultOrganisationRoleID = source.DefaultOrganisationRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationUserTarget = source.DefaultOrganisationUserTarget.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationRole = source.DefaultOrganisationRole.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationRoleTarget ToEntity(this DefaultOrganisationRoleTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationRoleTarget();

            // Properties
            target.DefaultOrganisationRoleID = source.DefaultOrganisationRoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationRoleTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationRoleTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationRoleTarget> ToEntities(this IEnumerable<DefaultOrganisationRoleTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationRoleTarget source, DefaultOrganisationRoleTargetDTO target);

        static partial void OnEntityCreating(DefaultOrganisationRoleTargetDTO source, Bec.TargetFramework.Data.DefaultOrganisationRoleTarget target);

    }

}
