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

    public static partial class VProductDiscountConverter
    {

        public static VProductDiscountDTO ToDto(this Bec.TargetFramework.Data.VProductDiscount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VProductDiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VProductDiscount source, int level)
        {
            if (source == null)
              return null;

            var target = new VProductDiscountDTO();

            // Properties
            target.ParentID = source.ParentID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsPackage = source.IsPackage;
            target.CreatedOn = source.CreatedOn;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountApplyOnID = source.DiscountApplyOnID;
            target.Description = source.Description;
            target.DiscountID = source.DiscountID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountPeriod = source.DiscountPeriod;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountStatusID = source.DiscountStatusID;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.DisocuntPeriodUnitID = source.DisocuntPeriodUnitID;
            target.InvoiceName = source.InvoiceName;
            target.IsPercentage = source.IsPercentage;
            target.IsRecurring = source.IsRecurring;
            target.MaxRedemptions = source.MaxRedemptions;
            target.Name = source.Name;
            target.ValidTill = source.ValidTill;
            target.DiscountStatus = source.DiscountStatus;
            target.DiscountType = source.DiscountType;
            target.DiscountApplyIn = source.DiscountApplyIn;
            target.PeriodUnit = source.PeriodUnit;
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

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VProductDiscount ToEntity(this VProductDiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VProductDiscount();

            // Properties
            target.ParentID = source.ParentID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsPackage = source.IsPackage;
            target.CreatedOn = source.CreatedOn;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountApplyOnID = source.DiscountApplyOnID;
            target.Description = source.Description;
            target.DiscountID = source.DiscountID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountPeriod = source.DiscountPeriod;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountStatusID = source.DiscountStatusID;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.DisocuntPeriodUnitID = source.DisocuntPeriodUnitID;
            target.InvoiceName = source.InvoiceName;
            target.IsPercentage = source.IsPercentage;
            target.IsRecurring = source.IsRecurring;
            target.MaxRedemptions = source.MaxRedemptions;
            target.Name = source.Name;
            target.ValidTill = source.ValidTill;
            target.DiscountStatus = source.DiscountStatus;
            target.DiscountType = source.DiscountType;
            target.DiscountApplyIn = source.DiscountApplyIn;
            target.PeriodUnit = source.PeriodUnit;
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

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VProductDiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VProductDiscount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VProductDiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VProductDiscount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VProductDiscount> ToEntities(this IEnumerable<VProductDiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VProductDiscount source, VProductDiscountDTO target);

        static partial void OnEntityCreating(VProductDiscountDTO source, Bec.TargetFramework.Data.VProductDiscount target);

    }

}
