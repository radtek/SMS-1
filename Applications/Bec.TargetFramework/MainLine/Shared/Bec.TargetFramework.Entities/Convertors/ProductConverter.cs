﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductConverter
    {

        public static ProductDTO ToDto(this Bec.TargetFramework.Data.Product source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Product source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsPackage = source.IsPackage;
            target.IsDeposit = source.IsDeposit;
            target.ProductVersionID = source.ProductVersionID;
            target.ProductTemplateVersionID = source.ProductTemplateVersionID;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeResold = source.CanBeResold;
            target.IsDeductionProduct = source.IsDeductionProduct;

            // Navigation Properties
            if (level > 0) {
              target.ProductDetails = source.ProductDetails.ToDtosWithRelated(level - 1);
              target.ArtefactProducts = source.ArtefactProducts.ToDtosWithRelated(level - 1);
              target.PackageProductRelationships_ParentProductID_ParentProductVersionID = source.PackageProductRelationships_ParentProductID_ParentProductVersionID.ToDtosWithRelated(level - 1);
              target.PackageProductRelationships_ChildProductID_ChildProductVersionID = source.PackageProductRelationships_ChildProductID_ChildProductVersionID.ToDtosWithRelated(level - 1);
              target.ModuleProducts = source.ModuleProducts.ToDtosWithRelated(level - 1);
              target.ShoppingCartItems = source.ShoppingCartItems.ToDtosWithRelated(level - 1);
              target.ProductDeductions = source.ProductDeductions.ToDtosWithRelated(level - 1);
              target.InvoiceLineItems = source.InvoiceLineItems.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationProducts = source.DefaultOrganisationProducts.ToDtosWithRelated(level - 1);
              target.ProductDiscounts = source.ProductDiscounts.ToDtosWithRelated(level - 1);
              target.Packages = source.Packages.ToDtosWithRelated(level - 1);
              target.PlanProducts = source.PlanProducts.ToDtosWithRelated(level - 1);
              target.ProductClaims = source.ProductClaims.ToDtosWithRelated(level - 1);
              target.ProductSpecificationBlueprints = source.ProductSpecificationBlueprints.ToDtosWithRelated(level - 1);
              target.ProductTags = source.ProductTags.ToDtosWithRelated(level - 1);
              target.ProductSpecificationAttributes = source.ProductSpecificationAttributes.ToDtosWithRelated(level - 1);
              target.ProductVariantAttributeCombinations = source.ProductVariantAttributeCombinations.ToDtosWithRelated(level - 1);
              target.ProductRoles = source.ProductRoles.ToDtosWithRelated(level - 1);
              target.ProductFamilyProductPackages = source.ProductFamilyProductPackages.ToDtosWithRelated(level - 1);
              target.ProductProductAttributes = source.ProductProductAttributes.ToDtosWithRelated(level - 1);
              target.ProductRelationships_ParentProductID_ParentProductVersionID = source.ProductRelationships_ParentProductID_ParentProductVersionID.ToDtosWithRelated(level - 1);
              target.ProductRelationships_ChildProductID_ChildProductVersionID = source.ProductRelationships_ChildProductID_ChildProductVersionID.ToDtosWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.PackageProducts = source.PackageProducts.ToDtosWithRelated(level - 1);
              target.ShoppingCartBlueprintProducts = source.ShoppingCartBlueprintProducts.ToDtosWithRelated(level - 1);
              target.OrganisationProductPurchases = source.OrganisationProductPurchases.ToDtosWithRelated(level - 1);
              target.DiscountRelatedProducts = source.DiscountRelatedProducts.ToDtosWithRelated(level - 1);
              target.ComponentTiers = source.ComponentTiers.ToDtosWithRelated(level - 1);
              target.Deductions = source.Deductions.ToDtosWithRelated(level - 1);
              target.ProductPlans = source.ProductPlans.ToDtosWithRelated(level - 1);
              target.ProductBusTasks = source.ProductBusTasks.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Product ToEntity(this ProductDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Product();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsPackage = source.IsPackage;
            target.IsDeposit = source.IsDeposit;
            target.ProductVersionID = source.ProductVersionID;
            target.ProductTemplateVersionID = source.ProductTemplateVersionID;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.CanBeResold = source.CanBeResold;
            target.IsDeductionProduct = source.IsDeductionProduct;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Product> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Product> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Product> ToEntities(this IEnumerable<ProductDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Product source, ProductDTO target);

        static partial void OnEntityCreating(ProductDTO source, Bec.TargetFramework.Data.Product target);

    }

}
