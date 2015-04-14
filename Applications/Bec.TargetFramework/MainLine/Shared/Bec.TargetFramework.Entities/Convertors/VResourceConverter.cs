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

    public static partial class VResourceConverter
    {

        public static VResourceDTO ToDto(this Bec.TargetFramework.Data.VResource source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VResourceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VResource source, int level)
        {
            if (source == null)
              return null;

            var target = new VResourceDTO();

            // Properties
            target.ResourceID = source.ResourceID;
            target.ResourceName = source.ResourceName;
            target.ResourceDescription = source.ResourceDescription;
            target.SourceID = source.SourceID;
            target.ResourceTypeID = source.ResourceTypeID;
            target.ResourceCategoryID = source.ResourceCategoryID;
            target.ResourceSubCategoryID = source.ResourceSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VResource ToEntity(this VResourceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VResource();

            // Properties
            target.ResourceID = source.ResourceID;
            target.ResourceName = source.ResourceName;
            target.ResourceDescription = source.ResourceDescription;
            target.SourceID = source.SourceID;
            target.ResourceTypeID = source.ResourceTypeID;
            target.ResourceCategoryID = source.ResourceCategoryID;
            target.ResourceSubCategoryID = source.ResourceSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VResourceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VResource> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VResourceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VResource> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VResource> ToEntities(this IEnumerable<VResourceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VResource source, VResourceDTO target);

        static partial void OnEntityCreating(VResourceDTO source, Bec.TargetFramework.Data.VResource target);

    }

}
