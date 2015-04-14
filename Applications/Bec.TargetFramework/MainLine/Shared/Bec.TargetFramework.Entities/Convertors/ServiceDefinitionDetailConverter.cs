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

    public static partial class ServiceDefinitionDetailConverter
    {

        public static ServiceDefinitionDetailDTO ToDto(this Bec.TargetFramework.Data.ServiceDefinitionDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ServiceDefinitionDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ServiceDefinitionDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new ServiceDefinitionDetailDTO();

            // Properties
            target.ServiceDefinitionDetailID = source.ServiceDefinitionDetailID;
            target.EnvironmentName = source.EnvironmentName;
            target.ServicePartialURL = source.ServicePartialURL;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ServiceDefinitionID = source.ServiceDefinitionID;
            target.ServerURL = source.ServerURL;

            // Navigation Properties
            if (level > 0) {
              target.ServiceDefinition = source.ServiceDefinition.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ServiceDefinitionDetail ToEntity(this ServiceDefinitionDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ServiceDefinitionDetail();

            // Properties
            target.ServiceDefinitionDetailID = source.ServiceDefinitionDetailID;
            target.EnvironmentName = source.EnvironmentName;
            target.ServicePartialURL = source.ServicePartialURL;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ServiceDefinitionID = source.ServiceDefinitionID;
            target.ServerURL = source.ServerURL;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ServiceDefinitionDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ServiceDefinitionDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ServiceDefinitionDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ServiceDefinitionDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ServiceDefinitionDetail> ToEntities(this IEnumerable<ServiceDefinitionDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ServiceDefinitionDetail source, ServiceDefinitionDetailDTO target);

        static partial void OnEntityCreating(ServiceDefinitionDetailDTO source, Bec.TargetFramework.Data.ServiceDefinitionDetail target);

    }

}
