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

    public static partial class NotificationConverter
    {

        public static NotificationDTO ToDto(this Bec.TargetFramework.Data.Notification source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Notification source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationDTO();

            // Properties
            target.NotificationID = source.NotificationID;
            target.FromParentID = source.FromParentID;
            target.DateSent = source.DateSent;
            target.ParentID = source.ParentID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ModuleNotificationConstructID = source.ModuleNotificationConstructID;
            target.ModuleNotificationConstructVersionNumber = source.ModuleNotificationConstructVersionNumber;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsInternal = source.IsInternal;
            target.IsExternal = source.IsExternal;
            target.IsVisible = source.IsVisible;
            target.NotificationData = source.NotificationData;
            target.NotificationStatusID = source.NotificationStatusID;
            target.ConversationID = source.ConversationID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationRecipients = source.NotificationRecipients.ToDtosWithRelated(level - 1);
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
              target.InvoiceProcessLogs = source.InvoiceProcessLogs.ToDtosWithRelated(level - 1);
              target.OrganisationDirectDebitMandates = source.OrganisationDirectDebitMandates.ToDtosWithRelated(level - 1);
              target.Conversation = source.Conversation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Notification ToEntity(this NotificationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Notification();

            // Properties
            target.NotificationID = source.NotificationID;
            target.FromParentID = source.FromParentID;
            target.DateSent = source.DateSent;
            target.ParentID = source.ParentID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ModuleNotificationConstructID = source.ModuleNotificationConstructID;
            target.ModuleNotificationConstructVersionNumber = source.ModuleNotificationConstructVersionNumber;
            target.IsSent = source.IsSent;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsInternal = source.IsInternal;
            target.IsExternal = source.IsExternal;
            target.IsVisible = source.IsVisible;
            target.NotificationData = source.NotificationData;
            target.NotificationStatusID = source.NotificationStatusID;
            target.ConversationID = source.ConversationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Notification> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Notification> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Notification> ToEntities(this IEnumerable<NotificationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Notification source, NotificationDTO target);

        static partial void OnEntityCreating(NotificationDTO source, Bec.TargetFramework.Data.Notification target);

    }

}
