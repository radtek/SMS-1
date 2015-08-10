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

    public static partial class VNotificationViewOnlyUaoConverter
    {

        public static VNotificationViewOnlyUaoDTO ToDto(this Bec.TargetFramework.Data.VNotificationViewOnlyUao source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationViewOnlyUaoDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationViewOnlyUao source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationViewOnlyUaoDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.ResourceTypeID = source.ResourceTypeID;
            target.NotificationID = source.NotificationID;
            target.NotificationData = source.NotificationData;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.DateSent = source.DateSent;
            target.Name = source.Name;
            target.NotificationSubject = source.NotificationSubject;
            target.IsInternal = source.IsInternal;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationViewOnlyUao ToEntity(this VNotificationViewOnlyUaoDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationViewOnlyUao();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.ResourceTypeID = source.ResourceTypeID;
            target.NotificationID = source.NotificationID;
            target.NotificationData = source.NotificationData;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.DateSent = source.DateSent;
            target.Name = source.Name;
            target.NotificationSubject = source.NotificationSubject;
            target.IsInternal = source.IsInternal;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationViewOnlyUaoDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationViewOnlyUao> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationViewOnlyUaoDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationViewOnlyUao> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationViewOnlyUao> ToEntities(this IEnumerable<VNotificationViewOnlyUaoDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationViewOnlyUao source, VNotificationViewOnlyUaoDTO target);

        static partial void OnEntityCreating(VNotificationViewOnlyUaoDTO source, Bec.TargetFramework.Data.VNotificationViewOnlyUao target);

    }

}
