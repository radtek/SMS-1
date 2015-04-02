﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class ProductDiscountTemplateDTO
    {
        #region Constructors
  
        public ProductDiscountTemplateDTO() {
        }

        public ProductDiscountTemplateDTO(global::System.Guid productTemplateID, int productVersionID, global::System.Guid discountTemplateID, int discountTemplateVersionNumber, bool isActive, bool isDeleted, ProductTemplateDTO productTemplate, DiscountTemplateDTO discountTemplate) {

          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.DiscountTemplateID = discountTemplateID;
          this.DiscountTemplateVersionNumber = discountTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductTemplate = productTemplate;
          this.DiscountTemplate = discountTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid DiscountTemplateID { get; set; }

        [DataMember]
        public int DiscountTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public DiscountTemplateDTO DiscountTemplate { get; set; }

        #endregion
    }

}
