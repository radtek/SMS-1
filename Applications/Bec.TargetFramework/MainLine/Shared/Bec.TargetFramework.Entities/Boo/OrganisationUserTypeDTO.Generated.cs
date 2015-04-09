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
    public partial class OrganisationUserTypeDTO
    {
        #region Constructors
  
        public OrganisationUserTypeDTO() {
        }

        public OrganisationUserTypeDTO(global::System.Guid organisationID, global::System.Guid userTypeID, bool isActive, bool isDeleted, bool isForDefaultUser, UserTypeDTO userType, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.UserTypeID = userTypeID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsForDefaultUser = isForDefaultUser;
          this.UserType = userType;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsForDefaultUser { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
