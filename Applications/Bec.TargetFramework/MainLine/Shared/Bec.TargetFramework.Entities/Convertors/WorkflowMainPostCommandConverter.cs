﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowMainPostCommandConverter
    {

        public static WorkflowMainPostCommandDTO ToDto(this Bec.TargetFramework.Data.WorkflowMainPostCommand source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowMainPostCommandDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowMainPostCommand source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowMainPostCommandDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowCommandID = source.WorkflowCommandID;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowCommand = source.WorkflowCommand.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowMainPostCommand ToEntity(this WorkflowMainPostCommandDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowMainPostCommand();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowCommandID = source.WorkflowCommandID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowMainPostCommandDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainPostCommand> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowMainPostCommandDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainPostCommand> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowMainPostCommand> ToEntities(this IEnumerable<WorkflowMainPostCommandDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowMainPostCommand source, WorkflowMainPostCommandDTO target);

        static partial void OnEntityCreating(WorkflowMainPostCommandDTO source, Bec.TargetFramework.Data.WorkflowMainPostCommand target);

    }

}
