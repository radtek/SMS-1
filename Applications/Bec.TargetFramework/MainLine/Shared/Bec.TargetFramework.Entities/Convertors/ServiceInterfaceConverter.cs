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

    public static partial class ServiceInterfaceConverter
    {

        public static ServiceInterfaceDTO ToDto(this Bec.TargetFramework.Data.ServiceInterface source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ServiceInterfaceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ServiceInterface source, int level)
        {
            if (source == null)
              return null;

            var target = new ServiceInterfaceDTO();

            // Properties
            target.ServiceInterfaceID = source.ServiceInterfaceID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ServiceInterfaceTypeID = source.ServiceInterfaceTypeID;
            target.ServiceInterfaceCategoryID = source.ServiceInterfaceCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ServiceDefinitions = source.ServiceDefinitions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ServiceInterface ToEntity(this ServiceInterfaceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ServiceInterface();

            // Properties
            target.ServiceInterfaceID = source.ServiceInterfaceID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ServiceInterfaceTypeID = source.ServiceInterfaceTypeID;
            target.ServiceInterfaceCategoryID = source.ServiceInterfaceCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ServiceInterfaceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ServiceInterface> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ServiceInterfaceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ServiceInterface> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ServiceInterface> ToEntities(this IEnumerable<ServiceInterfaceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ServiceInterface source, ServiceInterfaceDTO target);

        static partial void OnEntityCreating(ServiceInterfaceDTO source, Bec.TargetFramework.Data.ServiceInterface target);

    }

}
