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

    public static partial class WorkflowActionParameterTemplateConverter
    {

        public static WorkflowActionParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionParameterTemplateDTO();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowParameterTemplate = source.WorkflowParameterTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowActionParameterNotificationConstructTemplates = source.WorkflowActionParameterNotificationConstructTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionParameterTemplate ToEntity(this WorkflowActionParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionParameterTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionParameterTemplate> ToEntities(this IEnumerable<WorkflowActionParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionParameterTemplate source, WorkflowActionParameterTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionParameterTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionParameterTemplate target);

    }

}
