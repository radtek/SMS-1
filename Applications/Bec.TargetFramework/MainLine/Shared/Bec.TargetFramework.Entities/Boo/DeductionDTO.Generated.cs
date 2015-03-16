﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class DeductionDTO
    {
        #region Constructors
  
        public DeductionDTO() {
        }

        public DeductionDTO(global::System.Guid deductionID, global::System.Nullable<int> deductionTypeID, global::System.Nullable<int> deductionSubTypeID, global::System.Nullable<int> deductionCategoryID, global::System.Nullable<int> deductionSubCategoryID, string name, string description, bool isActive, bool isDeleted, bool isPercentageBased, int deductionVersionNumber, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, bool isTierDeduction, bool isCheckoutDeduction, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> deductionTemplateID, global::System.Nullable<int> deductionTemplateVersionNumber, List<ProductDeductionDTO> productDeductions, List<CountryDeductionDTO> countryDeductions, OrganisationTypeDTO organisationType, UserTypeDTO userType, DeductionTemplateDTO deductionTemplate, List<ProductDTO> products, List<ComponentTierDTO> componentTiers) {

          this.DeductionID = deductionID;
          this.DeductionTypeID = deductionTypeID;
          this.DeductionSubTypeID = deductionSubTypeID;
          this.DeductionCategoryID = deductionCategoryID;
          this.DeductionSubCategoryID = deductionSubCategoryID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsPercentageBased = isPercentageBased;
          this.DeductionVersionNumber = deductionVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsTierDeduction = isTierDeduction;
          this.IsCheckoutDeduction = isCheckoutDeduction;
          this.ParentID = parentID;
          this.DeductionTemplateID = deductionTemplateID;
          this.DeductionTemplateVersionNumber = deductionTemplateVersionNumber;
          this.ProductDeductions = productDeductions;
          this.CountryDeductions = countryDeductions;
          this.OrganisationType = organisationType;
          this.UserType = userType;
          this.DeductionTemplate = deductionTemplate;
          this.Products = products;
          this.ComponentTiers = componentTiers;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DeductionID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DeductionTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DeductionSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DeductionCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DeductionSubCategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsPercentageBased { get; set; }

        [DataMember]
        public int DeductionVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public bool IsTierDeduction { get; set; }

        [DataMember]
        public bool IsCheckoutDeduction { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> DeductionTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DeductionTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductDeductionDTO> ProductDeductions { get; set; }

        [DataMember]
        public List<CountryDeductionDTO> CountryDeductions { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public DeductionTemplateDTO DeductionTemplate { get; set; }

        [DataMember]
        public List<ProductDTO> Products { get; set; }

        [DataMember]
        public List<ComponentTierDTO> ComponentTiers { get; set; }

        #endregion
    }

}
