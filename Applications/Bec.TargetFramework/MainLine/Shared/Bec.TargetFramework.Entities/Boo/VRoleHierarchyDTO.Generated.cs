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
    public partial class VRoleHierarchyDTO
    {
        #region Constructors
  
        public VRoleHierarchyDTO() {
        }

        public VRoleHierarchyDTO(global::System.Guid roleID, string roleName, int level, global::System.Nullable<System.Guid> parentID) {

          this.RoleID = roleID;
          this.RoleName = roleName;
          this.Level = level;
          this.ParentID = parentID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion
    }

}
