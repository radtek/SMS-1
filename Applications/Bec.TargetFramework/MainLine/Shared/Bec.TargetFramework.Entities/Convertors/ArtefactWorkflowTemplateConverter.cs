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

    public static partial class ArtefactWorkflowTemplateConverter
    {

        public static ArtefactWorkflowTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactWorkflowTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactWorkflowTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactWorkflowTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactWorkflowTemplateDTO();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ArtefactWorkflowTemplateID = source.ArtefactWorkflowTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
              target.WorkflowTemplate = source.WorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactWorkflowTemplate ToEntity(this ArtefactWorkflowTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactWorkflowTemplate();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.WorkflowTemplateID = source.WorkflowTemplateID;
            target.WorkflowTemplateVersionNumber = source.WorkflowTemplateVersionNumber;
            target.ArtefactWorkflowTemplateID = source.ArtefactWorkflowTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactWorkflowTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactWorkflowTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactWorkflowTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactWorkflowTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactWorkflowTemplate> ToEntities(this IEnumerable<ArtefactWorkflowTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactWorkflowTemplate source, ArtefactWorkflowTemplateDTO target);

        static partial void OnEntityCreating(ArtefactWorkflowTemplateDTO source, Bec.TargetFramework.Data.ArtefactWorkflowTemplate target);

    }

}
