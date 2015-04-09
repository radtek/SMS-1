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

    public static partial class ModuleArtefactConverter
    {

        public static ModuleArtefactDTO ToDto(this Bec.TargetFramework.Data.ModuleArtefact source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleArtefactDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleArtefact source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleArtefactDTO();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Artefact = source.Artefact.ToDtoWithRelated(level - 1);
              target.Module = source.Module.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleArtefact ToEntity(this ModuleArtefactDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleArtefact();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleArtefactDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleArtefact> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleArtefactDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleArtefact> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleArtefact> ToEntities(this IEnumerable<ModuleArtefactDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleArtefact source, ModuleArtefactDTO target);

        static partial void OnEntityCreating(ModuleArtefactDTO source, Bec.TargetFramework.Data.ModuleArtefact target);

    }

}
