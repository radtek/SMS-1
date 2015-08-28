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

    public static partial class SpecificiationAttributeOptionConverter
    {

        public static SpecificiationAttributeOptionDTO ToDto(this Bec.TargetFramework.Data.SpecificiationAttributeOption source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SpecificiationAttributeOptionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SpecificiationAttributeOption source, int level)
        {
            if (source == null)
              return null;

            var target = new SpecificiationAttributeOptionDTO();

            // Properties
            target.SpecficiationAttributeOptionID = source.SpecficiationAttributeOptionID;
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.SpecificationAttributeID = source.SpecificationAttributeID;
            target.DisplayOrder = source.DisplayOrder;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeOptions = source.ProductSpecificationAttributeOptions.ToDtosWithRelated(level - 1);
              target.SpecificationAttribute = source.SpecificationAttribute.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SpecificiationAttributeOption ToEntity(this SpecificiationAttributeOptionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SpecificiationAttributeOption();

            // Properties
            target.SpecficiationAttributeOptionID = source.SpecficiationAttributeOptionID;
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.SpecificationAttributeID = source.SpecificationAttributeID;
            target.DisplayOrder = source.DisplayOrder;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SpecificiationAttributeOptionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SpecificiationAttributeOption> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SpecificiationAttributeOptionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SpecificiationAttributeOption> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SpecificiationAttributeOption> ToEntities(this IEnumerable<SpecificiationAttributeOptionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SpecificiationAttributeOption source, SpecificiationAttributeOptionDTO target);

        static partial void OnEntityCreating(SpecificiationAttributeOptionDTO source, Bec.TargetFramework.Data.SpecificiationAttributeOption target);

    }

}
