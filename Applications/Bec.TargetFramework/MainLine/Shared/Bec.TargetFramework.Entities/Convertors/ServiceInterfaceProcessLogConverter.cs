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

    public static partial class ServiceInterfaceProcessLogConverter
    {

        public static ServiceInterfaceProcessLogDTO ToDto(this Bec.TargetFramework.Data.ServiceInterfaceProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ServiceInterfaceProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ServiceInterfaceProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new ServiceInterfaceProcessLogDTO();

            // Properties
            target.ServiceInterfaceProcessLogID = source.ServiceInterfaceProcessLogID;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsComplete = source.IsComplete;
            target.NumberOfRetries = source.NumberOfRetries;
            target.HasError = source.HasError;
            target.ServiceDefinitionID = source.ServiceDefinitionID;
            target.ProcessDetail = source.ProcessDetail;
            target.ProcessMessage = source.ProcessMessage;
            target.ParentID = source.ParentID;

            // Navigation Properties
            if (level > 0) {
              target.ServiceDefinition = source.ServiceDefinition.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.ProductPurchaseBusTaskProcessLog = source.ProductPurchaseBusTaskProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ServiceInterfaceProcessLog ToEntity(this ServiceInterfaceProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ServiceInterfaceProcessLog();

            // Properties
            target.ServiceInterfaceProcessLogID = source.ServiceInterfaceProcessLogID;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsComplete = source.IsComplete;
            target.NumberOfRetries = source.NumberOfRetries;
            target.HasError = source.HasError;
            target.ServiceDefinitionID = source.ServiceDefinitionID;
            target.ProcessDetail = source.ProcessDetail;
            target.ProcessMessage = source.ProcessMessage;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ServiceInterfaceProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ServiceInterfaceProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ServiceInterfaceProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ServiceInterfaceProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ServiceInterfaceProcessLog> ToEntities(this IEnumerable<ServiceInterfaceProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ServiceInterfaceProcessLog source, ServiceInterfaceProcessLogDTO target);

        static partial void OnEntityCreating(ServiceInterfaceProcessLogDTO source, Bec.TargetFramework.Data.ServiceInterfaceProcessLog target);

    }

}
