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

    public static partial class ProductFamilyConverter
    {

        public static ProductFamilyDTO ToDto(this Bec.TargetFramework.Data.ProductFamily source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductFamilyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductFamily source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductFamilyDTO();

            // Properties
            target.ProductFamilyID = source.ProductFamilyID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductFamilyProductPackages = source.ProductFamilyProductPackages.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductFamily ToEntity(this ProductFamilyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductFamily();

            // Properties
            target.ProductFamilyID = source.ProductFamilyID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductFamilyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductFamily> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductFamilyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductFamily> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductFamily> ToEntities(this IEnumerable<ProductFamilyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductFamily source, ProductFamilyDTO target);

        static partial void OnEntityCreating(ProductFamilyDTO source, Bec.TargetFramework.Data.ProductFamily target);

    }

}
