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

    public static partial class WorkflowActionExecuteCommandTemplateConverter
    {

        public static WorkflowActionExecuteCommandTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionExecuteCommandTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionExecuteCommandTemplateDTO();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowCommandTemplate = source.WorkflowCommandTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate ToEntity(this WorkflowActionExecuteCommandTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionExecuteCommandTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionExecuteCommandTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate> ToEntities(this IEnumerable<WorkflowActionExecuteCommandTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate source, WorkflowActionExecuteCommandTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionExecuteCommandTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionExecuteCommandTemplate target);

    }

}
