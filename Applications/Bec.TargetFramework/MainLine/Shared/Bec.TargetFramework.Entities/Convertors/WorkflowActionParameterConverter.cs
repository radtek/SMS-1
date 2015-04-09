﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionParameterConverter
    {

        public static WorkflowActionParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionParameterDTO();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowAction = source.WorkflowAction.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionParameter ToEntity(this WorkflowActionParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionParameter();

            // Properties
            target.WorkflowActionID = source.WorkflowActionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionParameter> ToEntities(this IEnumerable<WorkflowActionParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionParameter source, WorkflowActionParameterDTO target);

        static partial void OnEntityCreating(WorkflowActionParameterDTO source, Bec.TargetFramework.Data.WorkflowActionParameter target);

    }

}
