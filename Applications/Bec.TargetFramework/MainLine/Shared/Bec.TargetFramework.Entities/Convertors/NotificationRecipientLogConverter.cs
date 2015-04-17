﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationRecipientLogConverter
    {

        public static NotificationRecipientLogDTO ToDto(this Bec.TargetFramework.Data.NotificationRecipientLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationRecipientLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationRecipientLog source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationRecipientLogDTO();

            // Properties
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.CreatedOn = source.CreatedOn;
            target.SentOn = source.SentOn;
            target.NotificationExportFormatID = source.NotificationExportFormatID;
            target.IsSent = source.IsSent;
            target.IsRead = source.IsRead;
            target.ErrorOccured = source.ErrorOccured;
            target.DateRead = source.DateRead;
            target.NotificationDeliveryMethodID = source.NotificationDeliveryMethodID;
            target.NotificationRecipientLogID = source.NotificationRecipientLogID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationRecipient = source.NotificationRecipient.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationRecipientLog ToEntity(this NotificationRecipientLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationRecipientLog();

            // Properties
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.CreatedOn = source.CreatedOn;
            target.SentOn = source.SentOn;
            target.NotificationExportFormatID = source.NotificationExportFormatID;
            target.IsSent = source.IsSent;
            target.IsRead = source.IsRead;
            target.ErrorOccured = source.ErrorOccured;
            target.DateRead = source.DateRead;
            target.NotificationDeliveryMethodID = source.NotificationDeliveryMethodID;
            target.NotificationRecipientLogID = source.NotificationRecipientLogID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationRecipientLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationRecipientLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationRecipientLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationRecipientLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationRecipientLog> ToEntities(this IEnumerable<NotificationRecipientLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationRecipientLog source, NotificationRecipientLogDTO target);

        static partial void OnEntityCreating(NotificationRecipientLogDTO source, Bec.TargetFramework.Data.NotificationRecipientLog target);

    }

}
