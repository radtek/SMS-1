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
    public partial class WorkflowRoleDTO
    {
        #region Constructors
  
        public WorkflowRoleDTO() {
        }

        public WorkflowRoleDTO(global::System.Guid workflowRoleID, string roleName, string roleDescription, bool isActive, bool isDeleted, global::System.Guid workflowID, int workflowVersionNumber, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, WorkflowDTO workflow, List<WorkflowClaimDTO> workflowClaims) {

          this.WorkflowRoleID = workflowRoleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.WorkflowID = workflowID;
          this.WorkflowVersionNumber = workflowVersionNumber;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.Workflow = workflow;
          this.WorkflowClaims = workflowClaims;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid WorkflowRoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid WorkflowID { get; set; }

        [DataMember]
        public int WorkflowVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public WorkflowDTO Workflow { get; set; }

        [DataMember]
        public List<WorkflowClaimDTO> WorkflowClaims { get; set; }

        #endregion
    }

}
