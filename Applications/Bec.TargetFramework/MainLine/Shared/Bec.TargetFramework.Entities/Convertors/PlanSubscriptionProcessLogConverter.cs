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

    public static partial class PlanSubscriptionProcessLogConverter
    {

        public static PlanSubscriptionProcessLogDTO ToDto(this Bec.TargetFramework.Data.PlanSubscriptionProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanSubscriptionProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanSubscriptionProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanSubscriptionProcessLogDTO();

            // Properties
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.IsCancelled = source.IsCancelled;
            target.IsRenewed = source.IsRenewed;
            target.PlanSubscriptionStatusDetail = source.PlanSubscriptionStatusDetail;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanSubscriptionProcessLog ToEntity(this PlanSubscriptionProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanSubscriptionProcessLog();

            // Properties
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.IsCancelled = source.IsCancelled;
            target.IsRenewed = source.IsRenewed;
            target.PlanSubscriptionStatusDetail = source.PlanSubscriptionStatusDetail;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanSubscriptionProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanSubscriptionProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanSubscriptionProcessLog> ToEntities(this IEnumerable<PlanSubscriptionProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanSubscriptionProcessLog source, PlanSubscriptionProcessLogDTO target);

        static partial void OnEntityCreating(PlanSubscriptionProcessLogDTO source, Bec.TargetFramework.Data.PlanSubscriptionProcessLog target);

    }

}
