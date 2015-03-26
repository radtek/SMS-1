﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PackageProductRelationshipTemplateConverter
    {

        public static PackageProductRelationshipTemplateDTO ToDto(this Bec.TargetFramework.Data.PackageProductRelationshipTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductRelationshipTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductRelationshipTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductRelationshipTemplateDTO();

            // Properties
            target.PackageProductRelationshipTemplateID = source.PackageProductRelationshipTemplateID;
            target.ParentProductTemplateID = source.ParentProductTemplateID;
            target.ChildProductTemplateID = source.ChildProductTemplateID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ProductTemplate_ParentProductTemplateID_ParentProductVersionID = source.ProductTemplate_ParentProductTemplateID_ParentProductVersionID.ToDtoWithRelated(level - 1);
              target.ProductTemplate_ChildProductTemplateID_ChildProductVersionID = source.ProductTemplate_ChildProductTemplateID_ChildProductVersionID.ToDtoWithRelated(level - 1);
              target.PackageProductTemplate = source.PackageProductTemplate.ToDtoWithRelated(level - 1);
              target.PackageProductRelationshipBlueprintTemplates = source.PackageProductRelationshipBlueprintTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductRelationshipTemplate ToEntity(this PackageProductRelationshipTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductRelationshipTemplate();

            // Properties
            target.PackageProductRelationshipTemplateID = source.PackageProductRelationshipTemplateID;
            target.ParentProductTemplateID = source.ParentProductTemplateID;
            target.ChildProductTemplateID = source.ChildProductTemplateID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageProductTemplateID = source.PackageProductTemplateID;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;
            target.PackageTemplateID = source.PackageTemplateID;
            target.PackageTemplateVersionNumber = source.PackageTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductRelationshipTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationshipTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductRelationshipTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationshipTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductRelationshipTemplate> ToEntities(this IEnumerable<PackageProductRelationshipTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductRelationshipTemplate source, PackageProductRelationshipTemplateDTO target);

        static partial void OnEntityCreating(PackageProductRelationshipTemplateDTO source, Bec.TargetFramework.Data.PackageProductRelationshipTemplate target);

    }

}
