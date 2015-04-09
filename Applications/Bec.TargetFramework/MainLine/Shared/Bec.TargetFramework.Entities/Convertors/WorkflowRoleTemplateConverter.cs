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

    public static partial class WorkflowRoleTemplateConverter
    {

        public static WorkflowRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowRoleTemplateDTO();

            // Properties
            target.WorkflowRoleTemplateID = source.WorkflowRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowClaimTemplates = source.WorkflowClaimTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowRoleTemplate ToEntity(this WorkflowRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowRoleTemplate();

            // Properties
            target.WorkflowRoleTemplateID = source.WorkflowRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowRoleTemplate> ToEntities(this IEnumerable<WorkflowRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowRoleTemplate source, WorkflowRoleTemplateDTO target);

        static partial void OnEntityCreating(WorkflowRoleTemplateDTO source, Bec.TargetFramework.Data.WorkflowRoleTemplate target);

    }

}
