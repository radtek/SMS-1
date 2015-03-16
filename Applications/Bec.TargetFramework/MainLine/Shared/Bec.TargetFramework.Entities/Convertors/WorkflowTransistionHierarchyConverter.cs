﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTransistionHierarchyConverter
    {

        public static WorkflowTransistionHierarchyDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionHierarchy source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionHierarchyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionHierarchy source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionHierarchyDTO();

            // Properties
            target.WorkflowTransistionHierarchyID = source.WorkflowTransistionHierarchyID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber = source.WorkflowTransistion_ParentComponentID_WorkflowID_WorkflowVersionNumber.ToDtoWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber = source.WorkflowTransistion_ChildComponentID_WorkflowID_WorkflowVersionNumber.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionHierarchy ToEntity(this WorkflowTransistionHierarchyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionHierarchy();

            // Properties
            target.WorkflowTransistionHierarchyID = source.WorkflowTransistionHierarchyID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionHierarchyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionHierarchy> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionHierarchyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionHierarchy> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionHierarchy> ToEntities(this IEnumerable<WorkflowTransistionHierarchyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionHierarchy source, WorkflowTransistionHierarchyDTO target);

        static partial void OnEntityCreating(WorkflowTransistionHierarchyDTO source, Bec.TargetFramework.Data.WorkflowTransistionHierarchy target);

    }

}
