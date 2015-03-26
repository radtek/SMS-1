﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 24/03/2015 09:58:29
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Analysis.Entities
{

    public static partial class AnalysisProcessLogStepOutputConverter
    {

        public static AnalysisProcessLogStepOutputDTO ToDto(this Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AnalysisProcessLogStepOutputDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput source, int level)
        {
            if (source == null)
              return null;

            var target = new AnalysisProcessLogStepOutputDTO();

            // Properties
            target.AnalysisProcessLogStepOutputID = source.AnalysisProcessLogStepOutputID;
            target.AnalysisProcessLogID = source.AnalysisProcessLogID;
            target.CreatedOn = source.CreatedOn;
            target.Output = source.Output;
            target.OutputType = source.OutputType;

            // Navigation Properties
            if (level > 0) {
              target.AnalysisProcessLog = source.AnalysisProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput ToEntity(this AnalysisProcessLogStepOutputDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput();

            // Properties
            target.AnalysisProcessLogStepOutputID = source.AnalysisProcessLogStepOutputID;
            target.AnalysisProcessLogID = source.AnalysisProcessLogID;
            target.CreatedOn = source.CreatedOn;
            target.Output = source.Output;
            target.OutputType = source.OutputType;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AnalysisProcessLogStepOutputDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AnalysisProcessLogStepOutputDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput> ToEntities(this IEnumerable<AnalysisProcessLogStepOutputDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput source, AnalysisProcessLogStepOutputDTO target);

        static partial void OnEntityCreating(AnalysisProcessLogStepOutputDTO source, Bec.TargetFramework.Data.Analysis.AnalysisProcessLogStepOutput target);

    }

}
