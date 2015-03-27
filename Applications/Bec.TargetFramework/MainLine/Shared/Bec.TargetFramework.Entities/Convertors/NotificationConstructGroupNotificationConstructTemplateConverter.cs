﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructGroupNotificationConstructTemplateConverter
    {

        public static NotificationConstructGroupNotificationConstructTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructGroupNotificationConstructTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructGroupNotificationConstructTemplateDTO();

            // Properties
            target.NotificationConstructGroupNotificationConstructTemplateID = source.NotificationConstructGroupNotificationConstructTemplateID;
            target.NotificationConstructGroupNotificationConstructTemplateVersion = source.NotificationConstructGroupNotificationConstructTemplateVersion;
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.UserTypeID = source.UserTypeID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructGroupTemplate = source.NotificationConstructGroupTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate ToEntity(this NotificationConstructGroupNotificationConstructTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate();

            // Properties
            target.NotificationConstructGroupNotificationConstructTemplateID = source.NotificationConstructGroupNotificationConstructTemplateID;
            target.NotificationConstructGroupNotificationConstructTemplateVersion = source.NotificationConstructGroupNotificationConstructTemplateVersion;
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.UserTypeID = source.UserTypeID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructGroupNotificationConstructTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructGroupNotificationConstructTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate> ToEntities(this IEnumerable<NotificationConstructGroupNotificationConstructTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate source, NotificationConstructGroupNotificationConstructTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructGroupNotificationConstructTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructGroupNotificationConstructTemplate target);

    }

}
