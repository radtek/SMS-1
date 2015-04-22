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

    public static partial class WorkflowCommandConditionTemplateConverter
    {

        public static WorkflowCommandConditionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowCommandConditionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowCommandConditionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowCommandConditionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowCommandConditionTemplateDTO();

            // Properties
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowCommandTemplate = source.WorkflowCommandTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowCommandTemplate1 = source.WorkflowCommandTemplate1.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowCommandConditionTemplate ToEntity(this WorkflowCommandConditionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowCommandConditionTemplate();

            // Properties
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowCommandConditionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommandConditionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowCommandConditionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowCommandConditionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowCommandConditionTemplate> ToEntities(this IEnumerable<WorkflowCommandConditionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowCommandConditionTemplate source, WorkflowCommandConditionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowCommandConditionTemplateDTO source, Bec.TargetFramework.Data.WorkflowCommandConditionTemplate target);

    }

}
