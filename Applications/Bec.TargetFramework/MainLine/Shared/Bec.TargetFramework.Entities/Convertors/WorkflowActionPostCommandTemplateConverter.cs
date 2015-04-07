﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowActionPostCommandTemplateConverter
    {

        public static WorkflowActionPostCommandTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionPostCommandTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionPostCommandTemplateDTO();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowActionTemplate = source.WorkflowActionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowCommandTemplate = source.WorkflowCommandTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowCommandTemplate1 = source.WorkflowCommandTemplate1.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate ToEntity(this WorkflowActionPostCommandTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionPostCommandTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionPostCommandTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate> ToEntities(this IEnumerable<WorkflowActionPostCommandTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate source, WorkflowActionPostCommandTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionPostCommandTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionPostCommandTemplate target);

    }

}
