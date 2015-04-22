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

    public static partial class WorkflowStatusTypeTemplateConverter
    {

        public static WorkflowStatusTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowStatusTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowStatusTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowStatusTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowStatusTypeTemplateDTO();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowStatusTypeTemplate ToEntity(this WorkflowStatusTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowStatusTypeTemplate();

            // Properties
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowStatusTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowStatusTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowStatusTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowStatusTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowStatusTypeTemplate> ToEntities(this IEnumerable<WorkflowStatusTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowStatusTypeTemplate source, WorkflowStatusTypeTemplateDTO target);

        static partial void OnEntityCreating(WorkflowStatusTypeTemplateDTO source, Bec.TargetFramework.Data.WorkflowStatusTypeTemplate target);

    }

}
