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

    public static partial class VNotificationInternalUnreadConverter
    {

        public static VNotificationInternalUnreadDTO ToDto(this Bec.TargetFramework.Data.VNotificationInternalUnread source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationInternalUnreadDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationInternalUnread source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationInternalUnreadDTO();

            // Properties
            target.NotificationID = source.NotificationID;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.DateSent = source.DateSent;
            target.NotificationData = source.NotificationData;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.NotificationSubject = source.NotificationSubject;
            target.UserID = source.UserID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationInternalUnread ToEntity(this VNotificationInternalUnreadDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationInternalUnread();

            // Properties
            target.NotificationID = source.NotificationID;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.DateSent = source.DateSent;
            target.NotificationData = source.NotificationData;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.NotificationSubject = source.NotificationSubject;
            target.UserID = source.UserID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationInternalUnreadDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationInternalUnread> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationInternalUnreadDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationInternalUnread> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationInternalUnread> ToEntities(this IEnumerable<VNotificationInternalUnreadDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationInternalUnread source, VNotificationInternalUnreadDTO target);

        static partial void OnEntityCreating(VNotificationInternalUnreadDTO source, Bec.TargetFramework.Data.VNotificationInternalUnread target);

    }

}
