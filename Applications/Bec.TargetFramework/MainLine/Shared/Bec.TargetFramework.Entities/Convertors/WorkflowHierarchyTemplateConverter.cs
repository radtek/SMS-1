﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowHierarchyTemplateConverter
    {

        public static WorkflowHierarchyTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowHierarchyTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowHierarchyTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowHierarchyTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowHierarchyTemplateDTO();

            // Properties
            target.WorkflowHierarchyTemplateID = source.WorkflowHierarchyTemplateID;
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTranistionEnd = source.IsTranistionEnd;
            target.IsChildDependentOnParent = source.IsChildDependentOnParent;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTransistionTemplate = source.WorkflowTransistionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowHierarchyTemplate ToEntity(this WorkflowHierarchyTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowHierarchyTemplate();

            // Properties
            target.WorkflowHierarchyTemplateID = source.WorkflowHierarchyTemplateID;
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ChildComponentID = source.ChildComponentID;
            target.ParentComponentID = source.ParentComponentID;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTranistionEnd = source.IsTranistionEnd;
            target.IsChildDependentOnParent = source.IsChildDependentOnParent;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowHierarchyTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowHierarchyTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowHierarchyTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowHierarchyTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowHierarchyTemplate> ToEntities(this IEnumerable<WorkflowHierarchyTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowHierarchyTemplate source, WorkflowHierarchyTemplateDTO target);

        static partial void OnEntityCreating(WorkflowHierarchyTemplateDTO source, Bec.TargetFramework.Data.WorkflowHierarchyTemplate target);

    }

}
