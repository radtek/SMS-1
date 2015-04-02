﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductClaimConverter
    {

        public static ProductClaimDTO ToDto(this Bec.TargetFramework.Data.ProductClaim source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductClaimDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductClaim source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductClaimDTO();

            // Properties
            target.ProductClaimID = source.ProductClaimID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.RoleID = source.RoleID;
            target.ProductRoleID = source.ProductRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Operation = source.Operation.ToDtoWithRelated(level - 1);
              target.ProductRole = source.ProductRole.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.Resource = source.Resource.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.State = source.State.ToDtoWithRelated(level - 1);
              target.StateItem = source.StateItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductClaim ToEntity(this ProductClaimDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductClaim();

            // Properties
            target.ProductClaimID = source.ProductClaimID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.RoleID = source.RoleID;
            target.ProductRoleID = source.ProductRoleID;
            target.ResourceID = source.ResourceID;
            target.OperationID = source.OperationID;
            target.StateID = source.StateID;
            target.StateItemID = source.StateItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductClaimDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductClaim> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductClaimDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductClaim> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductClaim> ToEntities(this IEnumerable<ProductClaimDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductClaim source, ProductClaimDTO target);

        static partial void OnEntityCreating(ProductClaimDTO source, Bec.TargetFramework.Data.ProductClaim target);

    }

}
