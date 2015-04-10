﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorflowParameterTemplateConverter
    {

        public static WorflowParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorflowParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorflowParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorflowParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorflowParameterTemplateDTO();

            // Properties
            target.WorflowParameterTemplateID = source.WorflowParameterTemplateID;
            target.IsConfigurable1 = source.IsConfigurable1;
            target.ParameterName = source.ParameterName;
            target.ParameterValue = source.ParameterValue;
            target.ParameterType = source.ParameterType;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorflowParameterTemplate ToEntity(this WorflowParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorflowParameterTemplate();

            // Properties
            target.WorflowParameterTemplateID = source.WorflowParameterTemplateID;
            target.IsConfigurable1 = source.IsConfigurable1;
            target.ParameterName = source.ParameterName;
            target.ParameterValue = source.ParameterValue;
            target.ParameterType = source.ParameterType;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorflowParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorflowParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorflowParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorflowParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorflowParameterTemplate> ToEntities(this IEnumerable<WorflowParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorflowParameterTemplate source, WorflowParameterTemplateDTO target);

        static partial void OnEntityCreating(WorflowParameterTemplateDTO source, Bec.TargetFramework.Data.WorflowParameterTemplate target);

    }

}
