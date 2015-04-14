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

    public static partial class NotificationConstructTargetConverter
    {

        public static NotificationConstructTargetDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructTargetDTO();

            // Properties
            target.NotificationConstructTargetID = source.NotificationConstructTargetID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsSingleUser = source.IsSingleUser;
            target.IsOrganisationBranchOnly = source.IsOrganisationBranchOnly;
            target.IsDefaultTarget = source.IsDefaultTarget;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructTarget ToEntity(this NotificationConstructTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructTarget();

            // Properties
            target.NotificationConstructTargetID = source.NotificationConstructTargetID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.IsSingleUser = source.IsSingleUser;
            target.IsOrganisationBranchOnly = source.IsOrganisationBranchOnly;
            target.IsDefaultTarget = source.IsDefaultTarget;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructTarget> ToEntities(this IEnumerable<NotificationConstructTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructTarget source, NotificationConstructTargetDTO target);

        static partial void OnEntityCreating(NotificationConstructTargetDTO source, Bec.TargetFramework.Data.NotificationConstructTarget target);

    }

}
