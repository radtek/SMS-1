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

    public static partial class VWorkflowInstanceRetryConverter
    {

        public static VWorkflowInstanceRetryDTO ToDto(this Bec.TargetFramework.Data.VWorkflowInstanceRetry source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VWorkflowInstanceRetryDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VWorkflowInstanceRetry source, int level)
        {
            if (source == null)
              return null;

            var target = new VWorkflowInstanceRetryDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.PreviousStepID = source.PreviousStepID;
            target.PreviousStepName = source.PreviousStepName;
            target.StepID = source.StepID;
            target.StepName = source.StepName;
            target.SessionStartedOn = source.SessionStartedOn;
            target.Count = source.Count;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VWorkflowInstanceRetry ToEntity(this VWorkflowInstanceRetryDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VWorkflowInstanceRetry();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.WorkflowInstanceID = source.WorkflowInstanceID;
            target.WorkflowInstanceSessionID = source.WorkflowInstanceSessionID;
            target.PreviousStepID = source.PreviousStepID;
            target.PreviousStepName = source.PreviousStepName;
            target.StepID = source.StepID;
            target.StepName = source.StepName;
            target.SessionStartedOn = source.SessionStartedOn;
            target.Count = source.Count;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VWorkflowInstanceRetryDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceRetry> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VWorkflowInstanceRetryDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VWorkflowInstanceRetry> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VWorkflowInstanceRetry> ToEntities(this IEnumerable<VWorkflowInstanceRetryDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VWorkflowInstanceRetry source, VWorkflowInstanceRetryDTO target);

        static partial void OnEntityCreating(VWorkflowInstanceRetryDTO source, Bec.TargetFramework.Data.VWorkflowInstanceRetry target);

    }

}
