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

    public static partial class WorkflowActionStartConditionTemplateConverter
    {

        public static WorkflowActionStartConditionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionStartConditionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionStartConditionTemplateDTO();

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

        public static Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate ToEntity(this WorkflowActionStartConditionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionStartConditionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionStartConditionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate> ToEntities(this IEnumerable<WorkflowActionStartConditionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate source, WorkflowActionStartConditionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionStartConditionTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionStartConditionTemplate target);

    }

}
