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

    public static partial class WorkflowConverter
    {

        public static WorkflowDTO ToDto(this Bec.TargetFramework.Data.Workflow source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Workflow source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowDTO();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.WorkflowSubTypeID = source.WorkflowSubTypeID;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.WorkflowSubCategoryID = source.WorkflowSubCategoryID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowInstances = source.WorkflowInstances.ToDtosWithRelated(level - 1);
              target.WorkflowStatusTypes = source.WorkflowStatusTypes.ToDtosWithRelated(level - 1);
              target.ModuleWorkflows = source.ModuleWorkflows.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationWorkflows = source.DefaultOrganisationWorkflows.ToDtosWithRelated(level - 1);
              target.OrganisationWorkflows = source.OrganisationWorkflows.ToDtosWithRelated(level - 1);
              target.ArtefactWorkflows = source.ArtefactWorkflows.ToDtosWithRelated(level - 1);
              target.ApplicationStageWorkflows = source.ApplicationStageWorkflows.ToDtosWithRelated(level - 1);
              target.WorkflowActions = source.WorkflowActions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowActions = source.WorkflowTransistionWorkflowActions.ToDtosWithRelated(level - 1);
              target.WorkflowCommands = source.WorkflowCommands.ToDtosWithRelated(level - 1);
              target.WorkflowCommandParameters = source.WorkflowCommandParameters.ToDtosWithRelated(level - 1);
              target.WorkflowMainExecuteCommands = source.WorkflowMainExecuteCommands.ToDtosWithRelated(level - 1);
              target.WorkflowMainPostCommands = source.WorkflowMainPostCommands.ToDtosWithRelated(level - 1);
              target.WorkflowMainPreCommands = source.WorkflowMainPreCommands.ToDtosWithRelated(level - 1);
              target.WorkflowConditions = source.WorkflowConditions.ToDtosWithRelated(level - 1);
              target.WorkflowConditionParameters = source.WorkflowConditionParameters.ToDtosWithRelated(level - 1);
              target.WorkflowMainCompleteConditions = source.WorkflowMainCompleteConditions.ToDtosWithRelated(level - 1);
              target.WorkflowMainStartConditions = source.WorkflowMainStartConditions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionCompleteConditions = source.WorkflowTransistionCompleteConditions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionStartConditions = source.WorkflowTransistionStartConditions.ToDtosWithRelated(level - 1);
              target.WorkflowDecisions = source.WorkflowDecisions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowDecisions = source.WorkflowTransistionWorkflowDecisions.ToDtosWithRelated(level - 1);
              target.WorkflowHierarchies = source.WorkflowHierarchies.ToDtosWithRelated(level - 1);
              target.WorkflowMainParameters = source.WorkflowMainParameters.ToDtosWithRelated(level - 1);
              target.WorkflowParameters = source.WorkflowParameters.ToDtosWithRelated(level - 1);
              target.WorkflowTransistions = source.WorkflowTransistions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionHierarchies = source.WorkflowTransistionHierarchies.ToDtosWithRelated(level - 1);
              target.WorkflowNotificationConstructs = source.WorkflowNotificationConstructs.ToDtosWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowObjectTypes = source.WorkflowObjectTypes.ToDtosWithRelated(level - 1);
              target.WorkflowRoles = source.WorkflowRoles.ToDtosWithRelated(level - 1);
              target.WorkflowTreeStructures = source.WorkflowTreeStructures.ToDtosWithRelated(level - 1);
              target.WorkflowClaims = source.WorkflowClaims.ToDtosWithRelated(level - 1);
              target.WorkflowCommandConditions = source.WorkflowCommandConditions.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionParameters = source.WorkflowTransistionParameters.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Workflow ToEntity(this WorkflowDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Workflow();

            // Properties
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.WorkflowSubTypeID = source.WorkflowSubTypeID;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.WorkflowSubCategoryID = source.WorkflowSubCategoryID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Workflow> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Workflow> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Workflow> ToEntities(this IEnumerable<WorkflowDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Workflow source, WorkflowDTO target);

        static partial void OnEntityCreating(WorkflowDTO source, Bec.TargetFramework.Data.Workflow target);

    }

}
