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

    public static partial class ProductDetailConverter
    {

        public static ProductDetailDTO ToDto(this Bec.TargetFramework.Data.ProductDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductDetailDTO();

            // Properties
            target.ProductDetailID = source.ProductDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ProductID = source.ProductID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ShortDescription = source.ShortDescription;
            target.LongDescription = source.LongDescription;
            target.MetaKeywords = source.MetaKeywords;
            target.MetaDescription = source.MetaDescription;
            target.MetaTitle = source.MetaTitle;
            target.RequireOtherProducts = source.RequireOtherProducts;
            target.AutomaticallyAddRequiredProducts = source.AutomaticallyAddRequiredProducts;
            target.HasUserAgreement = source.HasUserAgreement;
            target.UserAgreementText = source.UserAgreementText;
            target.IsRecurring = source.IsRecurring;
            target.RecurringCycleLength = source.RecurringCycleLength;
            target.RecurringCyclePeriodID = source.RecurringCyclePeriodID;
            target.RecurringTotalCycle = source.RecurringTotalCycle;
            target.IsTaxExempt = source.IsTaxExempt;
            target.TaxCategoryID = source.TaxCategoryID;
            target.OrderMinimumQuantity = source.OrderMinimumQuantity;
            target.OrderMaximumQuantity = source.OrderMaximumQuantity;
            target.CallForPrice = source.CallForPrice;
            target.Price = source.Price;
            target.ProductCost = source.ProductCost;
            target.CustomerEntersPrice = source.CustomerEntersPrice;
            target.HasTierPrices = source.HasTierPrices;
            target.HasDiscountsApplied = source.HasDiscountsApplied;
            target.MinimumCustomerEnteredPrice = source.MinimumCustomerEnteredPrice;
            target.MaximumCustomerEnteredPrice = source.MaximumCustomerEnteredPrice;
            target.DisplayOrder = source.DisplayOrder;
            target.AvailableStartDate = source.AvailableStartDate;
            target.AvailableEndDate = source.AvailableEndDate;
            target.ProductTypeID = source.ProductTypeID;
            target.ProductSubTypeID = source.ProductSubTypeID;
            target.ProductCategoryID = source.ProductCategoryID;
            target.ProductSubCategoryID = source.ProductSubCategoryID;
            target.ProductVersionID = source.ProductVersionID;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.InvoiceName = source.InvoiceName;
            target.IsDepositProduct = source.IsDepositProduct;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductDetail ToEntity(this ProductDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductDetail();

            // Properties
            target.ProductDetailID = source.ProductDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ProductID = source.ProductID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ShortDescription = source.ShortDescription;
            target.LongDescription = source.LongDescription;
            target.MetaKeywords = source.MetaKeywords;
            target.MetaDescription = source.MetaDescription;
            target.MetaTitle = source.MetaTitle;
            target.RequireOtherProducts = source.RequireOtherProducts;
            target.AutomaticallyAddRequiredProducts = source.AutomaticallyAddRequiredProducts;
            target.HasUserAgreement = source.HasUserAgreement;
            target.UserAgreementText = source.UserAgreementText;
            target.IsRecurring = source.IsRecurring;
            target.RecurringCycleLength = source.RecurringCycleLength;
            target.RecurringCyclePeriodID = source.RecurringCyclePeriodID;
            target.RecurringTotalCycle = source.RecurringTotalCycle;
            target.IsTaxExempt = source.IsTaxExempt;
            target.TaxCategoryID = source.TaxCategoryID;
            target.OrderMinimumQuantity = source.OrderMinimumQuantity;
            target.OrderMaximumQuantity = source.OrderMaximumQuantity;
            target.CallForPrice = source.CallForPrice;
            target.Price = source.Price;
            target.ProductCost = source.ProductCost;
            target.CustomerEntersPrice = source.CustomerEntersPrice;
            target.HasTierPrices = source.HasTierPrices;
            target.HasDiscountsApplied = source.HasDiscountsApplied;
            target.MinimumCustomerEnteredPrice = source.MinimumCustomerEnteredPrice;
            target.MaximumCustomerEnteredPrice = source.MaximumCustomerEnteredPrice;
            target.DisplayOrder = source.DisplayOrder;
            target.AvailableStartDate = source.AvailableStartDate;
            target.AvailableEndDate = source.AvailableEndDate;
            target.ProductTypeID = source.ProductTypeID;
            target.ProductSubTypeID = source.ProductSubTypeID;
            target.ProductCategoryID = source.ProductCategoryID;
            target.ProductSubCategoryID = source.ProductSubCategoryID;
            target.ProductVersionID = source.ProductVersionID;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.InvoiceName = source.InvoiceName;
            target.IsDepositProduct = source.IsDepositProduct;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductDetail> ToEntities(this IEnumerable<ProductDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductDetail source, ProductDetailDTO target);

        static partial void OnEntityCreating(ProductDetailDTO source, Bec.TargetFramework.Data.ProductDetail target);

    }

}
