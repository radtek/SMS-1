﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowCommandParameterConverter
    {

        public static WorkflowCommandParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowCommandParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowCommandParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowCommandParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowCommandParameterDTO();

            // Properties
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
              target.WorkflowCommand = source.WorkflowCommand.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowCommandParameter ToEntity(this WorkflowCommandParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowCommandParameter();

            // Properties
            target.WorkflowCommandID = source.WorkflowCommandID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowCommandParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommandParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowCommandParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommandParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowCommandParameter> ToEntities(this IEnumerable<WorkflowCommandParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowCommandParameter source, WorkflowCommandParameterDTO target);

        static partial void OnEntityCreating(WorkflowCommandParameterDTO source, Bec.TargetFramework.Data.WorkflowCommandParameter target);

    }

}
