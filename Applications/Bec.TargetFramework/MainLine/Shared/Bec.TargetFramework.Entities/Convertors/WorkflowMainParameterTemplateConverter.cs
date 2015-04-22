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

    public static partial class WorkflowMainParameterTemplateConverter
    {

        public static WorkflowMainParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowMainParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowMainParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowMainParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowMainParameterTemplateDTO();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowParameterTemplate = source.WorkflowParameterTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowMainParameterTemplate ToEntity(this WorkflowMainParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowMainParameterTemplate();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowMainParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowMainParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowMainParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowMainParameterTemplate> ToEntities(this IEnumerable<WorkflowMainParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowMainParameterTemplate source, WorkflowMainParameterTemplateDTO target);

        static partial void OnEntityCreating(WorkflowMainParameterTemplateDTO source, Bec.TargetFramework.Data.WorkflowMainParameterTemplate target);

    }

}
