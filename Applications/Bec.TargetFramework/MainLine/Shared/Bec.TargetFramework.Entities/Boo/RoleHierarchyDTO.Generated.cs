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
    public partial class RoleHierarchyDTO
    {
        #region Constructors
  
        public RoleHierarchyDTO() {
        }

        public RoleHierarchyDTO(global::System.Guid roleHierarchyID, global::System.Guid roleID, global::System.Nullable<System.Guid> parentRoleID, int level, RoleDTO role_ParentRoleID, RoleDTO role_RoleID) {

          this.RoleHierarchyID = roleHierarchyID;
          this.RoleID = roleID;
          this.ParentRoleID = parentRoleID;
          this.Level = level;
          this.Role_ParentRoleID = role_ParentRoleID;
          this.Role_RoleID = role_RoleID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleHierarchyID { get; set; }

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentRoleID { get; set; }

        [DataMember]
        public int Level { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public RoleDTO Role_ParentRoleID { get; set; }

        [DataMember]
        public RoleDTO Role_RoleID { get; set; }

        #endregion
    }

}