﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PackageProductRelationshipBlueprintTemplateConverter
    {

        public static PackageProductRelationshipBlueprintTemplateDTO ToDto(this Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductRelationshipBlueprintTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductRelationshipBlueprintTemplateDTO();

            // Properties
            target.PackageProductRelationshipBlueprintTemplateID = source.PackageProductRelationshipBlueprintTemplateID;
            target.PackageProductRelationshipTemplateID = source.PackageProductRelationshipTemplateID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.PackageProductRelationshipTemplate = source.PackageProductRelationshipTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate ToEntity(this PackageProductRelationshipBlueprintTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate();

            // Properties
            target.PackageProductRelationshipBlueprintTemplateID = source.PackageProductRelationshipBlueprintTemplateID;
            target.PackageProductRelationshipTemplateID = source.PackageProductRelationshipTemplateID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductRelationshipBlueprintTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductRelationshipBlueprintTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate> ToEntities(this IEnumerable<PackageProductRelationshipBlueprintTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate source, PackageProductRelationshipBlueprintTemplateDTO target);

        static partial void OnEntityCreating(PackageProductRelationshipBlueprintTemplateDTO source, Bec.TargetFramework.Data.PackageProductRelationshipBlueprintTemplate target);

    }

}
