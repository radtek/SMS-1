﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class SpecificationAttributeTemplateConverter
    {

        public static SpecificationAttributeTemplateDTO ToDto(this Bec.TargetFramework.Data.SpecificationAttributeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SpecificationAttributeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SpecificationAttributeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new SpecificationAttributeTemplateDTO();

            // Properties
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.SpecificationAttributeTypeID = source.SpecificationAttributeTypeID;
            target.SpecificationAttributeCategoryID = source.SpecificationAttributeCategoryID;
            target.SpecificationAttributeSubTypeID = source.SpecificationAttributeSubTypeID;
            target.SpecificationAttributeSubCategoryID = source.SpecificationAttributeSubCategoryID;
            target.Order = source.Order;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeTemplates = source.ProductSpecificationAttributeTemplates.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeOptionTemplates = source.SpecificationAttributeOptionTemplates.ToDtosWithRelated(level - 1);
              target.SpecificationAttributes = source.SpecificationAttributes.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID = source.SpecificationAttributeRelationshipTemplates_ParentSpecificationAttributeTemplateID.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID = source.SpecificationAttributeRelationshipTemplates_SpecificationAttributeTemplateID.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SpecificationAttributeTemplate ToEntity(this SpecificationAttributeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SpecificationAttributeTemplate();

            // Properties
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.SpecificationAttributeTypeID = source.SpecificationAttributeTypeID;
            target.SpecificationAttributeCategoryID = source.SpecificationAttributeCategoryID;
            target.SpecificationAttributeSubTypeID = source.SpecificationAttributeSubTypeID;
            target.SpecificationAttributeSubCategoryID = source.SpecificationAttributeSubCategoryID;
            target.Order = source.Order;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SpecificationAttributeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttributeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SpecificationAttributeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttributeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SpecificationAttributeTemplate> ToEntities(this IEnumerable<SpecificationAttributeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SpecificationAttributeTemplate source, SpecificationAttributeTemplateDTO target);

        static partial void OnEntityCreating(SpecificationAttributeTemplateDTO source, Bec.TargetFramework.Data.SpecificationAttributeTemplate target);

    }

}
