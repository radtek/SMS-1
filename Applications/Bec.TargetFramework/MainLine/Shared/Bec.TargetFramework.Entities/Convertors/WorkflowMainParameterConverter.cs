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

    public static partial class WorkflowMainParameterConverter
    {

        public static WorkflowMainParameterDTO ToDto(this Bec.TargetFramework.Data.WorkflowMainParameter source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowMainParameterDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowMainParameter source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowMainParameterDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowParameterID = source.WorkflowParameterID;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowParameter = source.WorkflowParameter.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowMainParameter ToEntity(this WorkflowMainParameterDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowMainParameter();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowParameterID = source.WorkflowParameterID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowMainParameterDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainParameter> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowMainParameterDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainParameter> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowMainParameter> ToEntities(this IEnumerable<WorkflowMainParameterDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowMainParameter source, WorkflowMainParameterDTO target);

        static partial void OnEntityCreating(WorkflowMainParameterDTO source, Bec.TargetFramework.Data.WorkflowMainParameter target);

    }

}
