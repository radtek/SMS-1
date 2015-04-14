﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationWorkflowTemplateConverter
    {

        public static DefaultOrganisationWorkflowTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationWorkflowTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationWorkflowTemplateDTO();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate ToEntity(this DefaultOrganisationWorkflowTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationWorkflowTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationWorkflowTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate> ToEntities(this IEnumerable<DefaultOrganisationWorkflowTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate source, DefaultOrganisationWorkflowTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationWorkflowTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationWorkflowTemplate target);

    }

}
