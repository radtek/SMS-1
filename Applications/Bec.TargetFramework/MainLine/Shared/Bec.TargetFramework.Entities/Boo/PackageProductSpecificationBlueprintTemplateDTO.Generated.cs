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
    public partial class PackageProductSpecificationBlueprintTemplateDTO
    {
        #region Constructors
  
        public PackageProductSpecificationBlueprintTemplateDTO() {
        }

        public PackageProductSpecificationBlueprintTemplateDTO(global::System.Guid packageProductSpecificationBlueprintTemplateID, global::System.Guid packageProductTemplateID, global::System.Guid productSpecificationAttributeTemplate, global::System.Guid defaultProductSpecificationAttributeOptionTemplateID, bool isActive, bool isDeleted, global::System.Guid packageTemplateID, int packageTemplateVersionNumber, ProductSpecificationAttributeTemplateDTO productSpecificationAttributeTemplate1, ProductSpecificationAttributeOptionTemplateDTO productSpecificationAttributeOptionTemplate, PackageProductTemplateDTO packageProductTemplate) {

          this.PackageProductSpecificationBlueprintTemplateID = packageProductSpecificationBlueprintTemplateID;
          this.PackageProductTemplateID = packageProductTemplateID;
          this.ProductSpecificationAttributeTemplate = productSpecificationAttributeTemplate;
          this.DefaultProductSpecificationAttributeOptionTemplateID = defaultProductSpecificationAttributeOptionTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageTemplateID = packageTemplateID;
          this.PackageTemplateVersionNumber = packageTemplateVersionNumber;
          this.ProductSpecificationAttributeTemplate1 = productSpecificationAttributeTemplate1;
          this.ProductSpecificationAttributeOptionTemplate = productSpecificationAttributeOptionTemplate;
          this.PackageProductTemplate = packageProductTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductSpecificationBlueprintTemplateID { get; set; }

        [DataMember]
        public global::System.Guid PackageProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductSpecificationAttributeTemplate { get; set; }

        [DataMember]
        public global::System.Guid DefaultProductSpecificationAttributeOptionTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid PackageTemplateID { get; set; }

        [DataMember]
        public int PackageTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductSpecificationAttributeTemplateDTO ProductSpecificationAttributeTemplate1 { get; set; }

        [DataMember]
        public ProductSpecificationAttributeOptionTemplateDTO ProductSpecificationAttributeOptionTemplate { get; set; }

        [DataMember]
        public PackageProductTemplateDTO PackageProductTemplate { get; set; }

        #endregion
    }

}
