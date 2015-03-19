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

    public static partial class WorkflowActionValidationTemplateConverter
    {

        public static WorkflowActionValidationTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionValidationTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionValidationTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionValidationTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionValidationTemplateDTO();

            // Properties
            target.WorkflowActionValidationTemplateID = source.WorkflowActionValidationTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionValidationTemplate ToEntity(this WorkflowActionValidationTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionValidationTemplate();

            // Properties
            target.WorkflowActionValidationTemplateID = source.WorkflowActionValidationTemplateID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionValidationTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionValidationTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionValidationTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionValidationTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionValidationTemplate> ToEntities(this IEnumerable<WorkflowActionValidationTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionValidationTemplate source, WorkflowActionValidationTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionValidationTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionValidationTemplate target);

    }

}
