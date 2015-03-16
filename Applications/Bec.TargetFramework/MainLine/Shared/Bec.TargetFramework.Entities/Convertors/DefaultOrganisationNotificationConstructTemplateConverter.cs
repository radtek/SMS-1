﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationNotificationConstructTemplateConverter
    {

        public static DefaultOrganisationNotificationConstructTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationNotificationConstructTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationNotificationConstructTemplateDTO();

            // Properties
            target.DefaultOrganisationNotificationConstructTemplateID = source.DefaultOrganisationNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ParentID = source.ParentID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate ToEntity(this DefaultOrganisationNotificationConstructTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate();

            // Properties
            target.DefaultOrganisationNotificationConstructTemplateID = source.DefaultOrganisationNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ParentID = source.ParentID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationNotificationConstructTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationNotificationConstructTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate> ToEntities(this IEnumerable<DefaultOrganisationNotificationConstructTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate source, DefaultOrganisationNotificationConstructTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationNotificationConstructTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationNotificationConstructTemplate target);

    }

}
