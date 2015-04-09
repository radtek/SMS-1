﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowTemplateConverter
    {

        public static WorkflowTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTemplateDTO();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.WorkflowSubTypeID = source.WorkflowSubTypeID;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.WorkflowSubCategoryID = source.WorkflowSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationWorkflowTemplates = source.DefaultOrganisationWorkflowTemplates.ToDtosWithRelated(level - 1);
              target.WorflowParameterTemplates = source.WorflowParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowClaimTemplates = source.WorkflowClaimTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandConditionTemplates = source.WorkflowCommandConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandParameterTemplates = source.WorkflowCommandParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandTemplates = source.WorkflowCommandTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionCompleteConditionTemplates = source.WorkflowTransistionCompleteConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionStartConditionTemplates = source.WorkflowTransistionStartConditionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionWorkflowActionTemplates = source.WorkflowTransistionWorkflowActionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowStatusTypeTemplates = source.WorkflowStatusTypeTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargetTemplates = source.DefaultOrganisationUserTargetTemplates.ToDtosWithRelated(level - 1);
              target.ModuleWorkflowTemplates = source.ModuleWorkflowTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowConditionParameterTemplates = source.WorkflowConditionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionParameterTemplates = source.WorkflowTransistionParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionHierarchyTemplates = source.WorkflowTransistionHierarchyTemplates.ToDtosWithRelated(level - 1);
              target.Workflows = source.Workflows.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionTemplates = source.WorkflowDecisionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowHierarchyTemplates = source.WorkflowHierarchyTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowObjectTypeTemplates = source.WorkflowObjectTypeTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowActionTemplates = source.WorkflowActionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTransistionTemplates = source.WorkflowTransistionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowRoleTemplates = source.WorkflowRoleTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowNotificationConstructTemplates = source.WorkflowNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.ArtefactWorkflowTemplates = source.ArtefactWorkflowTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructTemplates = source.NotificationConstructGroupNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowParameterTemplates = source.WorkflowParameterTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandTemplate1s = source.WorkflowCommandTemplate1s.ToDtosWithRelated(level - 1);
              target.WorkflowMainParameterTemplates = source.WorkflowMainParameterTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTemplate ToEntity(this WorkflowTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTemplate();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.WorkflowTypeID = source.WorkflowTypeID;
            target.WorkflowSubTypeID = source.WorkflowSubTypeID;
            target.WorkflowCategoryID = source.WorkflowCategoryID;
            target.WorkflowSubCategoryID = source.WorkflowSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTemplate> ToEntities(this IEnumerable<WorkflowTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTemplate source, WorkflowTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTemplateDTO source, Bec.TargetFramework.Data.WorkflowTemplate target);

    }

}
