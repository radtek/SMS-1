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

    public static partial class ArtefactStatusTypeTemplateConverter
    {

        public static ArtefactStatusTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactStatusTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactStatusTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactStatusTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactStatusTypeTemplateDTO();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
              target.ArtefactDependencyStatusTypeTemplates = source.ArtefactDependencyStatusTypeTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactStatusTypeTemplate ToEntity(this ArtefactStatusTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactStatusTypeTemplate();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactStatusTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactStatusTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactStatusTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactStatusTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactStatusTypeTemplate> ToEntities(this IEnumerable<ArtefactStatusTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactStatusTypeTemplate source, ArtefactStatusTypeTemplateDTO target);

        static partial void OnEntityCreating(ArtefactStatusTypeTemplateDTO source, Bec.TargetFramework.Data.ArtefactStatusTypeTemplate target);

    }

}
