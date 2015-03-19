﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowInstanceExecutionStatusEventConverter
    {

        public static WorkflowInstanceExecutionStatusEventDTO ToDto(this Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowInstanceExecutionStatusEventDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowInstanceExecutionStatusEventDTO();

            // Properties
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.EventDate = source.EventDate;
            target.EventBy = source.EventBy;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.EventOrder = source.EventOrder;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowInstanceID = source.WorkflowInstanceID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowInstanceExecution = source.WorkflowInstanceExecution.ToDtoWithRelated(level - 1);
              target.WorkflowExecutionStatus = source.WorkflowExecutionStatus.ToDtoWithRelated(level - 1);
              target.WorkflowInstanceExecutionDataItems = source.WorkflowInstanceExecutionDataItems.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent ToEntity(this WorkflowInstanceExecutionStatusEventDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent();

            // Properties
            target.WorkflowInstanceExecutionStatusEventID = source.WorkflowInstanceExecutionStatusEventID;
            target.EventDate = source.EventDate;
            target.EventBy = source.EventBy;
            target.WorkflowExecutionStatusID = source.WorkflowExecutionStatusID;
            target.WorkflowInstanceExecutionID = source.WorkflowInstanceExecutionID;
            target.EventOrder = source.EventOrder;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.WorkflowInstanceID = source.WorkflowInstanceID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowInstanceExecutionStatusEventDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowInstanceExecutionStatusEventDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent> ToEntities(this IEnumerable<WorkflowInstanceExecutionStatusEventDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent source, WorkflowInstanceExecutionStatusEventDTO target);

        static partial void OnEntityCreating(WorkflowInstanceExecutionStatusEventDTO source, Bec.TargetFramework.Data.WorkflowInstanceExecutionStatusEvent target);

    }

}
