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

    public static partial class WorkflowActionExecutionTemplateConverter
    {

        public static WorkflowActionExecutionTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionExecutionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionExecutionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionExecutionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionExecutionTemplateDTO();

            // Properties
            target.WorkflowActionExecutionID = source.WorkflowActionExecutionID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPre = source.IsPre;
            target.IsPost = source.IsPost;
            target.IsCanStart = source.IsCanStart;
            target.IsCanComplete = source.IsCanComplete;
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

        public static Bec.TargetFramework.Data.WorkflowActionExecutionTemplate ToEntity(this WorkflowActionExecutionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionExecutionTemplate();

            // Properties
            target.WorkflowActionExecutionID = source.WorkflowActionExecutionID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPre = source.IsPre;
            target.IsPost = source.IsPost;
            target.IsCanStart = source.IsCanStart;
            target.IsCanComplete = source.IsCanComplete;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionExecutionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecutionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionExecutionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionExecutionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionExecutionTemplate> ToEntities(this IEnumerable<WorkflowActionExecutionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionExecutionTemplate source, WorkflowActionExecutionTemplateDTO target);

        static partial void OnEntityCreating(WorkflowActionExecutionTemplateDTO source, Bec.TargetFramework.Data.WorkflowActionExecutionTemplate target);

    }

}
