﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class ProductDetailDTO
    {
        #region Constructors
  
        public ProductDetailDTO() {
        }

        public ProductDetailDTO(global::System.Guid productDetailID, string name, string description, global::System.Guid productID, bool isActive, bool isDeleted, string shortDescription, string longDescription, string metaKeywords, string metaDescription, string metaTitle, bool requireOtherProducts, bool automaticallyAddRequiredProducts, bool hasUserAgreement, string userAgreementText, bool isRecurring, int recurringCycleLength, int recurringCyclePeriodID, int recurringTotalCycle, global::System.Nullable<bool> isTaxExempt, global::System.Nullable<int> taxCategoryID, int orderMinimumQuantity, int orderMaximumQuantity, bool callForPrice, decimal price, decimal productCost, bool customerEntersPrice, bool hasTierPrices, bool hasDiscountsApplied, decimal minimumCustomerEnteredPrice, decimal maximumCustomerEnteredPrice, int displayOrder, global::System.Nullable<System.DateTime> availableStartDate, global::System.Nullable<System.DateTime> availableEndDate, int productTypeID, global::System.Nullable<int> productSubTypeID, global::System.Nullable<int> productCategoryID, global::System.Nullable<int> productSubCategoryID, int productVersionID, string currencyCode, global::System.Nullable<decimal> currencyRate, global::System.Nullable<System.DateTime> currencyRateDate, global::System.Nullable<decimal> currencyRateToGBP, global::System.Nullable<decimal> currencyRateToUSD, string invoiceName, bool isDepositProduct, ProductDTO product) {

          this.ProductDetailID = productDetailID;
          this.Name = name;
          this.Description = description;
          this.ProductID = productID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ShortDescription = shortDescription;
          this.LongDescription = longDescription;
          this.MetaKeywords = metaKeywords;
          this.MetaDescription = metaDescription;
          this.MetaTitle = metaTitle;
          this.RequireOtherProducts = requireOtherProducts;
          this.AutomaticallyAddRequiredProducts = automaticallyAddRequiredProducts;
          this.HasUserAgreement = hasUserAgreement;
          this.UserAgreementText = userAgreementText;
          this.IsRecurring = isRecurring;
          this.RecurringCycleLength = recurringCycleLength;
          this.RecurringCyclePeriodID = recurringCyclePeriodID;
          this.RecurringTotalCycle = recurringTotalCycle;
          this.IsTaxExempt = isTaxExempt;
          this.TaxCategoryID = taxCategoryID;
          this.OrderMinimumQuantity = orderMinimumQuantity;
          this.OrderMaximumQuantity = orderMaximumQuantity;
          this.CallForPrice = callForPrice;
          this.Price = price;
          this.ProductCost = productCost;
          this.CustomerEntersPrice = customerEntersPrice;
          this.HasTierPrices = hasTierPrices;
          this.HasDiscountsApplied = hasDiscountsApplied;
          this.MinimumCustomerEnteredPrice = minimumCustomerEnteredPrice;
          this.MaximumCustomerEnteredPrice = maximumCustomerEnteredPrice;
          this.DisplayOrder = displayOrder;
          this.AvailableStartDate = availableStartDate;
          this.AvailableEndDate = availableEndDate;
          this.ProductTypeID = productTypeID;
          this.ProductSubTypeID = productSubTypeID;
          this.ProductCategoryID = productCategoryID;
          this.ProductSubCategoryID = productSubCategoryID;
          this.ProductVersionID = productVersionID;
          this.CurrencyCode = currencyCode;
          this.CurrencyRate = currencyRate;
          this.CurrencyRateDate = currencyRateDate;
          this.CurrencyRateToGBP = currencyRateToGBP;
          this.CurrencyRateToUSD = currencyRateToUSD;
          this.InvoiceName = invoiceName;
          this.IsDepositProduct = isDepositProduct;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductDetailID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string LongDescription { get; set; }

        [DataMember]
        public string MetaKeywords { get; set; }

        [DataMember]
        public string MetaDescription { get; set; }

        [DataMember]
        public string MetaTitle { get; set; }

        [DataMember]
        public bool RequireOtherProducts { get; set; }

        [DataMember]
        public bool AutomaticallyAddRequiredProducts { get; set; }

        [DataMember]
        public bool HasUserAgreement { get; set; }

        [DataMember]
        public string UserAgreementText { get; set; }

        [DataMember]
        public bool IsRecurring { get; set; }

        [DataMember]
        public int RecurringCycleLength { get; set; }

        [DataMember]
        public int RecurringCyclePeriodID { get; set; }

        [DataMember]
        public int RecurringTotalCycle { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsTaxExempt { get; set; }

        [DataMember]
        public global::System.Nullable<int> TaxCategoryID { get; set; }

        [DataMember]
        public int OrderMinimumQuantity { get; set; }

        [DataMember]
        public int OrderMaximumQuantity { get; set; }

        [DataMember]
        public bool CallForPrice { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal ProductCost { get; set; }

        [DataMember]
        public bool CustomerEntersPrice { get; set; }

        [DataMember]
        public bool HasTierPrices { get; set; }

        [DataMember]
        public bool HasDiscountsApplied { get; set; }

        [DataMember]
        public decimal MinimumCustomerEnteredPrice { get; set; }

        [DataMember]
        public decimal MaximumCustomerEnteredPrice { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AvailableStartDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AvailableEndDate { get; set; }

        [DataMember]
        public int ProductTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ProductSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ProductCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ProductSubCategoryID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CurrencyRateDate { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToGBP { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CurrencyRateToUSD { get; set; }

        [DataMember]
        public string InvoiceName { get; set; }

        [DataMember]
        public bool IsDepositProduct { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
