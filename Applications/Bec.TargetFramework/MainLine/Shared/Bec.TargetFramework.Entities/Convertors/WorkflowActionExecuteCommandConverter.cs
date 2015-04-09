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

    public static partial class WorkflowActionExecuteCommandConverter
    {

        public static WorkflowActionExecuteCommandDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionExecuteCommand source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionExecuteCommandDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionExecuteCommand source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionExecuteCommandDTO();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowAction = source.WorkflowAction.ToDtoWithRelated(level - 1);
              target.WorkflowCommand = source.WorkflowCommand.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionExecuteCommand ToEntity(this WorkflowActionExecuteCommandDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionExecuteCommand();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionExecuteCommandDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecuteCommand> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionExecuteCommandDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecuteCommand> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionExecuteCommand> ToEntities(this IEnumerable<WorkflowActionExecuteCommandDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionExecuteCommand source, WorkflowActionExecuteCommandDTO target);

        static partial void OnEntityCreating(WorkflowActionExecuteCommandDTO source, Bec.TargetFramework.Data.WorkflowActionExecuteCommand target);

    }

}
