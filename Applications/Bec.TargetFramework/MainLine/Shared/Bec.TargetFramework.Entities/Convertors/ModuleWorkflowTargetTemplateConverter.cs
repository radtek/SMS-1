﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleWorkflowTargetTemplateConverter
    {

        public static ModuleWorkflowTargetTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleWorkflowTargetTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleWorkflowTargetTemplateDTO();

            // Properties
            target.ModuleWorkflowTargetTemplateID = source.ModuleWorkflowTargetTemplateID;
            target.ModuleWorkflowTemplateID = source.ModuleWorkflowTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.UserTypeID = source.UserTypeID;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserSubCategoryID = source.UserSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.ModuleWorkflowTemplate = source.ModuleWorkflowTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate ToEntity(this ModuleWorkflowTargetTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate();

            // Properties
            target.ModuleWorkflowTargetTemplateID = source.ModuleWorkflowTargetTemplateID;
            target.ModuleWorkflowTemplateID = source.ModuleWorkflowTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.UserTypeID = source.UserTypeID;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserSubCategoryID = source.UserSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleWorkflowTargetTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleWorkflowTargetTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate> ToEntities(this IEnumerable<ModuleWorkflowTargetTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate source, ModuleWorkflowTargetTemplateDTO target);

        static partial void OnEntityCreating(ModuleWorkflowTargetTemplateDTO source, Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate target);

    }

}
