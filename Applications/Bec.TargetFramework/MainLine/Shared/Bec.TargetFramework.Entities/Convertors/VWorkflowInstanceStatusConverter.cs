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

    public static partial class VWorkflowInstanceStatusConverter
    {

        public static VWorkflowInstanceStatusDTO ToDto(this Bec.TargetFramework.Data.VWorkflowInstanceStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VWorkflowInstanceStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VWorkflowInstanceStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new VWorkflowInstanceStatusDTO();

            // Properties
            target.StepName = source.StepName;
            target.StepStatus = source.StepStatus;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VWorkflowInstanceStatus ToEntity(this VWorkflowInstanceStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VWorkflowInstanceStatus();

            // Properties
            target.StepName = source.StepName;
            target.StepStatus = source.StepStatus;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VWorkflowInstanceStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VWorkflowInstanceStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VWorkflowInstanceStatus> ToEntities(this IEnumerable<VWorkflowInstanceStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VWorkflowInstanceStatus source, VWorkflowInstanceStatusDTO target);

        static partial void OnEntityCreating(VWorkflowInstanceStatusDTO source, Bec.TargetFramework.Data.VWorkflowInstanceStatus target);

    }

}
