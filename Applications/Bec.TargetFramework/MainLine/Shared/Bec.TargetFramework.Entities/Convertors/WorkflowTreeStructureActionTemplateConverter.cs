﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTreeStructureActionTemplateConverter
    {

        public static WorkflowTreeStructureActionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTreeStructureActionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTreeStructureActionTemplateDTO();

            // Properties
            target.WorkflowTreeStructureActionTemplateID = source.WorkflowTreeStructureActionTemplateID;
            target.WorkflowTreeStructureTemplateID = source.WorkflowTreeStructureTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate ToEntity(this WorkflowTreeStructureActionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate();

            // Properties
            target.WorkflowTreeStructureActionTemplateID = source.WorkflowTreeStructureActionTemplateID;
            target.WorkflowTreeStructureTemplateID = source.WorkflowTreeStructureTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ConditionString = source.ConditionString;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTreeStructureActionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTreeStructureActionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate> ToEntities(this IEnumerable<WorkflowTreeStructureActionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate source, WorkflowTreeStructureActionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTreeStructureActionTemplateDTO source, Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate target);

    }

}
