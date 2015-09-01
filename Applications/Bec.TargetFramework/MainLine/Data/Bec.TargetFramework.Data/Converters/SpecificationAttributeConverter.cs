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

    public static partial class SpecificationAttributeConverter
    {

        public static SpecificationAttributeDTO ToDto(this Bec.TargetFramework.Data.SpecificationAttribute source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SpecificationAttributeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.SpecificationAttribute source, int level)
        {
            if (source == null)
              return null;

            var target = new SpecificationAttributeDTO();

            // Properties
            target.SpecificationAttributeID = source.SpecificationAttributeID;
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

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributes = source.ProductSpecificationAttributes.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeTemplate = source.SpecificationAttributeTemplate.ToDtoWithRelated(level - 1);
              target.SpecificationAttributeRelationships_ParentSpecificationAttributeID = source.SpecificationAttributeRelationships_ParentSpecificationAttributeID.ToDtosWithRelated(level - 1);
              target.SpecificationAttributeRelationships_SpecificationAttributeID = source.SpecificationAttributeRelationships_SpecificationAttributeID.ToDtosWithRelated(level - 1);
              target.SpecificiationAttributeOptions = source.SpecificiationAttributeOptions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.SpecificationAttribute ToEntity(this SpecificationAttributeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.SpecificationAttribute();

            // Properties
            target.SpecificationAttributeID = source.SpecificationAttributeID;
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

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SpecificationAttributeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttribute> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SpecificationAttributeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.SpecificationAttribute> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.SpecificationAttribute> ToEntities(this IEnumerable<SpecificationAttributeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.SpecificationAttribute source, SpecificationAttributeDTO target);

        static partial void OnEntityCreating(SpecificationAttributeDTO source, Bec.TargetFramework.Data.SpecificationAttribute target);

    }

}