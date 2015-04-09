﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ProductFamilyProductPackageDTO
    {
        #region Constructors
  
        public ProductFamilyProductPackageDTO() {
        }

        public ProductFamilyProductPackageDTO(global::System.Guid productFamilyProductPackageID, global::System.Guid productID, global::System.Guid productFamilyID, global::System.Guid packageProductID, int productVersionID, global::System.Guid packageID, int packageVersionNumber, PackageProductDTO packageProduct, ProductFamilyDTO productFamily, ProductDTO product) {

          this.ProductFamilyProductPackageID = productFamilyProductPackageID;
          this.ProductID = productID;
          this.ProductFamilyID = productFamilyID;
          this.PackageProductID = packageProductID;
          this.ProductVersionID = productVersionID;
          this.PackageID = packageID;
          this.PackageVersionNumber = packageVersionNumber;
          this.PackageProduct = packageProduct;
          this.ProductFamily = productFamily;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductFamilyProductPackageID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public global::System.Guid ProductFamilyID { get; set; }

        [DataMember]
        public global::System.Guid PackageProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PackageID { get; set; }

        [DataMember]
        public int PackageVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PackageProductDTO PackageProduct { get; set; }

        [DataMember]
        public ProductFamilyDTO ProductFamily { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
