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

    public static partial class NotificationConstructDataTemplateConverter
    {

        public static NotificationConstructDataTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructDataTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructDataTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructDataTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructDataTemplateDTO();

            // Properties
            target.NotificationConstructDataTemplateID = source.NotificationConstructDataTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationData = source.NotificationData;
            target.NotificationDataLength = source.NotificationDataLength;
            target.NotificationDataMimeType = source.NotificationDataMimeType;
            target.NotificationDataFileName = source.NotificationDataFileName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CreatedOn = source.CreatedOn;
            target.UsesBusinessObjects = source.UsesBusinessObjects;
            target.UsesDataSources = source.UsesDataSources;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructDataTemplate ToEntity(this NotificationConstructDataTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructDataTemplate();

            // Properties
            target.NotificationConstructDataTemplateID = source.NotificationConstructDataTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.NotificationData = source.NotificationData;
            target.NotificationDataLength = source.NotificationDataLength;
            target.NotificationDataMimeType = source.NotificationDataMimeType;
            target.NotificationDataFileName = source.NotificationDataFileName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CreatedOn = source.CreatedOn;
            target.UsesBusinessObjects = source.UsesBusinessObjects;
            target.UsesDataSources = source.UsesDataSources;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructDataTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructDataTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructDataTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructDataTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructDataTemplate> ToEntities(this IEnumerable<NotificationConstructDataTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructDataTemplate source, NotificationConstructDataTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructDataTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructDataTemplate target);

    }

}
