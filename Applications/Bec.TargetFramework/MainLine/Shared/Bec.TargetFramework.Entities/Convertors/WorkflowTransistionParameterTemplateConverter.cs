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

    public static partial class WorkflowTransistionParameterTemplateConverter
    {

        public static WorkflowTransistionParameterTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowTransistionParameterTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowTransistionParameterTemplateDTO();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowParameterTemplate = source.WorkflowParameterTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTransistionTemplate = source.WorkflowTransistionTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate ToEntity(this WorkflowTransistionParameterTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate();

            // Properties
            target.WorkflowTransistionTemplateID = source.WorkflowTransistionTemplateID;
            target.WorkflowParameterTemplateID = source.WorkflowParameterTemplateID;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowTransistionParameterTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowTransistionParameterTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate> ToEntities(this IEnumerable<WorkflowTransistionParameterTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate source, WorkflowTransistionParameterTemplateDTO target);

        static partial void OnEntityCreating(WorkflowTransistionParameterTemplateDTO source, Bec.TargetFramework.Data.WorkflowTransistionParameterTemplate target);

    }

}
