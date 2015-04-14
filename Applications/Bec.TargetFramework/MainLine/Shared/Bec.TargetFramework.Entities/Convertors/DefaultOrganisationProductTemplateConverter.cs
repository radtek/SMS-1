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

    public static partial class DefaultOrganisationProductTemplateConverter
    {

        public static DefaultOrganisationProductTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationProductTemplateDTO();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationProductTemplate ToEntity(this DefaultOrganisationProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationProductTemplate();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationProductTemplate> ToEntities(this IEnumerable<DefaultOrganisationProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationProductTemplate source, DefaultOrganisationProductTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationProductTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationProductTemplate target);

    }

}
