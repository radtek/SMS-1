﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class ProductFamilyTemplateDTO
    {
        #region Constructors
  
        public ProductFamilyTemplateDTO() {
        }

        public ProductFamilyTemplateDTO(global::System.Guid productFamilyTemplateID, string name, string description, bool isActive, bool isDeleted, List<ProductFamilyProductPackageTemplateDTO> productFamilyProductPackageTemplates) {

          this.ProductFamilyTemplateID = productFamilyTemplateID;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductFamilyProductPackageTemplates = productFamilyProductPackageTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductFamilyTemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductFamilyProductPackageTemplateDTO> ProductFamilyProductPackageTemplates { get; set; }

        #endregion
    }

}