﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTransistionWorkflowActionTemplateConverter
    {

        public static WorkflowTransistionWorkflowActionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionWorkflowActionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionWorkflowActionTemplateDTO();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTransistionTemplate = source.WorkflowTransistionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate ToEntity(this WorkflowTransistionWorkflowActionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionWorkflowActionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionWorkflowActionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate> ToEntities(this IEnumerable<WorkflowTransistionWorkflowActionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate source, WorkflowTransistionWorkflowActionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTransistionWorkflowActionTemplateDTO source, Bec.TargetFramework.Data.WorkflowTransistionWorkflowActionTemplate target);

    }

}
