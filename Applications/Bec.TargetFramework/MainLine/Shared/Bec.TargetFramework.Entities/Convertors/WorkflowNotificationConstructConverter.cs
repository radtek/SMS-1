﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowNotificationConstructConverter
    {

        public static WorkflowNotificationConstructDTO ToDto(this Bec.TargetFramework.Data.WorkflowNotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowNotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowNotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowNotificationConstructDTO();

            // Properties
            target.WorkflowNotificationConstructID = source.WorkflowNotificationConstructID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowNotificationConstruct ToEntity(this WorkflowNotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowNotificationConstruct();

            // Properties
            target.WorkflowNotificationConstructID = source.WorkflowNotificationConstructID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowNotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowNotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowNotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowNotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowNotificationConstruct> ToEntities(this IEnumerable<WorkflowNotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowNotificationConstruct source, WorkflowNotificationConstructDTO target);

        static partial void OnEntityCreating(WorkflowNotificationConstructDTO source, Bec.TargetFramework.Data.WorkflowNotificationConstruct target);

    }

}
