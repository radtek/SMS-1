﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class DeductionTemplateDTO
    {
        #region Constructors
  
        public DeductionTemplateDTO() {
        }

        public DeductionTemplateDTO(global::System.Guid deductionTemplateID, global::System.Nullable<int> deductionTypeID, global::System.Nullable<int> deductionSubTypeID, global::System.Nullable<int> deductionCategoryID, global::System.Nullable<int> deductionSubCategoryID, string name, string description, bool isActive, bool isDeleted, bool isPercentageBased, int deductionTemplateVersionNumber, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, bool isTierDeduction, bool isCheckoutDeduction, global::System.Nullable<System.Guid> parentID, List<CountryDeductionTemplateDTO> countryDeductionTemplates, List<ProductDeductionTemplateDTO> productDeductionTemplates, List<DeductionDTO> deductions, OrganisationTypeDTO organisationType, UserTypeDTO userType, List<ProductTemplateDTO> productTemplates, List<ComponentTierTemplateDTO> componentTierTemplates) {

          this.DeductionTemplateID = deductionTemplateID;
          this.DeductionTypeID = deductionTypeID;
          this.DeductionSubTypeID = deductionSubTypeID;
          this.DeductionCategoryID = deductionCategoryID;
          this.DeductionSubCategoryID = deductionSubCategoryID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsPercentageBased = isPercentageBased;
          this.DeductionTemplateVersionNumber = deductionTemplateVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsTierDeduction = isTierDeduction;
          this.IsCheckoutDeduction = isCheckoutDeduction;
          this.ParentID = parentID;
          this.CountryDeductionTemplates = countryDeductionTemplates;
          this.ProductDeductionTemplates = productDeductionTemplates;
          this.Deductions = deductions;
          this.OrganisationType = organisationType;
          this.UserType = userType;
          this.ProductTemplates = productTemplates;
          this.ComponentTierTemplates = componentTierTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DeductionTemplateID { get; set; }

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
        public int DeductionTemplateVersionNumber { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<CountryDeductionTemplateDTO> CountryDeductionTemplates { get; set; }

        [DataMember]
        public List<ProductDeductionTemplateDTO> ProductDeductionTemplates { get; set; }

        [DataMember]
        public List<DeductionDTO> Deductions { get; set; }

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public List<ProductTemplateDTO> ProductTemplates { get; set; }

        [DataMember]
        public List<ComponentTierTemplateDTO> ComponentTierTemplates { get; set; }

        #endregion
    }

}
