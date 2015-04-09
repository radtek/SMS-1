﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PackageConverter
    {

        public static PackageDTO ToDto(this Bec.TargetFramework.Data.Package source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Package source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageDTO();

            // Properties
            target.PackageID = source.PackageID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageVersionNumber = source.PackageVersionNumber;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.PackageTemplate = source.PackageTemplate.ToDtoWithRelated(level - 1);
              target.PackageProducts = source.PackageProducts.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Package ToEntity(this PackageDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Package();

            // Properties
            target.PackageID = source.PackageID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageVersionNumber = source.PackageVersionNumber;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Package> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Package> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Package> ToEntities(this IEnumerable<PackageDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Package source, PackageDTO target);

        static partial void OnEntityCreating(PackageDTO source, Bec.TargetFramework.Data.Package target);

    }

}
