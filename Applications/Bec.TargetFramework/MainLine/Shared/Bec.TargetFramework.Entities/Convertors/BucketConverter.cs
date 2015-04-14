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

    public static partial class BucketConverter
    {

        public static BucketDTO ToDto(this Bec.TargetFramework.Data.Bucket source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BucketDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Bucket source, int level)
        {
            if (source == null)
              return null;

            var target = new BucketDTO();

            // Properties
            target.BucketID = source.BucketID;
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
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Bucket ToEntity(this BucketDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Bucket();

            // Properties
            target.BucketID = source.BucketID;
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

        public static List<BucketDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Bucket> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BucketDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Bucket> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Bucket> ToEntities(this IEnumerable<BucketDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Bucket source, BucketDTO target);

        static partial void OnEntityCreating(BucketDTO source, Bec.TargetFramework.Data.Bucket target);

    }

}
