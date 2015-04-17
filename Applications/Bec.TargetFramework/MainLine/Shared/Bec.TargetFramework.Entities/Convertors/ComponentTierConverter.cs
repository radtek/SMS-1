﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ComponentTierConverter
    {

        public static ComponentTierDTO ToDto(this Bec.TargetFramework.Data.ComponentTier source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ComponentTierDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ComponentTier source, int level)
        {
            if (source == null)
              return null;

            var target = new ComponentTierDTO();

            // Properties
            target.ComponentTierID = source.ComponentTierID;
            target.TotalValueLowerBound = source.TotalValueLowerBound;
            target.TotalValueUpperBound = source.TotalValueUpperBound;
            target.QuantityCountLowerBound = source.QuantityCountLowerBound;
            target.QuantityCountUpperBound = source.QuantityCountUpperBound;
            target.IsPercentageBased = source.IsPercentageBased;
            target.TierPrice = source.TierPrice;
            target.TierPercentage = source.TierPercentage;
            target.ApplyToTotal = source.ApplyToTotal;
            target.ApplyOnPaymentMethodTypeID = source.ApplyOnPaymentMethodTypeID;
            target.ApplyPerTransaction = source.ApplyPerTransaction;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Order = source.Order;
            target.TierOrder = source.TierOrder;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.HasNoUpperBound = source.HasNoUpperBound;
            target.ParentVersionNumber = source.ParentVersionNumber;
            target.ApplyOnPaymentCardTypeID = source.ApplyOnPaymentCardTypeID;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.Products = source.Products.ToDtosWithRelated(level - 1);
              target.Discounts = source.Discounts.ToDtosWithRelated(level - 1);
              target.PlanTransactions = source.PlanTransactions.ToDtosWithRelated(level - 1);
              target.Deductions = source.Deductions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ComponentTier ToEntity(this ComponentTierDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ComponentTier();

            // Properties
            target.ComponentTierID = source.ComponentTierID;
            target.TotalValueLowerBound = source.TotalValueLowerBound;
            target.TotalValueUpperBound = source.TotalValueUpperBound;
            target.QuantityCountLowerBound = source.QuantityCountLowerBound;
            target.QuantityCountUpperBound = source.QuantityCountUpperBound;
            target.IsPercentageBased = source.IsPercentageBased;
            target.TierPrice = source.TierPrice;
            target.TierPercentage = source.TierPercentage;
            target.ApplyToTotal = source.ApplyToTotal;
            target.ApplyOnPaymentMethodTypeID = source.ApplyOnPaymentMethodTypeID;
            target.ApplyPerTransaction = source.ApplyPerTransaction;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Order = source.Order;
            target.TierOrder = source.TierOrder;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.HasNoUpperBound = source.HasNoUpperBound;
            target.ParentVersionNumber = source.ParentVersionNumber;
            target.ApplyOnPaymentCardTypeID = source.ApplyOnPaymentCardTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ComponentTierDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ComponentTier> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ComponentTierDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ComponentTier> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ComponentTier> ToEntities(this IEnumerable<ComponentTierDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ComponentTier source, ComponentTierDTO target);

        static partial void OnEntityCreating(ComponentTierDTO source, Bec.TargetFramework.Data.ComponentTier target);

    }

}
