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

    public static partial class ApplicationStageWorkflowConverter
    {

        public static ApplicationStageWorkflowDTO ToDto(this Bec.TargetFramework.Data.ApplicationStageWorkflow source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ApplicationStageWorkflowDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ApplicationStageWorkflow source, int level)
        {
            if (source == null)
              return null;

            var target = new ApplicationStageWorkflowDTO();

            // Properties
            target.ApplicationStageWorkflowID = source.ApplicationStageWorkflowID;
            target.ApplicationStageID = source.ApplicationStageID;
            target.WorkflowID = source.WorkflowID;
            target.VersionNumber = source.VersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ApplicationStage = source.ApplicationStage.ToDtoWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ApplicationStageWorkflow ToEntity(this ApplicationStageWorkflowDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ApplicationStageWorkflow();

            // Properties
            target.ApplicationStageWorkflowID = source.ApplicationStageWorkflowID;
            target.ApplicationStageID = source.ApplicationStageID;
            target.WorkflowID = source.WorkflowID;
            target.VersionNumber = source.VersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ApplicationStageWorkflowDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ApplicationStageWorkflow> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ApplicationStageWorkflowDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ApplicationStageWorkflow> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ApplicationStageWorkflow> ToEntities(this IEnumerable<ApplicationStageWorkflowDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ApplicationStageWorkflow source, ApplicationStageWorkflowDTO target);

        static partial void OnEntityCreating(ApplicationStageWorkflowDTO source, Bec.TargetFramework.Data.ApplicationStageWorkflow target);

    }

}
