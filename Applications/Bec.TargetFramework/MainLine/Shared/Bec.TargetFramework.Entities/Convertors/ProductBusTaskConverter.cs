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

    public static partial class ProductBusTaskConverter
    {

        public static ProductBusTaskDTO ToDto(this Bec.TargetFramework.Data.ProductBusTask source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductBusTaskDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductBusTask source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductBusTaskDTO();

            // Properties
            target.ProductBusTaskID = source.ProductBusTaskID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskID = source.BusTaskID;
            target.Order = source.Order;
            target.BusTaskVersionNumber = source.BusTaskVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.ProductPurchaseBusTaskProcessLogs = source.ProductPurchaseBusTaskProcessLogs.ToDtosWithRelated(level - 1);
              target.BusTask = source.BusTask.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductBusTask ToEntity(this ProductBusTaskDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductBusTask();

            // Properties
            target.ProductBusTaskID = source.ProductBusTaskID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskID = source.BusTaskID;
            target.Order = source.Order;
            target.BusTaskVersionNumber = source.BusTaskVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductBusTaskDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductBusTask> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductBusTaskDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductBusTask> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductBusTask> ToEntities(this IEnumerable<ProductBusTaskDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductBusTask source, ProductBusTaskDTO target);

        static partial void OnEntityCreating(ProductBusTaskDTO source, Bec.TargetFramework.Data.ProductBusTask target);

    }

}
