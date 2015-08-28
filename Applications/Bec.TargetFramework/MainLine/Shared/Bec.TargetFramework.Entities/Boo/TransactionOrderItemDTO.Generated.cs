﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class TransactionOrderItemDTO
    {
        #region Constructors
  
        public TransactionOrderItemDTO() {
        }

        public TransactionOrderItemDTO(global::System.Guid orderItemID, int quantity, decimal price, decimal priceInclTaxAndDeduct, decimal priceExclTaxAndDeduct, global::System.Nullable<decimal> taxTotal, global::System.Nullable<decimal> taxTotalPercentage, global::System.Nullable<decimal> taxTotalValue, global::System.Nullable<decimal> deductionTotal, global::System.Nullable<decimal> deductionTotalPercentage, global::System.Nullable<decimal> deductionTotalValue, global::System.Nullable<decimal> discountTotal, global::System.Nullable<decimal> discountTotalPercentage, global::System.Nullable<decimal> discountTotalValue, global::System.Guid orderID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> invoiceLineItemID, TransactionOrderDTO transactionOrder, InvoiceLineItemDTO invoiceLineItem) {

          this.OrderItemID = orderItemID;
          this.Quantity = quantity;
          this.Price = price;
          this.PriceInclTaxAndDeduct = priceInclTaxAndDeduct;
          this.PriceExclTaxAndDeduct = priceExclTaxAndDeduct;
          this.TaxTotal = taxTotal;
          this.TaxTotalPercentage = taxTotalPercentage;
          this.TaxTotalValue = taxTotalValue;
          this.DeductionTotal = deductionTotal;
          this.DeductionTotalPercentage = deductionTotalPercentage;
          this.DeductionTotalValue = deductionTotalValue;
          this.DiscountTotal = discountTotal;
          this.DiscountTotalPercentage = discountTotalPercentage;
          this.DiscountTotalValue = discountTotalValue;
          this.OrderID = orderID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InvoiceLineItemID = invoiceLineItemID;
          this.TransactionOrder = transactionOrder;
          this.InvoiceLineItem = invoiceLineItem;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrderItemID { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public decimal PriceInclTaxAndDeduct { get; set; }

        [DataMember]
        public decimal PriceExclTaxAndDeduct { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotal { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TaxTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotal { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionTotalValue { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotal { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountTotalValue { get; set; }

        [DataMember]
        public global::System.Guid OrderID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InvoiceLineItemID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public TransactionOrderDTO TransactionOrder { get; set; }

        [DataMember]
        public InvoiceLineItemDTO InvoiceLineItem { get; set; }

        #endregion
    }

}
