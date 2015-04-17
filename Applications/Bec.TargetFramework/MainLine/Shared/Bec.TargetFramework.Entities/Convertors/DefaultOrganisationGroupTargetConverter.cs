﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationGroupTargetConverter
    {

        public static DefaultOrganisationGroupTargetDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationGroupTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationGroupTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationGroupTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationGroupTargetDTO();

            // Properties
            target.DefaultOrganisationGroupID = source.DefaultOrganisationGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationUserTarget = source.DefaultOrganisationUserTarget.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationGroup = source.DefaultOrganisationGroup.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationGroupTarget ToEntity(this DefaultOrganisationGroupTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationGroupTarget();

            // Properties
            target.DefaultOrganisationGroupID = source.DefaultOrganisationGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationGroupTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationGroupTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationGroupTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationGroupTarget> ToEntities(this IEnumerable<DefaultOrganisationGroupTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationGroupTarget source, DefaultOrganisationGroupTargetDTO target);

        static partial void OnEntityCreating(DefaultOrganisationGroupTargetDTO source, Bec.TargetFramework.Data.DefaultOrganisationGroupTarget target);

    }

}
