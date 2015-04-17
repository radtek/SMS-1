﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class ProductRoleDTO
    {
        #region Constructors
  
        public ProductRoleDTO() {
        }

        public ProductRoleDTO(global::System.Guid productRoleID, string roleName, string roleDescription, bool isActive, bool isDeleted, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, global::System.Guid productID, int productVersionID, List<ProductClaimDTO> productClaims, ProductDTO product) {

          this.ProductRoleID = productRoleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.ProductClaims = productClaims;
          this.Product = product;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductClaimDTO> ProductClaims { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        #endregion
    }

}
