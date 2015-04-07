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

    public static partial class NotificationConstructParameterConverter
    {

        public static NotificationConstructParameterDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructParameterDTO();

            // Properties
            target.NotificationConstructParameterID = source.NotificationConstructParameterID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
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
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructParameter ToEntity(this NotificationConstructParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructParameter();

            // Properties
            target.NotificationConstructParameterID = source.NotificationConstructParameterID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
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

        public static List<NotificationConstructParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructParameter> ToEntities(this IEnumerable<NotificationConstructParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructParameter source, NotificationConstructParameterDTO target);

        static partial void OnEntityCreating(NotificationConstructParameterDTO source, Bec.TargetFramework.Data.NotificationConstructParameter target);

    }

}
