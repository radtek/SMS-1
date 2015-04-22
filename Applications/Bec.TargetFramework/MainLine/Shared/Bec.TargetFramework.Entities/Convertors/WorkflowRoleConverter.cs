﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowRoleConverter
    {

        public static WorkflowRoleDTO ToDto(this Bec.TargetFramework.Data.WorkflowRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowRole source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowRoleDTO();

            // Properties
            target.WorkflowRoleID = source.WorkflowRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.WorkflowClaims = source.WorkflowClaims.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowRole ToEntity(this WorkflowRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowRole();

            // Properties
            target.WorkflowRoleID = source.WorkflowRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowRole> ToEntities(this IEnumerable<WorkflowRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowRole source, WorkflowRoleDTO target);

        static partial void OnEntityCreating(WorkflowRoleDTO source, Bec.TargetFramework.Data.WorkflowRole target);

    }

}
