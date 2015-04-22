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

    public static partial class WorkflowActionProductPlaceholderConverter
    {

        public static WorkflowActionProductPlaceholderDTO ToDto(this Bec.TargetFramework.Data.WorkflowActionProductPlaceholder source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowActionProductPlaceholderDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowActionProductPlaceholder source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowActionProductPlaceholderDTO();

            // Properties
            target.WorkflowActionProductPlaceholderID = source.WorkflowActionProductPlaceholderID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.ProductTypeID = source.ProductTypeID;
            target.Order = source.Order;
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

        public static Bec.TargetFramework.Data.WorkflowActionProductPlaceholder ToEntity(this WorkflowActionProductPlaceholderDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowActionProductPlaceholder();

            // Properties
            target.WorkflowActionProductPlaceholderID = source.WorkflowActionProductPlaceholderID;
            target.WorkflowActionTemplateID = source.WorkflowActionTemplateID;
            target.ProductTypeID = source.ProductTypeID;
            target.Order = source.Order;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowActionProductPlaceholderDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionProductPlaceholder> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowActionProductPlaceholderDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowActionProductPlaceholder> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowActionProductPlaceholder> ToEntities(this IEnumerable<WorkflowActionProductPlaceholderDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowActionProductPlaceholder source, WorkflowActionProductPlaceholderDTO target);

        static partial void OnEntityCreating(WorkflowActionProductPlaceholderDTO source, Bec.TargetFramework.Data.WorkflowActionProductPlaceholder target);

    }

}
