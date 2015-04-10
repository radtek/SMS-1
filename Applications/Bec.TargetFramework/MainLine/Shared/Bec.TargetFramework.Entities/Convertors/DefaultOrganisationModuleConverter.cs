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

    public static partial class DefaultOrganisationModuleConverter
    {

        public static DefaultOrganisationModuleDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationModule source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationModuleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationModule source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationModuleDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Module = source.Module.ToDtoWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationModule ToEntity(this DefaultOrganisationModuleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationModule();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationModuleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationModule> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationModuleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationModule> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationModule> ToEntities(this IEnumerable<DefaultOrganisationModuleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationModule source, DefaultOrganisationModuleDTO target);

        static partial void OnEntityCreating(DefaultOrganisationModuleDTO source, Bec.TargetFramework.Data.DefaultOrganisationModule target);

    }

}
