﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowParameterConverter
    {

        public static WorkflowParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowParameterDTO();

            // Properties
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowActionParameters = source.WorkflowActionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowConditionParameters = source.WorkflowConditionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowCommandParameters = source.WorkflowCommandParameters.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionParameters = source.WorkflowDecisionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionParameters = source.WorkflowTransistionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowMainParameter = source.WorkflowMainParameter.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowParameter ToEntity(this WorkflowParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowParameter();

            // Properties
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowParameter> ToEntities(this IEnumerable<WorkflowParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowParameter source, WorkflowParameterDTO target);

        static partial void OnEntityCreating(WorkflowParameterDTO source, Bec.TargetFramework.Data.WorkflowParameter target);

    }

}
