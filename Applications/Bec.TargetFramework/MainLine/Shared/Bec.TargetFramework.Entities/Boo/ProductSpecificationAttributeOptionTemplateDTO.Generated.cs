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
    public partial class ProductSpecificationAttributeOptionTemplateDTO
    {
        #region Constructors
  
        public ProductSpecificationAttributeOptionTemplateDTO() {
        }

        public ProductSpecificationAttributeOptionTemplateDTO(global::System.Guid specificationAttributeOptionTemplateID, decimal priceAdjustement, global::System.Nullable<decimal> weightAdjustment, decimal cost, decimal defaultValue, decimal defaultQuantity, int displayOrder, bool isActive, bool isDeleted, global::System.Guid productSpecificationAttributeTemplateID, global::System.Guid productSpecificationAttributeOptionTemplateID, ProductSpecificationAttributeTemplateDTO productSpecificationAttributeTemplate, SpecificationAttributeOptionTemplateDTO specificationAttributeOptionTemplate, List<ProductSpecificationBlueprintTemplateDTO> productSpecificationBlueprintTemplates, List<PackageProductSpecificationBlueprintTemplateDTO> packageProductSpecificationBlueprintTemplates) {

          this.SpecificationAttributeOptionTemplateID = specificationAttributeOptionTemplateID;
          this.PriceAdjustement = priceAdjustement;
          this.WeightAdjustment = weightAdjustment;
          this.Cost = cost;
          this.DefaultValue = defaultValue;
          this.DefaultQuantity = defaultQuantity;
          this.DisplayOrder = displayOrder;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductSpecificationAttributeTemplateID = productSpecificationAttributeTemplateID;
          this.ProductSpecificationAttributeOptionTemplateID = productSpecificationAttributeOptionTemplateID;
          this.ProductSpecificationAttributeTemplate = productSpecificationAttributeTemplate;
          this.SpecificationAttributeOptionTemplate = specificationAttributeOptionTemplate;
          this.ProductSpecificationBlueprintTemplates = productSpecificationBlueprintTemplates;
          this.PackageProductSpecificationBlueprintTemplates = packageProductSpecificationBlueprintTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SpecificationAttributeOptionTemplateID { get; set; }

        [DataMember]
        public decimal PriceAdjustement { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> WeightAdjustment { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public decimal DefaultValue { get; set; }

        [DataMember]
        public decimal DefaultQuantity { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeOptionTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeTemplateDTO ProductSpecificationAttributeTemplate { get; set; }

        [DataMember]
        public SpecificationAttributeOptionTemplateDTO SpecificationAttributeOptionTemplate { get; set; }

        [DataMember]
        public List<ProductSpecificationBlueprintTemplateDTO> ProductSpecificationBlueprintTemplates { get; set; }

        [DataMember]
        public List<PackageProductSpecificationBlueprintTemplateDTO> PackageProductSpecificationBlueprintTemplates { get; set; }

        #endregion
    }

}
