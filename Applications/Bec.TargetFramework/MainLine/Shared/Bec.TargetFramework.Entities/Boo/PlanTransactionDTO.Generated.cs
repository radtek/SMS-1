﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class PlanTransactionDTO
    {
        #region Constructors
  
        public PlanTransactionDTO() {
        }

        public PlanTransactionDTO(global::System.Guid planTransactionID, global::System.Guid planID, int planVersionNumber, global::System.Guid productID, int productVersionID, global::System.Nullable<bool> isTotalValuePricingBound, global::System.Nullable<bool> isTransactionCountPricingBound, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, global::System.Nullable<System.Guid> parentID, bool applyTransactionTierPricingPerTransaction, PlanProductDTO planProduct, PlanDTO plan, List<ComponentTierDTO> componentTiers) {

          this.PlanTransactionID = planTransactionID;
          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsTotalValuePricingBound = isTotalValuePricingBound;
          this.IsTransactionCountPricingBound = isTransactionCountPricingBound;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.ApplyTransactionTierPricingPerTransaction = applyTransactionTierPricingPerTransaction;
          this.PlanProduct = planProduct;
          this.Plan = plan;
          this.ComponentTiers = componentTiers;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanTransactionID { get; set; }

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsTotalValuePricingBound { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsTransactionCountPricingBound { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public bool ApplyTransactionTierPricingPerTransaction { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanProductDTO PlanProduct { get; set; }

        [DataMember]
        public PlanDTO Plan { get; set; }

        [DataMember]
        public List<ComponentTierDTO> ComponentTiers { get; set; }

        #endregion
    }

}
