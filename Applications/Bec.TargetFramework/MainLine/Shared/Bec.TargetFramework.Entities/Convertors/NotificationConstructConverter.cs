﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructConverter
    {

        public static NotificationConstructDTO ToDto(this Bec.TargetFramework.Data.NotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructDTO();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructSubTypeID = source.NotificationConstructSubTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.NotificationConstructSubCategoryID = source.NotificationConstructSubCategoryID;
            target.ExternalRelatedNotificationConstructID = source.ExternalRelatedNotificationConstructID;
            target.ExternalRelatedNotificationConstructVersionNumber = source.ExternalRelatedNotificationConstructVersionNumber;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationTitle = source.NotificationTitle;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.NotificationConstructMutatorObjectType = source.NotificationConstructMutatorObjectType;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationNotificationConstructs = source.DefaultOrganisationNotificationConstructs.ToDtosWithRelated(level - 1);
              target.ModuleNotificationConstructs = source.ModuleNotificationConstructs.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaims = source.NotificationConstructClaims.ToDtosWithRelated(level - 1);
              target.ArtefactNotificationConstructs = source.ArtefactNotificationConstructs.ToDtosWithRelated(level - 1);
              target.WorkflowNotificationConstructs = source.WorkflowNotificationConstructs.ToDtosWithRelated(level - 1);
              target.NotificationConstructRoles = source.NotificationConstructRoles.ToDtosWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructParameters = source.NotificationConstructParameters.ToDtosWithRelated(level - 1);
              target.NotificationConstructData = source.NotificationConstructData.ToDtosWithRelated(level - 1);
              target.Notifications = source.Notifications.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargets = source.NotificationConstructTargets.ToDtosWithRelated(level - 1);
              target.WorkflowActionParameterNotificationConstructs = source.WorkflowActionParameterNotificationConstructs.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructs = source.NotificationConstructGroupNotificationConstructs.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstruct ToEntity(this NotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstruct();

            // Properties
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructSubTypeID = source.NotificationConstructSubTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.NotificationConstructSubCategoryID = source.NotificationConstructSubCategoryID;
            target.ExternalRelatedNotificationConstructID = source.ExternalRelatedNotificationConstructID;
            target.ExternalRelatedNotificationConstructVersionNumber = source.ExternalRelatedNotificationConstructVersionNumber;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationTitle = source.NotificationTitle;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.NotificationConstructMutatorObjectType = source.NotificationConstructMutatorObjectType;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstruct> ToEntities(this IEnumerable<NotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstruct source, NotificationConstructDTO target);

        static partial void OnEntityCreating(NotificationConstructDTO source, Bec.TargetFramework.Data.NotificationConstruct target);

    }

}
