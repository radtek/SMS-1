﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowConditionParameterConverter
    {

        public static WorkflowConditionParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowConditionParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowConditionParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowConditionParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowConditionParameterDTO();

            // Properties
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowConditionParameter ToEntity(this WorkflowConditionParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowConditionParameter();

            // Properties
            target.WorkflowConditionID = source.WorkflowConditionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowConditionParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowConditionParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowConditionParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowConditionParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowConditionParameter> ToEntities(this IEnumerable<WorkflowConditionParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowConditionParameter source, WorkflowConditionParameterDTO target);

        static partial void OnEntityCreating(WorkflowConditionParameterDTO source, Bec.TargetFramework.Data.WorkflowConditionParameter target);

    }

}
