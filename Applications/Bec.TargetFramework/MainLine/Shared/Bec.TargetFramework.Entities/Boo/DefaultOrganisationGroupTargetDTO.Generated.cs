﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class DefaultOrganisationGroupTargetDTO
    {
        #region Constructors
  
        public DefaultOrganisationGroupTargetDTO() {
        }

        public DefaultOrganisationGroupTargetDTO(global::System.Guid defaultOrganisationGroupID, bool isActive, bool isDeleted, global::System.Guid defaultOrganisationUserTargetID, DefaultOrganisationUserTargetDTO defaultOrganisationUserTarget, DefaultOrganisationGroupDTO defaultOrganisationGroup) {

          this.DefaultOrganisationGroupID = defaultOrganisationGroupID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationUserTargetID = defaultOrganisationUserTargetID;
          this.DefaultOrganisationUserTarget = defaultOrganisationUserTarget;
          this.DefaultOrganisationGroup = defaultOrganisationGroup;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationGroupID { get; set; }

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
        public DefaultOrganisationGroupDTO DefaultOrganisationGroup { get; set; }

        #endregion
    }

}
