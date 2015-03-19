﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class VProductDiscountDTO
    {
        #region Constructors
  
        public VProductDiscountDTO() {
        }

        public VProductDiscountDTO(global::System.Nullable<System.Guid> parentID, global::System.Guid productID, int productVersionID, bool isPackage, global::System.DateTime createdOn, global::System.Nullable<decimal> discountAmount, global::System.Nullable<int> discountApplyOnID, string description, global::System.Guid discountID, global::System.Nullable<decimal> discountPercentage, global::System.Nullable<int> discountPeriod, global::System.Nullable<int> discountQuantity, int discountStatusID, int discountTypeID, int discountVersionNumber, global::System.Nullable<int> disocuntPeriodUnitID, string invoiceName, bool isPercentage, global::System.Nullable<bool> isRecurring, global::System.Nullable<int> maxRedemptions, string name, global::System.Nullable<System.DateTime> validTill, string discountStatus, string discountType, string discountApplyIn, string periodUnit, bool isSingleProductDiscount, bool isCheckoutDiscount, bool isSingleProductQuantityDiscount, int singleProductQuantityDiscountDivisor, bool isSingleProductQuantityDiscountPercentageBased, bool isSingleProductQuantityDiscountAdditionalQuantityBased, int singleProductQuantityDiscountAdditionalQuantity, bool isMultipleProductCombinationDiscount, bool isMultipleProductCombinationDiscountPercentageBased, bool isMultipleProductCombinationDiscountCheapestFreeBased) {

          this.ParentID = parentID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsPackage = isPackage;
          this.CreatedOn = createdOn;
          this.DiscountAmount = discountAmount;
          this.DiscountApplyOnID = discountApplyOnID;
          this.Description = description;
          this.DiscountID = discountID;
          this.DiscountPercentage = discountPercentage;
          this.DiscountPeriod = discountPeriod;
          this.DiscountQuantity = discountQuantity;
          this.DiscountStatusID = discountStatusID;
          this.DiscountTypeID = discountTypeID;
          this.DiscountVersionNumber = discountVersionNumber;
          this.DisocuntPeriodUnitID = disocuntPeriodUnitID;
          this.InvoiceName = invoiceName;
          this.IsPercentage = isPercentage;
          this.IsRecurring = isRecurring;
          this.MaxRedemptions = maxRedemptions;
          this.Name = name;
          this.ValidTill = validTill;
          this.DiscountStatus = discountStatus;
          this.DiscountType = discountType;
          this.DiscountApplyIn = discountApplyIn;
          this.PeriodUnit = periodUnit;
          this.IsSingleProductDiscount = isSingleProductDiscount;
          this.IsCheckoutDiscount = isCheckoutDiscount;
          this.IsSingleProductQuantityDiscount = isSingleProductQuantityDiscount;
          this.SingleProductQuantityDiscountDivisor = singleProductQuantityDiscountDivisor;
          this.IsSingleProductQuantityDiscountPercentageBased = isSingleProductQuantityDiscountPercentageBased;
          this.IsSingleProductQuantityDiscountAdditionalQuantityBased = isSingleProductQuantityDiscountAdditionalQuantityBased;
          this.SingleProductQuantityDiscountAdditionalQuantity = singleProductQuantityDiscountAdditionalQuantity;
          this.IsMultipleProductCombinationDiscount = isMultipleProductCombinationDiscount;
          this.IsMultipleProductCombinationDiscountPercentageBased = isMultipleProductCombinationDiscountPercentageBased;
          this.IsMultipleProductCombinationDiscountCheapestFreeBased = isMultipleProductCombinationDiscountCheapestFreeBased;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsPackage { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountAmount { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountApplyOnID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Guid DiscountID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountQuantity { get; set; }

        [DataMember]
        public int DiscountStatusID { get; set; }

        [DataMember]
        public int DiscountTypeID { get; set; }

        [DataMember]
        public int DiscountVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> DisocuntPeriodUnitID { get; set; }

        [DataMember]
        public string InvoiceName { get; set; }

        [DataMember]
        public bool IsPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsRecurring { get; set; }

        [DataMember]
        public global::System.Nullable<int> MaxRedemptions { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ValidTill { get; set; }

        [DataMember]
        public string DiscountStatus { get; set; }

        [DataMember]
        public string DiscountType { get; set; }

        [DataMember]
        public string DiscountApplyIn { get; set; }

        [DataMember]
        public string PeriodUnit { get; set; }

        [DataMember]
        public bool IsSingleProductDiscount { get; set; }

        [DataMember]
        public bool IsCheckoutDiscount { get; set; }

        [DataMember]
        public bool IsSingleProductQuantityDiscount { get; set; }

        [DataMember]
        public int SingleProductQuantityDiscountDivisor { get; set; }

        [DataMember]
        public bool IsSingleProductQuantityDiscountPercentageBased { get; set; }

        [DataMember]
        public bool IsSingleProductQuantityDiscountAdditionalQuantityBased { get; set; }

        [DataMember]
        public int SingleProductQuantityDiscountAdditionalQuantity { get; set; }

        [DataMember]
        public bool IsMultipleProductCombinationDiscount { get; set; }

        [DataMember]
        public bool IsMultipleProductCombinationDiscountPercentageBased { get; set; }

        [DataMember]
        public bool IsMultipleProductCombinationDiscountCheapestFreeBased { get; set; }

        #endregion
    }

}
