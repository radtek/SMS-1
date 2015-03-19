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

    public static partial class WorkflowHierarchyConverter
    {

        public static WorkflowHierarchyDTO ToDto(this Bec.TargetFramework.Data.WorkflowHierarchy source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowHierarchyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowHierarchy source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowHierarchyDTO();

            // Properties
            target.WorkflowHierarchyID = source.WorkflowHierarchyID;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTranistionEnd = source.IsTranistionEnd;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.IsChildDependentOnParent = source.IsChildDependentOnParent;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowTransistion = source.WorkflowTransistion.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowHierarchy ToEntity(this WorkflowHierarchyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowHierarchy();

            // Properties
            target.WorkflowHierarchyID = source.WorkflowHierarchyID;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTranistionEnd = source.IsTranistionEnd;
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.IsChildDependentOnParent = source.IsChildDependentOnParent;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowHierarchyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowHierarchy> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowHierarchyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowHierarchy> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowHierarchy> ToEntities(this IEnumerable<WorkflowHierarchyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowHierarchy source, WorkflowHierarchyDTO target);

        static partial void OnEntityCreating(WorkflowHierarchyDTO source, Bec.TargetFramework.Data.WorkflowHierarchy target);

    }

}
