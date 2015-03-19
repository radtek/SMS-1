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

    public static partial class WorkflowStatusTypeConverter
    {

        public static WorkflowStatusTypeDTO ToDto(this Bec.TargetFramework.Data.WorkflowStatusType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowStatusTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowStatusType source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowStatusTypeDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowStatusType ToEntity(this WorkflowStatusTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowStatusType();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowStatusTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowStatusType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowStatusTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowStatusType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowStatusType> ToEntities(this IEnumerable<WorkflowStatusTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowStatusType source, WorkflowStatusTypeDTO target);

        static partial void OnEntityCreating(WorkflowStatusTypeDTO source, Bec.TargetFramework.Data.WorkflowStatusType target);

    }

}
