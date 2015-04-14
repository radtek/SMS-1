﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class BucketTemplateConverter
    {

        public static BucketTemplateDTO ToDto(this Bec.TargetFramework.Data.BucketTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BucketTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BucketTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new BucketTemplateDTO();

            // Properties
            target.BucketTemplateID = source.BucketTemplateID;
            target.BucketName = source.BucketName;
            target.BucketDescription = source.BucketDescription;
            target.BucketTypeID = source.BucketTypeID;
            target.BucketSubTypeID = source.BucketSubTypeID;
            target.BucketCategoryID = source.BucketCategoryID;
            target.BucketSubCategoryID = source.BucketSubCategoryID;
            target.IsGlobal = source.IsGlobal;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplates = source.DefaultOrganisationTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisations = source.DefaultOrganisations.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BucketTemplate ToEntity(this BucketTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BucketTemplate();

            // Properties
            target.BucketTemplateID = source.BucketTemplateID;
            target.BucketName = source.BucketName;
            target.BucketDescription = source.BucketDescription;
            target.BucketTypeID = source.BucketTypeID;
            target.BucketSubTypeID = source.BucketSubTypeID;
            target.BucketCategoryID = source.BucketCategoryID;
            target.BucketSubCategoryID = source.BucketSubCategoryID;
            target.IsGlobal = source.IsGlobal;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BucketTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BucketTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BucketTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BucketTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BucketTemplate> ToEntities(this IEnumerable<BucketTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BucketTemplate source, BucketTemplateDTO target);

        static partial void OnEntityCreating(BucketTemplateDTO source, Bec.TargetFramework.Data.BucketTemplate target);

    }

}
