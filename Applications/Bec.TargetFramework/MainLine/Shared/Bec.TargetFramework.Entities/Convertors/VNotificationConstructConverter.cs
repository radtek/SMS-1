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

    public static partial class VNotificationConstructConverter
    {

        public static VNotificationConstructDTO ToDto(this Bec.TargetFramework.Data.VNotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VNotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VNotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new VNotificationConstructDTO();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.Name = source.Name;
            target.NotificationTitle = source.NotificationTitle;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.Description = source.Description;
            target.ExternalRelatedNotificationConstructID = source.ExternalRelatedNotificationConstructID;
            target.ExternalRelatedNotificationConstructVersionNumber = source.ExternalRelatedNotificationConstructVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.TypeName = source.TypeName;
            target.CategoryName = source.CategoryName;
            target.ExportFormatName = source.ExportFormatName;
            target.DeliveryMethodName = source.DeliveryMethodName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VNotificationConstruct ToEntity(this VNotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VNotificationConstruct();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.Name = source.Name;
            target.NotificationTitle = source.NotificationTitle;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.Description = source.Description;
            target.ExternalRelatedNotificationConstructID = source.ExternalRelatedNotificationConstructID;
            target.ExternalRelatedNotificationConstructVersionNumber = source.ExternalRelatedNotificationConstructVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.TypeName = source.TypeName;
            target.CategoryName = source.CategoryName;
            target.ExportFormatName = source.ExportFormatName;
            target.DeliveryMethodName = source.DeliveryMethodName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VNotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VNotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VNotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VNotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VNotificationConstruct> ToEntities(this IEnumerable<VNotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VNotificationConstruct source, VNotificationConstructDTO target);

        static partial void OnEntityCreating(VNotificationConstructDTO source, Bec.TargetFramework.Data.VNotificationConstruct target);

    }

}
