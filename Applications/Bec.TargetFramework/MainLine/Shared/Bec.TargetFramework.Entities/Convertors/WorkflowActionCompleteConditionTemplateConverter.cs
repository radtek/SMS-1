﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionCompleteConditionTemplateConverter
    {

        public static WorkflowActionCompleteConditionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionCompleteConditionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionCompleteConditionTemplateDTO();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
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

        public static Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate ToEntity(this WorkflowActionCompleteConditionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionCompleteConditionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionCompleteConditionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate> ToEntities(this IEnumerable<WorkflowActionCompleteConditionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate source, WorkflowActionCompleteConditionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionCompleteConditionTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionCompleteConditionTemplate target);

    }

}
