﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class WorkflowObjectTypeTemplateConverter
    {

        public static WorkflowObjectTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.WorkflowObjectTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static WorkflowObjectTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.WorkflowObjectTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new WorkflowObjectTypeTemplateDTO();

            // Properties
            target.WorkflowObjectTypeTemplateID = source.WorkflowObjectTypeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeNameSpace = source.ObjectTypeNameSpace;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.WorkflowCommandTemplates = source.WorkflowCommandTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowDecisionTemplates = source.WorkflowDecisionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowActionTemplates = source.WorkflowActionTemplates.ToDtosWithRelated(level - 1);
              target.WorkflowCommandTemplate1s = source.WorkflowCommandTemplate1s.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.WorkflowObjectTypeTemplate ToEntity(this WorkflowObjectTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.WorkflowObjectTypeTemplate();

            // Properties
            target.WorkflowObjectTypeTemplateID = source.WorkflowObjectTypeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeNameSpace = source.ObjectTypeNameSpace;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<WorkflowObjectTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.WorkflowObjectTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<WorkflowObjectTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.WorkflowObjectTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.WorkflowObjectTypeTemplate> ToEntities(this IEnumerable<WorkflowObjectTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.WorkflowObjectTypeTemplate source, WorkflowObjectTypeTemplateDTO target);

        static partial void OnEntityCreating(WorkflowObjectTypeTemplateDTO source, Bec.TargetFramework.Data.WorkflowObjectTypeTemplate target);

    }

}
