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
    public partial class DiscountRelatedProductTemplateDTO
    {
        #region Constructors
  
        public DiscountRelatedProductTemplateDTO() {
        }

        public DiscountRelatedProductTemplateDTO(global::System.Guid discountRelatedProductTemplateID, global::System.Guid discountTemplateID, int discountTemplateVersionNumber, global::System.Guid productTemplateID, int productVersionID, bool isActive, bool isDeleted, DiscountTemplateDTO discountTemplate, ProductTemplateDTO productTemplate) {

          this.DiscountRelatedProductTemplateID = discountRelatedProductTemplateID;
          this.DiscountTemplateID = discountTemplateID;
          this.DiscountTemplateVersionNumber = discountTemplateVersionNumber;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DiscountTemplate = discountTemplate;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DiscountRelatedProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DiscountTemplateID { get; set; }

        [DataMember]
        public int DiscountTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DiscountTemplateDTO DiscountTemplate { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
