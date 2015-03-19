﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowMainStartConditionConverter
    {

        public static WorkflowMainStartConditionDTO ToDto(this Bec.TargetFramework.Data.WorkflowMainStartCondition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowMainStartConditionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowMainStartCondition source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowMainStartConditionDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowConditionID = source.WorkflowConditionID;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowCondition = source.WorkflowCondition.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowMainStartCondition ToEntity(this WorkflowMainStartConditionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowMainStartCondition();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowConditionID = source.WorkflowConditionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowMainStartConditionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainStartCondition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowMainStartConditionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainStartCondition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowMainStartCondition> ToEntities(this IEnumerable<WorkflowMainStartConditionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowMainStartCondition source, WorkflowMainStartConditionDTO target);

        static partial void OnEntityCreating(WorkflowMainStartConditionDTO source, Bec.TargetFramework.Data.WorkflowMainStartCondition target);

    }

}
