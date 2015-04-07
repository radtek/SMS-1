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
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class ComponentTierTemplateDTO
    {
        #region Constructors
  
        public ComponentTierTemplateDTO() {
        }

        public ComponentTierTemplateDTO(global::System.Guid componentTierTemplateID, global::System.Nullable<decimal> totalValueLowerBound, global::System.Nullable<decimal> totalValueUpperBound, global::System.Nullable<int> quantityCountLowerBound, global::System.Nullable<int> quantityCountUpperBound, bool isPercentageBased, global::System.Nullable<decimal> tierPrice, global::System.Nullable<decimal> tierPercentage, bool applyToTotal, global::System.Nullable<int> applyOnPaymentMethodTypeID, bool applyPerTransaction, string name, string description, int order, global::System.Nullable<int> tierOrder, global::System.Nullable<System.Guid> parentID, bool isActive, bool isDeleted, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, bool hasNoUpperBound, global::System.Nullable<int> parentVersionNumber, global::System.Nullable<int> applyOnPaymentCardTypeID, OrganisationTypeDTO organisationType, UserTypeDTO userType, List<PlanTransactionTemplateDTO> planTransactionTemplates, List<DiscountTemplateDTO> discountTemplates, List<ProductTemplateDTO> productTemplates, List<DeductionTemplateDTO> deductionTemplates) {

          this.ComponentTierTemplateID = componentTierTemplateID;
          this.TotalValueLowerBound = totalValueLowerBound;
          this.TotalValueUpperBound = totalValueUpperBound;
          this.QuantityCountLowerBound = quantityCountLowerBound;
          this.QuantityCountUpperBound = quantityCountUpperBound;
          this.IsPercentageBased = isPercentageBased;
          this.TierPrice = tierPrice;
          this.TierPercentage = tierPercentage;
          this.ApplyToTotal = applyToTotal;
          this.ApplyOnPaymentMethodTypeID = applyOnPaymentMethodTypeID;
          this.ApplyPerTransaction = applyPerTransaction;
          this.Name = name;
          this.Description = description;
          this.Order = order;
          this.TierOrder = tierOrder;
          this.ParentID = parentID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.HasNoUpperBound = hasNoUpperBound;
          this.ParentVersionNumber = parentVersionNumber;
          this.ApplyOnPaymentCardTypeID = applyOnPaymentCardTypeID;
          this.OrganisationType = organisationType;
          this.UserType = userType;
          this.PlanTransactionTemplates = planTransactionTemplates;
          this.DiscountTemplates = discountTemplates;
          this.ProductTemplates = productTemplates;
          this.DeductionTemplates = deductionTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ComponentTierTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TotalValueLowerBound { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TotalValueUpperBound { get; set; }

        [DataMember]
        public global::System.Nullable<int> QuantityCountLowerBound { get; set; }

        [DataMember]
        public global::System.Nullable<int> QuantityCountUpperBound { get; set; }

        [DataMember]
        public bool IsPercentageBased { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TierPrice { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> TierPercentage { get; set; }

        [DataMember]
        public bool ApplyToTotal { get; set; }

        [DataMember]
        public global::System.Nullable<int> ApplyOnPaymentMethodTypeID { get; set; }

        [DataMember]
        public bool ApplyPerTransaction { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public global::System.Nullable<int> TierOrder { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public bool HasNoUpperBound { get; set; }

        [DataMember]
        public global::System.Nullable<int> ParentVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> ApplyOnPaymentCardTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public List<PlanTransactionTemplateDTO> PlanTransactionTemplates { get; set; }

        [DataMember]
        public List<DiscountTemplateDTO> DiscountTemplates { get; set; }

        [DataMember]
        public List<ProductTemplateDTO> ProductTemplates { get; set; }

        [DataMember]
        public List<DeductionTemplateDTO> DeductionTemplates { get; set; }

        #endregion
    }

}
