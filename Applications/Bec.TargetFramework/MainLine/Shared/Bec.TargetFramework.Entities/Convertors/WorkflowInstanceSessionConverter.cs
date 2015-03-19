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

    public static partial class WorkflowInstanceSessionConverter
    {

        public static WorkflowInstanceSessionDTO ToDto(this Bec.TargetFramework.Data.WorkflowInstanceSession source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowInstanceSessionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowInstanceSession source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowInstanceSessionDTO();

            // Properties
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.SessionStartedOn = source.SessionStartedOn;
            target.SessionEndedOn = source.SessionEndedOn;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowInstance = source.WorkflowInstance.ToDtoWithRelated(level - 1);
              target.WorkflowInstanceExecutions = source.WorkflowInstanceExecutions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowInstanceSession ToEntity(this WorkflowInstanceSessionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowInstanceSession();

            // Properties
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.SessionStartedOn = source.SessionStartedOn;
            target.SessionEndedOn = source.SessionEndedOn;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowInstanceSessionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceSession> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowInstanceSessionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowInstanceSession> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowInstanceSession> ToEntities(this IEnumerable<WorkflowInstanceSessionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowInstanceSession source, WorkflowInstanceSessionDTO target);

        static partial void OnEntityCreating(WorkflowInstanceSessionDTO source, Bec.TargetFramework.Data.WorkflowInstanceSession target);

    }

}
