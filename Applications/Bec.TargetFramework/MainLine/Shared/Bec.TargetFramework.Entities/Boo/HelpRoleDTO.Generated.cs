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
    public partial class HelpRoleDTO
    {
        #region Constructors
  
        public HelpRoleDTO() {
        }

        public HelpRoleDTO(global::System.Guid helpRoleID, global::System.Guid roleID, RoleDTO role) {

          this.HelpRoleID = helpRoleID;
          this.RoleID = roleID;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid HelpRoleID { get; set; }

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
