﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleWorkflowTargetConverter
    {

        public static ModuleWorkflowTargetDTO ToDto(this Bec.TargetFramework.Data.ModuleWorkflowTarget source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleWorkflowTargetDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleWorkflowTarget source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleWorkflowTargetDTO();

            // Properties
            target.ModuleWorkflowTargetID = source.ModuleWorkflowTargetID;
            target.ModuleWorkflowID = source.ModuleWorkflowID;
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
              target.ModuleWorkflow = source.ModuleWorkflow.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleWorkflowTarget ToEntity(this ModuleWorkflowTargetDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleWorkflowTarget();

            // Properties
            target.ModuleWorkflowTargetID = source.ModuleWorkflowTargetID;
            target.ModuleWorkflowID = source.ModuleWorkflowID;
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

        public static List<ModuleWorkflowTargetDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTarget> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleWorkflowTargetDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleWorkflowTarget> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleWorkflowTarget> ToEntities(this IEnumerable<ModuleWorkflowTargetDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleWorkflowTarget source, ModuleWorkflowTargetDTO target);

        static partial void OnEntityCreating(ModuleWorkflowTargetDTO source, Bec.TargetFramework.Data.ModuleWorkflowTarget target);

    }

}
