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

    public static partial class PackageProductTemplateConverter
    {

        public static PackageProductTemplateDTO ToDto(this Bec.TargetFramework.Data.PackageProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductTemplateDTO();

            // Properties
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.PackageTemplateID = source.PackageTemplateID;
            target.UseProductDefaultBlueprint = source.UseProductDefaultBlueprint;
            target.UseDefaultProductPricing = source.UseDefaultProductPricing;
            target.IsFixedPrice = source.IsFixedPrice;
            target.ProductPriceModifierPercentage = source.ProductPriceModifierPercentage;
            target.ProductPriceModifierValue = source.ProductPriceModifierValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.UserDefinableQuantity = source.UserDefinableQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;
            target.RelatedProductProductAttributeTemplateID = source.RelatedProductProductAttributeTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.PackageProductRelationshipTemplates = source.PackageProductRelationshipTemplates.ToDtosWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.PackageTemplate = source.PackageTemplate.ToDtoWithRelated(level - 1);
              target.ProductFamilyProductPackageTemplates = source.ProductFamilyProductPackageTemplates.ToDtosWithRelated(level - 1);
              target.PackageProductSpecificationBlueprintTemplates = source.PackageProductSpecificationBlueprintTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductTemplate ToEntity(this PackageProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductTemplate();

            // Properties
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.PackageTemplateID = source.PackageTemplateID;
            target.UseProductDefaultBlueprint = source.UseProductDefaultBlueprint;
            target.UseDefaultProductPricing = source.UseDefaultProductPricing;
            target.IsFixedPrice = source.IsFixedPrice;
            target.ProductPriceModifierPercentage = source.ProductPriceModifierPercentage;
            target.ProductPriceModifierValue = source.ProductPriceModifierValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.UserDefinableQuantity = source.UserDefinableQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;
            target.RelatedProductProductAttributeTemplateID = source.RelatedProductProductAttributeTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductTemplate> ToEntities(this IEnumerable<PackageProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductTemplate source, PackageProductTemplateDTO target);

        static partial void OnEntityCreating(PackageProductTemplateDTO source, Bec.TargetFramework.Data.PackageProductTemplate target);

    }

}
