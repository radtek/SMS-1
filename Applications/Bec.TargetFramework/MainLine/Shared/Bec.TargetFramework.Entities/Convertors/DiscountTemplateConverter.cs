﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DiscountTemplateConverter
    {

        public static DiscountTemplateDTO ToDto(this Bec.TargetFramework.Data.DiscountTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DiscountTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DiscountTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DiscountTemplateDTO();

            // Properties
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountDurationTypeID = source.DiscountDurationTypeID;
            target.DiscountDurationMonth = source.DiscountDurationMonth;
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

            // Navigation Properties
            if (level > 0) {
              target.ProductDiscountTemplates = source.ProductDiscountTemplates.ToDtosWithRelated(level - 1);
              target.DiscountRelatedProductTemplates = source.DiscountRelatedProductTemplates.ToDtosWithRelated(level - 1);
              target.PlanDiscountTemplates = source.PlanDiscountTemplates.ToDtosWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.ComponentTierTemplates = source.ComponentTierTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DiscountTemplate ToEntity(this DiscountTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DiscountTemplate();

            // Properties
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.DiscountTypeID = source.DiscountTypeID;
            target.DiscountPercentage = source.DiscountPercentage;
            target.DiscountAmount = source.DiscountAmount;
            target.DiscountQuantity = source.DiscountQuantity;
            target.DiscountDurationTypeID = source.DiscountDurationTypeID;
            target.DiscountDurationMonth = source.DiscountDurationMonth;
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

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DiscountTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DiscountTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DiscountTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DiscountTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DiscountTemplate> ToEntities(this IEnumerable<DiscountTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DiscountTemplate source, DiscountTemplateDTO target);

        static partial void OnEntityCreating(DiscountTemplateDTO source, Bec.TargetFramework.Data.DiscountTemplate target);

    }

}
