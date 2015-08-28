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
    public partial class ProductFamilyProductPackageTemplateDTO
    {
        #region Constructors
  
        public ProductFamilyProductPackageTemplateDTO() {
        }

        public ProductFamilyProductPackageTemplateDTO(global::System.Guid productFamilyProductPackageTemplateID, global::System.Guid packageProductTemplateID, global::System.Guid productTemplateID, global::System.Guid productFamilyTemplateID, int productVersionID, global::System.Guid packageTemplateID, int packageTemplateVersionNumber, PackageProductTemplateDTO packageProductTemplate, ProductFamilyTemplateDTO productFamilyTemplate, ProductTemplateDTO productTemplate) {

          this.ProductFamilyProductPackageTemplateID = productFamilyProductPackageTemplateID;
          this.PackageProductTemplateID = packageProductTemplateID;
          this.ProductTemplateID = productTemplateID;
          this.ProductFamilyTemplateID = productFamilyTemplateID;
          this.ProductVersionID = productVersionID;
          this.PackageTemplateID = packageTemplateID;
          this.PackageTemplateVersionNumber = packageTemplateVersionNumber;
          this.PackageProductTemplate = packageProductTemplate;
          this.ProductFamilyTemplate = productFamilyTemplate;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductFamilyProductPackageTemplateID { get; set; }

        [DataMember]
        public global::System.Guid PackageProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public global::System.Guid ProductFamilyTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PackageTemplateID { get; set; }

        [DataMember]
        public int PackageTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PackageProductTemplateDTO PackageProductTemplate { get; set; }

        [DataMember]
        public ProductFamilyTemplateDTO ProductFamilyTemplate { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
