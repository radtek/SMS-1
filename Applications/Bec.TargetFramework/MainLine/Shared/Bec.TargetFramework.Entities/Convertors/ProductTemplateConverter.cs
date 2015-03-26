﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductTemplateConverter
    {

        public static ProductTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductTemplateDTO();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsPackage = source.IsPackage;
            target.ProductVersionID = source.ProductVersionID;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.IsDefaultTemplate = source.IsDefaultTemplate;
            target.CanBeResold = source.CanBeResold;
            target.IsDeductionProduct = source.IsDeductionProduct;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactProductTemplates = source.ArtefactProductTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationProductTemplates = source.DefaultOrganisationProductTemplates.ToDtosWithRelated(level - 1);
              target.PlanProductTemplates = source.PlanProductTemplates.ToDtosWithRelated(level - 1);
              target.PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID = source.PackageProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID.ToDtosWithRelated(level - 1);
              target.PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID = source.PackageProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID.ToDtosWithRelated(level - 1);
              target.PackageProductTemplates = source.PackageProductTemplates.ToDtosWithRelated(level - 1);
              target.ProductDiscountTemplates = source.ProductDiscountTemplates.ToDtosWithRelated(level - 1);
              target.ProductPlanTemplates = source.ProductPlanTemplates.ToDtosWithRelated(level - 1);
              target.ModuleProductTemplates = source.ModuleProductTemplates.ToDtosWithRelated(level - 1);
              target.ProductClaimTemplates = source.ProductClaimTemplates.ToDtosWithRelated(level - 1);
              target.ProductRoleTemplates = source.ProductRoleTemplates.ToDtosWithRelated(level - 1);
              target.ProductDetailTemplates = source.ProductDetailTemplates.ToDtosWithRelated(level - 1);
              target.ProductSpecificationAttributeTemplates = source.ProductSpecificationAttributeTemplates.ToDtosWithRelated(level - 1);
              target.ProductTagTemplates = source.ProductTagTemplates.ToDtosWithRelated(level - 1);
              target.ProductVariantAttributeCombinationTemplates = source.ProductVariantAttributeCombinationTemplates.ToDtosWithRelated(level - 1);
              target.ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID = source.ProductRelationshipTemplates_ParentProductTemplateID_ParentProductVersionID.ToDtosWithRelated(level - 1);
              target.ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID = source.ProductRelationshipTemplates_ChildProductTemplateID_ChildProductVersionID.ToDtosWithRelated(level - 1);
              target.ProductDeductionTemplates = source.ProductDeductionTemplates.ToDtosWithRelated(level - 1);
              target.Products = source.Products.ToDtosWithRelated(level - 1);
              target.PackageTemplates = source.PackageTemplates.ToDtosWithRelated(level - 1);
              target.ProductFamilyProductPackageTemplates = source.ProductFamilyProductPackageTemplates.ToDtosWithRelated(level - 1);
              target.ProductProductAttributeTemplates = source.ProductProductAttributeTemplates.ToDtosWithRelated(level - 1);
              target.DiscountRelatedProductTemplates = source.DiscountRelatedProductTemplates.ToDtosWithRelated(level - 1);
              target.ShoppingCartBlueprintProductTemplates = source.ShoppingCartBlueprintProductTemplates.ToDtosWithRelated(level - 1);
              target.DeductionTemplates = source.DeductionTemplates.ToDtosWithRelated(level - 1);
              target.ComponentTierTemplates = source.ComponentTierTemplates.ToDtosWithRelated(level - 1);
              target.ProductBusTaskTemplates = source.ProductBusTaskTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductTemplate ToEntity(this ProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductTemplate();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsPackage = source.IsPackage;
            target.ProductVersionID = source.ProductVersionID;
            target.ParentID = source.ParentID;
            target.OwnerOrganisationID = source.OwnerOrganisationID;
            target.IsDefaultTemplate = source.IsDefaultTemplate;
            target.CanBeResold = source.CanBeResold;
            target.IsDeductionProduct = source.IsDeductionProduct;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductTemplate> ToEntities(this IEnumerable<ProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductTemplate source, ProductTemplateDTO target);

        static partial void OnEntityCreating(ProductTemplateDTO source, Bec.TargetFramework.Data.ProductTemplate target);

    }

}
