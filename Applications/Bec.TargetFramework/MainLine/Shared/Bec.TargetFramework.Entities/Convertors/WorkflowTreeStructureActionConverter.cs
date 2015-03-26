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

    public static partial class WorkflowTreeStructureActionConverter
    {

        public static WorkflowTreeStructureActionDTO ToDto(this Bec.TargetFramework.Data.WorkflowTreeStructureAction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTreeStructureActionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTreeStructureAction source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTreeStructureActionDTO();

            // Properties
            target.WorkflowTreeStructureActionID = source.WorkflowTreeStructureActionID;
            target.WorkflowTreeStructureID = source.WorkflowTreeStructureID;
            target.WorkflowActionID = source.WorkflowActionID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTreeStructureAction ToEntity(this WorkflowTreeStructureActionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTreeStructureAction();

            // Properties
            target.WorkflowTreeStructureActionID = source.WorkflowTreeStructureActionID;
            target.WorkflowTreeStructureID = source.WorkflowTreeStructureID;
            target.WorkflowActionID = source.WorkflowActionID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTreeStructureActionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureAction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTreeStructureActionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureAction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTreeStructureAction> ToEntities(this IEnumerable<WorkflowTreeStructureActionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTreeStructureAction source, WorkflowTreeStructureActionDTO target);

        static partial void OnEntityCreating(WorkflowTreeStructureActionDTO source, Bec.TargetFramework.Data.WorkflowTreeStructureAction target);

    }

}
