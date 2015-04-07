﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:18
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
    public partial class GroupRoleDTO
    {
        #region Constructors
  
        public GroupRoleDTO() {
        }

        public GroupRoleDTO(global::System.Guid groupID, global::System.Guid roleID, bool isActive, bool isDeleted, global::System.Nullable<bool> isGlobal, GroupDTO group, RoleDTO role) {

          this.GroupID = groupID;
          this.RoleID = roleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsGlobal = isGlobal;
          this.Group = group;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid GroupID { get; set; }

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsGlobal { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public GroupDTO Group { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
