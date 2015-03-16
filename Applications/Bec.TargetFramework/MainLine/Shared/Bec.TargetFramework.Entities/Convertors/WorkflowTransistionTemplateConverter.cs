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

    public static partial class WorkflowTransistionTemplateConverter
    {

        public static WorkflowTransistionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionTemplateDTO();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTransistionCompleteConditionTemplates = source.WorkflowTransistionCompleteConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionStartConditionTemplates = source.WorkflowTransistionStartConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowActionTemplates = source.WorkflowTransistionWorkflowActionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionParameterTemplates = source.WorkflowTransistionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = source.WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber = source.WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowDecisionTemplates = source.WorkflowTransistionWorkflowDecisionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowHierarchyTemplates = source.WorkflowHierarchyTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionTemplate ToEntity(this WorkflowTransistionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionTemplate();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsWorkflowStart = source.IsWorkflowStart;
            target.IsWorkflowEnd = source.IsWorkflowEnd;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionTemplate> ToEntities(this IEnumerable<WorkflowTransistionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionTemplate source, WorkflowTransistionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTransistionTemplateDTO source, Bec.TargetFramework.Data.WorkflowTransistionTemplate target);

    }

}
