﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class DiscountTemplateDTO
    {
        #region Constructors
  
        public DiscountTemplateDTO() {
        }

        public DiscountTemplateDTO(global::System.Guid discountTemplateID, int discountTemplateVersionNumber, string name, string description, string invoiceName, int discountTypeID, global::System.Nullable<decimal> discountPercentage, global::System.Nullable<decimal> discountAmount, global::System.Nullable<int> discountQuantity, global::System.Nullable<int> discountDurationTypeID, global::System.Nullable<int> discountDurationMonth, global::System.Nullable<System.DateTime> validTill, global::System.Nullable<int> maxRedemptions, global::System.Nullable<int> discountApplyOnID, global::System.DateTime createdOn, bool isActive, bool isDeleted, global::System.Nullable<bool> isRecurring, bool isPercentage, global::System.Nullable<System.Guid> parentID, int discountStatusID, bool isSingleProductDiscount, bool isCheckoutDiscount, bool isSingleProductQuantityDiscount, int singleProductQuantityDiscountDivisor, bool isSingleProductQuantityDiscountPercentageBased, bool isSingleProductQuantityDiscountAdditionalQuantityBased, int singleProductQuantityDiscountAdditionalQuantity, bool isMultipleProductCombinationDiscount, bool isMultipleProductCombinationDiscountPercentageBased, bool isMultipleProductCombinationDiscountCheapestFreeBased, bool hasTiers, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, List<ProductDiscountTemplateDTO> productDiscountTemplates, List<DiscountRelatedProductTemplateDTO> discountRelatedProductTemplates, List<PlanDiscountTemplateDTO> planDiscountTemplates, OrganisationTypeDTO organisationType, UserTypeDTO userType, List<ComponentTierTemplateDTO> componentTierTemplates) {

          this.DiscountTemplateID = discountTemplateID;
          this.DiscountTemplateVersionNumber = discountTemplateVersionNumber;
          this.Name = name;
          this.Description = description;
          this.InvoiceName = invoiceName;
          this.DiscountTypeID = discountTypeID;
          this.DiscountPercentage = discountPercentage;
          this.DiscountAmount = discountAmount;
          this.DiscountQuantity = discountQuantity;
          this.DiscountDurationTypeID = discountDurationTypeID;
          this.DiscountDurationMonth = discountDurationMonth;
          this.ValidTill = validTill;
          this.MaxRedemptions = maxRedemptions;
          this.DiscountApplyOnID = discountApplyOnID;
          this.CreatedOn = createdOn;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsRecurring = isRecurring;
          this.IsPercentage = isPercentage;
          this.ParentID = parentID;
          this.DiscountStatusID = discountStatusID;
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
          this.HasTiers = hasTiers;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.ProductDiscountTemplates = productDiscountTemplates;
          this.DiscountRelatedProductTemplates = discountRelatedProductTemplates;
          this.PlanDiscountTemplates = planDiscountTemplates;
          this.OrganisationType = organisationType;
          this.UserType = userType;
          this.ComponentTierTemplates = componentTierTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DiscountTemplateID { get; set; }

        [DataMember]
        public int DiscountTemplateVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string InvoiceName { get; set; }

        [DataMember]
        public int DiscountTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DiscountAmount { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountQuantity { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountDurationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountDurationMonth { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ValidTill { get; set; }

        [DataMember]
        public global::System.Nullable<int> MaxRedemptions { get; set; }

        [DataMember]
        public global::System.Nullable<int> DiscountApplyOnID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsRecurring { get; set; }

        [DataMember]
        public bool IsPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public int DiscountStatusID { get; set; }

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

        [DataMember]
        public bool HasTiers { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductDiscountTemplateDTO> ProductDiscountTemplates { get; set; }

        [DataMember]
        public List<DiscountRelatedProductTemplateDTO> DiscountRelatedProductTemplates { get; set; }

        [DataMember]
        public List<PlanDiscountTemplateDTO> PlanDiscountTemplates { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public List<ComponentTierTemplateDTO> ComponentTierTemplates { get; set; }

        #endregion
    }

}
