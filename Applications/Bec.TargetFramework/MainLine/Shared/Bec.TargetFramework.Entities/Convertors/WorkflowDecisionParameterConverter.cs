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

    public static partial class WorkflowDecisionParameterConverter
    {

        public static WorkflowDecisionParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionParameterDTO();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowDecision = source.WorkflowDecision.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowDecisionParameter ToEntity(this WorkflowDecisionParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionParameter();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowParameterID = source.WorkflowParameterID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionParameter> ToEntities(this IEnumerable<WorkflowDecisionParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionParameter source, WorkflowDecisionParameterDTO target);

        static partial void OnEntityCreating(WorkflowDecisionParameterDTO source, Bec.TargetFramework.Data.WorkflowDecisionParameter target);

    }

}
