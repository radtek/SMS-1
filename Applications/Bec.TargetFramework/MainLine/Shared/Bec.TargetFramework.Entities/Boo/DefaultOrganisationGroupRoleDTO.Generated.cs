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
    public partial class DefaultOrganisationGroupRoleDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupRoleDTO() {
        }

        public DefaultOrganisationGroupRoleDTO(global::System.Guid defaultOrganisationGroupID, global::System.Guid defaultOrganisationRoleID, bool isActive, bool isDeleted, DefaultOrganisationGroupDTO defaultOrganisationGroup, DefaultOrganisationRoleDTO defaultOrganisationRole) {

          this.DefaultOrganisationGroupID = defaultOrganisationGroupID;
          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationGroup = defaultOrganisationGroup;
          this.DefaultOrganisationRole = defaultOrganisationRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationGroupDTO DefaultOrganisationGroup { get; set; }

        [DataMember]
        public DefaultOrganisationRoleDTO DefaultOrganisationRole { get; set; }

        #endregion
    }

}
