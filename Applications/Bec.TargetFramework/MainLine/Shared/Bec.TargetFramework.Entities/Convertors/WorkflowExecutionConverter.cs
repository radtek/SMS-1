﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowExecutionConverter
    {

        public static WorkflowExecutionDTO ToDto(this Bec.TargetFramework.Data.WorkflowExecution source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowExecutionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowExecution source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowExecutionDTO();

            // Properties
            target.WorkflowExecutionID = source.WorkflowExecutionID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.VersionNumber = source.VersionNumber;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowExecution ToEntity(this WorkflowExecutionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowExecution();

            // Properties
            target.WorkflowExecutionID = source.WorkflowExecutionID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.VersionNumber = source.VersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowExecutionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowExecution> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowExecutionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowExecution> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowExecution> ToEntities(this IEnumerable<WorkflowExecutionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowExecution source, WorkflowExecutionDTO target);

        static partial void OnEntityCreating(WorkflowExecutionDTO source, Bec.TargetFramework.Data.WorkflowExecution target);

    }

}
