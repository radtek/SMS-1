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
    public partial class VUserAccountOrganisationUserTypeOrganisationTypeDTO
    {
        #region Constructors
  
        public VUserAccountOrganisationUserTypeOrganisationTypeDTO() {
        }

        public VUserAccountOrganisationUserTypeOrganisationTypeDTO(global::System.Guid userAccountOrganisationID, global::System.Nullable<System.Guid> userID, global::System.Nullable<System.Guid> userTypeID, string userType, global::System.Nullable<System.Guid> organisationID, global::System.Nullable<int> organisationTypeID, string organisationType) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.UserID = userID;
          this.UserTypeID = userTypeID;
          this.UserType = userType;
          this.OrganisationID = organisationID;
          this.OrganisationTypeID = organisationTypeID;
          this.OrganisationType = organisationType;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public string OrganisationType { get; set; }

        #endregion
    }

}
