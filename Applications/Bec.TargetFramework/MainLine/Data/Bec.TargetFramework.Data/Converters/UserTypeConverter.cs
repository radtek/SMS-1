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

    public static partial class UserTypeConverter
    {

        public static UserTypeDTO ToDto(this Bec.TargetFramework.Data.UserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserType source, int level)
        {
            if (source == null)
              return null;

            var target = new UserTypeDTO();

            // Properties
            target.UserTypeID = source.UserTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;
            target.IsPrincipal = source.IsPrincipal;
            target.IsSecondary = source.IsSecondary;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationUserTypeTemplates = source.DefaultOrganisationUserTypeTemplates.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisations = source.UserAccountOrganisations.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargets = source.DefaultOrganisationUserTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargetTemplates = source.DefaultOrganisationUserTargetTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTypes = source.DefaultOrganisationUserTypes.ToDtosWithRelated(level - 1);
              target.OrganisationUserTypes = source.OrganisationUserTypes.ToDtosWithRelated(level - 1);
              target.ComponentTierTemplates = source.ComponentTierTemplates.ToDtosWithRelated(level - 1);
              target.ComponentTiers = source.ComponentTiers.ToDtosWithRelated(level - 1);
              target.Discounts = source.Discounts.ToDtosWithRelated(level - 1);
              target.DiscountTemplates = source.DiscountTemplates.ToDtosWithRelated(level - 1);
              target.Deductions = source.Deductions.ToDtosWithRelated(level - 1);
              target.DeductionTemplates = source.DeductionTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructs = source.NotificationConstructGroupNotificationConstructs.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructTemplates = source.NotificationConstructGroupNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationSecondaryUserTypes = source.UserAccountOrganisationSecondaryUserTypes.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargetTemplates = source.NotificationConstructTargetTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargets = source.NotificationConstructTargets.ToDtosWithRelated(level - 1);
              target.ResourceOperationTargets = source.ResourceOperationTargets.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserType ToEntity(this UserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserType();

            // Properties
            target.UserTypeID = source.UserTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;
            target.IsPrincipal = source.IsPrincipal;
            target.IsSecondary = source.IsSecondary;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserType> ToEntities(this IEnumerable<UserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserType source, UserTypeDTO target);

        static partial void OnEntityCreating(UserTypeDTO source, Bec.TargetFramework.Data.UserType target);

    }

}