﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ComponentTierTemplateConverter
    {

        public static ComponentTierTemplateDTO ToDto(this Bec.TargetFramework.Data.ComponentTierTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ComponentTierTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ComponentTierTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ComponentTierTemplateDTO();

            // Properties
            target.ComponentTierTemplateID = source.ComponentTierTemplateID;
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
              target.PlanTransactionTemplates = source.PlanTransactionTemplates.ToDtosWithRelated(level - 1);
              target.DiscountTemplates = source.DiscountTemplates.ToDtosWithRelated(level - 1);
              target.ProductTemplates = source.ProductTemplates.ToDtosWithRelated(level - 1);
              target.DeductionTemplates = source.DeductionTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ComponentTierTemplate ToEntity(this ComponentTierTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ComponentTierTemplate();

            // Properties
            target.ComponentTierTemplateID = source.ComponentTierTemplateID;
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

        public static List<ComponentTierTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ComponentTierTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ComponentTierTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ComponentTierTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ComponentTierTemplate> ToEntities(this IEnumerable<ComponentTierTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ComponentTierTemplate source, ComponentTierTemplateDTO target);

        static partial void OnEntityCreating(ComponentTierTemplateDTO source, Bec.TargetFramework.Data.ComponentTierTemplate target);

    }

}