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

    public static partial class PackageProductSpecificationBlueprintTemplateConverter
    {

        public static PackageProductSpecificationBlueprintTemplateDTO ToDto(this Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductSpecificationBlueprintTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductSpecificationBlueprintTemplateDTO();

            // Properties
            target.PackageProductSpecificationBlueprintTemplateID = source.PackageProductSpecificationBlueprintTemplateID;
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.ProductSpecificationAttributeTemplate = source.ProductSpecificationAttributeTemplate;
            target.DefaultProductSpecificationAttributeOptionTemplateID = source.DefaultProductSpecificationAttributeOptionTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeTemplate1 = source.ProductSpecificationAttributeTemplate1.ToDtoWithRelated(level - 1);
              target.ProductSpecificationAttributeOptionTemplate = source.ProductSpecificationAttributeOptionTemplate.ToDtoWithRelated(level - 1);
              target.PackageProductTemplate = source.PackageProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate ToEntity(this PackageProductSpecificationBlueprintTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate();

            // Properties
            target.PackageProductSpecificationBlueprintTemplateID = source.PackageProductSpecificationBlueprintTemplateID;
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.ProductSpecificationAttributeTemplate = source.ProductSpecificationAttributeTemplate;
            target.DefaultProductSpecificationAttributeOptionTemplateID = source.DefaultProductSpecificationAttributeOptionTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductSpecificationBlueprintTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductSpecificationBlueprintTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate> ToEntities(this IEnumerable<PackageProductSpecificationBlueprintTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate source, PackageProductSpecificationBlueprintTemplateDTO target);

        static partial void OnEntityCreating(PackageProductSpecificationBlueprintTemplateDTO source, Bec.TargetFramework.Data.PackageProductSpecificationBlueprintTemplate target);

    }

}
