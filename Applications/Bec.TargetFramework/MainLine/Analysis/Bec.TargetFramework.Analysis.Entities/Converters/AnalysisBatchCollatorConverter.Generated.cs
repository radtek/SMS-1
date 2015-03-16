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

    public static partial class AnalysisBatchCollatorConverter
    {

        public static AnalysisBatchCollatorDTO ToDto(this Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AnalysisBatchCollatorDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator source, int level)
        {
            if (source == null)
              return null;

            var target = new AnalysisBatchCollatorDTO();

            // Properties
            target.AnalysisBatchCollatorID = source.AnalysisBatchCollatorID;
            target.AnalysisBatchCollatorVersionNumber = source.AnalysisBatchCollatorVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AnalysisBatchCollatorTypeID = source.AnalysisBatchCollatorTypeID;
            target.AnalysisBatchCollatorCategoryID = source.AnalysisBatchCollatorCategoryID;
            target.ObjectName = source.ObjectName;
            target.ObjectAssembly = source.ObjectAssembly;

            // Navigation Properties
            if (level > 0) {
              target.AnalysisInterfaces = source.AnalysisInterfaces.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator ToEntity(this AnalysisBatchCollatorDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator();

            // Properties
            target.AnalysisBatchCollatorID = source.AnalysisBatchCollatorID;
            target.AnalysisBatchCollatorVersionNumber = source.AnalysisBatchCollatorVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AnalysisBatchCollatorTypeID = source.AnalysisBatchCollatorTypeID;
            target.AnalysisBatchCollatorCategoryID = source.AnalysisBatchCollatorCategoryID;
            target.ObjectName = source.ObjectName;
            target.ObjectAssembly = source.ObjectAssembly;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AnalysisBatchCollatorDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AnalysisBatchCollatorDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator> ToEntities(this IEnumerable<AnalysisBatchCollatorDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator source, AnalysisBatchCollatorDTO target);

        static partial void OnEntityCreating(AnalysisBatchCollatorDTO source, Bec.TargetFramework.Data.Analysis.AnalysisBatchCollator target);

    }

}
