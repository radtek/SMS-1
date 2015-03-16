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

    public static partial class WorkflowDecisionErrorConverter
    {

        public static WorkflowDecisionErrorDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionError source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionErrorDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionError source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionErrorDTO();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionErrorID = source.WorkflowDecisionErrorID;

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

        public static Bec.TargetFramework.Data.WorkflowDecisionError ToEntity(this WorkflowDecisionErrorDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionError();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionErrorID = source.WorkflowDecisionErrorID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionErrorDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionError> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionErrorDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionError> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionError> ToEntities(this IEnumerable<WorkflowDecisionErrorDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionError source, WorkflowDecisionErrorDTO target);

        static partial void OnEntityCreating(WorkflowDecisionErrorDTO source, Bec.TargetFramework.Data.WorkflowDecisionError target);

    }

}
