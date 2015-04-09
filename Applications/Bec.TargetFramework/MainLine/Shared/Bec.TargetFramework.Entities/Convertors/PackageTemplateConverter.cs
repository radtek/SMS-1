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

    public static partial class PackageTemplateConverter
    {

        public static PackageTemplateDTO ToDto(this Bec.TargetFramework.Data.PackageTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageTemplateDTO();

            // Properties
            target.PackageTemplateID = source.PackageTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.PackageProductTemplates = source.PackageProductTemplates.ToDtosWithRelated(level - 1);
              target.Packages = source.Packages.ToDtosWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageTemplate ToEntity(this PackageTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageTemplate();

            // Properties
            target.PackageTemplateID = source.PackageTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageTemplate> ToEntities(this IEnumerable<PackageTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageTemplate source, PackageTemplateDTO target);

        static partial void OnEntityCreating(PackageTemplateDTO source, Bec.TargetFramework.Data.PackageTemplate target);

    }

}
