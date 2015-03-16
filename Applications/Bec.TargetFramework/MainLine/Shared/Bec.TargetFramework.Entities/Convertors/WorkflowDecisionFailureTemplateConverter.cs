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

    public static partial class WorkflowDecisionFailureTemplateConverter
    {

        public static WorkflowDecisionFailureTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionFailureTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionFailureTemplateDTO();

            // Properties
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.NextWorkflowActionTemplateID = source.NextWorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.NextWorkflowDecisionTemplateID = source.NextWorkflowDecisionTemplateID;
            target.WorkflowDecisionFailureTemplateID = source.WorkflowDecisionFailureTemplateID;

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

        public static Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate ToEntity(this WorkflowDecisionFailureTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate();

            // Properties
            target.WorkflowDecisionTemplateID = source.WorkflowDecisionTemplateID;
            target.NextWorkflowActionTemplateID = source.NextWorkflowActionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.NextWorkflowDecisionTemplateID = source.NextWorkflowDecisionTemplateID;
            target.WorkflowDecisionFailureTemplateID = source.WorkflowDecisionFailureTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionFailureTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionFailureTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate> ToEntities(this IEnumerable<WorkflowDecisionFailureTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate source, WorkflowDecisionFailureTemplateDTO target);

        static partial void OnEntityCreating(WorkflowDecisionFailureTemplateDTO source, Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate target);

    }

}
