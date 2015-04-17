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

    public static partial class WorkflowExecutionStatusConverter
    {

        public static WorkflowExecutionStatusDTO ToDto(this Bec.TargetFramework.Data.WorkflowExecutionStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowExecutionStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowExecutionStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowExecutionStatusDTO();

            // Properties
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.Name = source.Name;
            target.Description = source.Description;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowInstanceExecutionStatusEvents = source.WorkflowInstanceExecutionStatusEvents.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowExecutionStatus ToEntity(this WorkflowExecutionStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowExecutionStatus();

            // Properties
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.Name = source.Name;
            target.Description = source.Description;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowExecutionStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowExecutionStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowExecutionStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowExecutionStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowExecutionStatus> ToEntities(this IEnumerable<WorkflowExecutionStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowExecutionStatus source, WorkflowExecutionStatusDTO target);

        static partial void OnEntityCreating(WorkflowExecutionStatusDTO source, Bec.TargetFramework.Data.WorkflowExecutionStatus target);

    }

}
