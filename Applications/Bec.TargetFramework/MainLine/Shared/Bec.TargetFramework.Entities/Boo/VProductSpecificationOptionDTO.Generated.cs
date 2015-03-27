﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class VProductSpecificationOptionDTO
    {
        #region Constructors
  
        public VProductSpecificationOptionDTO() {
        }

        public VProductSpecificationOptionDTO(global::System.Guid productID, int productVersionID, global::System.Guid productSpecificationAttributeID, bool isMandatory, bool isMultiSelect, bool isPreSelected, int minimumSelectionLimit, int maximumSelectionLimit, bool isUserDefined, bool isPriceDriven, global::System.Guid specificationAttributeID, global::System.Guid productSpecificationAttributeOptionID, decimal priceAdjustment, global::System.Nullable<decimal> weightAdjustment, decimal cost, decimal defaultValue, int defaultQuantity, bool isActive, bool isDeleted, int displayOrder, string optionName, string optionDescription) {

          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.ProductSpecificationAttributeID = productSpecificationAttributeID;
          this.IsMandatory = isMandatory;
          this.IsMultiSelect = isMultiSelect;
          this.IsPreSelected = isPreSelected;
          this.MinimumSelectionLimit = minimumSelectionLimit;
          this.MaximumSelectionLimit = maximumSelectionLimit;
          this.IsUserDefined = isUserDefined;
          this.IsPriceDriven = isPriceDriven;
          this.SpecificationAttributeID = specificationAttributeID;
          this.ProductSpecificationAttributeOptionID = productSpecificationAttributeOptionID;
          this.PriceAdjustment = priceAdjustment;
          this.WeightAdjustment = weightAdjustment;
          this.Cost = cost;
          this.DefaultValue = defaultValue;
          this.DefaultQuantity = defaultQuantity;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DisplayOrder = displayOrder;
          this.OptionName = optionName;
          this.OptionDescription = optionDescription;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeID { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsMultiSelect { get; set; }

        [DataMember]
        public bool IsPreSelected { get; set; }

        [DataMember]
        public int MinimumSelectionLimit { get; set; }

        [DataMember]
        public int MaximumSelectionLimit { get; set; }

        [DataMember]
        public bool IsUserDefined { get; set; }

        [DataMember]
        public bool IsPriceDriven { get; set; }

        [DataMember]
        public global::System.Guid SpecificationAttributeID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeOptionID { get; set; }

        [DataMember]
        public decimal PriceAdjustment { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> WeightAdjustment { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public decimal DefaultValue { get; set; }

        [DataMember]
        public int DefaultQuantity { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string OptionName { get; set; }

        [DataMember]
        public string OptionDescription { get; set; }

        #endregion
    }

}
