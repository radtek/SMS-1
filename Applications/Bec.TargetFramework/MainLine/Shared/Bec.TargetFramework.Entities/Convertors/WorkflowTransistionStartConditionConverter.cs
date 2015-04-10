﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTransistionStartConditionConverter
    {

        public static WorkflowTransistionStartConditionDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionStartCondition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionStartConditionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionStartCondition source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionStartConditionDTO();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowTransistion = source.WorkflowTransistion.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionStartCondition ToEntity(this WorkflowTransistionStartConditionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionStartCondition();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionStartConditionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionStartCondition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionStartConditionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionStartCondition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionStartCondition> ToEntities(this IEnumerable<WorkflowTransistionStartConditionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionStartCondition source, WorkflowTransistionStartConditionDTO target);

        static partial void OnEntityCreating(WorkflowTransistionStartConditionDTO source, Bec.TargetFramework.Data.WorkflowTransistionStartCondition target);

    }

}
