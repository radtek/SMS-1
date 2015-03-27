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

    public static partial class ArtefactConverter
    {

        public static ArtefactDTO ToDto(this Bec.TargetFramework.Data.Artefact source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Artefact source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactDTO();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactProducts = source.ArtefactProducts.ToDtosWithRelated(level - 1);
              target.OrganisationArtefacts = source.OrganisationArtefacts.ToDtosWithRelated(level - 1);
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
              target.ArtefactSubscriptions = source.ArtefactSubscriptions.ToDtosWithRelated(level - 1);
              target.ModuleArtefacts = source.ModuleArtefacts.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationArtefacts = source.DefaultOrganisationArtefacts.ToDtosWithRelated(level - 1);
              target.ArtefactClaims = source.ArtefactClaims.ToDtosWithRelated(level - 1);
              target.ArtefactNotificationConstructs = source.ArtefactNotificationConstructs.ToDtosWithRelated(level - 1);
              target.ArtefactDependencies_ArtefactID_ArtefactVersionNumber = source.ArtefactDependencies_ArtefactID_ArtefactVersionNumber.ToDtosWithRelated(level - 1);
              target.ArtefactWorkflows = source.ArtefactWorkflows.ToDtosWithRelated(level - 1);
              target.ArtefactRoles = source.ArtefactRoles.ToDtosWithRelated(level - 1);
              target.StatusTypes = source.StatusTypes.ToDtosWithRelated(level - 1);
              target.ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber = source.ArtefactDependencies_DependencyArtefactID_DependencyArtefactVersionNumber.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Artefact ToEntity(this ArtefactDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Artefact();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Artefact> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Artefact> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Artefact> ToEntities(this IEnumerable<ArtefactDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Artefact source, ArtefactDTO target);

        static partial void OnEntityCreating(ArtefactDTO source, Bec.TargetFramework.Data.Artefact target);

    }

}
