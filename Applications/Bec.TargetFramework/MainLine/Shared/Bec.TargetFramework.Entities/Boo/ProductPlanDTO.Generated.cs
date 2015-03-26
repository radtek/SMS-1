﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class ProductPlanDTO
    {
        #region Constructors
  
        public ProductPlanDTO() {
        }

        public ProductPlanDTO(global::System.Guid productID, int productVersionID, global::System.Guid planID, int planVersionNumber, bool isActive, bool isDeleted, PlanDTO plan, ProductDTO product) {

          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Plan = plan;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanDTO Plan { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
