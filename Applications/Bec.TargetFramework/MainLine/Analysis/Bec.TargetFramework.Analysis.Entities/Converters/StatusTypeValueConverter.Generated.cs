﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/5/2015 2:37:38 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Analysis
{

    public static partial class StatusTypeValueConverter
    {

        public static StatusTypeValueDTO ToDto(this Bec.TargetFramework.Data.Analysis.StatusTypeValue source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeValueDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Analysis.StatusTypeValue source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeValueDTO();

            // Properties
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.AnalysisProcessLogs = source.AnalysisProcessLogs.ToDtosWithRelated(level - 1);
              target.AnalysisProcessLogSteps = source.AnalysisProcessLogSteps.ToDtosWithRelated(level - 1);
              target.AnalysisProcessLogBatches = source.AnalysisProcessLogBatches.ToDtosWithRelated(level - 1);
              target.AnalysisProcessLogBatchDetails = source.AnalysisProcessLogBatchDetails.ToDtosWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Analysis.StatusTypeValue ToEntity(this StatusTypeValueDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Analysis.StatusTypeValue();

            // Properties
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeValueDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Analysis.StatusTypeValue> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeValueDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Analysis.StatusTypeValue> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Analysis.StatusTypeValue> ToEntities(this IEnumerable<StatusTypeValueDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Analysis.StatusTypeValue source, StatusTypeValueDTO target);

        static partial void OnEntityCreating(StatusTypeValueDTO source, Bec.TargetFramework.Data.Analysis.StatusTypeValue target);

    }

}
