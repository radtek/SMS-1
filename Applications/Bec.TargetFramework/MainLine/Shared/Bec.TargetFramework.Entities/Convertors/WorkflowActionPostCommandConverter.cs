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

    public static partial class WorkflowActionPostCommandConverter
    {

        public static WorkflowActionPostCommandDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionPostCommand source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionPostCommandDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionPostCommand source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionPostCommandDTO();

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

        public static Bec.TargetFramework.Data.WorkflowActionPostCommand ToEntity(this WorkflowActionPostCommandDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionPostCommand();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionPostCommandDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPostCommand> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionPostCommandDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPostCommand> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionPostCommand> ToEntities(this IEnumerable<WorkflowActionPostCommandDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionPostCommand source, WorkflowActionPostCommandDTO target);

        static partial void OnEntityCreating(WorkflowActionPostCommandDTO source, Bec.TargetFramework.Data.WorkflowActionPostCommand target);

    }

}
