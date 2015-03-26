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

    public static partial class WorkflowDecisionSuccessConverter
    {

        public static WorkflowDecisionSuccessDTO ToDto(this Bec.TargetFramework.Data.WorkflowDecisionSuccess source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDecisionSuccessDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowDecisionSuccess source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDecisionSuccessDTO();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionSuccessID = source.WorkflowDecisionSuccessID;

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

        public static Bec.TargetFramework.Data.WorkflowDecisionSuccess ToEntity(this WorkflowDecisionSuccessDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowDecisionSuccess();

            // Properties
            target.WorkflowDecisionID = source.WorkflowDecisionID;
            target.NextWorkflowActionID = source.NextWorkflowActionID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.NextWorkflowDecisionID = source.NextWorkflowDecisionID;
            target.WorkflowDecisionSuccessID = source.WorkflowDecisionSuccessID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDecisionSuccessDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionSuccess> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDecisionSuccessDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowDecisionSuccess> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowDecisionSuccess> ToEntities(this IEnumerable<WorkflowDecisionSuccessDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowDecisionSuccess source, WorkflowDecisionSuccessDTO target);

        static partial void OnEntityCreating(WorkflowDecisionSuccessDTO source, Bec.TargetFramework.Data.WorkflowDecisionSuccess target);

    }

}
