﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductRelationshipTemplateConverter
    {

        public static ProductRelationshipTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductRelationshipTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductRelationshipTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductRelationshipTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductRelationshipTemplateDTO();

            // Properties
            target.ProductRelationshipTemplateID = source.ProductRelationshipTemplateID;
            target.ParentProductTemplateID = source.ParentProductTemplateID;
            target.ChildProductTemplateID = source.ChildProductTemplateID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.ProductRelationshipBlueprintTemplates = source.ProductRelationshipBlueprintTemplates.ToDtosWithRelated(level - 1);
              target.ProductTemplate_ParentProductTemplateID_ParentProductVersionID = source.ProductTemplate_ParentProductTemplateID_ParentProductVersionID.ToDtoWithRelated(level - 1);
              target.ProductTemplate_ChildProductTemplateID_ChildProductVersionID = source.ProductTemplate_ChildProductTemplateID_ChildProductVersionID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductRelationshipTemplate ToEntity(this ProductRelationshipTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductRelationshipTemplate();

            // Properties
            target.ProductRelationshipTemplateID = source.ProductRelationshipTemplateID;
            target.ParentProductTemplateID = source.ParentProductTemplateID;
            target.ChildProductTemplateID = source.ChildProductTemplateID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductRelationshipTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductRelationshipTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductRelationshipTemplate> ToEntities(this IEnumerable<ProductRelationshipTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductRelationshipTemplate source, ProductRelationshipTemplateDTO target);

        static partial void OnEntityCreating(ProductRelationshipTemplateDTO source, Bec.TargetFramework.Data.ProductRelationshipTemplate target);

    }

}
