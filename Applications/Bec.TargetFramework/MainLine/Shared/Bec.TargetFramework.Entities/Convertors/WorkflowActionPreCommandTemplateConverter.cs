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

    public static partial class WorkflowActionPreCommandTemplateConverter
    {

        public static WorkflowActionPreCommandTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionPreCommandTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionPreCommandTemplateDTO();

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

        public static Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate ToEntity(this WorkflowActionPreCommandTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate();

            // Properties
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.WorkflowCommandTemplateID = source.WorkflowCommandTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionPreCommandTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionPreCommandTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate> ToEntities(this IEnumerable<WorkflowActionPreCommandTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate source, WorkflowActionPreCommandTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionPreCommandTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionPreCommandTemplate target);

    }

}
