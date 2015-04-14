﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class PackageProductRelationshipDTO
    {
        #region Constructors
  
        public PackageProductRelationshipDTO() {
        }

        public PackageProductRelationshipDTO(global::System.Guid packageProductRelationshipID, global::System.Guid parentProductID, global::System.Guid childProductID, int productRelationshipTypeID, bool isMandatory, bool isActive, bool isDeleted, global::System.Guid packageProductID, int parentProductVersionID, int childProductVersionID, global::System.Guid packageID, int packageVersionNumber, ProductDTO product_ParentProductID_ParentProductVersionID, ProductDTO product_ChildProductID_ChildProductVersionID, PackageProductDTO packageProduct, List<PackageProductRelationshipBlueprintDTO> packageProductRelationshipBlueprints) {

          this.PackageProductRelationshipID = packageProductRelationshipID;
          this.ParentProductID = parentProductID;
          this.ChildProductID = childProductID;
          this.ProductRelationshipTypeID = productRelationshipTypeID;
          this.IsMandatory = isMandatory;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PackageProductID = packageProductID;
          this.ParentProductVersionID = parentProductVersionID;
          this.ChildProductVersionID = childProductVersionID;
          this.PackageID = packageID;
          this.PackageVersionNumber = packageVersionNumber;
          this.Product_ParentProductID_ParentProductVersionID = product_ParentProductID_ParentProductVersionID;
          this.Product_ChildProductID_ChildProductVersionID = product_ChildProductID_ChildProductVersionID;
          this.PackageProduct = packageProduct;
          this.PackageProductRelationshipBlueprints = packageProductRelationshipBlueprints;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PackageProductRelationshipID { get; set; }

        [DataMember]
        public global::System.Guid ParentProductID { get; set; }

        [DataMember]
        public global::System.Guid ChildProductID { get; set; }

        [DataMember]
        public int ProductRelationshipTypeID { get; set; }

        [DataMember]
        public bool IsMandatory { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid PackageProductID { get; set; }

        [DataMember]
        public int ParentProductVersionID { get; set; }

        [DataMember]
        public int ChildProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PackageID { get; set; }

        [DataMember]
        public int PackageVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product_ParentProductID_ParentProductVersionID { get; set; }

        [DataMember]
        public ProductDTO Product_ChildProductID_ChildProductVersionID { get; set; }

        [DataMember]
        public PackageProductDTO PackageProduct { get; set; }

        [DataMember]
        public List<PackageProductRelationshipBlueprintDTO> PackageProductRelationshipBlueprints { get; set; }

        #endregion
    }

}
