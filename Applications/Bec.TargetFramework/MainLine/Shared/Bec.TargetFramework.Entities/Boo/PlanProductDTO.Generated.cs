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
    public partial class PlanProductDTO
    {
        #region Constructors
  
        public PlanProductDTO() {
        }

        public PlanProductDTO(global::System.Guid planID, int planVersionNumber, global::System.Guid productID, int productVersionID, int period, int periodUnitID, bool isActive, bool isDeleted, global::System.Nullable<int> planProductStatusID, PlanDTO plan, ProductDTO product, List<PlanTransactionDTO> planTransactions) {

          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.Period = period;
          this.PeriodUnitID = periodUnitID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanProductStatusID = planProductStatusID;
          this.Plan = plan;
          this.Product = product;
          this.PlanTransactions = planTransactions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public int PeriodUnitID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> PlanProductStatusID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanDTO Plan { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public List<PlanTransactionDTO> PlanTransactions { get; set; }

        #endregion
    }

}
