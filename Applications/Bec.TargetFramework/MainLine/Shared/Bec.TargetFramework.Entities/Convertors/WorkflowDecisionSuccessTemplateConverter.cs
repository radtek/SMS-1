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

    public static partial class WorkflowDecisionSuccessTemplateConverter
    {

        public static WorkflowDecisionSuccessTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionSuccessTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionSuccessTemplateDTO();

            // Properties
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.NextWorkflowActionTemplateID = source.NextWorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.NextWorkflowDecisionTemplateID = source.NextWorkflowDecisionTemplateID;
            target.WorkflowDecisionSuccessTemplateID = source.WorkflowDecisionSuccessTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = source.WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber.ToDtoWithRelated(level - 1);
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber = source.WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate ToEntity(this WorkflowDecisionSuccessTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate();

            // Properties
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.NextWorkflowActionTemplateID = source.NextWorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.NextWorkflowDecisionTemplateID = source.NextWorkflowDecisionTemplateID;
            target.WorkflowDecisionSuccessTemplateID = source.WorkflowDecisionSuccessTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionSuccessTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionSuccessTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate> ToEntities(this IEnumerable<WorkflowDecisionSuccessTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate source, WorkflowDecisionSuccessTemplateDTO target);

        static partial void OnEntityCreating(WorkflowDecisionSuccessTemplateDTO source, Bec.TargetFramework.Data.WorkflowDecisionSuccessTemplate target);

    }

}
