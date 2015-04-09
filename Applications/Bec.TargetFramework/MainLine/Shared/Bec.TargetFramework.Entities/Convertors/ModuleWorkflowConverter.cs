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

    public static partial class ModuleWorkflowConverter
    {

        public static ModuleWorkflowDTO ToDto(this Bec.TargetFramework.Data.ModuleWorkflow source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleWorkflowDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleWorkflow source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleWorkflowDTO();

            // Properties
            target.ModuleWorkflowID = source.ModuleWorkflowID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.ModuleID = source.ModuleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AppliesToAllOrganisations = source.AppliesToAllOrganisations;
            target.AppliesToAllUsers = source.AppliesToAllUsers;
            target.ModuleVersionNumber = source.ModuleVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Module = source.Module.ToDtoWithRelated(level - 1);
              target.Workflow = source.Workflow.ToDtoWithRelated(level - 1);
              target.ModuleWorkflowTargets = source.ModuleWorkflowTargets.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleWorkflow ToEntity(this ModuleWorkflowDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleWorkflow();

            // Properties
            target.ModuleWorkflowID = source.ModuleWorkflowID;
            target.WorkflowID = source.WorkflowID;
            target.WorkflowVersionNumber = source.WorkflowVersionNumber;
            target.ModuleID = source.ModuleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AppliesToAllOrganisations = source.AppliesToAllOrganisations;
            target.AppliesToAllUsers = source.AppliesToAllUsers;
            target.ModuleVersionNumber = source.ModuleVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleWorkflowDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflow> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleWorkflowDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflow> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleWorkflow> ToEntities(this IEnumerable<ModuleWorkflowDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleWorkflow source, ModuleWorkflowDTO target);

        static partial void OnEntityCreating(ModuleWorkflowDTO source, Bec.TargetFramework.Data.ModuleWorkflow target);

    }

}
