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

    public static partial class ArtefactDependencyConverter
    {

        public static ArtefactDependencyDTO ToDto(this Bec.TargetFramework.Data.ArtefactDependency source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactDependencyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactDependency source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactDependencyDTO();

            // Properties
            target.ArtefactDependencyID = source.ArtefactDependencyID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.DependencyArtefactID = source.DependencyArtefactID;
            target.DependencyArtefactVersionNumber = source.DependencyArtefactVersionNumber;
            target.ArtefactDependencyTemplateID = source.ArtefactDependencyTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Artefact_ArtefactID_ArtefactVersionNumber = source.Artefact_ArtefactID_ArtefactVersionNumber.ToDtoWithRelated(level - 1);
              target.ArtefactDependencyTemplate = source.ArtefactDependencyTemplate.ToDtoWithRelated(level - 1);
              target.Artefact_DependencyArtefactID_DependencyArtefactVersionNumber = source.Artefact_DependencyArtefactID_DependencyArtefactVersionNumber.ToDtoWithRelated(level - 1);
              target.ArtefactDependencyStatusTypes = source.ArtefactDependencyStatusTypes.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactDependency ToEntity(this ArtefactDependencyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactDependency();

            // Properties
            target.ArtefactDependencyID = source.ArtefactDependencyID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.DependencyArtefactID = source.DependencyArtefactID;
            target.DependencyArtefactVersionNumber = source.DependencyArtefactVersionNumber;
            target.ArtefactDependencyTemplateID = source.ArtefactDependencyTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactDependencyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactDependency> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactDependencyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactDependency> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactDependency> ToEntities(this IEnumerable<ArtefactDependencyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactDependency source, ArtefactDependencyDTO target);

        static partial void OnEntityCreating(ArtefactDependencyDTO source, Bec.TargetFramework.Data.ArtefactDependency target);

    }

}
