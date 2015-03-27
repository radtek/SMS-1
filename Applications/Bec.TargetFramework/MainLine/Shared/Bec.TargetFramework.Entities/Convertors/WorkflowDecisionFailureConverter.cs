﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowDecisionFailureConverter
    {

        public static WorkflowDecisionFailureDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionFailure source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionFailureDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionFailure source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionFailureDTO();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionFailureID = source.WorkflowDecisionFailureID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber = source.WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber.ToDtoWithRelated(level - 1);
              target.WorkflowAction = source.WorkflowAction.ToDtoWithRelated(level - 1);
              target.WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber = source.WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowDecisionFailure ToEntity(this WorkflowDecisionFailureDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionFailure();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionFailureID = source.WorkflowDecisionFailureID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionFailureDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionFailure> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionFailureDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionFailure> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionFailure> ToEntities(this IEnumerable<WorkflowDecisionFailureDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionFailure source, WorkflowDecisionFailureDTO target);

        static partial void OnEntityCreating(WorkflowDecisionFailureDTO source, Bec.TargetFramework.Data.WorkflowDecisionFailure target);

    }

}
