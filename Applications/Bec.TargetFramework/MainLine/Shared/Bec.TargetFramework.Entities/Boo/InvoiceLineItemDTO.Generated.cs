﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class InvoiceLineItemDTO
    {
        #region Constructors
  
        public InvoiceLineItemDTO() {
        }

        public InvoiceLineItemDTO(global::System.Guid invoiceLineItemID, global::System.Nullable<System.Guid> invoiceID, global::System.DateTime dateFrom, global::System.DateTime dateTo, decimal singleProductPrice, global::System.Nullable<decimal> taxTotal, decimal price, decimal quantity, string description, int invoiceLineItemTypeID, global::System.Nullable<System.Guid> parentID, decimal priceInclTax, string countryCode, bool isCredit, global::System.Nullable<decimal> singleProductPriceInclTaxAndDeduct, decimal singleProductPriceExclTaxAndDeduct, bool isDebit, global::System.Nullable<System.Guid> productID, global::System.Nullable<decimal> taxTotalPercentage, global::System.Nullable<decimal> taxTotalValue, global::System.Nullable<decimal> discountTotalValue, global::System.Nullable<decimal> discountTotalPercentage, global::System.Nullable<decimal> deductionTotalValue, global::System.Nullable<decimal> deductionTotalPercentage, global::System.Nullable<decimal> deductionTotal, bool isActive, bool isDeleted, bool isClosed, global::System.Nullable<System.Guid> planSubscriptionPeriodID, bool isFrozenPendingPayment, global::System.Nullable<int> productVersionID, decimal priceExclTax, global::System.Nullable<decimal> discountTotal, bool isDepositProduct, global::System.Nullable<System.Guid> accountID, List<ShoppingCartItemDTO> shoppingCartItems, CountryCodeDTO countryCode1, InvoiceDTO invoice, ProductDTO product, List<TransactionOrderItemDTO> transactionOrderItems, PlanSubscriptionPeriodDTO planSubscriptionPeriod, List<ProductPurchaseDTO> productPurchases, List<OrganisationProductPurchaseDTO> organisationProductPurchases, AccountDTO account) {

          this.InvoiceLineItemID = invoiceLineItemID;
          this.InvoiceID = invoiceID;
          this.DateFrom = dateFrom;
          this.DateTo = dateTo;
          this.SingleProductPrice = singleProductPrice;
          this.TaxTotal = taxTotal;
          this.Price = price;
          this.Quantity = quantity;
          this.Description = description;
          this.InvoiceLineItemTypeID = invoiceLineItemTypeID;
          this.ParentID = parentID;
          this.PriceInclTax = priceInclTax;
          this.CountryCode = countryCode;
          this.IsCredit = isCredit;
          this.SingleProductPriceInclTaxAndDeduct = singleProductPriceInclTaxAndDeduct;
          this.SingleProductPriceExclTaxAndDeduct = singleProductPriceExclTaxAndDeduct;
          this.IsDebit = isDebit;
          this.ProductID = productID;
          this.TaxTotalPercentage = taxTotalPercentage;
          this.TaxTotalValue = taxTotalValue;
          this.DiscountTotalValue = discountTotalValue;
          this.DiscountTotalPercentage = discountTotalPercentage;
          this.DeductionTotalValue = deductionTotalValue;
          this.DeductionTotalPercentage = deductionTotalPercentage;
          this.DeductionTotal = deductionTotal;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsClosed = isClosed;
          this.PlanSubscriptionPeriodID = planSubscriptionPeriodID;
          this.IsFrozenPendingPayment = isFrozenPendingPayment;
          this.ProductVersionID = productVersionID;
          this.PriceExclTax = priceExclTax;
          this.DiscountTotal = discountTotal;
          this.IsDepositProduct = isDepositProduct;
          this.AccountID = accountID;
          this.ShoppingCartItems = shoppingCartItems;
          this.CountryCode1 = countryCode1;
          this.Invoice = invoice;
          this.Product = product;
          this.TransactionOrderItems = transactionOrderItems;
          this.PlanSubscriptionPeriod = planSubscriptionPeriod;
          this.ProductPurchases = productPurchases;
          this.OrganisationProductPurchases = organisationProductPurchases;
          this.Account = account;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InvoiceLineItemID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InvoiceID { get; set; }

        [DataMember]
        public global::System.DateTime DateFrom { get; set; }

        [DataMember]
        public global::System.DateTime DateTo { get; set; }

        [DataMember]
        public decimal SingleProductPrice { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotal { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int InvoiceLineItemTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public decimal PriceInclTax { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public bool IsCredit { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> SingleProductPriceInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal SingleProductPriceExclTaxAndDeduct { get; set; }

        [DataMember]
        public bool IsDebit { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotal { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PlanSubscriptionPeriodID { get; set; }

        [DataMember]
        public bool IsFrozenPendingPayment { get; set; }

        [DataMember]
        public global::System.Nullable<int> ProductVersionID { get; set; }

        [DataMember]
        public decimal PriceExclTax { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotal { get; set; }

        [DataMember]
        public bool IsDepositProduct { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> AccountID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ShoppingCartItemDTO> ShoppingCartItems { get; set; }

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public InvoiceDTO Invoice { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public List<TransactionOrderItemDTO> TransactionOrderItems { get; set; }

        [DataMember]
        public PlanSubscriptionPeriodDTO PlanSubscriptionPeriod { get; set; }

        [DataMember]
        public List<ProductPurchaseDTO> ProductPurchases { get; set; }

        [DataMember]
        public List<OrganisationProductPurchaseDTO> OrganisationProductPurchases { get; set; }

        [DataMember]
        public AccountDTO Account { get; set; }

        #endregion
    }

}
