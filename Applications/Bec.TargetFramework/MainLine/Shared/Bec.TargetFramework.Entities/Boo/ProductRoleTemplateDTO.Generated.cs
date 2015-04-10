﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class ProductRoleTemplateDTO
    {
        #region Constructors
  
        public ProductRoleTemplateDTO() {
        }

        public ProductRoleTemplateDTO(global::System.Guid productRoleTemplateID, string roleName, string roleDescription, bool isActive, bool isDeleted, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, global::System.Guid productTemplateID, int productVersionID, List<ProductClaimTemplateDTO> productClaimTemplates, ProductTemplateDTO productTemplate) {

          this.ProductRoleTemplateID = productRoleTemplateID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.ProductClaimTemplates = productClaimTemplates;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductRoleTemplateID { get; set; }

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
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ProductClaimTemplateDTO> ProductClaimTemplates { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
