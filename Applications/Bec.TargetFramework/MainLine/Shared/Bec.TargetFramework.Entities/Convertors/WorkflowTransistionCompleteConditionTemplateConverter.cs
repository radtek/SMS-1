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

    public static partial class WorkflowTransistionCompleteConditionTemplateConverter
    {

        public static WorkflowTransistionCompleteConditionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionCompleteConditionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionCompleteConditionTemplateDTO();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowConditionTemplate = source.WorkflowConditionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTransistionTemplate = source.WorkflowTransistionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate ToEntity(this WorkflowTransistionCompleteConditionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowConditionTemplateID = source.WorkflowConditionTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionCompleteConditionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionCompleteConditionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate> ToEntities(this IEnumerable<WorkflowTransistionCompleteConditionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate source, WorkflowTransistionCompleteConditionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTransistionCompleteConditionTemplateDTO source, Bec.TargetFramework.Data.WorkflowTransistionCompleteConditionTemplate target);

    }

}
