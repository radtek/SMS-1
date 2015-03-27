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
    public partial class ProductRelationshipDTO
    {
        #region Constructors
  
        public ProductRelationshipDTO() {
        }

        public ProductRelationshipDTO(global::System.Guid productRelationshipID, global::System.Guid parentProductID, global::System.Guid childProductID, int productRelationshipTypeID, bool isMandatory, bool isActive, bool isDeleted, int parentProductVersionID, int childProductVersionID, List<ProductRelationshipBlueprintDTO> productRelationshipBlueprints, ProductDTO product_ParentProductID_ParentProductVersionID, ProductDTO product_ChildProductID_ChildProductVersionID) {

          this.ProductRelationshipID = productRelationshipID;
          this.ParentProductID = parentProductID;
          this.ChildProductID = childProductID;
          this.ProductRelationshipTypeID = productRelationshipTypeID;
          this.IsMandatory = isMandatory;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentProductVersionID = parentProductVersionID;
          this.ChildProductVersionID = childProductVersionID;
          this.ProductRelationshipBlueprints = productRelationshipBlueprints;
          this.Product_ParentProductID_ParentProductVersionID = product_ParentProductID_ParentProductVersionID;
          this.Product_ChildProductID_ChildProductVersionID = product_ChildProductID_ChildProductVersionID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRelationshipID { get; set; }

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
        public int ParentProductVersionID { get; set; }

        [DataMember]
        public int ChildProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductRelationshipBlueprintDTO> ProductRelationshipBlueprints { get; set; }

        [DataMember]
        public ProductDTO Product_ParentProductID_ParentProductVersionID { get; set; }

        [DataMember]
        public ProductDTO Product_ChildProductID_ChildProductVersionID { get; set; }

        #endregion
    }

}
