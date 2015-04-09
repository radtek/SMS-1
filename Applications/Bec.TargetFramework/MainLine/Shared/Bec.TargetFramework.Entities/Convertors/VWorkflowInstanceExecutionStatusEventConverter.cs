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

    public static partial class VWorkflowInstanceExecutionStatusEventConverter
    {

        public static VWorkflowInstanceExecutionStatusEventDTO ToDto(this Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VWorkflowInstanceExecutionStatusEventDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent source, int level)
        {
            if (source == null)
              return null;

            var target = new VWorkflowInstanceExecutionStatusEventDTO();

            // Properties
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.EventDate = source.EventDate;
            target.EventBy = source.EventBy;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.EventOrder = source.EventOrder;
            target.Name = source.Name;
            target.ActionDecision = source.ActionDecision;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent ToEntity(this VWorkflowInstanceExecutionStatusEventDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent();

            // Properties
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.EventDate = source.EventDate;
            target.EventBy = source.EventBy;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.EventOrder = source.EventOrder;
            target.Name = source.Name;
            target.ActionDecision = source.ActionDecision;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VWorkflowInstanceExecutionStatusEventDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VWorkflowInstanceExecutionStatusEventDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent> ToEntities(this IEnumerable<VWorkflowInstanceExecutionStatusEventDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent source, VWorkflowInstanceExecutionStatusEventDTO target);

        static partial void OnEntityCreating(VWorkflowInstanceExecutionStatusEventDTO source, Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent target);

    }

}
