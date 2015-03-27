﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DiscountConverter
    {

        public static DiscountDTO ToDto(this Bec.TargetFramework.Data.Discount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Discount source, int level)
        {
            if (source == null)
              return null;

            var target = new DiscountDTO();

            // Properties
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountPeriod = source.DiscountPeriod;
            target.DisocuntPeriodUnitID = source.DisocuntPeriodUnitID;
            target.ValidTill = source.ValidTill;
            target.MaxRedemptions = source.MaxRedemptions;
            target.DiscountApplyOnID = source.DiscountApplyOnID;
            target.CreatedOn = source.CreatedOn;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsRecurring = source.IsRecurring;
            target.IsPercentage = source.IsPercentage;
            target.ParentID = source.ParentID;
            target.DiscountStatusID = source.DiscountStatusID;
            target.IsSingleProductDiscount = source.IsSingleProductDiscount;
            target.IsCheckoutDiscount = source.IsCheckoutDiscount;
            target.IsSingleProductQuantityDiscount = source.IsSingleProductQuantityDiscount;
            target.SingleProductQuantityDiscountDivisor = source.SingleProductQuantityDiscountDivisor;
            target.IsSingleProductQuantityDiscountPercentageBased = source.IsSingleProductQuantityDiscountPercentageBased;
            target.IsSingleProductQuantityDiscountAdditionalQuantityBased = source.IsSingleProductQuantityDiscountAdditionalQuantityBased;
            target.SingleProductQuantityDiscountAdditionalQuantity = source.SingleProductQuantityDiscountAdditionalQuantity;
            target.IsMultipleProductCombinationDiscount = source.IsMultipleProductCombinationDiscount;
            target.IsMultipleProductCombinationDiscountPercentageBased = source.IsMultipleProductCombinationDiscountPercentageBased;
            target.IsMultipleProductCombinationDiscountCheapestFreeBased = source.IsMultipleProductCombinationDiscountCheapestFreeBased;
            target.HasTiers = source.HasTiers;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ParentVersionNumber = source.ParentVersionNumber;
            target.OwnerOrganisationID = source.OwnerOrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.ProductDiscounts = source.ProductDiscounts.ToDtosWithRelated(level - 1);
              target.OrganisationDiscounts = source.OrganisationDiscounts.ToDtosWithRelated(level - 1);
              target.PlanDiscounts = source.PlanDiscounts.ToDtosWithRelated(level - 1);
              target.DiscountRelatedProducts = source.DiscountRelatedProducts.ToDtosWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.ComponentTiers = source.ComponentTiers.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Discount ToEntity(this DiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Discount();

            // Properties
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountPeriod = source.DiscountPeriod;
            target.DisocuntPeriodUnitID = source.DisocuntPeriodUnitID;
            target.ValidTill = source.ValidTill;
            target.MaxRedemptions = source.MaxRedemptions;
            target.DiscountApplyOnID = source.DiscountApplyOnID;
            target.CreatedOn = source.CreatedOn;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsRecurring = source.IsRecurring;
            target.IsPercentage = source.IsPercentage;
            target.ParentID = source.ParentID;
            target.DiscountStatusID = source.DiscountStatusID;
            target.IsSingleProductDiscount = source.IsSingleProductDiscount;
            target.IsCheckoutDiscount = source.IsCheckoutDiscount;
            target.IsSingleProductQuantityDiscount = source.IsSingleProductQuantityDiscount;
            target.SingleProductQuantityDiscountDivisor = source.SingleProductQuantityDiscountDivisor;
            target.IsSingleProductQuantityDiscountPercentageBased = source.IsSingleProductQuantityDiscountPercentageBased;
            target.IsSingleProductQuantityDiscountAdditionalQuantityBased = source.IsSingleProductQuantityDiscountAdditionalQuantityBased;
            target.SingleProductQuantityDiscountAdditionalQuantity = source.SingleProductQuantityDiscountAdditionalQuantity;
            target.IsMultipleProductCombinationDiscount = source.IsMultipleProductCombinationDiscount;
            target.IsMultipleProductCombinationDiscountPercentageBased = source.IsMultipleProductCombinationDiscountPercentageBased;
            target.IsMultipleProductCombinationDiscountCheapestFreeBased = source.IsMultipleProductCombinationDiscountCheapestFreeBased;
            target.HasTiers = source.HasTiers;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ParentVersionNumber = source.ParentVersionNumber;
            target.OwnerOrganisationID = source.OwnerOrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Discount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Discount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Discount> ToEntities(this IEnumerable<DiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Discount source, DiscountDTO target);

        static partial void OnEntityCreating(DiscountDTO source, Bec.TargetFramework.Data.Discount target);

    }

}
