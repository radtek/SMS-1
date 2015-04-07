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

    public static partial class VOrganisationCheckoutDiscountConverter
    {

        public static VOrganisationCheckoutDiscountDTO ToDto(this Bec.TargetFramework.Data.VOrganisationCheckoutDiscount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationCheckoutDiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationCheckoutDiscount source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationCheckoutDiscountDTO();

            // Properties
            target.ParentID = source.ParentID;
            target.OrganisationID = source.OrganisationID;
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

        public static Bec.TargetFramework.Data.VOrganisationCheckoutDiscount ToEntity(this VOrganisationCheckoutDiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationCheckoutDiscount();

            // Properties
            target.ParentID = source.ParentID;
            target.OrganisationID = source.OrganisationID;
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

        public static List<VOrganisationCheckoutDiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationCheckoutDiscount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationCheckoutDiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationCheckoutDiscount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationCheckoutDiscount> ToEntities(this IEnumerable<VOrganisationCheckoutDiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationCheckoutDiscount source, VOrganisationCheckoutDiscountDTO target);

        static partial void OnEntityCreating(VOrganisationCheckoutDiscountDTO source, Bec.TargetFramework.Data.VOrganisationCheckoutDiscount target);

    }

}
