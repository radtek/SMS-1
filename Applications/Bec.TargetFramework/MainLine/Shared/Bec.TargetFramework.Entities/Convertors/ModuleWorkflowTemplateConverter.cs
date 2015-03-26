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

    public static partial class ModuleWorkflowTemplateConverter
    {

        public static ModuleWorkflowTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleWorkflowTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleWorkflowTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleWorkflowTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleWorkflowTemplateDTO();

            // Properties
            target.ModuleWorkflowTemplateID = source.ModuleWorkflowTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AppliesToAllOrganisations = source.AppliesToAllOrganisations;
            target.AppliesToAllUsers = source.AppliesToAllUsers;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.ModuleWorkflowTargetTemplates = source.ModuleWorkflowTargetTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleWorkflowTemplate ToEntity(this ModuleWorkflowTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleWorkflowTemplate();

            // Properties
            target.ModuleWorkflowTemplateID = source.ModuleWorkflowTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.AppliesToAllOrganisations = source.AppliesToAllOrganisations;
            target.AppliesToAllUsers = source.AppliesToAllUsers;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleWorkflowTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleWorkflowTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleWorkflowTemplate> ToEntities(this IEnumerable<ModuleWorkflowTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleWorkflowTemplate source, ModuleWorkflowTemplateDTO target);

        static partial void OnEntityCreating(ModuleWorkflowTemplateDTO source, Bec.TargetFramework.Data.ModuleWorkflowTemplate target);

    }

}
