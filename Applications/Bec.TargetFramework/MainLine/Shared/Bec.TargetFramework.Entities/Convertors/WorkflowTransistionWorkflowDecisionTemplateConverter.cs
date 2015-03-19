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

    public static partial class WorkflowTransistionWorkflowDecisionTemplateConverter
    {

        public static WorkflowTransistionWorkflowDecisionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionWorkflowDecisionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionWorkflowDecisionTemplateDTO();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowDecisionTemplate = source.WorkflowDecisionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTransistionTemplate = source.WorkflowTransistionTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate ToEntity(this WorkflowTransistionWorkflowDecisionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionWorkflowDecisionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionWorkflowDecisionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate> ToEntities(this IEnumerable<WorkflowTransistionWorkflowDecisionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate source, WorkflowTransistionWorkflowDecisionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTransistionWorkflowDecisionTemplateDTO source, Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecisionTemplate target);

    }

}
