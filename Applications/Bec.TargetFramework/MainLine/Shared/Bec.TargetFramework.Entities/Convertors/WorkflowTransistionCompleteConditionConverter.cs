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

    public static partial class WorkflowTransistionCompleteConditionConverter
    {

        public static WorkflowTransistionCompleteConditionDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionCompleteConditionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionCompleteConditionDTO();

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

        public static Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition ToEntity(this WorkflowTransistionCompleteConditionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionCompleteConditionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionCompleteConditionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition> ToEntities(this IEnumerable<WorkflowTransistionCompleteConditionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition source, WorkflowTransistionCompleteConditionDTO target);

        static partial void OnEntityCreating(WorkflowTransistionCompleteConditionDTO source, Bec.TargetFramework.Data.WorkflowTransistionCompleteCondition target);

    }

}
