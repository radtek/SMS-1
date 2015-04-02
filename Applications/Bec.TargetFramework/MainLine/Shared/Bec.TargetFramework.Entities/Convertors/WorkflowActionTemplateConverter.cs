﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionTemplateConverter
    {

        public static WorkflowActionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionTemplateDTO();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTransistionEnd = source.IsTransistionEnd;
            target.WorkflowActionTypeTemplateID = source.WorkflowActionTypeTemplateID;
            target.IsManual = source.IsManual;
            target.WorkflowObjectTypeTemplateID = source.WorkflowObjectTypeTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTransistionWorkflowActionTemplates = source.WorkflowTransistionWorkflowActionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionExecuteCommandTemplates = source.WorkflowActionExecuteCommandTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionCompleteConditionTemplates = source.WorkflowActionCompleteConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionPostCommandTemplates = source.WorkflowActionPostCommandTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionPreCommandTemplates = source.WorkflowActionPreCommandTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionParameterTemplates = source.WorkflowActionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionErrorTemplates = source.WorkflowDecisionErrorTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionExecutionTemplates = source.WorkflowActionExecutionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionNotificationTemplates = source.WorkflowActionNotificationTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionProductPlaceholders = source.WorkflowActionProductPlaceholders.ToDtosWithRelated(level - 1);
              target.WorkflowActionStartConditionTemplates = source.WorkflowActionStartConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionValidationTemplates = source.WorkflowActionValidationTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionFailureTemplates = source.WorkflowDecisionFailureTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionSuccessTemplates = source.WorkflowDecisionSuccessTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowObjectTypeTemplate = source.WorkflowObjectTypeTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionTemplate ToEntity(this WorkflowActionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsTransistionStart = source.IsTransistionStart;
            target.IsTransistionEnd = source.IsTransistionEnd;
            target.WorkflowActionTypeTemplateID = source.WorkflowActionTypeTemplateID;
            target.IsManual = source.IsManual;
            target.WorkflowObjectTypeTemplateID = source.WorkflowObjectTypeTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionTemplate> ToEntities(this IEnumerable<WorkflowActionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionTemplate source, WorkflowActionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionTemplate target);

    }

}
