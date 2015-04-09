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

    public static partial class WorkflowInstanceExecutionConverter
    {

        public static WorkflowInstanceExecutionDTO ToDto(this Bec.TargetFramework.Data.WorkflowInstanceExecution source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowInstanceExecutionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowInstanceExecution source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowInstanceExecutionDTO();

            // Properties
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.CreatedOn = source.CreatedOn;
            target.NumberOfRetries = source.NumberOfRetries;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowInstanceSession = source.WorkflowInstanceSession.ToDtoWithRelated(level - 1);
              target.WorkflowInstanceExecutionStatusEvents = source.WorkflowInstanceExecutionStatusEvents.ToDtosWithRelated(level - 1);
              target.WorkflowInstanceExecutionTraces = source.WorkflowInstanceExecutionTraces.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowInstanceExecution ToEntity(this WorkflowInstanceExecutionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowInstanceExecution();

            // Properties
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.CreatedOn = source.CreatedOn;
            target.NumberOfRetries = source.NumberOfRetries;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowInstanceExecutionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceExecution> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowInstanceExecutionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceExecution> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowInstanceExecution> ToEntities(this IEnumerable<WorkflowInstanceExecutionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowInstanceExecution source, WorkflowInstanceExecutionDTO target);

        static partial void OnEntityCreating(WorkflowInstanceExecutionDTO source, Bec.TargetFramework.Data.WorkflowInstanceExecution target);

    }

}
