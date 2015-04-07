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

    public static partial class ClassificationTypeCategoryConverter
    {

        public static ClassificationTypeCategoryDTO ToDto(this Bec.TargetFramework.Data.ClassificationTypeCategory source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ClassificationTypeCategoryDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ClassificationTypeCategory source, int level)
        {
            if (source == null)
              return null;

            var target = new ClassificationTypeCategoryDTO();

            // Properties
            target.ClassificationTypeCategoryID = source.ClassificationTypeCategoryID;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ClassificationTypes_ClassificationTypeCategoryID = source.ClassificationTypes_ClassificationTypeCategoryID.ToDtosWithRelated(level - 1);
              target.ClassificationTypes_ParentClassificationTypeCategoryID = source.ClassificationTypes_ParentClassificationTypeCategoryID.ToDtosWithRelated(level - 1);
              target.UserAccountArchives = source.UserAccountArchives.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ClassificationTypeCategory ToEntity(this ClassificationTypeCategoryDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ClassificationTypeCategory();

            // Properties
            target.ClassificationTypeCategoryID = source.ClassificationTypeCategoryID;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ClassificationTypeCategoryDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ClassificationTypeCategory> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ClassificationTypeCategoryDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ClassificationTypeCategory> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ClassificationTypeCategory> ToEntities(this IEnumerable<ClassificationTypeCategoryDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ClassificationTypeCategory source, ClassificationTypeCategoryDTO target);

        static partial void OnEntityCreating(ClassificationTypeCategoryDTO source, Bec.TargetFramework.Data.ClassificationTypeCategory target);

    }

}
