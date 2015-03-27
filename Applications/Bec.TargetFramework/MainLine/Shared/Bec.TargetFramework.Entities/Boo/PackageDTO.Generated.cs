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
    public partial class PackageDTO
    {
        #region Constructors
  
        public PackageDTO() {
        }

        public PackageDTO(global::System.Guid packageID, global::System.Guid productID, int productVersionID, bool isActive, bool isDeleted, int packageVersionNumber, global::System.Guid packageTemplateID, int packageTemplateVersionNumber, ProductDTO product, PackageTemplateDTO packageTemplate, List<PackageProductDTO> packageProducts) {

          this.PackageID = packageID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageVersionNumber = packageVersionNumber;
          this.PackageTemplateID = packageTemplateID;
          this.PackageTemplateVersionNumber = packageTemplateVersionNumber;
          this.Product = product;
          this.PackageTemplate = packageTemplate;
          this.PackageProducts = packageProducts;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int PackageVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid PackageTemplateID { get; set; }

        [DataMember]
        public int PackageTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public PackageTemplateDTO PackageTemplate { get; set; }

        [DataMember]
        public List<PackageProductDTO> PackageProducts { get; set; }

        #endregion
    }

}
