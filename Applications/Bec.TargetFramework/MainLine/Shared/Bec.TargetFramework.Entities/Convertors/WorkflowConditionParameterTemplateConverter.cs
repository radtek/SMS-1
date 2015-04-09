﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowConditionParameterTemplateConverter
    {

        public static WorkflowConditionParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowConditionParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowConditionParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowConditionParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowConditionParameterTemplateDTO();

            // Properties
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowParameterTemplate = source.WorkflowParameterTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowConditionParameterTemplate ToEntity(this WorkflowConditionParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowConditionParameterTemplate();

            // Properties
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowConditionParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowConditionParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowConditionParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowConditionParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowConditionParameterTemplate> ToEntities(this IEnumerable<WorkflowConditionParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowConditionParameterTemplate source, WorkflowConditionParameterTemplateDTO target);

        static partial void OnEntityCreating(WorkflowConditionParameterTemplateDTO source, Bec.TargetFramework.Data.WorkflowConditionParameterTemplate target);

    }

}
