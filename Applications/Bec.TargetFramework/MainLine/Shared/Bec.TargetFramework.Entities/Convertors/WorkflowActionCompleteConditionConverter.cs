﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionCompleteConditionConverter
    {

        public static WorkflowActionCompleteConditionDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionCompleteCondition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionCompleteConditionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionCompleteCondition source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionCompleteConditionDTO();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowAction = source.WorkflowAction.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionCompleteCondition ToEntity(this WorkflowActionCompleteConditionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionCompleteCondition();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionCompleteConditionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionCompleteCondition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionCompleteConditionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionCompleteCondition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionCompleteCondition> ToEntities(this IEnumerable<WorkflowActionCompleteConditionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionCompleteCondition source, WorkflowActionCompleteConditionDTO target);

        static partial void OnEntityCreating(WorkflowActionCompleteConditionDTO source, Bec.TargetFramework.Data.WorkflowActionCompleteCondition target);

    }

}
