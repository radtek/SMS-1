﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructTemplateConverter
    {

        public static NotificationConstructTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructTemplateDTO();

            // Properties
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructSubTypeID = source.NotificationConstructSubTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.NotificationConstructSubCategoryID = source.NotificationConstructSubCategoryID;
            target.ExternalRelatedNotificationConstructTemplateID = source.ExternalRelatedNotificationConstructTemplateID;
            target.ExternalRelatedNotificationConstructTemplateVersionNumber = source.ExternalRelatedNotificationConstructTemplateVersionNumber;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationTitle = source.NotificationTitle;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.NotificationConstructMutatorObjectType = source.NotificationConstructMutatorObjectType;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationNotificationConstructTemplates = source.DefaultOrganisationNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaimTemplates = source.NotificationConstructClaimTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowNotificationConstructTemplates = source.WorkflowNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructDataTemplates = source.NotificationConstructDataTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructParameterTemplates = source.NotificationConstructParameterTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructs = source.NotificationConstructs.ToDtosWithRelated(level - 1);
              target.ArtefactNotificationConstructTemplates = source.ArtefactNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructRoleTemplates = source.NotificationConstructRoleTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargetTemplates = source.NotificationConstructTargetTemplates.ToDtosWithRelated(level - 1);
              target.ModuleNotificationConstructTemplates = source.ModuleNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionParameterNotificationConstructTemplates = source.WorkflowActionParameterNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructTemplates = source.NotificationConstructGroupNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructTemplate ToEntity(this NotificationConstructTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructTemplate();

            // Properties
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTypeID = source.NotificationConstructTypeID;
            target.NotificationConstructSubTypeID = source.NotificationConstructSubTypeID;
            target.NotificationConstructCategoryID = source.NotificationConstructCategoryID;
            target.NotificationConstructSubCategoryID = source.NotificationConstructSubCategoryID;
            target.ExternalRelatedNotificationConstructTemplateID = source.ExternalRelatedNotificationConstructTemplateID;
            target.ExternalRelatedNotificationConstructTemplateVersionNumber = source.ExternalRelatedNotificationConstructTemplateVersionNumber;
            target.NotificationSubject = source.NotificationSubject;
            target.NotificationAdditionalDetails = source.NotificationAdditionalDetails;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeIncludedInBatchNotification = source.CanBeIncludedInBatchNotification;
            target.NotificationDetails = source.NotificationDetails;
            target.NotificationReference = source.NotificationReference;
            target.NotificationTitle = source.NotificationTitle;
            target.DefaultNotificationExportFormatID = source.DefaultNotificationExportFormatID;
            target.DefaultNotificationDeliveryMethodID = source.DefaultNotificationDeliveryMethodID;
            target.NotificationConstructMutatorObjectType = source.NotificationConstructMutatorObjectType;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructTemplate> ToEntities(this IEnumerable<NotificationConstructTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructTemplate source, NotificationConstructTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructTemplate target);

    }

}
