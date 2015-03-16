﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DiscountRelatedProductTemplateConverter
    {

        public static DiscountRelatedProductTemplateDTO ToDto(this Bec.TargetFramework.Data.DiscountRelatedProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DiscountRelatedProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DiscountRelatedProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DiscountRelatedProductTemplateDTO();

            // Properties
            target.DiscountRelatedProductTemplateID = source.DiscountRelatedProductTemplateID;
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DiscountTemplate = source.DiscountTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DiscountRelatedProductTemplate ToEntity(this DiscountRelatedProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DiscountRelatedProductTemplate();

            // Properties
            target.DiscountRelatedProductTemplateID = source.DiscountRelatedProductTemplateID;
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DiscountRelatedProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DiscountRelatedProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DiscountRelatedProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DiscountRelatedProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DiscountRelatedProductTemplate> ToEntities(this IEnumerable<DiscountRelatedProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DiscountRelatedProductTemplate source, DiscountRelatedProductTemplateDTO target);

        static partial void OnEntityCreating(DiscountRelatedProductTemplateDTO source, Bec.TargetFramework.Data.DiscountRelatedProductTemplate target);

    }

}
