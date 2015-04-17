﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTransistionWorkflowDecisionConverter
    {

        public static WorkflowTransistionWorkflowDecisionDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionWorkflowDecisionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionWorkflowDecisionDTO();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowDecision = source.WorkflowDecision.ToDtoWithRelated(level - 1);
              target.WorkflowTransistion = source.WorkflowTransistion.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision ToEntity(this WorkflowTransistionWorkflowDecisionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision();

            // Properties
            target.WorkflowTransistionID = source.WorkflowTransistionID;
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionWorkflowDecisionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionWorkflowDecisionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision> ToEntities(this IEnumerable<WorkflowTransistionWorkflowDecisionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision source, WorkflowTransistionWorkflowDecisionDTO target);

        static partial void OnEntityCreating(WorkflowTransistionWorkflowDecisionDTO source, Bec.TargetFramework.Data.WorkflowTransistionWorkflowDecision target);

    }

}
