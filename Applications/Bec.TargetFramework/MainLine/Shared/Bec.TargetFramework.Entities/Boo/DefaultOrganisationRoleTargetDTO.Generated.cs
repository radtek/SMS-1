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
    public partial class DefaultOrganisationRoleTargetDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleTargetDTO() {
        }

        public DefaultOrganisationRoleTargetDTO(global::System.Guid defaultOrganisationRoleID, bool isActive, bool isDeleted, global::System.Guid defaultOrganisationUserTargetID, DefaultOrganisationUserTargetDTO defaultOrganisationUserTarget, DefaultOrganisationRoleDTO defaultOrganisationRole) {

          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationUserTargetID = defaultOrganisationUserTargetID;
          this.DefaultOrganisationUserTarget = defaultOrganisationUserTarget;
          this.DefaultOrganisationRole = defaultOrganisationRole;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationUserTargetID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationUserTargetDTO DefaultOrganisationUserTarget { get; set; }

        [DataMember]
        public DefaultOrganisationRoleDTO DefaultOrganisationRole { get; set; }

        #endregion
    }

}
