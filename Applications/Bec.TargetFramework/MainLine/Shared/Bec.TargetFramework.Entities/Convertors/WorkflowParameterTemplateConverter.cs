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

    public static partial class WorkflowParameterTemplateConverter
    {

        public static WorkflowParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowParameterTemplateDTO();

            // Properties
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowActionParameterTemplates = source.WorkflowActionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandParameterTemplates = source.WorkflowCommandParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowConditionParameterTemplates = source.WorkflowConditionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionParameterTemplates = source.WorkflowDecisionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionParameterTemplates = source.WorkflowTransistionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowMainParameterTemplate = source.WorkflowMainParameterTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowParameterTemplate ToEntity(this WorkflowParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowParameterTemplate();

            // Properties
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ObjectType = source.ObjectType;
            target.ObjectValue = source.ObjectValue;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowParameterTemplate> ToEntities(this IEnumerable<WorkflowParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowParameterTemplate source, WorkflowParameterTemplateDTO target);

        static partial void OnEntityCreating(WorkflowParameterTemplateDTO source, Bec.TargetFramework.Data.WorkflowParameterTemplate target);

    }

}
