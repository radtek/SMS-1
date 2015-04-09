﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ArtefactProductTemplateConverter
    {

        public static ArtefactProductTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactProductTemplateDTO();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactProductTemplate ToEntity(this ArtefactProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactProductTemplate();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactProductTemplate> ToEntities(this IEnumerable<ArtefactProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactProductTemplate source, ArtefactProductTemplateDTO target);

        static partial void OnEntityCreating(ArtefactProductTemplateDTO source, Bec.TargetFramework.Data.ArtefactProductTemplate target);

    }

}
