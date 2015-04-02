﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructParameterTemplateConverter
    {

        public static NotificationConstructParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructParameterTemplateDTO();

            // Properties
            target.NotificationConstructParameterTemplateID = source.NotificationConstructParameterTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ParameterOrBusinessObjectName = source.ParameterOrBusinessObjectName;
            target.DefaultValue = source.DefaultValue;
            target.ObjectType = source.ObjectType;
            target.ObjectName = source.ObjectName;
            target.ObjectNameSpace = source.ObjectNameSpace;
            target.ObjectAssembly = source.ObjectAssembly;
            target.ObjectParentName = source.ObjectParentName;
            target.ObjectParentNameSpace = source.ObjectParentNameSpace;
            target.ObjectParentAssembly = source.ObjectParentAssembly;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsBusinessObject = source.IsBusinessObject;
            target.BusinessObjectCategoryName = source.BusinessObjectCategoryName;
            target.ObjectParentType = source.ObjectParentType;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructParameterTemplate ToEntity(this NotificationConstructParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructParameterTemplate();

            // Properties
            target.NotificationConstructParameterTemplateID = source.NotificationConstructParameterTemplateID;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ParameterOrBusinessObjectName = source.ParameterOrBusinessObjectName;
            target.DefaultValue = source.DefaultValue;
            target.ObjectType = source.ObjectType;
            target.ObjectName = source.ObjectName;
            target.ObjectNameSpace = source.ObjectNameSpace;
            target.ObjectAssembly = source.ObjectAssembly;
            target.ObjectParentName = source.ObjectParentName;
            target.ObjectParentNameSpace = source.ObjectParentNameSpace;
            target.ObjectParentAssembly = source.ObjectParentAssembly;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsBusinessObject = source.IsBusinessObject;
            target.BusinessObjectCategoryName = source.BusinessObjectCategoryName;
            target.ObjectParentType = source.ObjectParentType;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructParameterTemplate> ToEntities(this IEnumerable<NotificationConstructParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructParameterTemplate source, NotificationConstructParameterTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructParameterTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructParameterTemplate target);

    }

}
