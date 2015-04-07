﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionConverter
    {

        public static WorkflowActionDTO ToDto(this Bec.TargetFramework.Data.WorkflowAction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowAction source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionDTO();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTransistionEnd = source.IsTransistionEnd;
            target.WorkflowActionTypeID = source.WorkflowActionTypeID;
            target.IsManual = source.IsManual;
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowObjectType = source.WorkflowObjectType.ToDtoWithRelated(level - 1);
              target.WorkflowActionCompleteConditions = source.WorkflowActionCompleteConditions.ToDtosWithRelated(level - 1);
              target.WorkflowActionExecuteCommands = source.WorkflowActionExecuteCommands.ToDtosWithRelated(level - 1);
              target.WorkflowActionParameters = source.WorkflowActionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowActionPostCommands = source.WorkflowActionPostCommands.ToDtosWithRelated(level - 1);
              target.WorkflowActionStartConditions = source.WorkflowActionStartConditions.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionFailures = source.WorkflowDecisionFailures.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionSuccesses = source.WorkflowDecisionSuccesses.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowActions = source.WorkflowTransistionWorkflowActions.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionErrors = source.WorkflowDecisionErrors.ToDtosWithRelated(level - 1);
              target.WorkflowActionPreCommands = source.WorkflowActionPreCommands.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowAction ToEntity(this WorkflowActionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowAction();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTransistionEnd = source.IsTransistionEnd;
            target.WorkflowActionTypeID = source.WorkflowActionTypeID;
            target.IsManual = source.IsManual;
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowAction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowAction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowAction> ToEntities(this IEnumerable<WorkflowActionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowAction source, WorkflowActionDTO target);

        static partial void OnEntityCreating(WorkflowActionDTO source, Bec.TargetFramework.Data.WorkflowAction target);

    }

}
