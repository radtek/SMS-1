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

    public static partial class DefaultOrganisationArtefactConverter
    {

        public static DefaultOrganisationArtefactDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationArtefact source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationArtefactDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationArtefact source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationArtefactDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Artefact = source.Artefact.ToDtoWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationArtefact ToEntity(this DefaultOrganisationArtefactDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationArtefact();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationArtefactDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationArtefact> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationArtefactDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationArtefact> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationArtefact> ToEntities(this IEnumerable<DefaultOrganisationArtefactDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationArtefact source, DefaultOrganisationArtefactDTO target);

        static partial void OnEntityCreating(DefaultOrganisationArtefactDTO source, Bec.TargetFramework.Data.DefaultOrganisationArtefact target);

    }

}
