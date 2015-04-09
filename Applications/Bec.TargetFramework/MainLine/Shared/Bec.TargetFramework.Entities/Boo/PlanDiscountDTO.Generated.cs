﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class PlanDiscountDTO
    {
        #region Constructors
  
        public PlanDiscountDTO() {
        }

        public PlanDiscountDTO(global::System.Guid planID, int planVersionNumber, global::System.Guid discountID, int discountVersionNumber, bool isActive, bool isDeleted, DiscountDTO discount, PlanDTO plan) {

          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.DiscountID = discountID;
          this.DiscountVersionNumber = discountVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Discount = discount;
          this.Plan = plan;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid DiscountID { get; set; }

        [DataMember]
        public int DiscountVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DiscountDTO Discount { get; set; }

        [DataMember]
        public PlanDTO Plan { get; set; }

        #endregion
    }

}
