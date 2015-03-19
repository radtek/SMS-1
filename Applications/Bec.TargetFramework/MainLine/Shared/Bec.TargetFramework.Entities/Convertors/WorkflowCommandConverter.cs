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

    public static partial class WorkflowCommandConverter
    {

        public static WorkflowCommandDTO ToDto(this Bec.TargetFramework.Data.WorkflowCommand source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowCommandDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowCommand source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowCommandDTO();

            // Properties
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActionExecuteCommands = source.WorkflowActionExecuteCommands.ToDtosWithRelated(level - 1);
              target.WorkflowActionPostCommands = source.WorkflowActionPostCommands.ToDtosWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowObjectType = source.WorkflowObjectType.ToDtoWithRelated(level - 1);
              target.WorkflowCommandParameters = source.WorkflowCommandParameters.ToDtosWithRelated(level - 1);
              target.WorkflowMainExecuteCommand = source.WorkflowMainExecuteCommand.ToDtoWithRelated(level - 1);
              target.WorkflowMainPostCommand = source.WorkflowMainPostCommand.ToDtoWithRelated(level - 1);
              target.WorkflowMainPreCommand = source.WorkflowMainPreCommand.ToDtoWithRelated(level - 1);
              target.WorkflowCommandConditions = source.WorkflowCommandConditions.ToDtosWithRelated(level - 1);
              target.WorkflowActionPreCommands = source.WorkflowActionPreCommands.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowCommand ToEntity(this WorkflowCommandDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowCommand();

            // Properties
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowObjectTypeID = source.WorkflowObjectTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowCommandDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommand> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowCommandDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommand> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowCommand> ToEntities(this IEnumerable<WorkflowCommandDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowCommand source, WorkflowCommandDTO target);

        static partial void OnEntityCreating(WorkflowCommandDTO source, Bec.TargetFramework.Data.WorkflowCommand target);

    }

}
