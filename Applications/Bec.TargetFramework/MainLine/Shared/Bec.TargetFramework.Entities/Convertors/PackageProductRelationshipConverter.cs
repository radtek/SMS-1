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

    public static partial class PackageProductRelationshipConverter
    {

        public static PackageProductRelationshipDTO ToDto(this Bec.TargetFramework.Data.PackageProductRelationship source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductRelationshipDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductRelationship source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductRelationshipDTO();

            // Properties
            target.PackageProductRelationshipID = source.PackageProductRelationshipID;
            target.ParentProductID = source.ParentProductID;
            target.ChildProductID = source.ChildProductID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageProductID = source.PackageProductID;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Product_ParentProductID_ParentProductVersionID = source.Product_ParentProductID_ParentProductVersionID.ToDtoWithRelated(level - 1);
              target.Product_ChildProductID_ChildProductVersionID = source.Product_ChildProductID_ChildProductVersionID.ToDtoWithRelated(level - 1);
              target.PackageProduct = source.PackageProduct.ToDtoWithRelated(level - 1);
              target.PackageProductRelationshipBlueprints = source.PackageProductRelationshipBlueprints.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductRelationship ToEntity(this PackageProductRelationshipDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductRelationship();

            // Properties
            target.PackageProductRelationshipID = source.PackageProductRelationshipID;
            target.ParentProductID = source.ParentProductID;
            target.ChildProductID = source.ChildProductID;
            target.ProductRelationshipTypeID = source.ProductRelationshipTypeID;
            target.IsMandatory = source.IsMandatory;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PackageProductID = source.PackageProductID;
            target.ParentProductVersionID = source.ParentProductVersionID;
            target.ChildProductVersionID = source.ChildProductVersionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductRelationshipDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationship> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductRelationshipDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductRelationship> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductRelationship> ToEntities(this IEnumerable<PackageProductRelationshipDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductRelationship source, PackageProductRelationshipDTO target);

        static partial void OnEntityCreating(PackageProductRelationshipDTO source, Bec.TargetFramework.Data.PackageProductRelationship target);

    }

}
