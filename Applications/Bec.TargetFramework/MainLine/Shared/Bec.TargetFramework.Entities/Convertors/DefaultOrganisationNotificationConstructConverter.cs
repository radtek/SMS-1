﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationNotificationConstructConverter
    {

        public static DefaultOrganisationNotificationConstructDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationNotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationNotificationConstructDTO();

            // Properties
            target.DefaultOrganisationNotificationConstructID = source.DefaultOrganisationNotificationConstructID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ParentID = source.ParentID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct ToEntity(this DefaultOrganisationNotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct();

            // Properties
            target.DefaultOrganisationNotificationConstructID = source.DefaultOrganisationNotificationConstructID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ParentID = source.ParentID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationNotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationNotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct> ToEntities(this IEnumerable<DefaultOrganisationNotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct source, DefaultOrganisationNotificationConstructDTO target);

        static partial void OnEntityCreating(DefaultOrganisationNotificationConstructDTO source, Bec.TargetFramework.Data.DefaultOrganisationNotificationConstruct target);

    }

}
