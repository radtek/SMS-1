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

    public static partial class WorkflowClaimTemplateConverter
    {

        public static WorkflowClaimTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowClaimTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowClaimTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowClaimTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowClaimTemplateDTO();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowClaimTemplateID = source.WorkflowClaimTemplateID;
            target.WorkflowRoleTemplateID = source.WorkflowRoleTemplateID;
            target.RoleID = source.RoleID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowRoleTemplate = source.WorkflowRoleTemplate.ToDtoWithRelated(level - 1);
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowClaimTemplate ToEntity(this WorkflowClaimTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowClaimTemplate();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowClaimTemplateID = source.WorkflowClaimTemplateID;
            target.WorkflowRoleTemplateID = source.WorkflowRoleTemplateID;
            target.RoleID = source.RoleID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowClaimTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowClaimTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowClaimTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowClaimTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowClaimTemplate> ToEntities(this IEnumerable<WorkflowClaimTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowClaimTemplate source, WorkflowClaimTemplateDTO target);

        static partial void OnEntityCreating(WorkflowClaimTemplateDTO source, Bec.TargetFramework.Data.WorkflowClaimTemplate target);

    }

}
