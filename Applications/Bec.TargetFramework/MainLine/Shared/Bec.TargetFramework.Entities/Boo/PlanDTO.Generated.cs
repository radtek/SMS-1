﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class PlanDTO
    {
        #region Constructors
  
        public PlanDTO() {
        }

        public PlanDTO(global::System.Guid planID, int planVersionNumber, string name, string description, string invoiceName, decimal price, int period, int trialPeriod, global::System.Nullable<int> periodUnitID, global::System.Nullable<int> trialPeriodUnitID, int freeQuantity, global::System.Nullable<decimal> setupCost, global::System.Nullable<decimal> downgradePenalty, global::System.DateTime createdOn, string createdBy, bool isActive, bool isDeleted, string countryCode, string currencyCode, global::System.Nullable<int> cancellationPeriod, global::System.Nullable<int> cancellationPeriodUnitID, bool isFree, bool hasInfinitePeriods, global::System.Nullable<System.Guid> parentID, global::System.Guid planTemplateID, int planTemplateVersionNumber, int planStatusID, bool isTransactionBased, global::System.Nullable<int> coolOffPeriod, global::System.Nullable<int> coolOffPeriodUnitID, global::System.Nullable<decimal> renewalPrice, global::System.Nullable<decimal> renewalPercentage, global::System.Nullable<bool> renewalIsPercentageOfOriginalPrice, global::System.Nullable<bool> hasForwardCycleFee, global::System.Nullable<decimal> forwardCycleFee, global::System.Nullable<decimal> forwardCycleFreeIsSameAsPrice, global::System.Nullable<int> renewalOfferPeriod, global::System.Nullable<int> renewalOfferPeriodUnitID, global::System.Nullable<int> forwardCycleFeePeriod, global::System.Nullable<int> forwardCycleFeePeriodUnitID, global::System.Nullable<bool> hasRenewalOffer, global::System.Nullable<decimal> priceDailyProRata, global::System.Nullable<bool> isAutoRenew, global::System.Nullable<int> autoRenewDecisionPeriod, global::System.Nullable<int> autoRenewDecisionUnitID, global::System.Nullable<int> autoRenewPeriod, global::System.Nullable<int> autoRenewPeriodUnitID, int planGroupID, global::System.Nullable<int> planTypeID, int planCategoryID, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, CountryCodeDTO countryCode1, PlanTemplateDTO planTemplate, List<PlanSubscriptionDTO> planSubscriptions, List<PlanProductDTO> planProducts, List<PlanBillingDTO> planBillings, List<PlanTransactionDTO> planTransactions, List<PlanDiscountDTO> planDiscounts, List<PlanGlobalPaymentMethodDTO> planGlobalPaymentMethods, List<ProductPlanDTO> productPlans, PlanGroupDTO planGroup) {

          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.Name = name;
          this.Description = description;
          this.InvoiceName = invoiceName;
          this.Price = price;
          this.Period = period;
          this.TrialPeriod = trialPeriod;
          this.PeriodUnitID = periodUnitID;
          this.TrialPeriodUnitID = trialPeriodUnitID;
          this.FreeQuantity = freeQuantity;
          this.SetupCost = setupCost;
          this.DowngradePenalty = downgradePenalty;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CountryCode = countryCode;
          this.CurrencyCode = currencyCode;
          this.CancellationPeriod = cancellationPeriod;
          this.CancellationPeriodUnitID = cancellationPeriodUnitID;
          this.IsFree = isFree;
          this.HasInfinitePeriods = hasInfinitePeriods;
          this.ParentID = parentID;
          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.PlanStatusID = planStatusID;
          this.IsTransactionBased = isTransactionBased;
          this.CoolOffPeriod = coolOffPeriod;
          this.CoolOffPeriodUnitID = coolOffPeriodUnitID;
          this.RenewalPrice = renewalPrice;
          this.RenewalPercentage = renewalPercentage;
          this.RenewalIsPercentageOfOriginalPrice = renewalIsPercentageOfOriginalPrice;
          this.HasForwardCycleFee = hasForwardCycleFee;
          this.ForwardCycleFee = forwardCycleFee;
          this.ForwardCycleFreeIsSameAsPrice = forwardCycleFreeIsSameAsPrice;
          this.RenewalOfferPeriod = renewalOfferPeriod;
          this.RenewalOfferPeriodUnitID = renewalOfferPeriodUnitID;
          this.ForwardCycleFeePeriod = forwardCycleFeePeriod;
          this.ForwardCycleFeePeriodUnitID = forwardCycleFeePeriodUnitID;
          this.HasRenewalOffer = hasRenewalOffer;
          this.PriceDailyProRata = priceDailyProRata;
          this.IsAutoRenew = isAutoRenew;
          this.AutoRenewDecisionPeriod = autoRenewDecisionPeriod;
          this.AutoRenewDecisionUnitID = autoRenewDecisionUnitID;
          this.AutoRenewPeriod = autoRenewPeriod;
          this.AutoRenewPeriodUnitID = autoRenewPeriodUnitID;
          this.PlanGroupID = planGroupID;
          this.PlanTypeID = planTypeID;
          this.PlanCategoryID = planCategoryID;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.CountryCode1 = countryCode1;
          this.PlanTemplate = planTemplate;
          this.PlanSubscriptions = planSubscriptions;
          this.PlanProducts = planProducts;
          this.PlanBillings = planBillings;
          this.PlanTransactions = planTransactions;
          this.PlanDiscounts = planDiscounts;
          this.PlanGlobalPaymentMethods = planGlobalPaymentMethods;
          this.ProductPlans = productPlans;
          this.PlanGroup = planGroup;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string InvoiceName { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public int TrialPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> PeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<int> TrialPeriodUnitID { get; set; }

        [DataMember]
        public int FreeQuantity { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> SetupCost { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DowngradePenalty { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string CurrencyCode { get; set; }

        [DataMember]
        public global::System.Nullable<int> CancellationPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> CancellationPeriodUnitID { get; set; }

        [DataMember]
        public bool IsFree { get; set; }

        [DataMember]
        public bool HasInfinitePeriods { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public int PlanStatusID { get; set; }

        [DataMember]
        public bool IsTransactionBased { get; set; }

        [DataMember]
        public global::System.Nullable<int> CoolOffPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> CoolOffPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> RenewalPrice { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> RenewalPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<bool> RenewalIsPercentageOfOriginalPrice { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasForwardCycleFee { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> ForwardCycleFee { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> ForwardCycleFreeIsSameAsPrice { get; set; }

        [DataMember]
        public global::System.Nullable<int> RenewalOfferPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> RenewalOfferPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ForwardCycleFeePeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> ForwardCycleFeePeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasRenewalOffer { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> PriceDailyProRata { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsAutoRenew { get; set; }

        [DataMember]
        public global::System.Nullable<int> AutoRenewDecisionPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> AutoRenewDecisionUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AutoRenewPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> AutoRenewPeriodUnitID { get; set; }

        [DataMember]
        public int PlanGroupID { get; set; }

        [DataMember]
        public global::System.Nullable<int> PlanTypeID { get; set; }

        [DataMember]
        public int PlanCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        [DataMember]
        public List<PlanSubscriptionDTO> PlanSubscriptions { get; set; }

        [DataMember]
        public List<PlanProductDTO> PlanProducts { get; set; }

        [DataMember]
        public List<PlanBillingDTO> PlanBillings { get; set; }

        [DataMember]
        public List<PlanTransactionDTO> PlanTransactions { get; set; }

        [DataMember]
        public List<PlanDiscountDTO> PlanDiscounts { get; set; }

        [DataMember]
        public List<PlanGlobalPaymentMethodDTO> PlanGlobalPaymentMethods { get; set; }

        [DataMember]
        public List<ProductPlanDTO> ProductPlans { get; set; }

        [DataMember]
        public PlanGroupDTO PlanGroup { get; set; }

        #endregion
    }

}
