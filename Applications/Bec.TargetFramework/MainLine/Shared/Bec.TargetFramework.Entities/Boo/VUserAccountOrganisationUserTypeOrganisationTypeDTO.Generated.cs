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
    public partial class VUserAccountOrganisationUserTypeOrganisationTypeDTO
    {
        #region Constructors
  
        public VUserAccountOrganisationUserTypeOrganisationTypeDTO() {
        }

        public VUserAccountOrganisationUserTypeOrganisationTypeDTO(global::System.Guid userAccountOrganisationID, global::System.Guid userID, global::System.Guid userTypeID, string userType, global::System.Guid organisationID, int organisationTypeID, string organisationType) {

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
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public string UserType { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

        [DataMember]
        public string OrganisationType { get; set; }

        #endregion
    }

}
