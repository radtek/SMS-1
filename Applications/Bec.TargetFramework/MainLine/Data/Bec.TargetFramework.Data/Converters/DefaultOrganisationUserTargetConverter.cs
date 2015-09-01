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

    public static partial class DefaultOrganisationUserTargetConverter
    {

        public static DefaultOrganisationUserTargetDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationUserTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationUserTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationUserTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationUserTargetDTO();

            // Properties
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserSubCategoryID = source.UserSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.UserTypeID = source.UserTypeID;
            target.ParentID = source.ParentID;
            target.IsDefault = source.IsDefault;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationStatusType = source.DefaultOrganisationStatusType.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationGroupTargets = source.DefaultOrganisationGroupTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleTargets = source.DefaultOrganisationRoleTargets.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationUserTarget ToEntity(this DefaultOrganisationUserTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationUserTarget();

            // Properties
            target.DefaultOrganisationUserTargetID = source.DefaultOrganisationUserTargetID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserSubCategoryID = source.UserSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.UserTypeID = source.UserTypeID;
            target.ParentID = source.ParentID;
            target.IsDefault = source.IsDefault;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationUserTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationUserTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationUserTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationUserTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationUserTarget> ToEntities(this IEnumerable<DefaultOrganisationUserTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationUserTarget source, DefaultOrganisationUserTargetDTO target);

        static partial void OnEntityCreating(DefaultOrganisationUserTargetDTO source, Bec.TargetFramework.Data.DefaultOrganisationUserTarget target);

    }

}