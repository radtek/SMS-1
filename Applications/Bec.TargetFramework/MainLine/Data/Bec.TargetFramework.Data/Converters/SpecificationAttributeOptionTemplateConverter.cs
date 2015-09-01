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

    public static partial class SpecificationAttributeOptionTemplateConverter
    {

        public static SpecificationAttributeOptionTemplateDTO ToDto(this Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SpecificationAttributeOptionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new SpecificationAttributeOptionTemplateDTO();

            // Properties
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DisplayOrder = source.DisplayOrder;
            target.Order = source.Order;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeOptionTemplates = source.ProductSpecificationAttributeOptionTemplates.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeTemplate = source.SpecificationAttributeTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate ToEntity(this SpecificationAttributeOptionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate();

            // Properties
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DisplayOrder = source.DisplayOrder;
            target.Order = source.Order;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SpecificationAttributeOptionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SpecificationAttributeOptionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate> ToEntities(this IEnumerable<SpecificationAttributeOptionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate source, SpecificationAttributeOptionTemplateDTO target);

        static partial void OnEntityCreating(SpecificationAttributeOptionTemplateDTO source, Bec.TargetFramework.Data.SpecificationAttributeOptionTemplate target);

    }

}