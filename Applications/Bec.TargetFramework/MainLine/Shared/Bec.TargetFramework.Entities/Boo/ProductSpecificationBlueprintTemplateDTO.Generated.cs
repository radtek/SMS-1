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
    public partial class ProductSpecificationBlueprintTemplateDTO
    {
        #region Constructors
  
        public ProductSpecificationBlueprintTemplateDTO() {
        }

        public ProductSpecificationBlueprintTemplateDTO(global::System.Guid productSpecificationBlueprintTemplateID, global::System.Guid productTemplateID, global::System.Guid productSpecificationAttributeTemplateID, global::System.Guid defaultProductSpecificationAttributeOptionTemplateID, bool isActive, bool isDeleted, int productVersionID, ProductSpecificationAttributeTemplateDTO productSpecificationAttributeTemplate, ProductSpecificationAttributeOptionTemplateDTO productSpecificationAttributeOptionTemplate) {

          this.ProductSpecificationBlueprintTemplateID = productSpecificationBlueprintTemplateID;
          this.ProductTemplateID = productTemplateID;
          this.ProductSpecificationAttributeTemplateID = productSpecificationAttributeTemplateID;
          this.DefaultProductSpecificationAttributeOptionTemplateID = defaultProductSpecificationAttributeOptionTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductVersionID = productVersionID;
          this.ProductSpecificationAttributeTemplate = productSpecificationAttributeTemplate;
          this.ProductSpecificationAttributeOptionTemplate = productSpecificationAttributeOptionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductSpecificationBlueprintTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultProductSpecificationAttributeOptionTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeTemplateDTO ProductSpecificationAttributeTemplate { get; set; }

        [DataMember]
        public ProductSpecificationAttributeOptionTemplateDTO ProductSpecificationAttributeOptionTemplate { get; set; }

        #endregion
    }

}
