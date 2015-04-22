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
    public partial class ProductClaimDTO
    {
        #region Constructors
  
        public ProductClaimDTO() {
        }

        public ProductClaimDTO(global::System.Guid productClaimID, global::System.Guid productID, int productVersionID, global::System.Nullable<System.Guid> roleID, global::System.Nullable<System.Guid> productRoleID, global::System.Nullable<System.Guid> resourceID, global::System.Nullable<System.Guid> operationID, global::System.Nullable<System.Guid> stateID, global::System.Nullable<System.Guid> stateItemID, bool isActive, bool isDeleted, OperationDTO operation, ProductRoleDTO productRole, ProductDTO product, ResourceDTO resource, RoleDTO role, StateDTO state, StateItemDTO stateItem) {

          this.ProductClaimID = productClaimID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.RoleID = roleID;
          this.ProductRoleID = productRoleID;
          this.ResourceID = resourceID;
          this.OperationID = operationID;
          this.StateID = stateID;
          this.StateItemID = stateItemID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Operation = operation;
          this.ProductRole = productRole;
          this.Product = product;
          this.Resource = resource;
          this.Role = role;
          this.State = state;
          this.StateItem = stateItem;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductClaimID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ProductRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ResourceID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OperationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> StateItemID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OperationDTO Operation { get; set; }

        [DataMember]
        public ProductRoleDTO ProductRole { get; set; }

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public ResourceDTO Resource { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public StateDTO State { get; set; }

        [DataMember]
        public StateItemDTO StateItem { get; set; }

        #endregion
    }

}
